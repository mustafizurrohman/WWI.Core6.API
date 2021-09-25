﻿using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WWI.Core3.Models.ViewModels;
using WWI.Core3.Services.MediatR.Queries;
using WWI.Core3.Services.ServiceCollection;

namespace WWI.Core3.Services.MediatR.Handlers
{
    public class GetHospitalsForSpecialityByIDQueryHandler : HandlerBase, IRequestHandler<GetHospitalsForSpecialityByIDQuery, List<Dropdown>>
    {
        public GetHospitalsForSpecialityByIDQueryHandler(IApplicationServices applicationServices)
            : base(applicationServices)
        {
            
        }


        public async Task<List<Dropdown>> Handle(GetHospitalsForSpecialityByIDQuery request, CancellationToken cancellationToken)
        {
            var hospitals = await DbContext.Specialities
                .Include(s => s.Hospitals)
                .Where(s => s.SpecialtyID == request.SpecialityID)
                .SelectMany(s => s.Hospitals)
                .Select(hs => hs.Hospital)
                .ProjectTo<Dropdown>(AutoMapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return hospitals;
        }
    }
}
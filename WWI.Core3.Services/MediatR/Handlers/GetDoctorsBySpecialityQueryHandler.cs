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
    public class GetDoctorsBySpecialityQueryHandler : HandlerBase, IRequestHandler<GetDoctorsBySpecialityQuery, List<Dropdown>>
    {
        public GetDoctorsBySpecialityQueryHandler(IApplicationServices applicationServices)
            : base(applicationServices)
        {
            
        }

        public async Task<List<Dropdown>> Handle(GetDoctorsBySpecialityQuery request, CancellationToken cancellationToken)
        {
            var doctorsForSpecialty = await DbContext.Doctors
                .Where(d => d.SpecialityID == request.SpecialityID)
                .ProjectTo<Dropdown>(AutoMapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            doctorsForSpecialty = doctorsForSpecialty
                .OrderBy(doc => doc.DisplayValue)
                .ToList();

            return doctorsForSpecialty;
        }
    }
}

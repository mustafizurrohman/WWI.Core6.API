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
    public class GetAllDoctorsQueryHandler : HandlerBase, IRequestHandler<GetAllDoctorsQuery, List<Dropdown>>
    {

        public GetAllDoctorsQueryHandler(IApplicationServices applicationServices) 
            : base(applicationServices)
        {
            
        }

        public async Task<List<Dropdown>> Handle(GetAllDoctorsQuery request, CancellationToken cancellationToken)
        {
            var doctors = await DbContext.Doctors
                .ProjectTo<Dropdown>(AutoMapper.ConfigurationProvider)
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            doctors = doctors
                .OrderBy(doc => doc.DisplayValue)
                .ToList();

            return doctors;
        }
    }
}
﻿using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using WWI.Core3.Services.MediatR.Queries;
using WWI.Core3.Services.ServiceCollection;

namespace WWI.Core3.Services.MediatR.Handlers
{
    public class GetDoctorsForSpecialityByIDQueryHandler : HandlerBase, IRequestHandler<GetDoctorsForSpecialityByIDQuery, List<Dropdown>>
    {
        public GetDoctorsForSpecialityByIDQueryHandler(IApplicationServices applicationServices)
            : base(applicationServices)
        {
            
        }

        public async Task<List<Dropdown>> Handle(GetDoctorsForSpecialityByIDQuery request, CancellationToken cancellationToken)
        {
            var doctors = await DbContext.Specialities
                .Include(sp => sp.Doctors)
                .Where(sp => sp.SpecialtyID == request.SpecialityID)
                .SelectMany(sp => sp.Doctors)
                .ProjectTo<Dropdown>(AutoMapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return doctors;
        }
    }
}
﻿namespace WWI.Core6.Services.MediatR.Handlers;

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
namespace WWI.Core6.Services.MediatR.Handlers;

public class GetAllHospitalsQueryHandler : HandlerBase, IRequestHandler<GetAllHospitalsQuery, List<Dropdown>>
{
    public GetAllHospitalsQueryHandler(IApplicationServices applicationServices)
        : base(applicationServices)
    {

    }

    public async Task<List<Dropdown>> Handle(GetAllHospitalsQuery request, CancellationToken cancellationToken)
    {
        var hospitals = await DbContext.Hospitals
            .ProjectTo<Dropdown>(AutoMapper.ConfigurationProvider)
            .OrderBy(hos => hos.DisplayValue)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return hospitals;
    }
}
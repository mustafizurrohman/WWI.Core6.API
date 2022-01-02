namespace WWI.Core6.Services.MediatR.Handlers;

public class GetSpecialitiesDropdownForHospitalQueryHandler : HandlerBase, IRequestHandler<GetSpecialitiesDropdownForHospitalQuery, List<Dropdown>>
{
    private ISharedService SharedService { get; }

    public GetSpecialitiesDropdownForHospitalQueryHandler(IApplicationServices applicationServices, ISharedService sharedService)
        : base(applicationServices)
    {
        SharedService = Guard.Against.Null(sharedService, nameof(sharedService));
    }

    public async Task<List<Dropdown>> Handle(GetSpecialitiesDropdownForHospitalQuery request, CancellationToken cancellationToken)
    {
        var specialityInformation = await SharedService.GetAdvancedHospitalInformation()
            .Where(hos => hos.HospitalID == request.HospitalID)
            .SelectMany(hos => hos.Specialities)
            .ProjectTo<Dropdown>(AutoMapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return specialityInformation;
    }
}
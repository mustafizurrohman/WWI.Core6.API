using WWI.Core6.Services.Interfaces;

namespace WWI.Core6.Services.MediatR.Handlers;

public class GetAdvancedHospitalInformationQueryHandler : HandlerBase, IRequestHandler<GetAdvancedHospitalInformationQuery, AdvancedHospitalInformation>
{
    private readonly IDataService _dataService;

    public GetAdvancedHospitalInformationQueryHandler(IApplicationServices applicationServices, IDataService dataService)
        : base(applicationServices)
    {
        _dataService = Guard.Against.Null(dataService, nameof(dataService));
    }

    public async Task<AdvancedHospitalInformation> Handle(GetAdvancedHospitalInformationQuery request, CancellationToken cancellationToken)
    {
        return await _dataService.GetAdvancedHospitalInformationAsync(request.HospitalID, cancellationToken);
    }
}
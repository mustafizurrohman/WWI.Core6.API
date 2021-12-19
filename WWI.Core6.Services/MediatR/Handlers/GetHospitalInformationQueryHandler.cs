using WWI.Core6.Models.ViewModels;
using WWI.Core6.Services.Interfaces;
using WWI.Core6.Services.MediatR.Queries;
using WWI.Core6.Services.ServiceCollection;

namespace WWI.Core6.Services.MediatR.Handlers
{
    public class GetHospitalInformationQueryHandler : HandlerBase, IRequestHandler<GetHospitalInformationQuery, HospitalInformation>
    {
        private IDataService DataService { get; } 

        public GetHospitalInformationQueryHandler(IApplicationServices applicationServices, IDataService dataService)
            : base(applicationServices)
        {
            DataService = Guard.Against.Null(dataService, nameof(dataService));
        }

        public async Task<HospitalInformation> Handle(GetHospitalInformationQuery request, CancellationToken cancellationToken)
        {
            return await DataService.GetHospitalInformationByIDAsync(request.HospitalID, cancellationToken);
        }
    }
}
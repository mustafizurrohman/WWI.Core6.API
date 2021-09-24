using Ardalis.GuardClauses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WWI.Core3.Models.ViewModels;
using WWI.Core3.Services.Interfaces;
using WWI.Core3.Services.MediatR.Queries;
using WWI.Core3.Services.ServiceCollection;

namespace WWI.Core3.Services.MediatR.Handlers
{
    public class GetAdvancedHospitalInformationQueryHandler : HandlerBase, IRequestHandler<GetAdvancedHospitalInformationQuery, AdvancedHospitalInformation>
    {
        private readonly IDataService DataService;

        public GetAdvancedHospitalInformationQueryHandler(IApplicationServices applicationServices, IDataService dataService)
            : base(applicationServices)
        {
            DataService = Guard.Against.Null(dataService, nameof(dataService));
        }

        public async Task<AdvancedHospitalInformation> Handle(GetAdvancedHospitalInformationQuery request, CancellationToken cancellationToken)
        {
            return await DataService.GetAdvancedHospitalInformationAsync(request.HospitalID, cancellationToken);
        }
    }
}

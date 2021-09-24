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
    public class GetDoctorsForHospitalQueryHandler : HandlerBase, IRequestHandler<GetDoctorsForHospitalQuery, HospitalDoctorInformation>
    {
        private IDataService DataService { get; }

        public GetDoctorsForHospitalQueryHandler(IApplicationServices applicationServices, IDataService dataService)
            : base(applicationServices)
        {
            DataService = Guard.Against.Null(dataService, nameof(dataService));
        }

        public async Task<HospitalDoctorInformation> Handle(GetDoctorsForHospitalQuery request, CancellationToken cancellationToken)
        {
            return await DataService.GetDoctorsForHospitalAsync(request.HospitalID, cancellationToken);
        }
    }
}

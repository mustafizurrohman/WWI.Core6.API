using WWI.Core6.Models.ViewModels;
using WWI.Core6.Services.Interfaces;
using WWI.Core6.Services.MediatR.Queries;
using WWI.Core6.Services.ServiceCollection;

namespace WWI.Core6.Services.MediatR.Handlers
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

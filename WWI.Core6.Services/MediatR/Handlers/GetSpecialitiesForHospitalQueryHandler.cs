using Microsoft.EntityFrameworkCore;
using WWI.Core6.Models.ViewModels;
using WWI.Core6.Services.Interfaces;
using WWI.Core6.Services.MediatR.Queries;
using WWI.Core6.Services.ServiceCollection;

namespace WWI.Core6.Services.MediatR.Handlers
{
    public class GetSpecialitiesForHospitalQueryHandler : HandlerBase, IRequestHandler<GetSpecialitiesForHospitalQuery, List<SpecialityInformation>>
    {
        private ISharedService SharedService { get; }

        public GetSpecialitiesForHospitalQueryHandler(IApplicationServices applicationServices, ISharedService sharedService)
            : base(applicationServices)
        {
            SharedService = Guard.Against.Null(sharedService, nameof(sharedService));
        }


        public async Task<List<SpecialityInformation>> Handle(GetSpecialitiesForHospitalQuery request, CancellationToken cancellationToken)
        {
            var specialityInformation = await SharedService.GetAdvancedHospitalInformation()
                .Where(hos => hos.HospitalID == request.HospitalID)
                .SelectMany(hos => hos.Specialities)
                .ToListAsync(cancellationToken);

            return specialityInformation;
        }
    }
}

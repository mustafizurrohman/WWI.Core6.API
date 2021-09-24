using Ardalis.GuardClauses;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WWI.Core3.Models.ViewModels;
using WWI.Core3.Services.Interfaces;
using WWI.Core3.Services.MediatR.Queries;
using WWI.Core3.Services.ServiceCollection;

namespace WWI.Core3.Services.MediatR.Handlers
{
    public class GetSpecialityInfoForHospitalQueryHandler : HandlerBase, IRequestHandler<GetSpecialityInfoForHospitalQuery, SpecialityInformation>
    {
        private ISharedService SharedService { get; }

        public GetSpecialityInfoForHospitalQueryHandler(IApplicationServices applicationServices, ISharedService sharedService)
            : base(applicationServices)
        {
            SharedService = Guard.Against.Null(sharedService, nameof(sharedService));
        }


        public async Task<SpecialityInformation> Handle(GetSpecialityInfoForHospitalQuery request, CancellationToken cancellationToken)
        {
            var advancedHospitalInformation = await SharedService.GetAdvancedHospitalInformation()
                .Where(hos => hos.HospitalID == request.HospitalID)
                .SingleOrDefaultAsync(cancellationToken);

            var specialityInformation = advancedHospitalInformation.Specialities
                .FirstOrDefault(sp => sp.SpecialtyID == request.SpecialityID);
            
            return specialityInformation;

        }
    }
}

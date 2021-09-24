using Ardalis.GuardClauses;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WWI.Core3.Models.ViewModels;
using WWI.Core3.Services.Interfaces;
using WWI.Core3.Services.MediatR.Queries;
using WWI.Core3.Services.ServiceCollection;

namespace WWI.Core3.Services.MediatR.Handlers
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

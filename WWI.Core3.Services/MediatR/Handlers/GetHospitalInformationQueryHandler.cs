﻿using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WWI.Core3.Models.ViewModels;
using WWI.Core3.Services.Interfaces;
using WWI.Core3.Services.MediatR.Queries;
using WWI.Core3.Services.ServiceCollection;

namespace WWI.Core3.Services.MediatR.Handlers
{
    public class GetHospitalInformationQueryHandler : HandlerBase, IRequestHandler<GetHospitalInformationQuery, HospitalInformation>
    {
        private IDataService DataService { get; } 

        public GetHospitalInformationQueryHandler(IApplicationServices applicationServices, IDataService dataService)
            : base(applicationServices)
        {
            DataService = dataService;
        }

        public async Task<HospitalInformation> Handle(GetHospitalInformationQuery request, CancellationToken cancellationToken)
        {
            return await DataService.GetHospitalInformationByIDAsync(request.HospitalID, cancellationToken);
        }
    }
}
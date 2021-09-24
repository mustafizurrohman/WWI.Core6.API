using Ardalis.GuardClauses;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using WWI.Core3.Models.ViewModels;
using WWI.Core3.Services.Interfaces;
using WWI.Core3.Services.MediatR.Queries;
using WWI.Core3.Services.ServiceCollection;

namespace WWI.Core3.Services.MediatR.Handlers
{
    public class GetSpecialityInformationByIDQueryHandler : HandlerBase, IRequestHandler<GetSpecialityInformationByIDQuery, Dropdown>
    {
        private IDataService DataService { get;  }

        public GetSpecialityInformationByIDQueryHandler(IApplicationServices applicationServices, IDataService dataService)  
            : base(applicationServices)
        {
            DataService = Guard.Against.Null(dataService, nameof(dataService));
        }

        public async Task<Dropdown> Handle(GetSpecialityInformationByIDQuery request, CancellationToken cancellationToken)
        {
            return await DataService.GetSpecialityInformation()
                .SingleOrDefaultAsync(sp => sp.ID == request.SpecialityID, cancellationToken);
        }
    }
}

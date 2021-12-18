using Microsoft.EntityFrameworkCore;
using WWI.Core3.Services.Interfaces;
using WWI.Core3.Services.MediatR.Queries;
using WWI.Core3.Services.ServiceCollection;

namespace WWI.Core3.Services.MediatR.Handlers
{
    public class GetAllSpecialitiesDropdownQueryHandler : HandlerBase, IRequestHandler<GetAllSpecialitiesDropdownQuery, List<Dropdown>>
    {
        private IDataService DataService { get; }

        public GetAllSpecialitiesDropdownQueryHandler(IApplicationServices applicationServices, IDataService dataService)
            : base(applicationServices)
        {
            DataService = Guard.Against.Null(dataService, nameof(dataService));
        }

        public async Task<List<Dropdown>> Handle(GetAllSpecialitiesDropdownQuery request, CancellationToken cancellationToken)
        {
            return await DataService.GetSpecialityInformation()
                .ToListAsync(cancellationToken);
        }
    }
}

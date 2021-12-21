using Microsoft.EntityFrameworkCore;
using WWI.Core6.Services.Interfaces;

namespace WWI.Core6.Services.MediatR.Handlers
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

using WWI.Core6.Models.ViewModels;

namespace WWI.Core6.Services.MediatR.Queries
{
    public class GetAllSpecialitiesDropdownQuery : IRequest<List<Dropdown>>
    {
        public GetAllSpecialitiesDropdownQuery()
        {

        }
    }
}

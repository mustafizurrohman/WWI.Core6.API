using WWI.Core6.Models.ViewModels;

namespace WWI.Core6.Services.MediatR.Queries
{
    public class GetAllHospitalsQuery : IRequest<List<Dropdown>>
    {        
        public GetAllHospitalsQuery()
        {
        }
    }
}

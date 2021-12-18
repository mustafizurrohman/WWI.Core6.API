using WWI.Core6.Models.ViewModels;

namespace WWI.Core6.Services.MediatR.Queries
{
    public class GetSpecialityInformationByIDQuery : IRequest<Dropdown>
    {
        public int SpecialityID { get; }

        public GetSpecialityInformationByIDQuery(int specialityID)
        {
            SpecialityID = specialityID;
        }
    }
}

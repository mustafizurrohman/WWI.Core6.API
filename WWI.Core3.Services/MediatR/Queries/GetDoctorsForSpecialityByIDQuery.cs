using MediatR;
using System.Collections.Generic;
using WWI.Core3.Models.ViewModels;

namespace WWI.Core3.Services.MediatR.Queries
{
    public class GetDoctorsForSpecialityByIDQuery : IRequest<List<Dropdown>>
    {
        public int SpecialityID { get; }

        public GetDoctorsForSpecialityByIDQuery(int specialityID)
        {
            SpecialityID = specialityID;
        }
    }
}

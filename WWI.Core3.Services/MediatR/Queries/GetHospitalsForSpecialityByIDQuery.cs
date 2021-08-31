using MediatR;
using System.Collections.Generic;
using WWI.Core3.Models.ViewModels;

namespace WWI.Core3.Services.MediatR.Queries
{
    public class GetHospitalsForSpecialityByIDQuery : IRequest<List<Dropdown>>
    {
        public int SpecialityID { get; }

        public GetHospitalsForSpecialityByIDQuery(int specialityID)
        {
            SpecialityID = specialityID;
        }
    }
}

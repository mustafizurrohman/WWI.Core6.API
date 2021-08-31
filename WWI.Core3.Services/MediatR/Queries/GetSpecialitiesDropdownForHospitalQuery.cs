using MediatR;
using System.Collections.Generic;
using WWI.Core3.Models.ViewModels;

namespace WWI.Core3.Services.MediatR.Queries
{
    public class GetSpecialitiesDropdownForHospitalQuery : IRequest<List<Dropdown>>
    {
        public int HospitalID { get; }

        public GetSpecialitiesDropdownForHospitalQuery(int hospitalID)
        {
            HospitalID = hospitalID;
        }
    }
}

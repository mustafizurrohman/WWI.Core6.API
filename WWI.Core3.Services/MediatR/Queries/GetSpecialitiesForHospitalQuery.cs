using MediatR;
using System.Collections.Generic;
using WWI.Core3.Models.ViewModels;

namespace WWI.Core3.Services.MediatR.Queries
{
    public class GetSpecialitiesForHospitalQuery : IRequest<List<SpecialityInformation>>
    {
        public int HospitalID { get;  }

        public GetSpecialitiesForHospitalQuery(int hospitalID)
        {
            HospitalID = hospitalID;
        }

    }
}

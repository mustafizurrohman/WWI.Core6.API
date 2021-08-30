using MediatR;
using System.Collections.Generic;
using WWI.Core3.Models.ViewModels;

namespace WWI.Core3.Services.MediatR.Queries
{
    public class GetDoctorByHospitalQuery : IRequest<List<Dropdown>>
    {
        public int HospitalID { get;  }

        public GetDoctorByHospitalQuery(int hospitalID)
        {
            HospitalID = hospitalID;
        }

    }
}

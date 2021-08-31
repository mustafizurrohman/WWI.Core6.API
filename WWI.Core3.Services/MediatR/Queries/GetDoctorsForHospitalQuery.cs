﻿using MediatR;
using WWI.Core3.Models.ViewModels;

namespace WWI.Core3.Services.MediatR.Queries
{
    public class GetDoctorsForHospitalQuery : IRequest<HospitalDoctorInformation>
    {
        public int HospitalID { get;  }

        public GetDoctorsForHospitalQuery(int hospitalID)
        {
            HospitalID = hospitalID;
        }
    }
}

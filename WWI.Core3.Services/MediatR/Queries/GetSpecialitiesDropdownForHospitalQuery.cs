﻿namespace WWI.Core3.Services.MediatR.Queries
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

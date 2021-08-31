using MediatR;
using WWI.Core3.Models.ViewModels;

namespace WWI.Core3.Services.MediatR.Queries
{
    public class GetSpecialityInfoForHospitalQuery : IRequest<SpecialityInformation>
    {
        public int HospitalID { get;  }
        public int SpecialityID { get; }

        public GetSpecialityInfoForHospitalQuery(int hospitalID, int specialityID)
        {
            HospitalID = hospitalID;
            SpecialityID = specialityID;
        }
    }
}

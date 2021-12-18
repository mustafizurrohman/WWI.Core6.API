using WWI.Core6.Models.ViewModels;

namespace WWI.Core6.Services.MediatR.Queries
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

using WWI.Core6.Models.ViewModels;

namespace WWI.Core6.Services.MediatR.Queries
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

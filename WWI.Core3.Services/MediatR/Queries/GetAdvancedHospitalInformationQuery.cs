using MediatR;
using WWI.Core3.Models.ViewModels;

namespace WWI.Core3.Services.MediatR.Queries
{
    public class GetAdvancedHospitalInformationQuery : IRequest<AdvancedHospitalInformation>
    {
        public int HospitalID { get; }

        public GetAdvancedHospitalInformationQuery(int hospitalID)
        {
            HospitalID = hospitalID;
        }
    }
}

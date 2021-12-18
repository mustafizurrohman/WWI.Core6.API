namespace WWI.Core3.Services.MediatR.Queries
{
    public class GetHospitalInformationQuery : IRequest<HospitalInformation>
    {
        public int HospitalID { get; }

        public GetHospitalInformationQuery(int hospitalID)
        {
            HospitalID = hospitalID;
        }
    }
}

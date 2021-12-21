namespace WWI.Core6.Services.MediatR.Queries
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

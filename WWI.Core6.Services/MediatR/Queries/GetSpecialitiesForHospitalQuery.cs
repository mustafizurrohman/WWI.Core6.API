namespace WWI.Core6.Services.MediatR.Queries;

public class GetSpecialitiesForHospitalQuery : IRequest<List<SpecialityInformation>>
{
    public int HospitalID { get;  }

    public GetSpecialitiesForHospitalQuery(int hospitalID)
    {
        HospitalID = hospitalID;
    }

}
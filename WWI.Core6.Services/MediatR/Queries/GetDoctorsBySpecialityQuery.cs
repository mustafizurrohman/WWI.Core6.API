namespace WWI.Core6.Services.MediatR.Queries;

public class GetDoctorsBySpecialityQuery : IRequest<List<Dropdown>>
{
    public int SpecialityID { get; }

    public GetDoctorsBySpecialityQuery(int specialityID)
    {
        this.SpecialityID = specialityID;
    }

}
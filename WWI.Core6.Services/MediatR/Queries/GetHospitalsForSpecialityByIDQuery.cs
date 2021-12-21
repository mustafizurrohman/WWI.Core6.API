namespace WWI.Core6.Services.MediatR.Queries
{
    public class GetHospitalsForSpecialityByIDQuery : IRequest<List<Dropdown>>
    {
        public int SpecialityID { get; }

        public GetHospitalsForSpecialityByIDQuery(int specialityID)
        {
            SpecialityID = specialityID;
        }
    }
}

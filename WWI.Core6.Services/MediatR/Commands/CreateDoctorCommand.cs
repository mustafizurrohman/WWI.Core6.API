namespace WWI.Core6.Services.MediatR.Commands
{
    public class CreateDoctorCommand : IRequest<DoctorInfo>
    {
        public string Firstname { get; }
        public string Middlename { get; }
        public string Lastname { get; }
        public int SpecialityID { get; }
    }

} 

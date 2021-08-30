using MediatR;
using System.Collections.Generic;
using WWI.Core3.Models.ViewModels;

namespace WWI.Core3.Services.MediatR.Commands
{
    public class CreateDoctorCommand : IRequest<DoctorInfo>
    {
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public int SpecialityID { get; set; }
        public List<int> HospitalIDs { get; set; }
    }

} 

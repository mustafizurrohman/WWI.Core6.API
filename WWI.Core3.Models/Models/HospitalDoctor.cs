using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WWI.Core3.Models.Models
{
    public class HospitalDoctor
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int HospitalDoctorID { get; set; }

        public int DoctorID { get; set; }
        public Doctor Doctor { get; set; }

        public int HospitalID { get; set; }
        public Hospital Hospital { get; set; }
    }
}

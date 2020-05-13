using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WWI.Core3.Models.Models;
using WWI.Core3.Models.Utils;

namespace WWI.Core3.Models
{
    /// <summary>
    /// Doctor 
    /// </summary>
    public partial class Doctor
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Doctor"/> class.
        /// </summary>
        public Doctor()
        {
            Hospitals = new List<HospitalDoctor>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int DoctorID { get; set; }

        [MaxLength(50)]
        public string Firstname { get; set; }

        [MaxLength(50)]
        public string Middlename { get; set; } = string.Empty;

        [MaxLength(50)]
        public string Lastname { get; set; }

        [ForeignKey("Speciality")]
        public int SpecialityID { get; set; }

        public Speciality Speciality { get; set; }

        public virtual List<HospitalDoctor> Hospitals { get; set; }

        [NotMapped]
        public string FullName => (Firstname + " " + Middlename + " " + Lastname).RemoveConsequtiveSpaces();

    }
}

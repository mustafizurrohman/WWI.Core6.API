using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WWI.Core3.Models.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class HospitalDoctor
    {

        /// <summary>
        /// Gets or sets the hospital doctor identifier.
        /// </summary>
        /// <value>
        /// The hospital doctor identifier.
        /// </value>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int HospitalDoctorID { get; set; }

        /// <summary>
        /// Gets or sets the doctor identifier.
        /// </summary>
        /// <value>
        /// The doctor identifier.
        /// </value>
        public int DoctorID { get; set; }

        /// <summary>
        /// Gets or sets the doctor.
        /// </summary>
        /// <value>
        /// The doctor.
        /// </value>
        public Doctor Doctor { get; set; }

        /// <summary>
        /// Gets or sets the hospital identifier.
        /// </summary>
        /// <value>
        /// The hospital identifier.
        /// </value>
        public int HospitalID { get; set; }

        /// <summary>
        /// Gets or sets the hospital.
        /// </summary>
        /// <value>
        /// The hospital.
        /// </value>
        public Hospital Hospital { get; set; }
    }
}

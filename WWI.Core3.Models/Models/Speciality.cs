using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WWI.Core3.Models.Models
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class Speciality
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="Speciality"/> class.
        /// </summary>
        public Speciality()
        {
            Doctors = new List<Doctor>();
        }

        /// <summary>
        /// Gets or sets the Specialty identifier.
        /// </summary>
        /// <value>
        /// The Specialty identifier.
        /// </value>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        // ReSharper disable once InconsistentNaming
        public int SpecialtyID { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [MaxLength(100)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the doctors.
        /// </summary>
        /// <value>
        /// The doctors.
        /// </value>
        public IEnumerable<Doctor> Doctors { get; set; }

        /// <summary>
        /// Gets or sets the hospitals.
        /// </summary>
        /// <value>
        /// The hospitals.
        /// </value>
        public IEnumerable<HospitalSpeciality> Hospitals { get; set; }

    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WWI.Core3.Models
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Speciality
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="Speciality"/> class.
        /// </summary>
        public Speciality()
        {
            Doctors = new List<Doctor>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int SpecialityID { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }


        public IEnumerable<Doctor> Doctors { get; set; }

    }
}

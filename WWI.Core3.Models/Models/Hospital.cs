using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WWI.Core3.Models.Models
{
    /// <summary>
    /// Hospital
    /// </summary>
    public partial class Hospital
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Hospital"/> class.
        /// </summary>
        public Hospital()
        {
            Doctors = new List<HospitalDoctor>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int HospitalID { get; set; }

        public string Name { get; set; }


        public Address Address { get; set; }

        public IEnumerable<HospitalDoctor> Doctors { get; set; }

    }
}

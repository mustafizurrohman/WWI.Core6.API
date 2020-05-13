using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WWI.Core3.Models.Models
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Address
    {
        public Address()
        {
            Hospitals = new List<Hospital>();
        }


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int AddressID { get; set; }

        [MaxLength(200)]
        public string Street { get; set; }

        [MaxLength(50)]
        public string City { get; set; }

        [MaxLength(50)]
        public string District { get; set; }

        [MaxLength(50)]
        public string State { get; set; }

        [MaxLength(50)]
        public string Country { get; set; }

        [MaxLength(50)]
        public string PIN { get; set; }

        public virtual IEnumerable<Hospital> Hospitals { get; set; }

    }
}

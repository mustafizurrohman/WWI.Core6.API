// ***********************************************************************
// Assembly         : WWI.Core3.Models
// Author           : Mustafizur Rohman
// Created          : 05-08-2020
//
// Last Modified By : Mustafizur Rohman
// Last Modified On : 05-15-2020
// ***********************************************************************
// <copyright file="Hospital.cs" company="WWI.Core3.Models">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WWI.Core3.Models.Models
{
    /// <summary>
    /// Hospital
    /// </summary>
    public sealed partial class Hospital
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Hospital" /> class.
        /// </summary>
        public Hospital()
        {
            Doctors = new List<HospitalDoctor>();
            Specialities = new List<HospitalSpeciality>();
        }

        /// <summary>
        /// Gets or sets the hospital identifier.
        /// </summary>
        /// <value>The hospital identifier.</value>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int HospitalID { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the address identifier.
        /// </summary>
        /// <value>The address identifier.</value>
        [ForeignKey("Address")]
        public int AddressID { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>The address.</value>
        public Address Address { get; set; }

        /// <summary>
        /// Gets or sets the doctors.
        /// </summary>
        /// <value>The doctors.</value>
        public IEnumerable<HospitalDoctor> Doctors { get; set; }

        /// <summary>
        /// Gets or sets the specialities.
        /// </summary>
        /// <value>The specialities.</value>
        public IEnumerable<HospitalSpeciality> Specialities { get; set; }

    }
}

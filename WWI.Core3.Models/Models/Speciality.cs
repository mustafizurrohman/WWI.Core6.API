// ***********************************************************************
// Assembly         : WWI.Core3.Models
// Author           : Mustafizur Rohman
// Created          : 05-08-2020
//
// Last Modified By : Mustafizur Rohman
// Last Modified On : 05-15-2020
// ***********************************************************************
// <copyright file="Speciality.cs" company="WWI.Core3.Models">
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
    /// Class Speciality. This class cannot be inherited.
    /// </summary>
    public sealed partial class Speciality
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="Speciality" /> class.
        /// </summary>
        public Speciality()
        {
            Doctors = new List<Doctor>();
        }

        /// <summary>
        /// Gets or sets the Specialty identifier.
        /// </summary>
        /// <value>The Specialty identifier.</value>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int SpecialtyID { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [MaxLength(100)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the doctors.
        /// </summary>
        /// <value>The doctors.</value>
        public IEnumerable<Doctor> Doctors { get; set; }

        /// <summary>
        /// Gets or sets the hospitals.
        /// </summary>
        /// <value>The hospitals.</value>
        public IEnumerable<HospitalSpeciality> Hospitals { get; set; }

    }
}

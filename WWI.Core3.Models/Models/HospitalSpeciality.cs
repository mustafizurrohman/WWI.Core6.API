// ***********************************************************************
// Assembly         : WWI.Core3.Models
// Author           : Mustafizur Rohman
// Created          : 05-15-2020
//
// Last Modified By : Mustafizur Rohman
// Last Modified On : 05-15-2020
// ***********************************************************************
// <copyright file="HospitalSpeciality.cs" company="WWI.Core3.Models">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WWI.Core3.Models.Models
{
    /// <summary>
    /// Class HospitalSpeciality.
    /// </summary>
    public sealed class HospitalSpeciality
    {

        /// <summary>
        /// Gets or sets the hospital speciality identifier.
        /// </summary>
        /// <value>The hospital speciality identifier.</value>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int HospitalSpecialityID { get; set; }


        /// <summary>
        /// Gets or sets the specialty identifier.
        /// </summary>
        /// <value>The specialty identifier.</value>
        public int SpecialtyID { get; set; }

        /// <summary>
        /// Gets or sets the speciality.
        /// </summary>
        /// <value>The speciality.</value>
        public Speciality Speciality { get; set; }

        /// <summary>
        /// Gets or sets the hospital identifier.
        /// </summary>
        /// <value>The hospital identifier.</value>
        public int HospitalID { get; set; }

        /// <summary>
        /// Gets or sets the hospital.
        /// </summary>
        /// <value>The hospital.</value>
        public Hospital Hospital { get; set; }


    }
}

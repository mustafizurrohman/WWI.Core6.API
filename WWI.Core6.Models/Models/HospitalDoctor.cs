// ***********************************************************************
// Assembly         : WWI.Core6.Models
// Author           : Mustafizur Rohman
// Created          : 05-09-2020
//
// Last Modified By : Mustafizur Rohman
// Last Modified On : 05-15-2020
// ***********************************************************************
// <copyright file="HospitalDoctor.cs" company="WWI.Core6.Models">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using JetBrains.Annotations;

namespace WWI.Core6.Models.Models
{
    /// <summary>
    /// Class HospitalDoctor.
    /// </summary>
    public sealed class HospitalDoctor
    {

        /// <summary>
        /// Gets or sets the hospital doctor identifier.
        /// </summary>
        /// <value>The hospital doctor identifier.</value>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int HospitalDoctorID { [UsedImplicitly] get; set; }

        /// <summary>
        /// Gets or sets the doctor identifier.
        /// </summary>
        /// <value>The doctor identifier.</value>
        public int DoctorID { get; set; }

        /// <summary>
        /// Gets or sets the doctor.
        /// </summary>
        /// <value>The doctor.</value>
        public Doctor Doctor { get; [UsedImplicitly] set; }

        /// <summary>
        /// Gets or sets the hospital identifier.
        /// </summary>
        /// <value>The hospital identifier.</value>
        public int HospitalID { get; set; }

        /// <summary>
        /// Gets or sets the hospital.
        /// </summary>
        /// <value>The hospital.</value>
        public Hospital Hospital { get; [UsedImplicitly] set; }
    }
}

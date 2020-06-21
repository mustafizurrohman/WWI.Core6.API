// ***********************************************************************
// Assembly         : WWI.Core3.Models
// Author           : Mustafizur Rohman
// Created          : 05-08-2020
//
// Last Modified By : Mustafizur Rohman
// Last Modified On : 05-15-2020
// ***********************************************************************
// <copyright file="Doctor.cs" company="WWI.Core3.Models">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using JetBrains.Annotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WWI.Core3.Models.Utils;

namespace WWI.Core3.Models.Models
{
    /// <summary>
    /// Doctor
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
    public sealed partial class Doctor
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Doctor" /> class.
        /// </summary>
        public Doctor()
        {
            Hospitals = new List<HospitalDoctor>();
        }

        /// <summary>
        /// Gets or sets the doctor identifier.
        /// </summary>
        /// <value>The doctor identifier.</value>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int DoctorID { get; set; }

        /// <summary>
        /// Gets or sets the firstname.
        /// </summary>
        /// <value>The firstname.</value>
        [MaxLength(50)]
        public string Firstname { get; set; }

        /// <summary>
        /// Gets or sets the middlename.
        /// </summary>
        /// <value>The middlename.</value>
        [MaxLength(50)]
        // ReSharper disable once IdentifierTypo
        public string Middlename { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the lastname.
        /// </summary>
        /// <value>The lastname.</value>
        [MaxLength(50)]
        public string Lastname { get; set; }

        /// <summary>
        /// Gets or sets the speciality identifier.
        /// </summary>
        /// <value>The speciality identifier.</value>
        [ForeignKey("Speciality")]
        public int SpecialityID { get; set; }

        /// <summary>
        /// Gets or sets the speciality.
        /// </summary>
        /// <value>The speciality.</value>
        public Speciality Speciality { get; [UsedImplicitly] set; }

        /// <summary>
        /// Gets or sets the hospitals.
        /// </summary>
        /// <value>The hospitals.</value>
        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Global
        // ReSharper disable once CollectionNeverUpdated.Global
        public List<HospitalDoctor> Hospitals { get; set; }

        /// <summary>
        /// Gets the full name.
        /// </summary>
        /// <value>The full name.</value>
        [NotMapped]
        public string FullName => (Firstname + " " + Middlename + " " + Lastname).RemoveConsecutiveSpaces();

    }
}

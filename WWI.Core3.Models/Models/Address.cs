// ***********************************************************************
// Assembly         : WWI.Core3.Models
// Author           : Mustafizur Rohman
// Created          : 05-08-2020
//
// Last Modified By : Mustafizur Rohman
// Last Modified On : 05-15-2020
// ***********************************************************************
// <copyright file="Address.cs" company="WWI.Core3.Models">
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
    /// Class Address.
    /// </summary>
    public sealed partial class Address
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Address" /> class.
        /// </summary>
        public Address()
        {
            Hospitals = new List<Hospital>();
        }

        /// <summary>
        /// Gets or sets the address identifier.
        /// </summary>
        /// <value>The address identifier.</value>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int AddressID { get; set; }

        /// <summary>
        /// Gets or sets the street.
        /// </summary>
        /// <value>The street.</value>
        [MaxLength(200)]
        public string Street { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>The city.</value>
        [MaxLength(50)]
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the district.
        /// </summary>
        /// <value>The district.</value>
        [MaxLength(50)]
        public string District { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>The state.</value>
        [MaxLength(50)]
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>The country.</value>
        [MaxLength(50)]
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the pin.
        /// </summary>
        /// <value>The pin.</value>
        [MaxLength(50)]
        // ReSharper disable once InconsistentNaming
        public string PIN { get; set; }

        /// <summary>
        /// Gets or sets the hospitals.
        /// </summary>
        /// <value>The hospitals.</value>
        // ReSharper disable once MemberCanBePrivate.Global
        public IEnumerable<Hospital> Hospitals { get; }

    }
}

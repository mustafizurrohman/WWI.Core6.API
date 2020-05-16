// ***********************************************************************
// Assembly         : WWI.Core3.Models
// Author           : Mustafizur Rohman
// Created          : 05-15-2020
//
// Last Modified By : Mustafizur Rohman
// Last Modified On : 05-16-2020
// ***********************************************************************
// <copyright file="AdvancedHospitalInformation.cs" company="WWI.Core3.Models">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using WWI.Core3.Models.Models;

namespace WWI.Core3.Models.ViewModels
{
    /// <summary>
    /// Class AdvancedHospitalInformation.
    /// </summary>
    public class AdvancedHospitalInformation
    {
        /// <summary>
        /// Gets or sets the name of the hospital.
        /// </summary>
        /// <value>The name of the hospital.</value>
        public string HospitalName { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>The address.</value>
        public Address Address { get; set; }

        /// <summary>
        /// Gets or sets the departments.
        /// </summary>
        /// <value>The departments.</value>
        public IEnumerable<SpecialityInformation> Departments { get; set; }

    }


}

// ***********************************************************************
// Assembly         : WWI.Core3.Models
// Author           : Mustafizur Rohman
// Created          : 05-19-2020
//
// Last Modified By : Mustafizur Rohman
// Last Modified On : 05-19-2020
// ***********************************************************************
// <copyright file="DoctorDropdown.cs" company="WWI.Core3.Models">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace WWI.Core3.Models.ViewModels.Dropdown
{
    /// <summary>
    /// Class DoctorDropdown.
    /// </summary>
    public class DoctorDropdown
    {
        /// <summary>
        /// Gets or sets the doctor identifier.
        /// </summary>
        /// <value>The doctor identifier.</value>
        public int DoctorID { get; set; }

        /// <summary>
        /// Gets or sets the full name.
        /// </summary>
        /// <value>The full name.</value>
        public string FullName { get; set; }
    }
}

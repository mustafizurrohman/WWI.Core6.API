// ***********************************************************************
// Assembly         : WWI.Core6.Models
// Author           : Mustafizur Rohman
// Created          : 05-16-2020
//
// Last Modified By : Mustafizur Rohman
// Last Modified On : 05-16-2020
// ***********************************************************************
// <copyright file="DoctorInfo.cs" company="WWI.Core6.Models">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace WWI.Core6.Models.ViewModels;

/// <summary>
/// Class DoctorInfo.
/// </summary>
public class DoctorInfo
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
    /// <summary>
    /// Gets or sets the name of the speciality.
    /// </summary>
    /// <value>The name of the speciality.</value>
    public string SpecialityName { get; set; }
}
// ***********************************************************************
// Assembly         : WWI.Core6.Models
// Author           : Mustafizur Rohman
// Created          : 05-16-2020
//
// Last Modified By : Mustafizur Rohman
// Last Modified On : 05-16-2020
// ***********************************************************************
// <copyright file="SpecialityInformation.cs" company="WWI.Core6.Models">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace WWI.Core6.Models.ViewModels;

/// <summary>
/// Class SpecialityInformation.
/// </summary>
public class SpecialityInformation
{
    /// <summary>
    /// Gets or sets the specialty identifier.
    /// </summary>
    /// <value>The specialty identifier.</value>
    public int SpecialtyID { get; set; }

    /// <summary>
    /// Gets or sets the name of the department.
    /// </summary>
    /// <value>The name of the department.</value>
    public string SpecialityName { get; set; }

    /// <summary>
    /// Gets or sets the doctor list.
    /// </summary>
    /// <value>The doctor list.</value>
    public List<string> DoctorList { get; set; }

}
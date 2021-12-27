// ***********************************************************************
// Assembly         : WWI.Core6.Models
// Author           : Mustafizur Rohman
// Created          : 05-16-2020
//
// Last Modified By : Mustafizur Rohman
// Last Modified On : 05-16-2020
// ***********************************************************************
// <copyright file="HospitalDoctorInformation.cs" company="WWI.Core6.Models">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace WWI.Core6.Models.ViewModels;

/// <summary>
/// Class HospitalDoctorInformation.
/// </summary>
public class HospitalDoctorInformation
{
    /// <summary>
    /// Gets or sets the hospital identifier.
    /// </summary>
    /// <value>The hospital identifier.</value>
    public int HospitalID { get; set; }

    /// <summary>
    /// Gets or sets the name of the hospital.
    /// </summary>
    /// <value>The name of the hospital.</value>
    public string HospitalName { get; set; }

    /// <summary>
    /// Gets or sets the doctors.
    /// </summary>
    /// <value>The doctors.</value>
    public List<DoctorInfo> Doctors { get; set; }
}
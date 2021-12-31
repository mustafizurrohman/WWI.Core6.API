// ***********************************************************************
// Assembly         : WWI.Core6.Services
// Author           : Mustafizur Rohman
// Created          : 09-16-2020
//
// Last Modified By : Mustafizur Rohman
// Last Modified On : 09-17-2020
// ***********************************************************************
// <copyright file="ISharedService.cs" company="WWI.Core6.Services">
//     Copyright (c) Personal. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace WWI.Core6.Services.Interfaces;

/// <summary>
/// Interface ISharedService
/// </summary>
public interface ISharedService
{

    /// <summary>
    /// Gets the hospital information.
    /// </summary>
    /// <returns>IQueryable&lt;HospitalInformation&gt;.</returns>
    IQueryable<HospitalInformation> GetHospitalInformation();

    /// <summary>
    /// Get advanced information about hospital
    /// </summary>
    /// <returns></returns>
    IQueryable<AdvancedHospitalInformation> GetAdvancedHospitalInformation();

    /// <summary>
    /// Gets information about a doctor
    /// </summary>
    /// <returns></returns>
    IQueryable<DoctorInfo> GetInformationAboutDoctor();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="firstName"></param>
    /// <param name="middleName"></param>
    /// <param name="lastName"></param>
    /// <param name="specialityID"></param>
    /// <returns></returns>
    bool BeUniqueName(string firstName, string middleName, string lastName, int specialityID);

}
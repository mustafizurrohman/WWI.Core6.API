﻿// ***********************************************************************
// Assembly         : WWI.Core6.Services
// Author           : Mustafizur Rohman
// Created          : 05-15-2020
//
// Last Modified By : Mustafizur Rohman
// Last Modified On : 05-15-2020
// ***********************************************************************
// <copyright file="IDataService.cs" company="WWI.Core6.Services">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace WWI.Core6.Services.Interfaces;

/// <summary>
/// Interface IDataService
/// </summary>
public interface IDataService
{
    /// <summary>
    /// Gets the hospital information by identifier asynchronous.
    /// </summary>
    /// <param name="hospitalID">The hospital identifier.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Task&lt;HospitalInformation&gt;.</returns>
    Task<HospitalInformation> GetHospitalInformationByIDAsync(int hospitalID, CancellationToken cancellationToken);


    /// <summary>
    /// Gets the advanced hospital information asynchronously
    /// </summary>
    /// <param name="hospitalID">The hospital identifier.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Task&lt;AdvancedHospitalInformation&gt;.</returns>
    Task<AdvancedHospitalInformation> GetAdvancedHospitalInformationAsync(int hospitalID, CancellationToken cancellationToken);

    /// <summary>
    /// Gets the doctors for hospital.
    /// </summary>
    /// <param name="hospitalID">The hospital identifier.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Task&lt;HospitalDoctorInformation&gt;.</returns>
    Task<HospitalDoctorInformation> GetDoctorsForHospitalAsync(int hospitalID, CancellationToken cancellationToken);

    /// <summary>
    /// Gets all speciality information for hospital.
    /// </summary>
    /// <param name="hospitalID">The hospital identifier.</param>
    /// <returns>Task&lt;IQueryable&lt;SpecialityInformation&gt;&gt;.</returns>
    IQueryable<SpecialityInformation> GetAllSpecialityInfoForHospital(int hospitalID);

    /// <summary>
    /// Gets the speciality information.
    /// </summary>
    /// <returns>IQueryable&lt;SpecialityDropdown&gt;.</returns>
    IQueryable<Dropdown> GetSpecialityInformation();
}
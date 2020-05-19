﻿// ***********************************************************************
// Assembly         : WWI.Core3.Services
// Author           : Mustafizur Rohman
// Created          : 05-15-2020
//
// Last Modified By : Mustafizur Rohman
// Last Modified On : 05-15-2020
// ***********************************************************************
// <copyright file="IDataService.cs" company="WWI.Core3.Services">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Linq;
using System.Threading.Tasks;
using WWI.Core3.Models.ViewModels;
using WWI.Core3.Models.ViewModels.Dropdown;

namespace WWI.Core3.Services.Interfaces
{
    /// <summary>
    /// Interface IDataService
    /// </summary>
    public interface IDataService
    {

        /// <summary>
        /// Gets the hospital information by identifier asynchronous.
        /// </summary>
        /// <param name="hospitalID">The hospital identifier.</param>
        /// <returns>Task&lt;HospitalInformation&gt;.</returns>
        Task<HospitalInformation> GetHospitalInformationByIDAsync(int hospitalID);

        /// <summary>
        /// Gets the advanced hospital information.
        /// </summary>
        /// <param name="hospitalID">The hospital identifier.</param>
        /// <returns>Task&lt;AdvancedHospitalInformation&gt;.</returns>
        Task<AdvancedHospitalInformation> GetAdvancedHospitalInformationAsync(int hospitalID);

        /// <summary>
        /// Gets the doctors for hospital.
        /// </summary>
        /// <param name="hospitalID">The hospital identifier.</param>
        /// <returns>Task&lt;HospitalDoctorInformation&gt;.</returns>
        Task<HospitalDoctorInformation> GetDoctorsForHospitalAsync(int hospitalID);

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
        IQueryable<SpecialityDropdown> GetSpecialityInformation();
    }
}
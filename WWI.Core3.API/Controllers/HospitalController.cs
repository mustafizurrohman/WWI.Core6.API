// ***********************************************************************
// Assembly         : WWI.Core3.API
// Author           : Mustafizur Rohman
// Created          : 05-17-2020
//
// Last Modified By : Mustafizur Rohman
// Last Modified On : 05-19-2020
// ***********************************************************************
// <copyright file="HospitalController.cs" company="WWI.Core3.API">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WWI.Core3.API.Controllers.Base;
using WWI.Core3.Models.ViewModels;
using WWI.Core3.Services.Interfaces;
using WWI.Core3.Services.ServiceCollection;

namespace WWI.Core3.API.Controllers
{

    /// <summary>
    /// Class HospitalController.
    /// Implements the <see cref="BaseAPIController" />
    /// </summary>
    /// <seealso cref="BaseAPIController" />
    public class HospitalController : BaseAPIController
    {

        #region  -- Private Variables -- 

        /// <summary>
        /// Gets the data service.
        /// </summary>
        /// <value>The data service.</value>
        private IDataService DataService { get; }

        #endregion

        #region -- Constructor -- 

        /// <summary>
        /// Initializes a new instance of the <see cref="HospitalController" /> class.
        /// </summary>
        /// <param name="applicationServices">Application Services</param>
        /// <param name="dataService">The data service.</param>
        public HospitalController(IApplicationServices applicationServices, IDataService dataService) : base(
            applicationServices)
        {
            DataService = dataService;
        }

        #endregion

        #region  -- GET Methods --

        /// <summary>
        /// Gets the hospitals.
        /// </summary>
        /// <returns>IActionResult.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetHospitals()
        {
            var hospitals = await DbContext.Hospitals
                .ProjectTo<Dropdown>(AutoMapper.ConfigurationProvider)
                .OrderBy(hos => hos.DisplayValue)
                .AsNoTracking()
                .ToListAsync();

            return Ok(hospitals);
        }


        /// <summary>
        /// Gets the hospital by identifier.
        /// </summary>
        /// <param name="hospitalID">The hospital identifier.</param>
        /// <returns>IActionResult.</returns>
        [HttpGet("{hospitalID}")]
        [ProducesResponseType(typeof(HospitalInformation), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetHospitalById(int hospitalID)
        {
            var hospital = await DataService.GetHospitalInformationByIDAsync(hospitalID);

            return Ok(hospital);
        }


        /// <summary>
        /// Gets the hospital information by identifier.
        /// </summary>
        /// <param name="hospitalID">The hospital identifier.</param>
        /// <returns>IActionResult.</returns>
        [HttpGet("{hospitalID}/advancedInfo")]
        [ProducesResponseType(typeof(AdvancedHospitalInformation), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetHospitalInfoById(int hospitalID)
        {
            var advancedHospitalInformation = await DataService.GetAdvancedHospitalInformationAsync(hospitalID);

            return Ok(advancedHospitalInformation);
        }


        /// <summary>
        /// Gets the doctors for hospital by identifier.
        /// </summary>
        /// <param name="hospitalID">The identifier.</param>
        /// <returns>IActionResult.</returns>
        [HttpGet("{hospitalID}/doctors")]
        [ProducesResponseType(typeof(HospitalDoctorInformation), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetDoctorsForHospitalById(int hospitalID)
        {
            var doctorsInHospital = await DataService.GetDoctorsForHospitalAsync(hospitalID);

            return Ok(doctorsInHospital);
        }


        /// <summary>
        /// Gets all speciality information for hospital.
        /// </summary>
        /// <param name="hospitalID">The hospital identifier.</param>
        /// <returns>IActionResult.</returns>
        [HttpGet("{hospitalID}/specialities")]
        [ProducesResponseType(typeof(SpecialityInformation), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAllSpecialityInfoForHospital(int hospitalID)
        {
            var specialityInformation = await DataService.GetAllSpecialityInfoForHospital(hospitalID)
                .ToListAsync();

            specialityInformation.ForEach(currentSpeciality =>
            {
                currentSpeciality.DoctorList = currentSpeciality.DoctorList.OrderBy(doc => doc).ToList();
            });

            return Ok(specialityInformation);
        }


        /// <summary>
        /// Gets the speciality information for hospital.
        /// </summary>
        /// <param name="hospitalID">The hospital identifier.</param>
        /// <param name="specialityID">The speciality identifier.</param>
        /// <returns>IActionResult.</returns>
        [HttpGet("{hospitalID}/specialities/{specialityID}")]
        [ProducesResponseType(typeof(AdvancedHospitalInformation), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetSpecialityInfoForHospital(int hospitalID, int specialityID)
        {
            var advancedHospitalInformation = await DataService.GetAdvancedHospitalInformationAsync(hospitalID);

            advancedHospitalInformation.Specialities = advancedHospitalInformation.Specialities
                .Where(s => s.SpecialtyID == specialityID)
                .ToList();

            return Ok(advancedHospitalInformation);
        }


        #endregion

    }
}
// ***********************************************************************
// Assembly         : WWI.Core3.API
// Author           : Mustafizur Rohman
// Created          : 05-17-2020
//
// Last Modified By : Mustafizur Rohman
// Last Modified On : 05-17-2020
// ***********************************************************************
// <copyright file="HospitalController.cs" company="WWI.Core3.API">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WWI.Core3.API.Controllers.Base;
using WWI.Core3.Services.Interfaces;
using WWI.Core3.Services.ServiceCollection;

namespace WWI.Core3.API.Controllers
{

    /// <summary>
    /// Class HospitalController.
    /// Implements the <see cref="WWI.Core3.API.Controllers.Base.BaseAPIController" />
    /// </summary>
    /// <seealso cref="WWI.Core3.API.Controllers.Base.BaseAPIController" />
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
        public HospitalController(ApplicationServices applicationServices, IDataService dataService) : base(
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
        public async Task<IActionResult> GetHospitals()
        {
            var hospitals = await DbContext.Hospitals
                .Select(hos => new
                {
                    hos.HospitalID,
                    hos.Name
                })
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
        public async Task<IActionResult> GetHospitalById(int hospitalID)
        {
            var hospital = await DataService.GetHospitalInformationByIDAsync(hospitalID);

            return Ok(hospital);
        }

        /// <summary>
        /// Gets the doctors for hospital by identifier.
        /// </summary>
        /// <param name="hospitalID">The identifier.</param>
        /// <returns>IActionResult.</returns>
        [HttpGet("{hospitalID}/doctors")]
        public async Task<IActionResult> GetDoctorsForHospitalById(int hospitalID)
        {
            var doctorsInHospital = await DataService.GetDoctorsForHospitalAsync(hospitalID);

            return Ok(doctorsInHospital);
        }

        /// <summary>
        /// Gets the hospital information by identifier.
        /// </summary>
        /// <param name="hospitalID">The hospital identifier.</param>
        /// <returns>IActionResult.</returns>
        [HttpGet("{hospitalID}/specialities")]
        public async Task<IActionResult> GetHospitalInfoById(int hospitalID)
        {
            var advancedHospitalInformation = await DataService.GetAdvancedHospitalInformationAsync(hospitalID);

            return Ok(advancedHospitalInformation);
        }

        /// <summary>
        /// Gets the speciality information for hospital.
        /// </summary>
        /// <param name="hospitalID">The hospital identifier.</param>
        /// <param name="specialityID">The speciality identifier.</param>
        /// <returns>IActionResult.</returns>
        [HttpGet("{hospitalID}/specialities/{specialityID}")]
        public async Task<IActionResult> GetSpecialityInfoForHospital(int hospitalID, int specialityID)
        {
            var advancedHospitalInformation = await DataService.GetAdvancedHospitalInformationAsync(hospitalID);

            advancedHospitalInformation.Specialities = advancedHospitalInformation.Specialities
                .Where(s => s.SpecialtyID == specialityID)
                .ToList();

            return Ok(advancedHospitalInformation);
        }

        /// <summary>
        /// Gets all speciality information for hospital.
        /// </summary>
        /// <param name="hospitalID">The hospital identifier.</param>
        /// <returns>IActionResult.</returns>
        [HttpGet("{hospitalID}/speciality")]
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

        #endregion

    }
}
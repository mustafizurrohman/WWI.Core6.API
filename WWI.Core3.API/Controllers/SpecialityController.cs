// ***********************************************************************
// Assembly         : WWI.Core3.API
// Author           : Mustafizur Rohman
// Created          : 05-17-2020
//
// Last Modified By : Mustafizur Rohman
// Last Modified On : 05-19-2020
// ***********************************************************************
// <copyright file="SpecialityController.cs" company="WWI.Core3.API">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WWI.Core3.API.Controllers.Base;
using WWI.Core3.Models.ViewModels;
using WWI.Core3.Services.Interfaces;
using WWI.Core3.Services.ServiceCollection;

namespace WWI.Core3.API.Controllers
{

    /// <summary>
    /// Class SpecialityController.
    /// Implements the <see cref="BaseAPIController" />
    /// </summary>
    /// <seealso cref="BaseAPIController" />
    public class SpecialityController : BaseAPIController
    {

        /// <summary>
        /// Gets the data service.
        /// </summary>
        /// <value>The data service.</value>
        private IDataService DataService { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SpecialityController" /> class.
        /// </summary>
        /// <param name="applicationServices">Application Services</param>
        /// <param name="dataService">The data service.</param>
        public SpecialityController(IApplicationServices applicationServices, IDataService dataService)
            : base(applicationServices)
        {
            DataService = dataService;
        }

        /// <summary>
        /// Gets the specialities.
        /// </summary>
        /// <returns>IActionResult.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<Dropdown>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetSpecialities()
        {
            List<Dropdown> specialityList = await DataService.GetSpecialityInformation()
                .ToListAsync();

            // Also works!!!
            // var specialityList = DataService.GetSpecialityInformation();

            return Ok(specialityList);
        }


        /// <summary>
        /// Gets the speciality by identifier.
        /// </summary>
        /// <param name="specialityID">The speciality identifier.</param>
        /// <returns>IActionResult.</returns>
        [HttpGet("{specialityID}")]
        [ProducesResponseType(typeof(Dropdown), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetSpecialityByID(int specialityID)
        {
            var speciality = await DataService.GetSpecialityInformation()
                .SingleOrDefaultAsync(s => s.ID == specialityID);

            return Ok(speciality);
        }

        /// <summary>
        /// Gets the doctors for speciality by identifier.
        /// </summary>
        /// <param name="specialityID">The speciality identifier.</param>
        /// <returns>IActionResult.</returns>
        [HttpGet("{specialityID}/doctor")]
        [ProducesResponseType(typeof(Dropdown), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetDoctorsForSpecialityByID(int specialityID)
        {
            var doctors = await DbContext.Specialities
                .Include(s => s.Doctors)
                .Where(s => s.SpecialtyID == specialityID)
                .SelectMany(s => s.Doctors)
                .ProjectTo<Dropdown>(AutoMapper.ConfigurationProvider)
                .ToListAsync();

            return Ok(doctors);
        }


        /// <summary>
        /// Gets the hospitals with speciality by a speciality identifier.
        /// </summary>
        /// <param name="specialityID">The speciality identifier.</param>
        /// <returns>IActionResult.</returns>
        [HttpGet("{specialityID}/hospital")]
        [ProducesResponseType(typeof(Dropdown), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetHospitalsForSpecialityByID(int specialityID)
        {
            var hospitals = await DbContext.Specialities
                .Include(s => s.Hospitals)
                .Where(s => s.SpecialtyID == specialityID)
                .SelectMany(s => s.Hospitals)
                .Select(hs => hs.Hospital)
                .ProjectTo<Dropdown>(AutoMapper.ConfigurationProvider)
                .ToListAsync();

            return Ok(hospitals);
        }
    }
}
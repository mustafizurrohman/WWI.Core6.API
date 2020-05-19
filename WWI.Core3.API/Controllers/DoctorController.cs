﻿// ***********************************************************************
// Assembly         : WWI.Core3.API
// Author           : Mustafizur Rohman
// Created          : 05-17-2020
//
// Last Modified By : Mustafizur Rohman
// Last Modified On : 05-19-2020
// ***********************************************************************
// <copyright file="DoctorController.cs" company="WWI.Core3.API">
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
using WWI.Core3.Models.ViewModels.Dropdown;
using WWI.Core3.Services.Interfaces;
using WWI.Core3.Services.ServiceCollection;

namespace WWI.Core3.API.Controllers
{

    /// <summary>
    /// Class DoctorController.
    /// Implements the <see cref="BaseAPIController" />
    /// </summary>
    /// <seealso cref="BaseAPIController" />
    public class DoctorController : BaseAPIController
    {

        #region -- Private Variables -- 

        /// <summary>
        /// Gets the data service.
        /// </summary>
        /// <value>The data service.</value>
        private IDataService DataService { get; }

        #endregion

        #region  -- Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DoctorController" /> class.
        /// </summary>
        /// <param name="applicationServices">The application services.</param>
        /// <param name="dataService">The data service.</param>
        public DoctorController(ApplicationServices applicationServices, IDataService dataService) : base(
            applicationServices)
        {
            DataService = dataService;
        }

        #endregion

        #region  -- GET Methods --

        /// <summary>
        /// Gets the doctors.
        /// </summary>
        /// <returns>IActionResult.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<DoctorDropdown>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetDoctors()
        {
            var doctors = await DbContext.Doctors
                .ProjectTo<DoctorDropdown>(AutoMapper.ConfigurationProvider)
                .AsNoTracking()
                .ToListAsync();

            doctors = doctors.OrderBy(doc => doc.FullName).ToList();

            return Ok(doctors);
        }


        /// <summary>
        /// Gets Doctors by speciality.
        /// </summary>
        /// <param name="specialityID">The speciality identifier.</param>
        /// <returns>IActionResult.</returns>
        [HttpGet("speciality/{specialityID}")]
        [ProducesResponseType(typeof(List<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DoctorsBySpeciality(int specialityID)
        {
            var doctorsForSpeciality = await DbContext.Doctors
                .Where(doc => doc.SpecialityID == specialityID)
                .Select(doc => new DoctorDropdown()
                {
                    DoctorID = doc.DoctorID,
                    FullName = doc.FullName
                })
                .ToListAsync();

            doctorsForSpeciality = doctorsForSpeciality.OrderBy(doc => doc.FullName).ToList();

            return Ok(doctorsForSpeciality);
        }

        #endregion

    }
}
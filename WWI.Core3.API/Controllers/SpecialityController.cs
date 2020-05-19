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

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WWI.Core3.API.Controllers.Base;
using WWI.Core3.Models.ViewModels.Dropdown;
using WWI.Core3.Services.Interfaces;
using WWI.Core3.Services.ServiceCollection;

namespace WWI.Core3.API.Controllers
{

    /// <summary>
    /// Class SpecialityController.
    /// Implements the <see cref="WWI.Core3.API.Controllers.Base.BaseAPIController" />
    /// </summary>
    /// <seealso cref="WWI.Core3.API.Controllers.Base.BaseAPIController" />
    [ApiController]
    public class SpecialityController : BaseAPIController
    {

        #region  -- Private Variables -- 

        /// <summary>
        /// Gets the data service.
        /// </summary>
        /// <value>The data service.</value>
        private IDataService DataService { get; }

        #endregion

        #region  -- Constructor -- 

        /// <summary>
        /// Initializes a new instance of the <see cref="SpecialityController" /> class.
        /// </summary>
        /// <param name="applicationServices">Application Services</param>
        /// <param name="dataService">The data service.</param>
        public SpecialityController(ApplicationServices applicationServices, IDataService dataService) : base(
            applicationServices)
        {
            DataService = dataService;
        }

        #endregion

        #region -- GET Methods --

        /// <summary>
        /// Gets the specialities.
        /// </summary>
        /// <returns>IActionResult.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<SpecialityDropdown>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetSpecialities()
        {
            var specialityList = await DataService.GetSpecialityInformation()
                .ToListAsync();

            return Ok(specialityList);
        }


        /// <summary>
        /// Gets the speciality by identifier.
        /// </summary>
        /// <param name="specialityID">The speciality identifier.</param>
        /// <returns>IActionResult.</returns>
        [HttpGet("{specialityID}")]
        [ProducesResponseType(typeof(SpecialityDropdown), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetSpecialityByID(int specialityID)
        {
            var speciality = await DataService.GetSpecialityInformation()
                .SingleOrDefaultAsync(s => s.SpecialtyID == specialityID);

            return Ok(speciality);
        }

        #endregion


    }
}
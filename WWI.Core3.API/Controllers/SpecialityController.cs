// ***********************************************************************
// Assembly         : WWI.Core3.API
// Author           : Mustafizur Rohman
// Created          : 05-17-2020
//
// Last Modified By : Mustafizur Rohman
// Last Modified On : 05-17-2020
// ***********************************************************************
// <copyright file="SpecialityController.cs" company="WWI.Core3.API">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Linq;
using System.Threading.Tasks;
using WWI.Core3.API.Controllers.Base;
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
        public async Task<IActionResult> GetSpecialities()
        {
            Log.Information("Retrieved list of specialities");

            var specialityList = await DbContext.Specialities
                .Select(s => s.Name)
                .OrderBy(s => s)
                .AsNoTracking()
                .ToListAsync();

            return Ok(specialityList);
        }

        #endregion


    }
}
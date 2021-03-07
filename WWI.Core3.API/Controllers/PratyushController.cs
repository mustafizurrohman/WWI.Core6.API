// ***********************************************************************
// Assembly         : WWI.Core3.API
// Author           : Mustafizur Rohman
// Created          : 07-12-2020
//
// Last Modified By : Mustafizur Rohman
// Last Modified On : 07-12-2020
// ***********************************************************************
// <copyright file="PratyushController.cs" company="WWI.Core3.API">
//     Copyright (c) Personal. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WWI.Core3.API.Controllers.Base;
using WWI.Core3.Services.ServiceCollection;

namespace WWI.Core3.API.Controllers
{

    /// <summary>
    /// Class PratyushController.
    /// Implements the <see cref="BaseAPIController" />
    /// </summary>
    /// <seealso cref="BaseAPIController" />
    public class PratyushController : BaseAPIController
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="PratyushController"/> class.
        /// </summary>
        public PratyushController(IApplicationServices applicationServices) : base(applicationServices)
        {

        }

        /// <summary>
        /// Tests this instance.
        /// </summary>
        /// <returns>Task&lt;IActionResult&gt;.</returns>
        [HttpGet("Test")]
        public async Task<IActionResult> TestAsync()
        {
            var doctors = await DbContext
                .Doctors
                .Select(doc => doc.Firstname)
                .ToListAsync();

            return Ok(doctors);
        }

    }
}

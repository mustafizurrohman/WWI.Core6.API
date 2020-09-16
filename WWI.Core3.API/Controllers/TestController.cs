// ***********************************************************************
// Assembly         : WWI.Core3.API
// Author           : Mustafizur Rohman
// Created          : 09-13-2020
//
// Last Modified By : Mustafizur Rohman
// Last Modified On : 09-13-2020
// ***********************************************************************
// <copyright file="TestController.cs" company="WWI.Core3.API">
//     Copyright (c) Personal. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************


using Microsoft.AspNetCore.Mvc;
using System;
using WWI.Core3.API.Controllers.Base;
using WWI.Core3.Services.ServiceCollection;

namespace WWI.Core3.API.Controllers
{
    /// <summary>
    /// Class TestController.
    /// </summary>
    public class TestController : BaseAPIController
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="TestController"/> class.
        /// </summary>
        /// <param name="applicationServices">The database context.</param>
        public TestController(IApplicationServices applicationServices) : base(applicationServices)
        {
        }

        /// <summary>
        /// Test123s this instance.
        /// </summary>
        /// <returns>IActionResult.</returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpGet]
        public IActionResult Test123()
        {
            throw new NotImplementedException();
        }


    }

}

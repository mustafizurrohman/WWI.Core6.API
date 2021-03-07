// ***********************************************************************
// Assembly         : WWI.Core3.API
// Author           : Mustafizur Rohman
// Created          : 10-26-2020
//
// Last Modified By : Mustafizur Rohman
// Last Modified On : 10-26-2020
// ***********************************************************************
// <copyright file="TestController.cs" company="WWI.Core3.API">
//     Copyright (c) Personal. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WWI.Core3.API.Controllers.Base;
using WWI.Core3.Core.Helpers;
using WWI.Core3.Services.ServiceCollection;

namespace WWI.Core3.API.Controllers
{
    /// <summary>
    /// Class TestController.
    /// </summary>
    public class TestController : BaseAPIController
    {

        public TestController(ApplicationServices applicationServices) : base(
            applicationServices)
        {

        }

        [HttpGet]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IActionResult Test()
        {
            var clock = new Clock();
            var start = clock.UtcNow;

            var end = clock.UtcNow;

            var time = (end - start).TotalMilliseconds;

            return Ok(time);

        }


    }
}

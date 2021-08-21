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
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WWI.Core3.API.Controllers.Base;
using WWI.Core3.Core.ExtensionMethods;
using WWI.Core3.Services.Interfaces;
using WWI.Core3.Services.ServiceCollection;

namespace WWI.Core3.API.Controllers
{
    /// <summary>
    /// Class TestController.
    /// </summary>
    public class TestController : BaseAPIController
    {

        private readonly IHTMLFormatterService _htmlFormatter;

        /// <summary>
        /// Initializes a new instance of the <see cref="TestController"/> class.
        /// </summary>
        /// <param name="applicationServices">The database context.</param>
        public TestController(IApplicationServices applicationServices, IHTMLFormatterService htmlFormatterService) : base(applicationServices)
        {
            _htmlFormatter = htmlFormatterService;
        }

        /// <summary>
        /// Test123s this instance.
        /// </summary>
        /// <returns>IActionResult.</returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpGet]
        public IActionResult Test123()
        {
            List<int> list = null;

            var isEmpty = list.IsEmpty();

            return Ok(isEmpty);
        }

        /// <summary>
        /// Gets the HTML.
        /// </summary>
        /// <returns>IActionResult.</returns>
        [HttpGet("html")]
        public async Task<IActionResult> GetHtml()
        {
            var doctors = await DbContext
                .Doctors
                .Include(doc => doc.Speciality)
                .Include(doc => doc.Hospitals)
                .Select(doc => new
                {
                    Name = doc.Firstname + " " + doc.Lastname,
                    Speciality = doc.Speciality.Name,
                    Hospitals = doc.Hospitals.Count
                })
                .OrderBy(doc => doc.Speciality)
                .ThenBy(doc => doc.Name)
                .ToListAsync();
            
            var bytes = _htmlFormatter.FormatAsHTMLTable(doctors);
            
            return File(bytes, "application/octet-stream", "doctors.html");
        }


    }

}

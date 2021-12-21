// ***********************************************************************
// Assembly         : WWI.Core6.API
// Author           : Mustafizur Rohman
// Created          : 09-13-2020
//
// Last Modified By : Mustafizur Rohman
// Last Modified On : 09-13-2020
// ***********************************************************************
// <copyright file="TestController.cs" company="WWI.Core6.API">
//     Copyright (c) Personal. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************


using Humanizer;
using Microsoft.EntityFrameworkCore;
using WWI.Core6.Core.ExtensionMethods;
using WWI.Core6.Services.Interfaces;

namespace WWI.Core6.API.Controllers.Demos
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
        /// <param name="htmlFormatterService"></param>
        public TestController(IApplicationServices applicationServices, IHTMLFormatterService htmlFormatterService) 
            : base(applicationServices)
        {
            _htmlFormatter = Guard.Against.Null(htmlFormatterService, nameof(htmlFormatterService));
        }

        /// <summary>
        /// Test123s this instance.
        /// </summary>
        /// <returns>IActionResult.</returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpGet("enumerable")]
        public IActionResult TesteEnumerableIsEmpty()
        {
            List<int> list = null;

            // ReSharper disable once ExpressionIsAlwaysNull
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

            var hospitals = await DbContext
                .Hospitals
                .OrderBy(hos => hos.Name)
                .Select(hos => new
                {
                    hos.Name,
                    Address = hos.Address.ToString()
                })
                .ToListAsync();

            var tableDoctorBody = _htmlFormatter.FormatAsHtmlTable(doctors);
            var tableHospitalBody = _htmlFormatter.FormatAsHtmlTable(hospitals); 

            var body = tableDoctorBody + "<br><br>" + tableHospitalBody;

            var htmlDocument = _htmlFormatter.GenerateHtmlDocument(body);
            
            return File(htmlDocument.ToByteArray(), "application/octet-stream", "doctors.html");
        }

        /// <summary>
        /// Tests the guard clauses.
        /// </summary>
        /// <param name="positiveNunmber">The positive nunmber.</param>
        /// <param name="negativeNumber">The negative number.</param>
        /// <param name="notZero">The not zero.</param>
        /// <returns>IActionResult.</returns>
        [HttpGet("guard")]
        public IActionResult TestGuardClauses(int positiveNunmber, int negativeNumber, int notZero)
        {
            var pn = Guard.Against.Negative(positiveNunmber, nameof(positiveNunmber));
            var zr = Guard.Against.Zero(notZero, nameof(notZero));

            return Ok();
        }

        /// <summary>
        /// Tests the humanizer.
        /// </summary>
        /// <returns>IActionResult.</returns>
        [HttpGet("humanizer")]
        public IActionResult TestHumanizer(int num)
        {
            var time = DateTime.Now.AddMinutes(num).Humanize();

            return Ok(time);
        }

    }

}

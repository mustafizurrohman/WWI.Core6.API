// ***********************************************************************
// Assembly         : WWI.Core3.API
// Author           : Mustafizur Rohman
// Created          : 05-17-2020
//
// Last Modified By : Mustafizur Rohman
// Last Modified On : 05-17-2020
// ***********************************************************************
// <copyright file="DoctorController.cs" company="WWI.Core3.API">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WWI.Core3.API.Controllers.Base;
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
        /// Initializes a new instance of the <see cref="DoctorController"/> class.
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
        public async Task<IActionResult> GetDoctors()
        {
            Log.Information("Retrieved list of all doctors");

            var doctors = (await DbContext.Doctors
                    .Include(doc => doc.Speciality)
                    .Select(doc => new
                    {
                        Name = Regex.Replace(doc.Firstname + " " + doc.Middlename + " " + doc.Lastname, @"\s+", " "),
                        Speciality = doc.Speciality.Name
                    })
                    .AsNoTracking()
                    .ToListAsync())
                .OrderBy(doc => doc.Speciality)
                .ThenBy(doc => doc.Name)
                .Select(doc => doc.Name + " (" + doc.Speciality + ")")
                .ToList();

            return Ok(doctors);
        }


        /// <summary>
        /// Gets Doctors by speciality.
        /// </summary>
        /// <param name="specialityID">The speciality identifier.</param>
        /// <returns>IActionResult.</returns>
        [HttpGet("{specialityID}")]
        public async Task<IActionResult> DoctorsBySpeciality(int specialityID)
        {
            var doctors = (await DbContext.Doctors
                    .Include(doc => doc.Speciality)
                    .Where(doc => doc.SpecialityID == specialityID)
                    .AsNoTracking()
                    .ToListAsync())
                .Select(doc => new
                {
                    Name = doc.FullName,
                    Speciality = doc.Speciality.Name
                })
                .OrderBy(doc => doc.Speciality)
                .ThenBy(doc => doc.Name)
                .ToList();

            var speciality = doctors.FirstOrDefault()?.Speciality ?? "None";
            Log.Information($"Retrieved list of doctors for '{speciality}'.");

            return Ok(doctors);
        }

        #endregion

    }
}
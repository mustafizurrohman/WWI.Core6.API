// ***********************************************************************
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

using Ardalis.GuardClauses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WWI.Core3.API.Controllers.Base;
using WWI.Core3.Models.ViewModels;
using WWI.Core3.Services.MediatR.Commands;
using WWI.Core3.Services.MediatR.Queries;
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
        private  IMediator Mediator { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DoctorController" /> class.
        /// </summary>
        /// <param name="applicationServices">The application services.</param>
        /// <param name="mediator"></param>
        public DoctorController(IApplicationServices applicationServices, IMediator mediator) 
            : base(applicationServices)
        {
            Mediator = Guard.Against.Null(mediator, nameof(mediator));
        }

        
        /// <summary>
        /// Gets the doctors.
        /// </summary>
        /// <returns>IActionResult.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<Dropdown>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetDoctors(CancellationToken cancellationToken)
        {
            var query = new GetAllDoctorsQuery();
            var doctors = await Mediator.Send(query, cancellationToken);

            return Ok(doctors);
        }


        /// <summary>
        /// Gets Doctors by specialty.
        /// </summary>
        /// <param name="specialityID">The specialty identifier.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>IActionResult.</returns>
        [HttpGet("speciality/{specialityID}")]
        [ProducesResponseType(typeof(List<Dropdown>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DoctorsBySpecialty(int specialityID, CancellationToken cancellationToken)
        {
            var query = new GetDoctorsBySpecialityQuery(specialityID);
            var doctors = await Mediator.Send(query, cancellationToken);

            return Ok(doctors);
        }


        /// <summary>
        /// Doctors the by hospital.
        /// </summary>
        /// <param name="hospitalID">The hospital identifier.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>IActionResult.</returns>
        [HttpGet("hospital/{hospitalID}")]
        [ProducesResponseType(typeof(List<Dropdown>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DoctorsByHospital(int hospitalID, CancellationToken cancellationToken)
        {
            var query = new GetDoctorByHospitalQuery(hospitalID);
            var doctors = await Mediator.Send(query, cancellationToken);

            return Ok(doctors);
        }

        /// <summary>
        /// add doctor as an asynchronous operation.
        /// </summary>
        /// <param name="doctor">The doctor.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>IActionResult.</returns>
        [HttpPut]
        public async Task<IActionResult> AddDoctorAsync(CreateDoctorCommand doctor, CancellationToken cancellationToken)
        {
            var doctorInfo = await Mediator.Send(doctor, cancellationToken);
            return Ok(doctorInfo); 
        }

    }
}
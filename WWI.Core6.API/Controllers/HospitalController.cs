// ***********************************************************************
// Assembly         : WWI.Core3.API
// Author           : Mustafizur Rohman
// Created          : 05-17-2020
//
// Last Modified By : Mustafizur Rohman
// Last Modified On : 05-19-2020
// ***********************************************************************
// <copyright file="HospitalController.cs" company="WWI.Core3.API">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using Microsoft.AspNetCore.Http;
using WWI.Core6.API.Controllers.Base;
using WWI.Core6.Models.ViewModels;
using WWI.Core6.Services.MediatR.Queries;
using WWI.Core6.Services.ServiceCollection;

namespace WWI.Core6.API.Controllers
{

    /// <summary>
    /// Class HospitalController.
    /// Implements the <see cref="BaseAPIController" />
    /// </summary>
    /// <seealso cref="BaseAPIController" />
    public class HospitalController : BaseAPIController
    {
        private  IMediator Mediator { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="HospitalController" /> class.
        /// </summary>
        /// <param name="applicationServices">Application Services</param>
        /// <param name="mediator"></param>
        public HospitalController(IApplicationServices applicationServices, IMediator mediator) 
            : base(applicationServices)
        {
            Mediator = Guard.Against.Null(mediator, nameof(mediator));
        }

        /// <summary>
        /// Gets the hospitals.
        /// </summary>
        /// <returns>IActionResult.</returns>
        [HttpGet("dropdown")]
        [ProducesResponseType(typeof(List<Dropdown>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetHospitals(CancellationToken cancellationToken)
        {
            var query = new GetAllHospitalsQuery();
            var hospitals = await Mediator.Send(query, cancellationToken);
            
            return Ok(hospitals);
        }


        /// <summary>
        /// Gets the hospital by identifier.
        /// </summary>
        /// <param name="hospitalID">The hospital identifier.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>IActionResult.</returns>
        [HttpGet("{hospitalID}/details")]
        [ProducesResponseType(typeof(HospitalInformation), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetHospitalById(int hospitalID, CancellationToken cancellationToken)
        {
            var query = new GetHospitalInformationQuery(hospitalID);
            var hospital = await Mediator.Send(query, cancellationToken);

            return Ok(hospital);
        }

        /// <summary>
        /// Gets the hospital information by identifier.
        /// </summary>
        /// <param name="hospitalID">The hospital identifier.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>IActionResult.</returns>
        [HttpGet("{hospitalID}/details/advanced")]
        [ProducesResponseType(typeof(AdvancedHospitalInformation), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetHospitalInfoById(int hospitalID, CancellationToken cancellationToken)
        {
            var query = new GetAdvancedHospitalInformationQuery(hospitalID);
            var advancedHospitalInformation = await Mediator.Send(query, cancellationToken);

            return Ok(advancedHospitalInformation);
        }


        /// <summary>
        /// Gets the doctors for hospital by identifier.
        /// </summary>
        /// <param name="hospitalID">The identifier.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>IActionResult.</returns>
        [HttpGet("{hospitalID}/doctors")]
        [ProducesResponseType(typeof(HospitalDoctorInformation), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetDoctorsForHospitalById(int hospitalID, CancellationToken cancellationToken)
        {
            var query = new GetDoctorsForHospitalQuery(hospitalID);
            var doctorsInHospital = await Mediator.Send(query, cancellationToken);

            return Ok(doctorsInHospital);
        }


        /// <summary>
        /// Gets the speciality information for hospital.
        /// </summary>
        /// <param name="hospitalID">The hospital identifier.</param>
        /// <param name="specialityID">The speciality identifier.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>IActionResult.</returns>
        [HttpGet("{hospitalID}/specialities/{specialityID}")]
        [ProducesResponseType(typeof(SpecialityInformation), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetSpecialityInfoForHospital(int hospitalID, int specialityID, CancellationToken cancellationToken)
        {
            var query = new GetSpecialityInfoForHospitalQuery(hospitalID, specialityID);
            var specialityInformation = await Mediator.Send(query, cancellationToken);

            return Ok(specialityInformation);
        }

        /// <summary>
        /// Gets the speciality information for hospital.
        /// </summary>
        /// <param name="hospitalID">The hospital identifier.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>IActionResult.</returns>
        [HttpGet("{hospitalID}/specialities/")]
        [ProducesResponseType(typeof(List<SpecialityInformation>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetSpecialitiesForHospital(int hospitalID, CancellationToken cancellationToken)
        {
            var query = new GetSpecialitiesForHospitalQuery(hospitalID);
            var specialityInformation = await Mediator.Send(query, cancellationToken);
                
            return Ok(specialityInformation);
        }

        /// <summary>
        /// Gets the speciality information for hospital.
        /// </summary>
        /// <param name="hospitalID">The hospital identifier.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>IActionResult.</returns>
        [HttpGet("{hospitalID}/specialities/dropdown")]
        [ProducesResponseType(typeof(List<Dropdown>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetSpecialitiesDropdownForHospital(int hospitalID, CancellationToken cancellationToken)
        {
            var query = new GetSpecialitiesDropdownForHospitalQuery(hospitalID);
            var specialityInformation = await Mediator.Send(query, cancellationToken);
            
            return Ok(specialityInformation);
        }

    }
}
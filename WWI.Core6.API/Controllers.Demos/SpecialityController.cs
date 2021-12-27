// ***********************************************************************
// Assembly         : WWI.Core6.API
// Author           : Mustafizur Rohman
// Created          : 05-17-2020
//
// Last Modified By : Mustafizur Rohman
// Last Modified On : 05-19-2020
// ***********************************************************************
// <copyright file="SpecialityController.cs" company="WWI.Core6.API">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace WWI.Core6.API.Controllers.Demos;

/// <summary>
/// Class SpecialityController.
/// Implements the <see cref="BaseAPIController" />
/// </summary>
/// <seealso cref="BaseAPIController" />
public class SpecialityController : BaseAPIController
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SpecialityController" /> class.
    /// </summary>
    /// <param name="applicationServices">Application Services</param>
    /// <param name="mediator"></param>
    public SpecialityController(IApplicationServices applicationServices, IMediator mediator)
        : base(applicationServices, mediator)
    {

    }

    /// <summary>
    /// Gets the specialities.
    /// </summary>
    /// <returns>IActionResult.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(List<Dropdown>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetSpecialities(CancellationToken cancellationToken)
    {
        var query = new GetAllSpecialitiesDropdownQuery();
        var specialityList = await Mediator.Send(query, cancellationToken);

        return Ok(specialityList);
    }


    /// <summary>
    /// Gets the speciality by identifier.
    /// </summary>
    /// <param name="specialityID">The speciality identifier.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>IActionResult.</returns>
    [HttpGet("{specialityID}")]
    [ProducesResponseType(typeof(Dropdown), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetSpecialityByID(int specialityID, CancellationToken cancellationToken)
    {
        var query = new GetSpecialityInformationByIDQuery(specialityID);
        var speciality = await Mediator.Send(query, cancellationToken);

        return Ok(speciality);
    }

    /// <summary>
    /// Gets the doctors for speciality by identifier.
    /// </summary>
    /// <param name="specialityID">The speciality identifier.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>IActionResult.</returns>
    [HttpGet("{specialityID}/doctor")]
    [ProducesResponseType(typeof(List<Dropdown>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetDoctorsForSpecialityByID(int specialityID, CancellationToken cancellationToken)
    {
        var query = new GetDoctorsForSpecialityByIDQuery(specialityID);
        var doctors = await Mediator.Send(query, cancellationToken);

        return Ok(doctors);
    }


    /// <summary>
    /// Gets the hospitals with speciality by a speciality identifier.
    /// </summary>
    /// <param name="specialityID">The speciality identifier.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>IActionResult.</returns>
    [HttpGet("{specialityID}/hospital")]
    [ProducesResponseType(typeof(List<Dropdown>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetHospitalsForSpecialityByID(int specialityID, CancellationToken cancellationToken)
    {
        var query = new GetHospitalsForSpecialityByIDQuery(specialityID);
        var hospitals = await Mediator.Send(query, cancellationToken);

        return Ok(hospitals);
    }
}
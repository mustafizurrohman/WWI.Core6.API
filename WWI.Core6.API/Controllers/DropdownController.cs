using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace WWI.Core6.API.Controllers;

/// <summary>
/// 
/// </summary>
[ProducesResponseType(typeof(List<Dropdown>), StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status204NoContent)]
public class DropdownController : BaseAPIController
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="applicationServices"></param>
    /// <param name="mediator"></param>
    public DropdownController(IApplicationServices applicationServices, IMediator mediator)
        : base(applicationServices, mediator)
    {
    }

    /// <summary>
    /// Gets the hospitals.
    /// </summary>
    /// <returns>IActionResult.</returns>
    [HttpGet("doctors")]
    public async Task<IActionResult> GetAllDoctorsAsync(CancellationToken cancellationToken)
    {
        var doctors = await Mediator.Send(new GetAllDoctorsQuery(), cancellationToken); 
        return Ok(doctors);
    }

    /// <summary>
    /// Gets the hospitals.
    /// </summary>
    /// <returns>IActionResult.</returns>
    [HttpGet("hospitals")]
    public async Task<IActionResult> GetAllHospitalsAsync(CancellationToken cancellationToken)
    {
        var hospitals = await Mediator.Send(new GetAllHospitalsQuery(), cancellationToken);
        return Ok(hospitals);
    }

    /// <summary>
    /// Gets the specialities
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("specialities")]
    public async Task<IActionResult> GetAllSpecialities(CancellationToken cancellationToken)
    {
        var specialities = await DbContext
            .Specialities
            .ProjectTo<Dropdown>(AutoMapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return Ok(specialities);
    }

}
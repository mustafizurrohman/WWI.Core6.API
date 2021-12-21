using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace WWI.Core6.API.Controllers
{
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
        private  IMediator Mediator { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicationServices"></param>
        /// <param name="mediator"></param>
        public DropdownController(IApplicationServices applicationServices, IMediator mediator)
            : base(applicationServices)
        {
            Mediator = Guard.Against.Null(mediator, nameof(mediator));
        }

        /// <summary>
        /// Gets the hospitals.
        /// </summary>
        /// <returns>IActionResult.</returns>
        [HttpGet("doctors")]
        public async Task<IActionResult> GetAllDoctorsAsync(CancellationToken cancellationToken)
        {
            var doctors = await DbContext
                .Doctors
                .OrderBy(doc => doc.Lastname)
                .ThenBy(doc => doc.Firstname)
                .ProjectTo<Dropdown>(AutoMapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            
            return Ok(doctors);
        }

        /// <summary>
        /// Gets the hospitals.
        /// </summary>
        /// <returns>IActionResult.</returns>
        [HttpGet("hospitals")]
        public async Task<IActionResult> GetAllHospitalsAsync(CancellationToken cancellationToken)
        {
            var query = new GetAllHospitalsQuery();
            var hospitals = await Mediator.Send(query, cancellationToken);
            
            return Ok(hospitals);
        }

    }
}

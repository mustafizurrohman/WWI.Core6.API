using Microsoft.AspNetCore.Mvc;
using WWI.Core3.Models.DatabaseContext;

namespace WWI.Core3.API.Controllers.Base
{

    /// <summary>
    /// Base Controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class BaseAPIController : ControllerBase
    {

        /// <summary>
        /// The database context
        /// </summary>
        public DocAppointmentContext DbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseAPIController"/> class.
        /// </summary>
        /// <param name="docAppointmentContext">The database context.</param>
        public BaseAPIController(DocAppointmentContext docAppointmentContext)
        {
            DbContext = docAppointmentContext;
        }

    }
}

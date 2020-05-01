using Microsoft.AspNetCore.Mvc;
using WWI.Core3.Models.Models;

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
        public WideWorldImportersContext DbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseAPIController"/> class.
        /// </summary>
        /// <param name="wideWorldImportersContext">The wide world importers context.</param>
        public BaseAPIController(WideWorldImportersContext wideWorldImportersContext)
        {
            DbContext = wideWorldImportersContext;
        }

    }
}

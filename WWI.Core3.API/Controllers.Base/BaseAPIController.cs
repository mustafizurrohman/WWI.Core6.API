using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WWI.Core3.API.ActionFilters;
using WWI.Core3.Models.DbContext;
using WWI.Core3.Services.ServiceCollection;

namespace WWI.Core3.API.Controllers.Base
{

    /// <summary>
    /// Base API Controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiController]
    [Benchmark]
    [Route("[controller]")]
    [Produces("application/json")]
    public class BaseAPIController : ControllerBase
    {

        /// <summary>
        /// The database context
        /// </summary>
        public DocAppointmentContext DbContext { get; }

        /// <summary>
        /// AutoMapper
        /// </summary>
        public IMapper AutoMapper { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseAPIController"/> class.
        /// </summary>
        /// <param name="applicationServices">The database context.</param>
        public BaseAPIController(ApplicationServices applicationServices)
        {
            DbContext = applicationServices.DbContext;
            AutoMapper = applicationServices.AutoMapper;
        }



    }
}

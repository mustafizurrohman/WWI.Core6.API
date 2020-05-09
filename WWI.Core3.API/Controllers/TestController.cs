using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WWI.Core3.API.Controllers.Base;
using WWI.Core3.Models.DatabaseContext;

namespace WWI.Core3.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="WWI.Core3.API.Controllers.Base.BaseAPIController" />
    public class TestController : BaseAPIController
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="TestController"/> class.
        /// </summary>
        /// <param name="docAppointmentContext">The wide world importers context.</param>
        public TestController(DocAppointmentContext docAppointmentContext) : base(docAppointmentContext)
        {

        }

        /// <summary>
        /// Gets the specialities.
        /// </summary>
        /// <returns></returns>
        [HttpGet("specialities")]
        public async Task<IActionResult> GetSpecialities()
        {
            var specilities = await DbContext.Specialities
                .Select(s => s.Name)
                .OrderBy(s => s)
                .ToListAsync();

            return Ok(specilities);

        }


    }
}

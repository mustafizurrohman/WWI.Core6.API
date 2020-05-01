using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WWI.Core3.API.Controllers.Base;
using WWI.Core3.Models.Models;

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
        /// <param name="wideWorldImportersContext">The wide world importers context.</param>
        public TestController(WideWorldImportersContext wideWorldImportersContext) : base(wideWorldImportersContext)
        {

        }

        /// <summary>
        /// Gets the information.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetInfo()
        {
            var test = await DbContext.Colors.Take(10).ToListAsync();

            var task1 = DbContext.Colors.Skip(0).Take(10).ToListAsync();

            return Ok(test);
        }

    }
}

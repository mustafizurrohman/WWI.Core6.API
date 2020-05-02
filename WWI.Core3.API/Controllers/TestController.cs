using Microsoft.AspNetCore.Mvc;
using System;
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
        /// Exceptions the specified number.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">
        /// number
        /// or
        /// number
        /// or
        /// number
        /// </exception>
        [HttpGet("ex")]
        public IActionResult Exception(int number = 0)
        {
            if (number <= 0)
            {
                throw new ArgumentException(nameof(number) + " must be positive");
            }
            if (number % 2 == 0)
            {
                throw new ArgumentException(nameof(number) + " must be even");
            }
            if (number % 2 == 1)
            {
                throw new ArgumentException(nameof(number) + " must be odd");
            }

            return Ok();
        }

    }
}

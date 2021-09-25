using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WWI.Core3.API.Controllers.Base;
using WWI.Core3.Services.Interfaces;
using WWI.Core3.Services.ServiceCollection;

namespace WWI.Core3.API.Controllers
{

    /// <summary>
    /// Class BogusController.
    /// Implements the <see cref="WWI.Core3.API.Controllers.Base.BaseAPIController" />
    /// </summary>
    /// <seealso cref="WWI.Core3.API.Controllers.Base.BaseAPIController" />
    public class BogusController : BaseAPIController
    {
        private IFakeDataGeneratorService FakeDataGeneratorService{ get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BogusController"/> class.
        /// </summary>
        /// <param name="applicationServices">The application services.</param>
        /// <param name="fakeDataGeneratorService">The fake data generator service.</param>
        public BogusController(IApplicationServices applicationServices, IFakeDataGeneratorService fakeDataGeneratorService)
            : base(applicationServices)
        {
            this.FakeDataGeneratorService = Guard.Against.Null(fakeDataGeneratorService, nameof(fakeDataGeneratorService));
        }

        /// <summary>
        /// Generates the fake doctors.
        /// </summary>
        /// <param name="num">The number.</param>
        /// <returns>IActionResult.</returns>
        [HttpGet("doctors")]
        public IActionResult GenerateFakeDoctors(int num)
        {
            num = Guard.Against.NegativeOrZero(num, nameof(num));

            var generatedFakeDoctors = FakeDataGeneratorService.GenerateFakeDoctors(num);
            
            return Ok(generatedFakeDoctors);
        }

        /// <summary>
        /// Generates the fake hospitals.
        /// </summary>
        /// <param name="num">The number.</param>
        /// <returns>IActionResult.</returns>
        [HttpGet("hospitals")]
        public IActionResult GenerateFakeHospitals(int num)
        {
            num = Guard.Against.NegativeOrZero(num, nameof(num));

            var generatedFakeHopistals = FakeDataGeneratorService.GenerateFakeHospitals(num);
            
            return Ok(generatedFakeHopistals);
        }

        /// <summary>
        /// Generates the fake addresses.
        /// </summary>
        /// <param name="num">The number.</param>
        /// <returns>IActionResult.</returns>
        [HttpGet("address")]
        public IActionResult GenerateFakeaddress(int num)
        {
            num = Guard.Against.NegativeOrZero(num, nameof(num));

            var generatedFakeAddress = FakeDataGeneratorService.GenerateFakeAddress(num)
                .Select(addr => addr.ToString());

            return Ok(generatedFakeAddress);
        }

    }
}

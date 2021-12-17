using WWI.Core3.API.Controllers.Base;
using WWI.Core3.Models.Models;
using WWI.Core3.Models.ViewModels;
using WWI.Core3.Services.Interfaces;
using WWI.Core3.Services.ServiceCollection;

namespace WWI.Core3.API.Controllers
{

    /// <summary>
    /// Class BogusController.
    /// Implements the <see cref="BaseAPIController" />
    /// </summary>
    /// <seealso cref="BaseAPIController" />
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
            FakeDataGeneratorService = Guard.Against.Null(fakeDataGeneratorService, nameof(fakeDataGeneratorService));
        }

        /// <summary>
        /// Generates the fake doctors.
        /// </summary>
        /// <param name="num">The number.</param>
        /// <returns>IActionResult.</returns>
        [HttpGet("doctors")]
        public IActionResult GenerateFakeDoctors(int num)
        {
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
            var generatedFakeHopistals = FakeDataGeneratorService.GenerateFakeHospitals(num);
            
            return Ok(generatedFakeHopistals);
        }

        /// <summary>
        /// Generates the fake addresses.
        /// </summary>
        /// <param name="num">The number.</param>
        /// <returns>IActionResult.</returns>
        [HttpGet("address")]
        public IActionResult GenerateFakeAddress(int num)
        {
            var generatedFakeAddress = FakeDataGeneratorService.GenerateFakeAddress(num)
                .Select(addr => addr.ToString());

            return Ok(generatedFakeAddress);
        }

        /// <summary>
        /// Generates the fake specialities.
        /// </summary>
        /// <param name="num">The number.</param>
        /// <returns>IActionResult.</returns>
        [HttpGet("specialities")]
        public IActionResult GenerateFakeSpecialities(int num)
        {
            var generatedFakeSpecialities = FakeDataGeneratorService.GenerateFakeSpecialities(num);

            var mapped = AutoMapper.Map<IEnumerable<Speciality>, List<Dropdown>>(generatedFakeSpecialities);

            return Ok(mapped);
        }

    }
}

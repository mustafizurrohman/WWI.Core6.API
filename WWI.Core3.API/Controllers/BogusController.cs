using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WWI.Core3.API.Controllers.Base;
using WWI.Core3.Models.Models;
using WWI.Core3.Models.ViewModels;
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
            this.FakeDataGeneratorService = fakeDataGeneratorService;
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
            
            var mappedDoctors = AutoMapper.Map<List<Doctor>, List<Dropdown>>(generatedFakeDoctors.ToList())
                .Select(doc => doc.DisplayValue);
                
            return Ok(mappedDoctors);
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

    }
}

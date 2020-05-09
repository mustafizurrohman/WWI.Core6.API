using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WWI.Core3.API.Controllers.Base;
using WWI.Core3.Models.DatabaseContext;

namespace WWI.Core3.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="WWI.Core3.API.Controllers.Base.BaseAPIController" />
    public class DataController : BaseAPIController
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="DataController"/> class.
        /// </summary>
        /// <param name="docAppointmentContext">The wide world importers context.</param>
        public DataController(DocAppointmentContext docAppointmentContext) : base(docAppointmentContext)
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
                .AsNoTracking()
                .ToListAsync();

            Log.Information("Retrieved list of specialities");

            return Ok(specilities);

        }

        /// <summary>
        /// Gets the doctors.
        /// </summary>
        /// <returns></returns>
        [HttpGet("doctors")]
        public async Task<IActionResult> GetDoctors()
        {
            var doctors = (await DbContext.Doctors
                .Include(doc => doc.Speciality)
                .Select(doc => new
                {
                    Name = Regex.Replace(doc.Firstname + " " + doc.Middlename + " " + doc.Lastname, @"\s+", " "),
                    Speciality = doc.Speciality.Name
                })
                .AsNoTracking()
                .ToListAsync())
                .OrderBy(doc => doc.Speciality)
                .ThenBy(doc => doc.Name)
                .ToList();

            return Ok(doctors);
        }

        /// <summary>
        /// Gets Doctors by speciality.
        /// </summary>
        /// <param name="specialityID">The speciality identifier.</param>
        /// <returns></returns>
        [HttpGet("doctors/{specialityID}")]
        public async Task<IActionResult> DoctorsBySpeciality(int specialityID)
        {
            var doctors = (await DbContext.Doctors
                .Include(doc => doc.Speciality)
                .Where(doc => doc.SpecialityID == specialityID)
                .AsNoTracking()
                .ToListAsync())
                .Select(doc => new
                {
                    Name = Regex.Replace(doc.Firstname + " " + doc.Middlename + " " + doc.Lastname, @"\s+", " "),
                    Speciality = doc.Speciality.Name
                })
                .OrderBy(doc => doc.Speciality)
                .ThenBy(doc => doc.Name)
                .ToList();

            return Ok(doctors);
        }


    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WWI.Core3.API.Controllers.Base;
using WWI.Core3.Models.DbContext;

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
            Log.Information("Retrieved list of specialities");

            var specialityList = await DbContext.Specialities
                .Select(s => s.Name)
                .OrderBy(s => s)
                .AsNoTracking()
                .ToListAsync();

            return Ok(specialityList);

        }

        /// <summary>
        /// Gets the doctors.
        /// </summary>
        /// <returns></returns>
        [HttpGet("doctors")]
        public async Task<IActionResult> GetDoctors()
        {
            Log.Information("Retrieved list of all doctors");

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
                .Select(doc => doc.Name + " (" + doc.Speciality + ")")
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
                    Name = doc.FullName,
                    Speciality = doc.Speciality.Name
                })
                .OrderBy(doc => doc.Speciality)
                .ThenBy(doc => doc.Name)
                .ToList();

            var speciality = doctors.FirstOrDefault()?.Speciality ?? "None";
            Log.Information($"Retrieved list of doctors for '{speciality}'.");

            return Ok(doctors);
        }

        /// <summary>
        /// Gets the hospitals.
        /// </summary>
        /// <returns></returns>
        [HttpGet("hospitals")]
        public async Task<IActionResult> GetHospitals()
        {
            var hospitals = await DbContext.Hospitals
                .ToListAsync();

            return Ok(hospitals);
        }

        /// <summary>
        /// Gets the hospital by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("hospitals/{id}")]
        public async Task<IActionResult> GetHospitalById(int id)
        {
            var hospital = await DbContext.Hospitals
                .Include(h => h.Specialities)
                .Select(hs => new
                {
                    HospitalID = hs.HospitalID,
                    HospitalName = hs.Name,
                    Specialities = hs.Specialities.Select(s => s.Speciality.Name).ToList()
                })
                .FirstOrDefaultAsync(hs => hs.HospitalID == id);

            return Ok(hospital);
        }

        /// <summary>
        /// Gets the doctors for hospital by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("hospitals/{id}/doctors")]
        public async Task<IActionResult> GetDoctorsForHospitalById(int id)
        {
            var doctorsInHospital = (await DbContext.Hospitals
                .Include(h => h.Doctors)
                .ThenInclude(h => h.Doctor)
                .ThenInclude(doc => doc.Speciality)
                .Where(h => h.HospitalID == id)
                .SelectMany(h => h.Doctors)
                .Select(hd => hd.Doctor)
                .Select(doc => new
                {
                    doc.FullName,
                    SpecialityName = doc.Speciality.Name
                })
                .ToListAsync())
                .OrderBy(doc => doc.SpecialityName)
                .ThenBy(doc => doc.FullName)
                .ToList();

            return Ok(doctorsInHospital);
        }




    }
}

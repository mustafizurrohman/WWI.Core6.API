using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WWI.Core3.Models.DbContext;
using WWI.Core3.Models.ViewModels;
using WWI.Core3.Services.Interfaces;
using WWI.Core3.Services.Services.Base;

namespace WWI.Core3.Services.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="WWI.Core3.Services.Services.Base.BaseService" />
    /// <seealso cref="WWI.Core3.Services.Interfaces.IDataService" />
    public class DataService : BaseService, IDataService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataService"/> class.
        /// </summary>
        /// <param name="docAppointmentContext">The database context.</param>
        /// <param name="autoMapper"></param>
        public DataService(DocAppointmentContext docAppointmentContext, IMapper autoMapper) : base(docAppointmentContext, autoMapper)
        {
        }

        public async Task<HospitalInformation> GetHospitalInformationByIDAsync(int hospitalID)
        {
            var hospitalInformation = await GetHospitalInformation()
                .SingleOrDefaultAsync(h => h.HospitalID == hospitalID);

            return hospitalInformation;
        }

        #region -- Private Methods --

        private IQueryable<HospitalInformation> GetHospitalInformation()
        {
            return DbContext.Hospitals
                .ProjectTo<HospitalInformation>(AutoMapper.ConfigurationProvider)
                .AsQueryable();
        }

        #endregion



    }
}
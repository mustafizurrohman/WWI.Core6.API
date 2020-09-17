// ***********************************************************************
// Assembly         : WWI.Core3.Services
// Author           : Mustafizur Rohman
// Created          : 05-15-2020
//
// Last Modified By : Mustafizur Rohman
// Last Modified On : 05-15-2020
// ***********************************************************************
// <copyright file="DataService.cs" company="WWI.Core3.Services">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WWI.Core3.Models.ViewModels;
using WWI.Core3.Services.Interfaces;
using WWI.Core3.Services.ServiceCollection;
using WWI.Core3.Services.Services.Base;

namespace WWI.Core3.Services.Services
{

    /// <summary>
    /// Class DataService.
    /// Implements the <see cref="WWI.Core3.Services.Services.Base.BaseService" />
    /// Implements the <see cref="WWI.Core3.Services.Interfaces.IDataService" />
    /// </summary>
    /// <seealso cref="WWI.Core3.Services.Services.Base.BaseService" />
    /// <seealso cref="WWI.Core3.Services.Interfaces.IDataService" />
    public class DataService : BaseService, IDataService
    {

        /// <summary>
        /// The shared service
        /// </summary>
        private ISharedService SharedService { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataService" /> class.
        /// </summary>
        /// <param name="applicationServices">Application Services</param>
        /// <param name="sharedService">Shared Service</param>
        public DataService(IApplicationServices applicationServices, ISharedService sharedService) : base(applicationServices)
        {
            SharedService = sharedService;
        }

        /// <summary>
        /// Gets the advanced hospital information.
        /// </summary>
        /// <param name="hospitalID">The hospital identifier.</param>
        /// <returns>Task&lt;AdvancedHospitalInformation&gt;.</returns>
        public async Task<AdvancedHospitalInformation> GetAdvancedHospitalInformationAsync(int hospitalID)
        {
            var advancedHospitalInformation = await DbContext.Hospitals
                .Where(hos => hos.HospitalID == hospitalID)
                .ProjectTo<AdvancedHospitalInformation>(AutoMapper.ConfigurationProvider)
                .SingleOrDefaultAsync();

            return advancedHospitalInformation;
        }

        /// <summary>
        /// Gets all speciality information for hospital.
        /// </summary>
        /// <param name="hospitalID">The hospital identifier.</param>
        /// <returns>Task&lt;IQueryable&lt;SpecialityInformation&gt;&gt;.</returns>
        public IQueryable<SpecialityInformation> GetAllSpecialityInfoForHospital(int hospitalID)
        {
            var specialityInformation = DbContext.Hospitals
                .Include(hos => hos.Specialities)
                .ThenInclude(hs => hs.Speciality)
                .Where(hos => hos.HospitalID == hospitalID)
                .SelectMany(hos => hos.Specialities.Select(h => h.Speciality))
                .ProjectTo<SpecialityInformation>(AutoMapper.ConfigurationProvider)
                .AsNoTracking();

            return specialityInformation;

        }


        /// <summary>
        /// Gets the doctors for hospital.
        /// </summary>
        /// <param name="hospitalID">The hospital identifier.</param>
        /// <returns>Task&lt;HospitalDoctorInformation&gt;.</returns>
        public async Task<HospitalDoctorInformation> GetDoctorsForHospitalAsync(int hospitalID)
        {
            var doctorsForHospital = await DbContext.Hospitals
                .Where(hos => hos.HospitalID == hospitalID)
                .ProjectTo<HospitalDoctorInformation>(AutoMapper.ConfigurationProvider)
                .SingleOrDefaultAsync();

            doctorsForHospital.Doctors = doctorsForHospital.Doctors
                .OrderBy(doc => doc.SpecialityName)
                .ThenBy(doc => doc.SpecialityName)
                .ToList();

            return doctorsForHospital;
        }

        /// <summary>
        /// Get hospital information by identifier as an asynchronous operation.
        /// </summary>
        /// <param name="hospitalID">The hospital identifier.</param>
        /// <returns>Task<HospitalInformation></HospitalInformation></returns>
        public async Task<HospitalInformation> GetHospitalInformationByIDAsync(int hospitalID)
        {
            var hospitalInformation = await SharedService.GetHospitalInformation()
                .SingleOrDefaultAsync(h => h.HospitalID == hospitalID);

            return hospitalInformation;
        }

        /// <summary>
        /// Gets the speciality information.
        /// </summary>
        /// <returns>IQueryable&lt;SpecialityDropdown&gt;.</returns>
        public IQueryable<Dropdown> GetSpecialityInformation()
        {
            var specialityQuery = DbContext.Specialities
                .ProjectTo<Dropdown>(AutoMapper.ConfigurationProvider)
                .OrderBy(s => s.DisplayValue)
                .AsNoTracking()
                .AsQueryable();

            return specialityQuery;
        }





    }
}
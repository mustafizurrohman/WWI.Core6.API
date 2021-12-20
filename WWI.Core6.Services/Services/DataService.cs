// ***********************************************************************
// Assembly         : WWI.Core6.Services
// Author           : Mustafizur Rohman
// Created          : 05-15-2020
//
// Last Modified By : Mustafizur Rohman
// Last Modified On : 05-15-2020
// ***********************************************************************
// <copyright file="DataService.cs" company="WWI.Core6.Services">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using WWI.Core6.Models.ViewModels;
using WWI.Core6.Services.Interfaces;
using WWI.Core6.Services.ServiceCollection;
using WWI.Core6.Services.Services.Base;

namespace WWI.Core6.Services.Services
{

    /// <summary>
    /// Class DataService.
    /// Implements the <see cref="BaseService" />
    /// Implements the <see cref="IDataService" />
    /// </summary>
    /// <seealso cref="BaseService" />
    /// <seealso cref="IDataService" />
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
            SharedService = Guard.Against.Null(sharedService, nameof(sharedService));
        }

        /// <summary>
        /// Gets the advanced hospital information.
        /// </summary>
        /// <param name="hospitalID">The hospital identifier.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Task&lt;AdvancedHospitalInformation&gt;.</returns>
        public async Task<AdvancedHospitalInformation> GetAdvancedHospitalInformationAsync(int hospitalID, CancellationToken cancellationToken)
        {
            var advancedHospitalInformation = await SharedService.GetAdvancedHospitalInformation()
                .SingleOrDefaultAsync(hos => hos.HospitalID == hospitalID, cancellationToken);

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
        /// <param name="cancellationToken"></param>
        /// <returns>Task&lt;HospitalDoctorInformation&gt;.</returns>
        public async Task<HospitalDoctorInformation> GetDoctorsForHospitalAsync(int hospitalID, CancellationToken cancellationToken)
        {
            var doctorsForHospital = await DbContext.Hospitals
                .Where(hos => hos.HospitalID == hospitalID)
                .ProjectTo<HospitalDoctorInformation>(AutoMapper.ConfigurationProvider)
                .SingleOrDefaultAsync(cancellationToken);

            if (doctorsForHospital is null)
                return null;

            doctorsForHospital.Doctors = doctorsForHospital.Doctors
                .OrderBy(doc => doc.SpecialityName)
                .ToList();

            return doctorsForHospital;
        }

        /// <summary>
        /// Get hospital information by identifier as an asynchronous operation.
        /// </summary>
        /// <param name="hospitalID">The hospital identifier.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Task<HospitalInformation></HospitalInformation></returns>
        public async Task<HospitalInformation> GetHospitalInformationByIDAsync(int hospitalID, CancellationToken cancellationToken)
        {
            var hospitalInformation = await SharedService.GetHospitalInformation()
                .SingleOrDefaultAsync(h => h.HospitalID == hospitalID, cancellationToken);

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
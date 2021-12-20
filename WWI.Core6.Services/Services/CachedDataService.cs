// ***********************************************************************
// Assembly         : WWI.Core6.Services
// Author           : Mustafizur Rohman
// Created          : 08-28-2021
//
// Last Modified By : Mustafizur Rohman
// Last Modified On : 08-28-2021
// ***********************************************************************
// <copyright file="CachedDataService.cs" company="WWI.Core6.Services">
//     Copyright (c) Personal. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using JetBrains.Annotations;
using Microsoft.Extensions.Caching.Memory;
using WWI.Core6.Models.ViewModels;
using WWI.Core6.Services.Interfaces;
using WWI.Core6.Services.ServiceCollection;
using WWI.Core6.Services.Services.Base;

// ReSharper disable InvertIf

namespace WWI.Core6.Services.Services
{
    /// <summary>
    /// Class CachedDataService.
    /// Implements the <see cref="BaseService" />
    /// Implements the <see cref="IDataService" />
    /// </summary>
    /// <seealso cref="BaseService" />
    /// <seealso cref="IDataService" />
    [UsedImplicitly]
    public class CachedDataService : BaseService, IDataService
    {
        #region -- Private -- 

        /// <summary>
        /// Gets the memory cache.
        /// </summary>
        /// <value>The memory cache.</value>
        private IMemoryCache MemoryCache { get; }

        /// <summary>
        /// Gets the data service.
        /// </summary>
        /// <value>The data service.</value>
        private IDataService DataService { get;  }

        /// <summary>
        /// Gets the memory cache entry options.
        /// </summary>
        /// <value>The memory cache entry options.</value>
        private MemoryCacheEntryOptions MemoryCacheEntryOptions { get; }


        #endregion

        
        /// <summary>
        /// Initializes a new instance of the <see cref="CachedDataService"/> class.
        /// </summary>
        /// <param name="applicationServices">The application services.</param>
        /// <param name="memoryCache">The memory cache.</param>
        /// <param name="dataService">The data service.</param>
        public CachedDataService(IApplicationServices applicationServices, IMemoryCache memoryCache, IDataService dataService) 
            : base(applicationServices)
        {
            MemoryCacheEntryOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromHours(1));

            MemoryCache = Guard.Against.Null(memoryCache, nameof(memoryCache));
            DataService = Guard.Against.Null(dataService, nameof(dataService));
        }

        /// <summary>
        /// get hospital information by identifier as an asynchronous operation.
        /// </summary>
        /// <param name="hospitalID">The hospital identifier.</param>
        /// <returns>Task&lt;HospitalInformation&gt;.</returns>
        public async Task<HospitalInformation> GetHospitalInformationByIDAsync(int hospitalID, CancellationToken cancellationToken)
        {
            var cacheKey = GetHospitalInformationByIDCacheKey(hospitalID);

            if (!MemoryCache.TryGetValue(cacheKey, out HospitalInformation hospitalInformation))
            {
                hospitalInformation = await DataService.GetHospitalInformationByIDAsync(hospitalID, cancellationToken);
                SetMemoryCache(cacheKey, hospitalInformation);
            }

            return hospitalInformation;
        }

        /// <summary>
        /// get advanced hospital information as an asynchronous operation.
        /// </summary>
        /// <param name="hospitalID">The hospital identifier.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Task&lt;AdvancedHospitalInformation&gt;.</returns>
        public async Task<AdvancedHospitalInformation> GetAdvancedHospitalInformationAsync(int hospitalID, CancellationToken cancellationToken)
        {
            var cacheKey = GetAdvancedHospitalInformationCacheKey(hospitalID);

            if (!MemoryCache.TryGetValue(cacheKey, out AdvancedHospitalInformation advancedHospitalInformation))
            {
                advancedHospitalInformation = await DataService.GetAdvancedHospitalInformationAsync(hospitalID, cancellationToken);
                SetMemoryCache(cacheKey, advancedHospitalInformation);
            }

            return advancedHospitalInformation;
        }

        /// <summary>
        /// get doctors for hospital as an asynchronous operation.
        /// </summary>
        /// <param name="hospitalID">The hospital identifier.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Task&lt;HospitalDoctorInformation&gt;.</returns>
        public async Task<HospitalDoctorInformation> GetDoctorsForHospitalAsync(int hospitalID, CancellationToken cancellationToken)
        {
            var cacheKey = GetDoctorsForHospital(hospitalID);

            if (!MemoryCache.TryGetValue(cacheKey, out HospitalDoctorInformation hospitalDoctorInformation))
            {
                hospitalDoctorInformation = await DataService.GetDoctorsForHospitalAsync(hospitalID, cancellationToken);
                SetMemoryCache(cacheKey, hospitalDoctorInformation);
            }

            return hospitalDoctorInformation;
        }

        /// <summary>
        /// Gets all speciality information for hospital.
        /// </summary>
        /// <param name="hospitalID">The hospital identifier.</param>
        /// <returns>Task&lt;IQueryable&lt;SpecialityInformation&gt;&gt;.</returns>
        public IQueryable<SpecialityInformation> GetAllSpecialityInfoForHospital(int hospitalID)
        {
            return DataService.GetAllSpecialityInfoForHospital(hospitalID);
        }

        /// <summary>
        /// Sets the memory cache.
        /// </summary>
        /// <param name="cacheKey">The cache key.</param>
        /// <param name="value">The value.</param>
        private void SetMemoryCache(string cacheKey, object value)
        {
            MemoryCache.Set(cacheKey, value, MemoryCacheEntryOptions);
        }

        /// <summary>
        /// Gets the speciality information.
        /// </summary>
        /// <returns>IQueryable&lt;SpecialityDropdown&gt;.</returns>
        public IQueryable<Dropdown> GetSpecialityInformation()
        {
            return DataService.GetSpecialityInformation();
        }

        /// <summary>
        /// Gets the hospital information by identifier cache key.
        /// </summary>
        /// <param name="hospitalID">The hospital identifier.</param>
        /// <returns>System.String.</returns>
        private static string GetHospitalInformationByIDCacheKey(int hospitalID)
        {
            return "HospitalInformation" + hospitalID;
        }

        /// <summary>
        /// Gets the advanced hospital information cache key.
        /// </summary>
        /// <param name="hospitalID">The hospital identifier.</param>
        /// <returns>System.String.</returns>
        private static string GetAdvancedHospitalInformationCacheKey(int hospitalID)
        {
            return "AdvancedHospitalInformation" + hospitalID;
        }

        /// <summary>
        /// Gets the doctors for hospital.
        /// </summary>
        /// <param name="hospitalID">The hospital identifier.</param>
        /// <returns>System.String.</returns>
        private static string GetDoctorsForHospital(int hospitalID)
        {
            return "DoctorsForHospital" + hospitalID;
        }



    }
}
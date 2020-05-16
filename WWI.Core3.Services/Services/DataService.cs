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
    /// </summary>
    /// <seealso cref="WWI.Core3.Services.Services.Base.BaseService" />
    /// <seealso cref="WWI.Core3.Services.Interfaces.IDataService" />
    public class DataService : BaseService, IDataService
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="DataService" /> class.
        /// </summary>
        /// <param name="applicationServices">Application Services</param>
        public DataService(ApplicationServices applicationServices) : base(applicationServices)
        {
        }

        /// <summary>
        /// get hospital information by identifier as an asynchronous operation.
        /// </summary>
        /// <param name="hospitalID">The hospital identifier.</param>
        /// <returns>Task&lt;HospitalInformation&gt;.</returns>
        public async Task<HospitalInformation> GetHospitalInformationByIDAsync(int hospitalID)
        {
            var hospitalInformation = await GetHospitalInformation()
                .SingleOrDefaultAsync(h => h.HospitalID == hospitalID);

            return hospitalInformation;
        }

        #region -- Private Methods --

        /// <summary>
        /// Gets the hospital information.
        /// </summary>
        /// <returns>IQueryable&lt;HospitalInformation&gt;.</returns>
        private IQueryable<HospitalInformation> GetHospitalInformation()
        {
            return DbContext.Hospitals
                .ProjectTo<HospitalInformation>(AutoMapper.ConfigurationProvider)
                .AsQueryable();
        }

        #endregion



    }
}
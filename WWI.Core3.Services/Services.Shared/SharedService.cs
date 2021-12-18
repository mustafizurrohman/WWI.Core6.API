// ***********************************************************************
// Assembly         : WWI.Core3.Services
// Author           : Mustafizur Rohman
// Created          : 09-16-2020
//
// Last Modified By : Mustafizur Rohman
// Last Modified On : 09-17-2020
// ***********************************************************************
// <copyright file="SharedService.cs" company="WWI.Core3.Services">
//     Copyright (c) Personal. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using AutoMapper.QueryableExtensions;
using WWI.Core6.Models.ViewModels;
using WWI.Core6.Services.Interfaces;
using WWI.Core6.Services.ServiceCollection;
using WWI.Core6.Services.Services.Base;

namespace WWI.Core6.Services.Services.Shared
{

    /// <summary>
    /// Class SharedService.
    /// Implements the <see cref="ISharedService" />
    /// </summary>
    /// <seealso cref="ISharedService" />
    public class SharedService : BaseService, ISharedService
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicationServices"></param>
        public SharedService(IApplicationServices applicationServices) : base(applicationServices)
        {
        }

        /// <summary>
        /// Gets the hospital information.
        /// </summary>
        /// <returns>IQueryable&lt;HospitalInformation&gt;.</returns>
        public IQueryable<HospitalInformation> GetHospitalInformation()
        {
            return DbContext.Hospitals
                .ProjectTo<HospitalInformation>(AutoMapper.ConfigurationProvider)
                .AsQueryable();
        }

        public IQueryable<AdvancedHospitalInformation> GetAdvancedHospitalInformation()
        {
            return DbContext.Hospitals
                .ProjectTo<AdvancedHospitalInformation>(AutoMapper.ConfigurationProvider)
                .AsQueryable();
        }

    }

}

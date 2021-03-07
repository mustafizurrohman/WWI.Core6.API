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

using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Linq;
using WWI.Core3.Models.DbContext;
using WWI.Core3.Models.ViewModels;
using WWI.Core3.Services.Interfaces;

namespace WWI.Core3.Services.Services.Shared
{

    /// <summary>
    /// Class SharedService.
    /// Implements the <see cref="ISharedService" />
    /// </summary>
    /// <seealso cref="ISharedService" />
    public class SharedService : ISharedService
    {

        #region - Attributes -- 

        /// <summary>
        /// Gets the database context.
        /// </summary>
        /// <value>The database context.</value>
        private DocAppointmentContext DbContext { get; }

        /// <summary>
        /// Gets the automatic mapper.
        /// </summary>
        /// <value>The automatic mapper.</value>
        private IMapper AutoMapper { get; }

        #endregion 

        #region -- Constructor --

        /// <summary>
        /// Initializes a new instance of the <see cref="SharedService"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        /// <param name="autoMapper">The automatic mapper.</param>
        public SharedService(DocAppointmentContext dbContext, IMapper autoMapper)
        {
            DbContext = dbContext;
            AutoMapper = autoMapper;
        }

        #endregion

        #region -- Public Methods --

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

        #endregion

    }

}

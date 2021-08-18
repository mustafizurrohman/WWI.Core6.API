// ***********************************************************************
// Assembly         : WWI.Core3.Services
// Author           : Mustafizur Rohman
// Created          : 09-16-2020
//
// Last Modified By : Mustafizur Rohman
// Last Modified On : 09-17-2020
// ***********************************************************************
// <copyright file="ISharedService.cs" company="WWI.Core3.Services">
//     Copyright (c) Personal. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Linq;
using WWI.Core3.Models.ViewModels;

namespace WWI.Core3.Services.Interfaces
{

    /// <summary>
    /// Interface ISharedService
    /// </summary>
    public interface ISharedService
    {

        /// <summary>
        /// Gets the hospital information.
        /// </summary>
        /// <returns>IQueryable&lt;HospitalInformation&gt;.</returns>
        IQueryable<HospitalInformation> GetHospitalInformation();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IQueryable<AdvancedHospitalInformation> GetAdvancedHospitalInformation();

    }

}
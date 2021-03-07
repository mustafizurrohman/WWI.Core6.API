// ***********************************************************************
// Assembly         : WWI.Core3.Services
// Author           : Mustafizur Rohman
// Created          : 09-16-2020
//
// Last Modified By : Mustafizur Rohman
// Last Modified On : 09-17-2020
// ***********************************************************************
// <copyright file="IApplicationServices.cs" company="WWI.Core3.Services">
//     Copyright (c) Personal. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using AutoMapper;
using WWI.Core3.Models.DbContext;

namespace WWI.Core3.Services.ServiceCollection
{

    /// <summary>
    /// Interface IApplicationServices
    /// </summary>
    public interface IApplicationServices
    {

        /// <summary>
        /// The database context
        /// </summary>
        /// <value>The database context.</value>
        DocAppointmentContext DbContext { get; }

        /// <summary>
        /// AutoMapper
        /// </summary>
        /// <value>The automatic mapper.</value>
        IMapper AutoMapper { get; }

    }

}
// ***********************************************************************
// Assembly         : WWI.Core6.Services
// Author           : Mustafizur Rohman
// Created          : 05-15-2020
//
// Last Modified By : Mustafizur Rohman
// Last Modified On : 05-15-2020
// ***********************************************************************
// <copyright file="BaseService.cs" company="WWI.Core6.Services">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using AutoMapper;
using WWI.Core6.Models.DbContext;

namespace WWI.Core6.Services.Services.Base;

/// <summary>
/// Class BaseService.
/// </summary>
public abstract class BaseService
{
    /// <summary>
    /// The database context
    /// </summary>
    protected DocAppointmentContext DbContext { get; }

    /// <summary>
    /// AutoMapper
    /// </summary>
    /// <value>The automatic mapper.</value>
    protected IMapper AutoMapper { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="BaseService" /> class.
    /// </summary>
    /// <param name="applicationServices">The application services.</param>
    protected BaseService(IApplicationServices applicationServices)
    {
        DbContext = Guard.Against.Null(applicationServices.DbContext, nameof(applicationServices.DbContext));
        AutoMapper = Guard.Against.Null(applicationServices.AutoMapper, nameof(applicationServices.AutoMapper));
    }



}
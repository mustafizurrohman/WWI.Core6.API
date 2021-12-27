// ***********************************************************************
// Assembly         : WWI.Core6.API
// Author           : Mustafizur Rohman
// Created          : 05-01-2020
//
// Last Modified By : Mustafizur Rohman
// Last Modified On : 05-19-2020
// ***********************************************************************
// <copyright file="BaseAPIController.cs" company="WWI.Core6.API">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Web.Http.OData;
using AutoMapper;
using WWI.Core6.Models.DbContext;

namespace WWI.Core6.API.Controllers.Base;

/// <summary>
/// Base API Controller
/// </summary>
/// <seealso cref="ControllerBase" />
[ApiController]
[Route("[controller]")]
[Produces("application/json")]
[EnableQuery]
public abstract class BaseAPIController : ControllerBase
{

    #region  -- Attributes -- 

    /// <summary>
    /// The database context
    /// </summary>
    /// <value>The database context.</value>
    protected DocAppointmentContext DbContext { get; }

    /// <summary>
    /// AutoMapper
    /// </summary>
    /// <value>AutoMapper</value>
    // ReSharper disable once MemberCanBePrivate.Global
    protected IMapper AutoMapper { get; }

    /// <summary>
    /// Mediator
    /// </summary>
    protected IMediator Mediator { get; }

    #endregion

    #region -- Constructor -- 

    /// <summary>
    /// Initializes a new instance of the <see cref="BaseAPIController" /> class.
    /// </summary>
    /// <param name="applicationServices">The collection of frequently used application services.</param>
    protected BaseAPIController(IApplicationServices applicationServices)
    {
        DbContext = Guard.Against.Null(applicationServices.DbContext, nameof(applicationServices.DbContext));
        AutoMapper = Guard.Against.Null(applicationServices.AutoMapper, nameof(applicationServices.AutoMapper));
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="applicationServices"></param>
    /// <param name="mediator"></param>
    protected BaseAPIController(IApplicationServices applicationServices, IMediator mediator)
        : this(applicationServices)
    {
        Mediator = Guard.Against.Null(mediator, nameof(mediator));
    }

    #endregion

}
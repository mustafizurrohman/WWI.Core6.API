// ***********************************************************************
// Assembly         : WWI.Core6.Middleware.Base
// Author           : Mustafizur Rohman
// Created          : 05-02-2020
//
// Last Modified By : Mustafizur Rohman
// Last Modified On : 05-02-2020
// ***********************************************************************
// <copyright file="BaseMiddleware.cs" company="WWI.Core6.Middleware.Base">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Http;

namespace WWI.Core6.Middleware.Base;

/// <summary>
/// Base Middleware: All Middleware inherit this
/// </summary>
public abstract class BaseMiddleware
{
    /// <summary>
    /// Request delegate
    /// </summary>
    /// <value>The next.</value>
    protected RequestDelegate Next { get; }

    /// <summary>
    /// Instance of service provider
    /// </summary>
    [UsedImplicitly]
    private readonly IServiceProvider _serviceProvider;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="next">The next.</param>
    /// <param name="serviceProvider">The service provider.</param>
    protected BaseMiddleware(RequestDelegate next, IServiceProvider serviceProvider)
    {
        Next = next;
        _serviceProvider = serviceProvider;
    }

    /// <summary>
    /// Middleware implementation goes here
    /// Must be implemented by the middleware
    /// </summary>
    /// <param name="context">The context.</param>
    /// <returns>Task.</returns>
    [UsedImplicitly]
    public abstract Task InvokeAsync(HttpContext context);
}
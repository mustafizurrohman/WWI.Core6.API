// ***********************************************************************
// Assembly         : WWI.Core6.Middleware.ExceptionHandler
// Author           : Mustafizur Rohman
// Created          : 05-02-2020
//
// Last Modified By : Mustafizur Rohman
// Last Modified On : 05-02-2020
// ***********************************************************************
// <copyright file="ExceptionHandler.cs" company="WWI.Core6.Middleware.ExceptionHandler">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Serilog;
using WWI.Core6.Middleware.Base;

namespace WWI.Core6.Middleware.ExceptionHandler;

/// <summary>
/// Exception Handler Middleware
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global
public class ExceptionHandler : BaseMiddleware
{

    /// <summary>
    /// Current hosting environment
    /// </summary>
    private readonly IHostingEnvironment _hostingEnvironment;


    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="requestDelegate">Request Delegate</param>
    /// <param name="hostingEnvironment">Hosting Environment</param>
    /// <param name="serviceProvider">ServiceProvider required Dependency Injection (DI)</param>
    public ExceptionHandler(RequestDelegate requestDelegate, IHostingEnvironment hostingEnvironment, IServiceProvider serviceProvider)
        : base(requestDelegate, serviceProvider)
    {
        _hostingEnvironment = hostingEnvironment;
    }

    /// <summary>
    /// Invoke as an asynchronous operation.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <returns>Task.</returns>
    public override async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await Next.Invoke(context);
        }
        catch (TaskCanceledException)
        {
            Log.Information("Request was cancelled.");
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }

    }


    /// <summary>
    /// Handles the exception asynchronous.
    /// </summary>
    /// <param name="httpContext">The HTTP context.</param>
    /// <param name="ex">The exception</param>
    /// <returns>Task.</returns>
    private Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
    {
        httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        if (_hostingEnvironment.IsDevelopment())
        {
            Log.Error(ex.ToString());
            return httpContext.Response.WriteAsync(ex.ToString());
        }

        Log.Error(ex.ToString());
        return httpContext.Response.WriteAsync("An internal server error occured. The details have been logged ...");
    }


}
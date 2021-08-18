// ***********************************************************************
// Assembly         : WWI.Core3.Middleware.ExceptionHandler
// Author           : Mustafizur Rohman
// Created          : 05-02-2020
//
// Last Modified By : Mustafizur Rohman
// Last Modified On : 05-02-2020
// ***********************************************************************
// <copyright file="ExceptionHandler.cs" company="WWI.Core3.Middleware.ExceptionHandler">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Serilog;
using System;
using System.Net;
using System.Threading.Tasks;
using WWI.Core3.Middleware.Base;

namespace WWI.Core3.Middleware.ExceptionHandler
{
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
#pragma warning disable CA1031 // Do not catch general exception types
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
#pragma warning restore CA1031 // Do not catch general exception types

        }


        /// <summary>
        /// Handles the exception asynchronous.
        /// </summary>
        /// <param name="httpContext">The HTTP context.</param>
        /// <param name="ex">The exception</param>
        /// <returns>Task.</returns>
        private Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {
            if (_hostingEnvironment.IsDevelopment())
            {
                Log.Error(ex.ToString());
            }
            else
            {
                Log.Error(ex.ToString());
            }

            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return httpContext.Response.WriteAsync("An internal server error occured. The details have been logged ....");
        }


    }
}

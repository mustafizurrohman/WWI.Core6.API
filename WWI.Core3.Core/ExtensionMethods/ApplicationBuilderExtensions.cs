// ***********************************************************************
// Assembly         : WWI.Core3.Core
// Author           : Mustafizur Rohman
// Created          : 05-02-2020
//
// Last Modified By : Mustafizur Rohman
// Last Modified On : 05-16-2020
// ***********************************************************************
// <copyright file="ApplicationBuilderExtensions.cs" company="WWI.Core3.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using WWI.Core3.Middleware.ExceptionHandler;
using WWI.Core3.Models.DbContext;

namespace WWI.Core3.Core.ExtensionMethods
{
    /// <summary>
    /// Extension methods for Application Builder
    /// </summary>
    public static class ApplicationBuilderExtensions
    {
        /// <summary>
        /// Extension Method to use custom exception handler
        /// </summary>
        /// <param name="applicationBuilder">Application Builder</param>
        /// <returns>IApplicationBuilder.</returns>
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseMiddleware<ExceptionHandler>();
        }

        /// <summary>
        /// Migrates the database.
        /// </summary>
        /// <param name="applicationBuilder">The application builder.</param>
        public static void MigrateDatabase(this IApplicationBuilder applicationBuilder)
        {
            using IServiceScope serviceScope = applicationBuilder.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope();
            {
                using var context = serviceScope.ServiceProvider.GetService<DocAppointmentContext>();
                try
                {
                    Log.Information("Starting to migrate database ...");
                    context.Database.Migrate();
                }
                catch (Exception ex)
                {
                    Log.Error("An exception occurred during migrating database ...");
                    Log.Error(ex.ToString());
                }
                finally
                {
                    Log.Information("Database Migration completed ...");
                }
            }
        }

    }

}

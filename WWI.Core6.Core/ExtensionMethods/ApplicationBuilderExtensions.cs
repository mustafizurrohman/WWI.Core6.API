// ***********************************************************************
// Assembly         : WWI.Core6.Core
// Author           : Mustafizur Rohman
// Created          : 05-02-2020
//
// Last Modified By : Mustafizur Rohman
// Last Modified On : 05-16-2020
// ***********************************************************************
// <copyright file="ApplicationBuilderExtensions.cs" company="WWI.Core6.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WWI.Core6.Middleware.ExceptionHandler;
using WWI.Core6.Models.DbContext;

namespace WWI.Core6.Core.ExtensionMethods;

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
    // ReSharper disable once UnusedMethodReturnValue.Global
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
        using IServiceScope serviceScope = applicationBuilder.ApplicationServices.GetService<IServiceScopeFactory>()?.CreateScope();

        if (serviceScope == null) 
            return;
            
        using var context = serviceScope.ServiceProvider.GetService<DocAppointmentContext>();
        try
        {
            Log.Information("Starting to migrate database ...");
            context?.Database.Migrate();
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
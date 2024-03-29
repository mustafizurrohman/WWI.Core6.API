﻿using System.Net;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics;
using WWI.Core6.API.Helpers;
using WWI.Core6.Core.ExtensionMethods;
using ValidationException = FluentValidation.ValidationException;

namespace WWI.Core6.API.ExtensionMethods;

/// <summary>
/// Class ApplicationBuilderExtensions.
/// </summary>
public static class ApplicationBuilderExtensions
{
    /// <summary>
    /// Configures the application.
    /// </summary>
    /// <param name="app">The application.</param>
    /// <param name="env">The env.</param>
    /// <param name="configuration"></param>
    /// <returns>IApplicationBuilder.</returns>
    public static IApplicationBuilder ConfigureApplication(this IApplicationBuilder app, IWebHostEnvironment env, IConfiguration configuration)
    {
        if (env.IsDevelopment())
            app.UseDeveloperExceptionPage();            

        #region -- NWebSec Options --

        if (!env.IsDevelopment())
            app.UseHsts(opts => opts.MaxAge(365).Preload());
            

        // Ensure that site content is not being embedded in an IFrame on other sites 
        //  - used for avoid click-jacking attacks.
        app.UseXfo(options => options.SameOrigin());

        // Blocks any content sniffing that could happen that might change an innocent MIME type (e.g. text/css) 
        // into something executable that could do some real damage.
        app.UseXContentTypeOptions();

        app.UseReferrerPolicy(opts => opts.NoReferrer());

        #endregion
           
        app.UseHttpsRedirection();

        app.UseCustomExceptionHandler();

        var applicationSettings = new ApplicationSettingsUtility(configuration).GetApplicationSettings();

        if (!applicationSettings.MediatRPipelineOptions.EnableValidationBehaviour)
          app.UseFluentValidationExceptionHandler();
            
        app.UseSerilogRequestLogging();

        app.UseRouting();

        app.UseAuthorization();

        // Database migration using EF Core
        app.MigrateDatabase();

        // Must be configurable in a real application
        app.UseCors(options =>
        {
            options.AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin();
        });

        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

        return app;
    }

    /// <summary>
    /// Not used anymore but it could be a way to handle validation errors
    /// </summary>
    /// <param name="applicationBuilder"></param>
    private static void UseFluentValidationExceptionHandler(this IApplicationBuilder applicationBuilder)
    {
        applicationBuilder.UseExceptionHandler(appBuilder =>
        {
            appBuilder.Run(async context =>
            {
                var errorFeature = context.Features.Get<IExceptionHandlerFeature>();
                var exception = errorFeature?.Error ?? new Exception();

                if (exception is not ValidationException validationException)
                    throw exception;

                var errors = validationException.Errors
                    .Select(err => new
                    {
                        err.PropertyName,
                        err.AttemptedValue,
                        err.ErrorMessage
                    })
                    .ToList();

                var errorText = JsonSerializer.Serialize(errors);

                context.Response.StatusCode = (int) HttpStatusCode.BadRequest;
                context.Response.ContentType = "application/json";

                await context.Response.WriteAsync(errorText, Encoding.UTF8);

            });
        });
    }


}
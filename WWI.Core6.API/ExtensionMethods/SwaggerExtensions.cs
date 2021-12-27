// ***********************************************************************
// Assembly         : WWI.Core6.Core
// Author           : Mustafizur Rohman
// Created          : 05-01-2020
//
// Last Modified By : Mustafizur Rohman
// Last Modified On : 05-16-2020
// ***********************************************************************
// <copyright file="SwaggerExtensions.cs" company="WWI.Core6.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace WWI.Core6.API.ExtensionMethods;

/// <summary>
/// Extensions for Swagger
/// </summary>
public static class SwaggerExtensions
{

    /// <summary>Adds the swagger documentation.</summary>
    /// <param name="services">The services.</param>
    /// <param name="info">The information.</param>
    /// <param name="apiKeyScheme">The API key scheme.</param>
    /// <returns>IServiceCollection.</returns>
    // ReSharper disable once UnusedMethodReturnValue.Global
    public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services, OpenApiInfo info, OpenApiSecurityScheme apiKeyScheme)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc(info?.Version, new OpenApiInfo
            {
                Version = info?.Version,
                Title = info?.Title,
                Description = info?.Description,
                TermsOfService = info?.TermsOfService,
                Contact = new OpenApiContact()
                {
                    Name = info?.Contact?.Name,
                    Email = info?.Contact?.Email,
                    Url = info?.Contact?.Url
                }
            });

            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = apiKeyScheme?.Description,
                Name = apiKeyScheme?.Name,
                Type = SecuritySchemeType.Http
            });

            var xmlFile = "WWI.Core6.API.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            c.IncludeXmlComments(xmlPath);
        });

        return services;
    }

    /// <summary>
    /// Extension method to use swagger documentation
    /// </summary>
    /// <param name="app"></param>
    /// <param name="info"></param>
    /// <returns></returns>
    // ReSharper disable once UnusedMethodReturnValue.Global
    public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app, OpenApiInfo info)
    {
        app.UseSwagger();

        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/" + info?.Version + "/swagger.json", info?.Title + " v" + info?.Version);
            c.DisplayRequestDuration();
        });

        return app;
    }
}
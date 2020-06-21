// ***********************************************************************
// Assembly         : WWI.Core3.Core
// Author           : Mustafizur Rohman
// Created          : 05-01-2020
//
// Last Modified By : Mustafizur Rohman
// Last Modified On : 05-16-2020
// ***********************************************************************
// <copyright file="SwaggerExtensions.cs" company="WWI.Core3.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;

namespace WWI.Core3.Core.ExtensionMethods
{
    /// <summary>
    /// Extensions for Swagger
    /// </summary>
    public static class SwaggerExtensions
    {

        /// <summary>
        /// Extension method to configure swagger and add documentation
        /// </summary>
        /// <param name="services"></param>
        /// <param name="info"></param>
        /// <param name="apiKeyScheme"></param>
        /// <returns></returns>
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
                        Name = info?.Contact.Name,
                        Email = info?.Contact.Email,
                        Url = info?.Contact.Url
                    }
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = apiKeyScheme?.Description,
                    Name = apiKeyScheme?.Name,
                    Type = SecuritySchemeType.Http
                });

                var xmlFile = "WWI.Core3.API.xml";
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
            });

            return app;
        }
    }
}
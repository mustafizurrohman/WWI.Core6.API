// ***********************************************************************
// Assembly         : WWI.Core3.API
// Author           : Mustafizur Rohman
// Created          : 04-23-2020
//
// Last Modified By : Mustafizur Rohman
// Last Modified On : 05-17-2020
// ***********************************************************************
// <copyright file="Startup.cs" company="WWI.Core3.API">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Serilog;
using System;
using System.Linq;
using WWI.Core3.API.ExtensionMethods;
using WWI.Core3.Core.Exceptions;
using WWI.Core3.Models.Validators;

namespace WWI.Core3.API
{
    /// <summary>
    /// Startup class
    /// </summary>
    public class Startup
    {                
        /// <summary>
        /// The OpenApi information
        /// </summary>
        private readonly OpenApiInfo _info = new OpenApiInfo();

        /// <summary>
        /// The open API security scheme
        /// </summary>
        private readonly OpenApiSecurityScheme _openApiSecurityScheme = new OpenApiSecurityScheme();

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>The configuration.</value>
        private IConfiguration Configuration { get; }
              
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">Service Collection</param>
        public void ConfigureServices(IServiceCollection services)
        {
            Configuration.GetSection("Swagger").Bind(_info);

            OpenApiInfoValidator validator = new OpenApiInfoValidator();
            var validationResult =  validator.Validate(_info);

            if (validationResult.Errors.Count > 0)
            {
                var errors = validationResult.Errors
                    .Select((e, index) => (index + 1) + "- " + e)
                    .Aggregate((e1, e2) => e1 + Environment.NewLine + e2);

                Log.Fatal("Invalid app settings. Please refer to the errors below");
                Log.Error(Environment.NewLine + Environment.NewLine + errors + Environment.NewLine);
                Log.Fatal("Please correct the app settings before starting the application again!!!");
                Log.Fatal("Application will now terminate ...");

                throw new AppSettingsValidationException(errors);
            }

            Log.Information("Application Settings validated ...");
            
            Configuration.GetSection("ApiKeyScheme").Bind(_openApiSecurityScheme);

            services.AddSwaggerDocumentation(_info, _openApiSecurityScheme);

            services.InstallServicesInAssembly(Configuration);
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">Application Builder</param>
        /// <param name="env">Hosting Environment</param>
        // ReSharper disable once UnusedMember.Global
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.ConfigureApplication(env)
                .UseSwaggerDocumentation(_info)
                .UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }

    }
}
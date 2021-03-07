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

using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Serilog;
using System;
using WWI.Core3.Core.ExtensionMethods;
using WWI.Core3.Models.DbContext;
using WWI.Core3.Services.Interfaces;
using WWI.Core3.Services.ServiceCollection;
using WWI.Core3.Services.Services;
using WWI.Core3.Services.Services.Shared;

namespace WWI.Core3.API
{
    /// <summary>
    /// Startup class
    /// </summary>
    public class Startup
    {

        #region -- Private Properties

        /// <summary>
        /// The OpenApi information
        /// </summary>
        private readonly OpenApiInfo _info = new OpenApiInfo();

        /// <summary>
        /// The open API security scheme
        /// </summary>
        private readonly OpenApiSecurityScheme _openApiSecurityScheme = new OpenApiSecurityScheme();

        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>The configuration.</value>
        private IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">Service Collection</param>
        public void ConfigureServices(IServiceCollection services)
        {
            #region -- Swagger --

            Configuration.GetSection("Swagger").Bind(_info);
            Configuration.GetSection("ApiKeyScheme").Bind(_openApiSecurityScheme);

            services.AddSwaggerDocumentation(_info, _openApiSecurityScheme);

            #endregion

            #region -- Database Configuration --

            string connectionString = Configuration.GetConnectionString("AppointmentDb");

            services.AddDbContext<DocAppointmentContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            #endregion

            #region -- Service Configuration --

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddTransient<IApplicationServices, ApplicationServices>();

            services.AddTransient<IDataService, DataService>();

            services.AddTransient<ISharedService, SharedService>();

            services.AddMvc()
                .AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);

            #endregion

            services.AddControllers();
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">Application Builder</param>
        /// <param name="env">Hosting Environment</param>
        // ReSharper disable once UnusedMember.Global
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            #region -- NWebSec Options --

            if (!env.IsDevelopment())
            {
                app.UseHsts(opts => opts.MaxAge(365).Preload());
            }

            // Ensure that site content is not being embedded in an IFrame on other sites 
            //  - used for avoid click-jacking attacks.
            app.UseXfo(options => options.SameOrigin());

            // Blocks any content sniffing that could happen that might change an innocent MIME type (e.g. text/css) 
            // into something executable that could do some real damage.
            app.UseXContentTypeOptions();

            app.UseReferrerPolicy(opts => opts.NoReferrer());

            #endregion

            app.UseSwaggerDocumentation(_info);

            app.UseHttpsRedirection();

            app.UseCustomExceptionHandler();

            app.UseSerilogRequestLogging();

            app.UseRouting();

            app.UseAuthorization();

            app.MigrateDatabase();

            app.UseCors(options =>
            {
                options.AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin();
            });

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });


        }

    }
}
// ***********************************************************************
// Assembly         : WWI.Core6.API
// Author           : Mustafizur Rohman
// Created          : 04-23-2020
//
// Last Modified By : Mustafizur Rohman
// Last Modified On : 05-17-2020
// ***********************************************************************
// <copyright file="Startup.cs" company="WWI.Core6.API">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using Microsoft.OpenApi.Models;
using WWI.Core6.API.ExtensionMethods;
using WWI.Core6.API.Helpers;

namespace WWI.Core6.API;

/// <summary>
/// Startup class
/// </summary>
public class Startup
{                
    /// <summary>
    /// The OpenApi information
    /// </summary>
    private readonly OpenApiInfo _info = new();

    /// <summary>
    /// The open API security scheme
    /// </summary>
    private readonly OpenApiSecurityScheme _openApiSecurityScheme = new();
        
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
        Configuration = Guard.Against.Null(configuration, nameof(configuration));
    }

    /// <summary>
    /// This method gets called by the runtime. Use this method to add services to the container.
    /// </summary>
    /// <param name="services">Service Collection</param>
    public void ConfigureServices(IServiceCollection services)
    {
        Configuration.GetSection("ApiKeyScheme").Bind(_openApiSecurityScheme);
        Configuration.GetSection("Swagger").Bind(_info);
            
        services.InstallServicesInAssembly(Configuration)
            .AddSwaggerDocumentation(_info, _openApiSecurityScheme);

        Log.Information("Validating Application Settings ...");

        ApplicationSettingsUtility applicationSettingsUtility = new(Configuration);
        applicationSettingsUtility.VerifyApplicationSettings();

        Log.Information("Application Settings sucessfully validated ...");
    }

    /// <summary>
    /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    /// </summary>
    /// <param name="app">Application Builder</param>
    /// <param name="env">Hosting Environment</param>
    // ReSharper disable once UnusedMember.Global
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.ConfigureApplication(env, Configuration)
            .UseSwaggerDocumentation(_info)
            .UseEndpoints(endpoints => { endpoints.MapControllers(); });

        Log.Information("Applcation startup complete ..." + Environment.NewLine);
    }

}
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using WWI.Core3.Core.ExtensionMethods;
using WWI.Core3.Services.Interfaces;
using WWI.Core3.Services.ServiceCollection;
using WWI.Core3.Services.Services;
using WWI.Core3.Services.Services.Shared;

namespace WWI.Core3.API.Installers
{
    /// <summary>
    /// 
    /// </summary>
    public class ServiceInstaller : IInstaller
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
        /// 
        /// </summary>
        /// <param name="serviceCollection"></param>
        /// <param name="configuration"></param>
        public void InstallServices(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            //configuration.GetSection("Swagger").Bind(_info);
            //configuration.GetSection("ApiKeyScheme").Bind(_openApiSecurityScheme);

            //serviceCollection.AddSwaggerDocumentation(_info, _openApiSecurityScheme);

            serviceCollection.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            serviceCollection.AddTransient<IApplicationServices, ApplicationServices>();

            serviceCollection.AddTransient<IDataService, DataService>();

            serviceCollection.AddTransient<ISharedService, SharedService>();

            serviceCollection.AddMvc()
                .AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
 
            serviceCollection.AddControllers();


        }
    }
}

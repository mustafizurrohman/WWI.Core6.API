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
using WWI.Core3.Services.Services;

namespace WWI.Core3.API
{

    /// <summary>
    /// Startup class
    /// </summary>
    public class Startup
    {

        #region -- Private Properties

        private readonly OpenApiInfo _info = new OpenApiInfo();
        private readonly OpenApiSecurityScheme _openApiSecurityScheme = new OpenApiSecurityScheme();

        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// 
        /// </summary>
        public IConfiguration Configuration { get; }

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

            services.AddDbContext<DocAppointmentContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("AppointmentDb"));
            });

            #endregion

            #region  -- Service Configuration --

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddTransient<IDataService, DataService>();

            #endregion

            services.AddControllers();
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">Application Builder</param>
        /// <param name="env">Hosting Environment</param>
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

            // Ensure that site content is not being embedded in an iframe on other sites 
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Serilog;
using WWI.Core3.Core.ExtensionMethods;
using WWI.Core3.Models.Models;

namespace WWI.Core3.API
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        private readonly OpenApiInfo _info = new OpenApiInfo();
        private readonly OpenApiSecurityScheme _openApiSecurityScheme = new OpenApiSecurityScheme();

        /// <summary>
        /// 
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
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {

            #region -- Swagger -- 

            Configuration.GetSection("Swagger").Bind(_info);
            Configuration.GetSection("ApiKeyScheme").Bind(_openApiSecurityScheme);

            services.AddSwaggerDocumentation(_info, _openApiSecurityScheme);

            #endregion

            #region -- Database Configuration --

            services.AddDbContext<WideWorldImportersContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("WideWorldDb"));
            });

            #endregion

            services.AddControllers();
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwaggerDocumentation(_info);

            app.UseHttpsRedirection();

            app.UseCustomExceptionHandler();

            app.UseSerilogRequestLogging();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

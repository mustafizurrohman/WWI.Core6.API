using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using WWI.Core3.Core.ExtensionMethods;

namespace WWI.Core3.API.ExtensionMethods
{
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
        /// <returns>IApplicationBuilder.</returns>
        public static IApplicationBuilder ConfigureApplication(this IApplicationBuilder app, IWebHostEnvironment env)
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

            return app;
        }
    }
}

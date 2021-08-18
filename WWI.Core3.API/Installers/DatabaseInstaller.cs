using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WWI.Core3.Models.DbContext;

namespace WWI.Core3.API.Installers
{
    /// <summary>
    /// 
    /// </summary>
    public class DatabaseInstaller : IInstaller
    {
        /// <summary>
        /// ConsoleLoggerFactory
        /// </summary>
        private static readonly ILoggerFactory ConsoleLoggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });

        /// <summary>
        /// public DatabaseInstaller
        /// </summary>
        /// <param name="serviceCollection"></param>
        /// <param name="configuration"></param>
        public void InstallServices(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("AppointmentDb");

            serviceCollection.AddDbContext<DocAppointmentContext>(options =>
            {
                options.UseSqlServer(connectionString);

                #if DEBUG
                options.EnableSensitiveDataLogging(true)
                    .UseLoggerFactory(ConsoleLoggerFactory);
                #endif

            });
        }
    }
}

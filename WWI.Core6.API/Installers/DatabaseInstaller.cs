using Microsoft.EntityFrameworkCore;
using WWI.Core6.Models.DbContext;

namespace WWI.Core6.API.Installers;

/// <summary>
/// 
/// </summary>
public class DatabaseInstaller : IInstaller
{

#if DEBUG
    /// <summary>
    /// ConsoleLoggerFactory
    /// </summary>
    private static readonly ILoggerFactory ConsoleLoggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });
#endif

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
            // We must not print the queries during production
            options.EnableSensitiveDataLogging()
                .UseLoggerFactory(ConsoleLoggerFactory);
            // https://docs.microsoft.com/en-in/ef/core/querying/single-split-queries
            // .UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)
            // Throws an exception. Will be helpful for performance optimization
            // .ConfigureWarnings(w => w.Throw(RelationalEventId.MultipleCollectionIncludeWarning));
#endif

        });
    }
}
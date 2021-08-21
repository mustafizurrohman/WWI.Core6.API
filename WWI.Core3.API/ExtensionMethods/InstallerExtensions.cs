using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using WWI.Core3.API.Installers;

namespace WWI.Core3.API.ExtensionMethods
{

    /// <summary>Class InstallerExtensions.</summary>
    public static class InstallerExtensions
    {

        /// <summary>
        /// Installs the services in assembly.
        /// </summary>
        /// <param name="serviceCollection">The service collection.</param>
        /// <param name="configuration">The configuration.</param>
        /// <returns>IServiceCollection.</returns>
        public static IServiceCollection InstallServicesInAssembly(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            var installers = typeof(Startup)
                .Assembly
                .ExportedTypes
                .Where(typ => typeof(IInstaller).IsAssignableFrom(typ)
                        && !typ.IsInterface
                        && !typ.IsAbstract)
                .Select(Activator.CreateInstance)
                .Cast<IInstaller>()
                .ToList();

            installers.ForEach(installer => installer.InstallServices(serviceCollection, configuration));

            return serviceCollection;
        }
    }
}

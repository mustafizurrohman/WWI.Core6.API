using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WWI.Core3.API.Installers
{
    /// <summary>
    /// 
    /// </summary>
    public static class InstallerExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceCollection"></param>
        /// <param name="configuration"></param>
        public static void InstallServicesInAssembly(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            var installers = typeof(Startup)
                .Assembly
                .ExportedTypes
                .Where(typ => typeof(IInstaller ).IsAssignableFrom(typ)
                        && !typ.IsInterface
                        && !typ.IsAbstract)
                .Select(Activator.CreateInstance)
                .Cast<IInstaller>()
                .ToList();

            installers.ForEach(installer => installer.InstallServices(serviceCollection, configuration));
        }
    }
}

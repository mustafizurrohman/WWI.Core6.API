// ***********************************************************************
// Assembly         : WWI.Core3.API
// Author           : Mustafizur Rohman
// Created          : 08-18-2021
//
// Last Modified By : Mustafizur Rohman
// Last Modified On : 08-20-2021
// ***********************************************************************
// <copyright file="InstallerExtensions.cs" company="WWI.Core3.API">
//     Copyright (c) Personal. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WWI.Core6.API.Installers;

namespace WWI.Core6.API.ExtensionMethods
{

    /// <summary>
    /// Class InstallerExtensions.
    /// </summary>
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

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
    public interface IInstaller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceCollection"></param>
        /// <param name="configuration"></param>
        void InstallServices(IServiceCollection serviceCollection, IConfiguration configuration);
    }
}

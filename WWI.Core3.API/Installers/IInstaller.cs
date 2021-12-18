using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WWI.Core6.API.Installers
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

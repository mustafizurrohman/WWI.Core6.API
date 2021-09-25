using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WWI.Core3.API.ExtensionMethods;
using WWI.Core3.Core.AutoMapper;
using WWI.Core3.Services.Interfaces;
using WWI.Core3.Services.MediatR.Decorators;
using WWI.Core3.Services.MediatR.Handlers;
using WWI.Core3.Services.MediatR.PipelineBehaviours;
using WWI.Core3.Services.ServiceCollection;
using WWI.Core3.Services.Services;
using WWI.Core3.Services.Services.Shared;

namespace WWI.Core3.API.Installers
{
    /// <summary>
    /// Class ServiceInstaller.
    /// Implements the <see cref="WWI.Core3.API.Installers.IInstaller" />
    /// </summary>
    /// <seealso cref="WWI.Core3.API.Installers.IInstaller" />
    public class ServiceInstaller : IInstaller
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceCollection"></param>
        /// <param name="configuration"></param>
        public void InstallServices(IServiceCollection serviceCollection, IConfiguration configuration)
        {

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            serviceCollection.AddSingleton(mapper);

            serviceCollection.AddTransient<IApplicationServices, ApplicationServices>();

            serviceCollection.AddTransient<IDataService, DataService>();
            serviceCollection.Decorate<IDataService, CachedDataService>();

            serviceCollection.AddTransient<ISharedService, SharedService>();

            serviceCollection.AddTransient<IHTMLFormatterService, HTMLFormatterService>();

            serviceCollection.AddTransient<IFakeDataGeneratorService, FakeDataGeneratorService>();

            serviceCollection.AddMediatR(typeof(HandlerBase).Assembly);
            serviceCollection.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            serviceCollection.AddValidatorsFromAssembly(typeof(RetryDecorator<>).Assembly);

            serviceCollection.Scan(scan =>
            {
                scan.FromAssembliesOf(typeof(HandlerBase))
                    .RegisterHandlers(typeof(INotificationHandler<>));
            });

            // TODO: Make this work!
            // serviceCollection.Decorate(typeof(INotificationHandler<>), typeof(RetryDecorator<>));

            serviceCollection.AddOptions();

            serviceCollection.AddMvc()
                .AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);

            serviceCollection.AddMemoryCache();

            serviceCollection.AddControllers();

        }
    }
}

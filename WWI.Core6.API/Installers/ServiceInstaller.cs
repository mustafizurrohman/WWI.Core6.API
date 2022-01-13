using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using WWI.Core6.API.ExtensionMethods;
using WWI.Core6.Core.AutoMapper;
using WWI.Core6.Services;
using WWI.Core6.Services.Interfaces;
using WWI.Core6.Services.MediatR.Handlers;
using WWI.Core6.Services.MediatR.PipelineBehaviours;
using WWI.Core6.Services.Services;
using WWI.Core6.Services.Services.Shared;

namespace WWI.Core6.API.Installers;

/// <summary>
/// Class ServiceInstaller.
/// Implements the <see cref="IInstaller" />
/// </summary>
/// <seealso cref="IInstaller" />
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

        // TODO: Scrutor can be used here
        serviceCollection.AddTransient<IApplicationServices, ApplicationServices>();

        serviceCollection.AddTransient<IDataService, DataService>();
        serviceCollection.Decorate<IDataService, CachedDataService>();

        serviceCollection.AddTransient<ISharedService, SharedService>();

        serviceCollection.AddTransient<IHTMLFormatterService, HTMLFormatterService>();

        serviceCollection.AddTransient<IFakeDataGeneratorService, FakeDataGeneratorService>();

        serviceCollection.AddMediatR(typeof(HandlerBase).Assembly);
        
        // Injected during MVC
        // serviceCollection.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));


        // serviceCollection.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));
        serviceCollection.AddTransient(typeof(IPipelineBehavior<,>), typeof(RetryBehaviour<,>));
        serviceCollection.AddTransient(typeof(IPipelineBehavior<,>), typeof(TimingBehaviour<,>));
        
        serviceCollection.AddValidatorsFromAssembly(typeof(Core6ServicesMarker).Assembly);
        
        serviceCollection.Scan(scan =>
        {
            scan.FromAssembliesOf(typeof(Core6ServicesMarker))
                .RegisterHandlers(typeof(INotificationHandler<>));
        });

        // TODO: Make this work!
        // Implemented with a pipeline behaviour. Explore this possibility later
        // and investage the advantages and disadvantages
        // serviceCollection.Decorate(typeof(INotificationHandler<>), typeof(RetryDecorator<>));

        serviceCollection.AddOptions();

        serviceCollection.AddMvc()
            .AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null)
            .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Core6ServicesMarker>());

        serviceCollection.AddMemoryCache();

        serviceCollection.AddControllers();

    }
}
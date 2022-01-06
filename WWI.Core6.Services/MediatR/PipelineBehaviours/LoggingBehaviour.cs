using System.Reflection;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using Serilog;

namespace WWI.Core6.Services.MediatR.PipelineBehaviours;

// https://garywoodfine.com/how-to-use-mediatr-pipeline-behaviours/
public class LoggingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
{
    public LoggingBehaviour()
    {
        
    }


    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        //Request
        Log.Information($"Handling {typeof(TRequest).Name}");
        
        //Type myType = request.GetType();
        
        //IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());
        
        //foreach (PropertyInfo prop in props)
        //{
        //    object propValue = prop.GetValue(request, null);
        //    Log.Information($"{Property} : {@Value}", prop.Name, propValue);
        //}
        
        var response = await next();
        
        //Response
        Log.Information($"MediatR Logging middleware : Handled {typeof(TResponse).Name}");
        return response;
    }
}
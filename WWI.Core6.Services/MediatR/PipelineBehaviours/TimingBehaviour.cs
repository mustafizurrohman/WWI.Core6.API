using System.Diagnostics;
using Serilog;

namespace WWI.Core6.Services.MediatR.PipelineBehaviours;

public class TimingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
{
    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        Stopwatch stopwatch = new();

        stopwatch.Start();
        var response = await next();
        stopwatch.Stop();

        Log.Information($"MediatR Timing middleware: Processed request in {stopwatch.ElapsedMilliseconds} ms.");

        return response;
    }
}
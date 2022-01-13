using Polly;

namespace WWI.Core6.Services.MediatR.PipelineBehaviours;

public class RetryBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
{
    private readonly IAsyncPolicy _retryPolicy;

    public RetryBehaviour()
    {
        // Policy examples here- https://github.com/App-vNext/Polly-Samples/tree/master/PollyDemos/Async
        _retryPolicy = Policy.Handle<Exception>()
            .WaitAndRetryAsync(15, i => TimeSpan.FromSeconds(i));
    }

    // Will take care of transient errors.
    public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        int attempts = 0;
                
        var respnse = _retryPolicy.ExecuteAsync(async () =>
        {
            var now = DateTime.Now;

            attempts++;
            Log.Information($"Polly: Attempt Number : {attempts} at {now}");
            Log.Information($"Next attempt at {now.AddSeconds(attempts)} if current attempt fails ... ");
            
            return await next();
        });

        return respnse;
    }
}
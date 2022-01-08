using Polly;

namespace WWI.Core6.Services.MediatR.PipelineBehaviours;

public class RetryBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
{
    private readonly IAsyncPolicy _retryPolicy;

    public RetryBehaviour()
    {
        _retryPolicy = Policy.Handle<Exception>()
            .WaitAndRetryAsync(3, i => TimeSpan.FromSeconds(i));
    }

    public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        int attempts = 0;
        
        var respnse = _retryPolicy.ExecuteAsync(async () =>
        {
            attempts++;
            Log.Information($"Polly: Attempt Number : {attempts}");
            return await next();
        });

        return respnse;
    }
}
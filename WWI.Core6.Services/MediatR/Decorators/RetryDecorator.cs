using Polly;

namespace WWI.Core6.Services.MediatR.Decorators
{
    public class RetryDecorator<TNotification> : INotificationHandler<TNotification>
        where TNotification : INotification
    {

        private readonly INotificationHandler<TNotification> _innerNotificationHandler;
        private readonly IAsyncPolicy _retryPolicy;

        public RetryDecorator(INotificationHandler<TNotification> innerNotificationHandler)
        {
            _innerNotificationHandler = innerNotificationHandler;

            _retryPolicy = Policy.Handle<Exception>()
                .WaitAndRetryAsync(3, i => TimeSpan.FromSeconds(i));
        }

        public async Task Handle(TNotification notification, CancellationToken cancellationToken)
        {
            await _retryPolicy.ExecuteAsync(() => _innerNotificationHandler.Handle(notification, cancellationToken));
        }
    }
}

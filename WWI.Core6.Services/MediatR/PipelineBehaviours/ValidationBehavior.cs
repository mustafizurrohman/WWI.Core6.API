﻿namespace WWI.Core6.Services.MediatR.PipelineBehaviours;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{

    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = Guard.Against.Null(validators, nameof(validators));
    }

    public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        var context = new ValidationContext<TRequest>(request);

        var failures = _validators
            .Select(validator => validator.Validate(context))
            .SelectMany(error => error.Errors)
            .Where(err => err != null)
            .ToList();

        if (failures.Any())
            throw new ValidationException(failures);

        return next();
    }
}
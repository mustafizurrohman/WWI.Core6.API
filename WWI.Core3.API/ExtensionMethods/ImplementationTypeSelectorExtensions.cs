using Scrutor;
using System;
using WWI.Core3.Services.MediatR.Decorators;

namespace WWI.Core3.API.ExtensionMethods
{
    /// <summary>
    /// Class ImplementationTypeSelectorExtensions.
    /// </summary>
    public static class ImplementationTypeSelectorExtensions
    {
        /// <summary>
        /// Registers the handlers.
        /// </summary>
        /// <param name="selector">The selector.</param>
        /// <param name="type">The type.</param>
        /// <returns>IImplementationTypeSelector.</returns>
        public static IImplementationTypeSelector RegisterHandlers(this IImplementationTypeSelector selector, Type type)
        {
            return selector.AddClasses(c =>
                    c.AssignableTo(type)
                        .Where(typ => typ == typeof(RetryDecorator<>))
                ).UsingRegistrationStrategy(RegistrationStrategy.Append)
                .AsImplementedInterfaces()
                .WithScopedLifetime();

        }
    }
}

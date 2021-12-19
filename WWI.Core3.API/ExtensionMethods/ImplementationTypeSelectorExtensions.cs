using Scrutor;
using WWI.Core6.Services.MediatR.Decorators;

namespace WWI.Core6.API.ExtensionMethods
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
        // ReSharper disable once UnusedMethodReturnValue.Global
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

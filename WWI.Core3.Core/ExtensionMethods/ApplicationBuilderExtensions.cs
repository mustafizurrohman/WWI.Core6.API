using Microsoft.AspNetCore.Builder;
using WWI.Core3.Middleware.ExceptionHandler;

namespace WWI.Core3.Core.ExtensionMethods
{
    /// <summary>
    /// Extension methods for Application Builder
    /// </summary>
    public static class ApplicationBuilderExtensions
    {
        /// <summary>
        /// Extension Method to use custom exception handler
        /// </summary>
        /// <param name="applicationBuilder">Application Builder</param>
        /// <returns></returns>
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseMiddleware<ExceptionHandler>();
        }

    }

}

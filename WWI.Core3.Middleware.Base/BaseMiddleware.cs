using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace WWI.Core3.Middleware.Base
{
    /// <summary>
    /// Base Middleware: All Middlewares inherit this
    /// </summary>
    public abstract class BaseMiddleware
    {
        /// <summary>
        /// Request delegate
        /// </summary>
        public RequestDelegate Next { get; }

        /// <summary>
        /// Instance of service provider
        /// </summary>
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="next"></param>
        /// <param name="serviceProvider"></param>
        protected BaseMiddleware(RequestDelegate next, IServiceProvider serviceProvider)
        {
            Next = next;
            _serviceProvider = serviceProvider;
        }

        /// <summary>
        /// Middleware implementation goes here
        /// Must be implemented by the middleware
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public abstract Task InvokeAsync(HttpContext context);
    }
}

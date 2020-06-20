// ***********************************************************************
// Assembly         : WWI.Core3.API
// Author           : Mustafizur Rohman
// Created          : 05-09-2020
//
// Last Modified By : Mustafizur Rohman
// Last Modified On : 05-17-2020
// ***********************************************************************
// <copyright file="BenchmarkAttribute.cs" company="WWI.Core3.API">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace WWI.Core3.API.ActionFilters
{

    /// <summary>
    /// Class BenchmarkAttribute. This class cannot be inherited.
    /// Implements the <see cref="Microsoft.AspNetCore.Mvc.Filters.ActionFilterAttribute" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Filters.ActionFilterAttribute" />
    public sealed class BenchmarkAttribute : ActionFilterAttribute
    {

        /// <summary>
        /// The timer
        /// </summary>
        private Stopwatch _timer = new Stopwatch();


        /// <summary>
        /// Executed before the start of execution
        /// </summary>
        /// <param name="context">The context.</param>
        /// <inheritdoc />
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _timer = Stopwatch.StartNew();
        }

        /// <summary>
        /// Executed after the end of execution
        /// </summary>
        /// <param name="context">The context.</param>
        /// <inheritdoc />
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            _timer.Stop();

            context.HttpContext.Response.Headers.Add("x-response-time", _timer.ElapsedMilliseconds + " ms");
        }

    }
}

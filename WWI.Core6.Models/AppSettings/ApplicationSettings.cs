using Microsoft.OpenApi.Models;

namespace WWI.Core6.Models.AppSettings
{

    /// <summary>
    /// Class ApplicationSettings.
    /// </summary>
    public class ApplicationSettings
    {
        /// <summary>
        /// Gets the open API information.
        /// </summary>
        /// <value>The open API information.</value>
        [UsedImplicitly]
        public OpenApiInfo OpenApiInfo { get; init; }

        /// <summary>
        /// Gets the performance options.
        /// </summary>
        /// <value>The performance options.</value>
        [UsedImplicitly]
        public PerformanceOptions PerformanceOptions { get; init; }

        /// <summary>
        /// Gets or sets the connection string.
        /// </summary>
        /// <value>The connection string.</value>
        [UsedImplicitly]
        public string ConnectionString { get; init; }

        /// <summary>
        /// 
        /// </summary>
        public MediatRPipelineOptions MediatRPipelineOptions { get; init; }
    }

}

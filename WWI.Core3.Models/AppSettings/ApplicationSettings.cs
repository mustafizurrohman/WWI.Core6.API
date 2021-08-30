using Microsoft.OpenApi.Models;

namespace WWI.Core3.Models.AppSettings
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
        public OpenApiInfo OpenApiInfo { get; set; }

        /// <summary>
        /// Gets the performance options.
        /// </summary>
        /// <value>The performance options.</value>
        public PerformanceOptions PerformanceOptions { get; set;  }

        /// <summary>
        /// Gets or sets the connection string.
        /// </summary>
        /// <value>The connection string.</value>
        public string ConnectionString { get; set; }
    }

}

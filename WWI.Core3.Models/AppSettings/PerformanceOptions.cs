using JetBrains.Annotations;

namespace WWI.Core3.Models.AppSettings
{
    /// <summary>
    /// Class PerformanceOptions.
    /// </summary>
    public class PerformanceOptions
    {
        /// <summary>
        /// Gets a value indicating whether [use response compression].
        /// </summary>
        /// <value><c>true</c> if [use response compression]; otherwise, <c>false</c>.</value>
        [UsedImplicitly]
        public bool UseResponseCompression { get; }

        /// <summary>
        /// Gets a value indicating whether [use exception handling middleware].
        /// </summary>
        /// <value><c>true</c> if [use exception handling middleware]; otherwise, <c>false</c>.</value>
        [UsedImplicitly]
        public bool UseExceptionHandlingMiddleware { get;  }

    }
}

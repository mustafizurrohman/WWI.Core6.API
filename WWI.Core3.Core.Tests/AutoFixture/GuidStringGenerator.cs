using System;
using System.Linq;

namespace WWI.Core3.Core.Tests.AutoFixture
{
    /// <summary>
    /// Class GuidStringGenerator.
    /// </summary>
    public static class GuidStringGenerator
    {
        /// <summary>
        /// Creates the anonymous.
        /// </summary>
        /// <returns>System.Char.</returns>
        public static char CreateAnonymous()
        {
            return new Guid().ToString().First();
        }
    }
}

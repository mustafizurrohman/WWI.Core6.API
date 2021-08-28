using System;

namespace WWI.Core3.Core.Tests.AutoFixture
{

    /// <summary>
    /// Class ConstrainedStringGenerator.
    /// </summary>
    public class ConstrainedStringGenerator
    {
        private readonly int _minimumLength;
        private readonly int _maximumLength;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConstrainedStringGenerator"/> class.
        /// </summary>
        /// <param name="minimumLength">The minimum length.</param>
        /// <param name="maximumLength">The maximum length.</param>
        /// <exception cref="ArgumentOutOfRangeException">...</exception>
        /// <exception cref="ArgumentOutOfRangeException">...</exception>
        public ConstrainedStringGenerator(int minimumLength, int maximumLength)
        {
            if (maximumLength < 0)
                throw new ArgumentOutOfRangeException(nameof(minimumLength));
            
            if (minimumLength > maximumLength)
                throw new ArgumentOutOfRangeException(nameof(maximumLength));
            
            this._minimumLength = minimumLength;
            this._maximumLength = maximumLength;
        }

        /// <summary>
        /// Createas the anonymous.
        /// </summary>
        /// <returns>System.String.</returns>
        public string CreateAnonymous()
        {
            var s = string.Empty;
            
            while (s.Length < this._minimumLength)
                s += GuidStringGenerator.CreateAnonymous();
                        
            if (s.Length > this._maximumLength)
                s = s.Substring(0, this._maximumLength);
            
            return s;
        }
    }

}

// ***********************************************************************
// Assembly         : WWI.Core3.Core
// Author           : Mustafizur Rohman
// Created          : 05-08-2020
//
// Last Modified By : Mustafizur Rohman
// Last Modified On : 05-16-2020
// ***********************************************************************
// <copyright file="RandomHelpers.cs" company="WWI.Core3.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Security.Cryptography;

namespace WWI.Core6.Core.Helpers
{
    /// <summary>
    /// Generates Cryptographically secure random numbers using RNGCryptoServiceProvider
    /// </summary>
    public static class RandomHelpers
    {

        #region -- Private Methods --

        /// <summary>
        /// The random number generator
        /// </summary>
        private static readonly RandomNumberGenerator RandomNumberGenerator;

        #endregion

        #region -- Constructor --

        /// <summary>
        /// Constructor
        /// </summary>
        static RandomHelpers()
        {
            RandomNumberGenerator = new RNGCryptoServiceProvider();
        }

        #endregion

        #region -- Implementation --

        /// <summary>
        /// Get the next random integer
        /// </summary>
        /// <param name="max">Max value to generate</param>
        /// <returns>Random [Int32]</returns>
        public static int Next(int max)
        {
            byte[] data = new byte[4];
            int[] result = new int[1];

            RandomNumberGenerator.GetBytes(data);
            Buffer.BlockCopy(data, 0, result, 0, 4);

            return Math.Abs(result[0] % max);
        }

        /// <summary>
        /// Returns a random number between 'min' and 'max'
        /// </summary>
        /// <param name="min">Min value to generate</param>
        /// <param name="max">Max value to generate</param>
        /// <returns>System.Int32.</returns>
        /// <exception cref="ArgumentException">Max must be greater than Min</exception>
        public static int Next(int min, int max)
        {

            if (max < min)
            {
                throw new ArgumentException("Max must be greater than Min");
            }

            // Generate a random number
            var randomNumber = Next(max);

            // Map (0 to max) to (min to max)
            var ratio = (max - (decimal)min) / max;

            decimal scaledNumber = min + randomNumber * ratio;

            return (int)Math.Floor(scaledNumber);

        }

        #endregion

    }
}

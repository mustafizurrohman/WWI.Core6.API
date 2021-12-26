// ***********************************************************************
// Assembly         : WWI.Core6.Core
// Author           : Mustafizur Rohman
// Created          : 05-08-2020
//
// Last Modified By : Mustafizur Rohman
// Last Modified On : 05-16-2020
// ***********************************************************************
// <copyright file="IntHelpers.cs" company="WWI.Core6.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Security.Cryptography;

namespace WWI.Core6.Core.Helpers
{
    /// <summary>
    /// Utility functions for integers
    /// </summary>
    public static class IntHelpers
    {

        /// <summary>
        /// Generates a cryptographically secure random number between min and max
        /// </summary>
        /// <param name="min">Lower bound</param>
        /// <param name="max">Upper bound</param>
        /// <returns>System.Int32.</returns>
        public static int GetRandomNumber(int min, int max)
        {
            RNGCryptoServiceProvider randomProvider = new();

            uint scale = uint.MaxValue;
            while (scale == uint.MaxValue)
            {
                // Get four random bytes.
                byte[] fourBytes = new byte[4];
                randomProvider.GetBytes(fourBytes);

                // Convert that into an uint.
                scale = BitConverter.ToUInt32(fourBytes, 0);
            }

            // Add min to the scaled difference between max and min.
            return (int)(min + (max - min) * (scale / (double)uint.MaxValue));
        }

        /// <summary>
        /// Generates a cryptographically secure random number between 0 and max
        /// </summary>
        /// <param name="max">Upper bound</param>
        /// <returns>System.Int32.</returns>
        public static int GetRandomNumber(int max)
        {
            return GetRandomNumber(0, max);
        }

    }
}

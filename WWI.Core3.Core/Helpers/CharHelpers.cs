// ***********************************************************************
// Assembly         : WWI.Core3.Core
// Author           : Mustafizur Rohman
// Created          : 05-08-2020
//
// Last Modified By : Mustafizur Rohman
// Last Modified On : 05-16-2020
// ***********************************************************************
// <copyright file="CharHelpers.cs" company="WWI.Core3.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace WWI.Core3.Core.Helpers
{
    /// <summary>
    /// Utility functions for characters
    /// </summary>
    public static class CharHelpers
    {

        /// <summary>
        /// Returns a random uppercase character
        /// </summary>
        /// <returns>System.Char.</returns>
        public static char GetRandomUppercaseCharacter()
        {
            var chars = @"ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            var randomNumber = IntHelpers.GetRandomNumber(chars.Length);

            return chars[randomNumber];
        }

        /// <summary>
        /// Returns a random lowercase character
        /// </summary>
        /// <returns>System.Char.</returns>
        public static char GetRandomLowercaseCharacter()
        {
            var chars = @"abcdefghijklmnopqrstuvwxyz";

            var randomNumber = IntHelpers.GetRandomNumber(chars.Length);

            return chars[randomNumber];
        }

        /// <summary>
        /// Returns a random lowercase character
        /// </summary>
        /// <returns>System.Char.</returns>
        public static char GetRandomSpecialCharacter()
        {
            var chars = @"!§$%&/()=_?#";

            var randomNumber = IntHelpers.GetRandomNumber(chars.Length);

            return chars[randomNumber];
        }

        /// <summary>
        /// Returns a random character
        /// </summary>
        /// <returns>System.Char.</returns>
        public static char GetRandomCharacter()
        {
            var chars = @"ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz!§$%&/()=_?#1234567890";

            var randomNumber = IntHelpers.GetRandomNumber(chars.Length);

            return chars[randomNumber];
        }

    }
}

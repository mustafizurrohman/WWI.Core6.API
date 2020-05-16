// ***********************************************************************
// Assembly         : WWI.Core3.Core
// Author           : Mustafizur Rohman
// Created          : 05-08-2020
//
// Last Modified By : Mustafizur Rohman
// Last Modified On : 05-08-2020
// ***********************************************************************
// <copyright file="StringHelpers.cs" company="WWI.Core3.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using WWI.Core3.Core.ExtensionMethods;

namespace WWI.Core3.Core.Helpers
{
    /// <summary>
    /// Helper functions for strings
    /// </summary>
    public static class StringHelpers
    {

        /// <summary>
        /// Returns a randomString of specified length
        /// </summary>
        /// <param name="length">The length.</param>
        /// <param name="printable">if set to <c>true</c> [printable].</param>
        /// <returns>System.String.</returns>
        /// <exception cref="ArgumentOutOfRangeException">length - Length must be positive!</exception>
        public static string GetRandomString(int length = 20, bool printable = true)
        {

            if (length < 0)
            {
                throw new ArgumentOutOfRangeException("length", "Length must be positive!");
            }

            // char.MinValue, char.MaxValue
            List<char> availableCharacters = new List<char>();


            if (!printable)
            {

                availableCharacters = Enumerable.Range(char.MinValue, char.MaxValue)
                                                .Select(x => (char)x)
                                                .Where(c => !char.IsControl(c))
                                                .ToList();
            }
            else
            {
                availableCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890+-*/!§$%&/()".ToList();
            }

            string generatedString = new string(Enumerable
                                                    .Repeat(availableCharacters, length)
                                                    .Select(s => s[RandomHelpers.Next(s.Count)]
                                               ).ToArray());

            return generatedString;
        }

        /// <summary>
        /// Gets the random password.
        /// </summary>
        /// <param name="length">The length.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="ArgumentException">Password must be at least 8 characters. - length</exception>
        public static string GetRandomPassword(int length = 10)
        {
            if (length < 8)
            {
                throw new ArgumentException("Password must be at least 8 characters.", nameof(length));
            }

            string password = string.Empty;

            password += CharHelpers.GetRandomLowercaseCharacter();
            password += CharHelpers.GetRandomUppercaseCharacter();
            password += CharHelpers.GetRandomSpecialCharacter();
            password += IntHelpers.GetRandomNumber(0, 9);

            for (int i = 4; i < length; i++)
            {
                password += CharHelpers.GetRandomCharacter();
            }

            password = ReplaceDuplicateCharacters(password);

            password = password.Randomize().Randomize();

            return password;
        }

        /// <summary>
        /// Replaces the duplicate characters in a string by a random character at the end
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>System.String.</returns>
        public static string ReplaceDuplicateCharacters(string input)
        {
            var stringWithoutDuplicates = input.RemoveDuplicates();

            if (stringWithoutDuplicates.Length == input.Length)
            {
                return input;
            }

            for (int i = 0; i < input.Length - stringWithoutDuplicates.Length; i++)
            {
                stringWithoutDuplicates += CharHelpers.GetRandomCharacter();
            }

            return ReplaceDuplicateCharacters(stringWithoutDuplicates);

        }

    }
}

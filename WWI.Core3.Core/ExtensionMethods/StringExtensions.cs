// ***********************************************************************
// Assembly         : WWI.Core3.Core
// Author           : Mustafizur Rohman
// Created          : 05-08-2020
//
// Last Modified By : Mustafizur Rohman
// Last Modified On : 05-16-2020
// ***********************************************************************
// <copyright file="StringExtensions.cs" company="WWI.Core3.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace WWI.Core3.Core.ExtensionMethods
{
    /// <summary>
    /// Extension methods for string
    /// </summary>
    public static class StringExtensions
    {

        /// <summary>
        /// Returns true of the provided string represents an email. Otherwise false.
        /// Does not actually verify the email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns><c>true</c> if [is valid email] [the specified email]; otherwise, <c>false</c>.</returns>
        public static bool IsValidEmail(this string email)
        {
            try
            {
                var address = new MailAddress(email);
                return address.Address == email;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Returns true of the provided string represents an email. Otherwise false.
        /// Does not actually verify the email.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <returns><c>true</c> if [is valid password] [the specified password]; otherwise, <c>false</c>.</returns>
        public static bool IsValidPassword(this string password)
        {
            if (password.Length < 8 || string.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            bool containsUppercase = password.Any(char.IsUpper);
            bool containsLowercase = password.Any(char.IsLower);
            bool containsDigit = password.Any(char.IsDigit);
            bool containsSpecialChars = password.ContainsSpecialCharacters();

            return containsUppercase && containsLowercase && containsDigit && containsSpecialChars;
        }

        /// <summary>
        /// Returns true of the provided string represents an email. Otherwise false.
        /// Does not actually verify the email.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <returns><c>true</c> if [contains special characters] [the specified password]; otherwise, <c>false</c>.</returns>
        /// TODO: Optimize this
        public static bool ContainsSpecialCharacters(this string password)
        {
            foreach (char c in password)
            {
                if (!char.IsLetterOrDigit(c))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Randomizes a string
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <returns>System.String.</returns>
        public static string Randomize(this string input)
        {
            return new string(input.ToCharArray().OrderBy(c => Guid.NewGuid()).ToArray());
        }

        /// <summary>
        /// Remove duplicate characters from a string
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <returns>System.String.</returns>
        public static string RemoveDuplicates(this string input)
        {
            return new string(input.ToCharArray().Distinct().ToArray());
        }

        /// <summary>
        /// Removes the consequtive spaces.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <returns>System.String.</returns>
        public static string RemoveConsequtiveSpaces(this string input)
        {
            return Regex.Replace(input, @"\s+", " ");
        }


    }
}

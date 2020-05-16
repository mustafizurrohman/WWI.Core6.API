// ***********************************************************************
// Assembly         : WWI.Core3.Models
// Author           : Mustafizur Rohman
// Created          : 05-15-2020
//
// Last Modified By : Mustafizur Rohman
// Last Modified On : 05-15-2020
// ***********************************************************************
// <copyright file="StringExtensions.cs" company="WWI.Core3.Models">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Text.RegularExpressions;

namespace WWI.Core3.Models.Utils
{
    /// <summary>
    /// Class StringExtensions.
    /// </summary>
    public static class StringExtensions
    {
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

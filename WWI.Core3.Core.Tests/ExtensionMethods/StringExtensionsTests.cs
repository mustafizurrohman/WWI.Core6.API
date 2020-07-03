// ***********************************************************************
// Assembly         : WWI.Core3.Core.Tests
// Author           : Mustafizur Rohman
// Created          : 07-03-2020
//
// Last Modified By : Mustafizur Rohman
// Last Modified On : 07-03-2020
// ***********************************************************************
// <copyright file="StringExtensionsTests.cs" company="WWI.Core3.Core.Tests">
//     Copyright (c) Personal. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Linq;
using WWI.Core3.Core.ExtensionMethods;
using Xunit;

namespace WWI.Core3.Core.Tests.ExtensionMethods
{

    /// <summary>
    /// Class StringExtensionsTests.
    /// </summary>
    public class StringExtensionsTests
    {

        #region -- Password Validation Tests -- 

        /// <summary>
        /// Defines the test method Verify_That_Valid_Passwords_Are_Correctly_Validated.
        /// </summary>
        /// <param name="password">The password.</param>
        [Theory]
        [InlineData("Aa1*df2d2")]
        public void Verify_That_Valid_Passwords_Are_Correctly_Validated(string password)
        {
            Assert.True(password.IsValidPassword());
        }

        /// <summary>
        /// Verifies the that invalid passwords are correctly invalidated.
        /// </summary>
        /// <param name="password">The password.</param>
        [Theory]
        [InlineData("abcd")]
        public void Verify_That_Invalid_Passwords_Are_Correctly_Invalidated(string password)
        {
            Assert.False(password.IsValidPassword());
        }

        #endregion

        #region -- Remove Consequitive Spaces Tests --

        /// <summary>
        /// Defines the test method Verify_That_Consequiteive_Spaces_Are_Corrected_Removed.
        /// </summary>
        /// <param name="inputString">The input string.</param>
        [Theory]
        [InlineData("Mustafizur       Rohman")]
        public void Verify_That_Consequiteive_Spaces_Are_Corrected_Removed(string inputString)
        {

            static int CountWords(string sourceString)
            {
                return sourceString
                    .Trim()
                    .Split(" ")
                    .Count(substring => !string.IsNullOrWhiteSpace(substring));
            }

            var outputString = inputString.RemoveConsequtiveSpaces();

            var wordsInSourceString = CountWords(inputString);
            var wordsInOutputString = CountWords(outputString);

            var spacesInOutputString = outputString.Count(s => s == ' ');

            Assert.Equal(wordsInSourceString, wordsInOutputString);
            Assert.Equal(wordsInOutputString, spacesInOutputString + 1);
        }

        #endregion



    }
}

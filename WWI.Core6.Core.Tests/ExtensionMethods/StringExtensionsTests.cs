// ***********************************************************************
// Assembly         : WWI.Core6.Core.Tests
// Author           : Mustafizur Rohman
// Created          : 07-03-2020
//
// Last Modified By : Mustafizur Rohman
// Last Modified On : 07-03-2020
// ***********************************************************************
// <copyright file="StringExtensionsTests.cs" company="WWI.Core6.Core.Tests">
//     Copyright (c) Personal. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using AutoFixture.Xunit2;
using FluentAssertions;
using WWI.Core6.Core.ExtensionMethods;
using Xunit;

namespace WWI.Core6.Core.Tests.ExtensionMethods;

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
    [Theory, AutoData]
    public void Verify_That_Consequiteive_Spaces_Are_Corrected_Removed(string inputString)
    {

        var outputString = inputString.RemoveConsequtiveSpaces();

        var wordsInOutputString = outputString.CountWords();

        var spacesInOutputString = outputString.Count(s => s == ' ');

        wordsInOutputString
            .Should()
            .Be(wordsInOutputString);

        wordsInOutputString
            .Should()
            .Be(spacesInOutputString + 1);

    }

    #endregion

    /// <summary>
    /// Defines the test method Verify_Method_CapitalizeEachWordOfSentence.
    /// </summary>
    /// <param name="inputString">The input string.</param>
    [Theory]
    [InlineData("this is a sentence which  needs to    be tested    . Test 12     543  ")]
    public void Verify_Method_CapitalizeEachWordOfSentence(string inputString)
    {
        var outputString = inputString.CapitalizeEachWordOfSentence();
    }



}
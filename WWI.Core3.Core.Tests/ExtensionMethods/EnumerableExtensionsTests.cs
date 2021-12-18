using AutoFixture;
using AutoFixture.Xunit2;
using FluentAssertions;
using WWI.Core3.Core.ExtensionMethods;
using Xunit;

namespace WWI.Core3.Core.Tests.ExtensionMethods
{

    /// <summary>
    /// Class EnumerableExtensionsTests.
    /// </summary>
    public class EnumerableExtensionsTests
    {

        /// <summary>
        /// Verifies the that shuffe does not delete elements.
        /// </summary>
        /// <param name="fixture"></param>
        /// <param name="numberOfElements">The number of elements.</param>
        [Theory, AutoData]
        public void Verify_That_Shuffe_Does_Not_Delete_Elements(IFixture fixture, int numberOfElements)
        {

            #region -- Arrange --

            var list = fixture.CreateMany<int>(numberOfElements).ToList();

            #endregion

            #region -- Act --

            var shuffledList = list.Shuffle().ToList();

            #endregion

            #region  -- Assert -- 

            list.Except(shuffledList).IsEmpty()
                .Should()
                .BeTrue();

            list.Count
                .Should()
                .Be(shuffledList.Count);

            #endregion

        }

        /// <summary>
        /// Tests the that get random element returns a random element.
        /// </summary>
        /// <param name="fixture"></param>
        /// <param name="numberOfElementsToGenerate">The number of elements to generate.</param>
        [Theory, AutoData]
        public void Test_That_GetRandomElement_Returns_A_Random_Element(IFixture fixture, int numberOfElementsToGenerate)
        {

            #region -- Arrange --

            var list = fixture.CreateMany<int>(numberOfElementsToGenerate).Distinct().ToList();

            var randomNumbers = new List<int>();

            #endregion

            #region -- Act --

            for (int i = 0; i < list.Count / 10; i++)
            {
                randomNumbers.Add(list.GetRandomShuffled());
            }

            randomNumbers = randomNumbers.Distinct().ToList();

            #endregion

            #region  -- Assert -- 

            // TODO: Write better assertions

            randomNumbers.Count
                .Should()
                .BeGreaterOrEqualTo(2);

            // 50% should be random
            randomNumbers.Count
                .Should()
                // ReSharper disable once PossibleLossOfFraction
                .BeGreaterOrEqualTo((int)(list.Count / 10 * 0.5));

            #endregion

        }

    }

}

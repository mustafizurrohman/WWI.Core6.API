using System.Linq;
using WWI.Core3.Core.ExtensionMethods;
using WWI.Core3.Core.Helpers;
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
        /// <param name="numberOfElements">The number of elements.</param>
        [Theory]
        [InlineData(100)]
        public void VerifyThatShuffeDoesNotDeleteElements(int numberOfElements)
        {
            var originalList = Enumerable.Range(0, numberOfElements)
                .Select(num => IntHelpers.GetRandomNumber(1, numberOfElements))
                .ToList();

            var shuffledList = originalList.Shuffle().ToList();

            var diff = originalList.Except(shuffledList).ToList();

            Assert.True(diff.Count == 0);
            Assert.True(diff.IsEmpty());

            Assert.True(originalList.Count == shuffledList.Count);
        }

    }

}

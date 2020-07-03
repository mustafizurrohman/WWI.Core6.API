using WWI.Core3.Core.ExtensionMethods;
using Xunit;

namespace WWI.Core3.Core.Tests.ExtensionMethods
{
    public class StringExtensionsTests
    {
        [Theory]
        [InlineData("Aa1*df2d2")]
        public void TestValidPasswords(string password)
        {
            Assert.True(password.IsValidPassword());
        }

    }
}

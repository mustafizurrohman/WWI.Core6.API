using System.Text.RegularExpressions;

namespace WWI.Core3.Models.Utils
{
    public static class StringExtensions
    {
        /// <summary>
        /// Removes the consequtive spaces.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <returns></returns>
        public static string RemoveConsequtiveSpaces(this string input)
        {
            return Regex.Replace(input, @"\s+", " ");
        }
    }
}

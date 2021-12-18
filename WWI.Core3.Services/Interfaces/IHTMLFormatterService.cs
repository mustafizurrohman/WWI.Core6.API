namespace WWI.Core3.Services.Interfaces
{
    /// <summary>
    /// Interface IHTMLFormatterService
    /// </summary>
    public interface IHTMLFormatterService
    {

        /// <summary>
        /// Generates the HTML document.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objectList">The object list.</param>
        /// <returns>System.String.</returns>
        string GenerateHtmlDocument<T>(IEnumerable<T> objectList);


        /// <summary>
        /// Generates the HTML document.
        /// </summary>
        /// <param name="htmlBody">The HTML body.</param>
        /// <returns>System.String.</returns>
        string GenerateHtmlDocument(string htmlBody);

        /// <summary>
        /// Formats as HTML table.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objectEnumerable">The object enumerable.</param>
        /// <returns>System.String.</returns>
        string FormatAsHtmlTable<T>(IEnumerable<T> objectEnumerable);

    }
}
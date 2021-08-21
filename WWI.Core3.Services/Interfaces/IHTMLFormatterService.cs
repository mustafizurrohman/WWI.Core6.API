using System.Collections.Generic;

namespace WWI.Core3.Services.Interfaces
{
    /// <summary>
    /// Interface IHTMLFormatterService
    /// </summary>
    public interface IHTMLFormatterService
    {
        /// <summary>
        /// Formats as HTML table.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objectList">The object list.</param>
        /// <returns>System.Byte[].</returns>
        byte[] FormatAsHTMLTable<T>(IEnumerable<T> objectList);
    }
}
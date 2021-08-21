using HtmlTableHelper;
using System.Collections.Generic;
using System.Text;
using WWI.Core3.Services.Interfaces;

namespace WWI.Core3.Services.Services
{
    /// <summary>
    /// Class HTMLFormatterService.
    /// Implements the <see cref="WWI.Core3.Services.Interfaces.IHTMLFormatterService" />
    /// </summary>
    /// <seealso cref="WWI.Core3.Services.Interfaces.IHTMLFormatterService" />
    public class HTMLFormatterService : IHTMLFormatterService
    {
        /// <summary>
        /// Formats as HTML table.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objectList">The object list.</param>
        /// <returns>System.Byte[].</returns>
        public byte[] FormatAsHTMLTable<T>(IEnumerable<T> objectList)
        {
            const string header =
                "<!DOCTYPE html>\r\n<html>\r\n<title>W3.CSS</title>\r\n<meta name=\"viewport\" content=\"width=device-width, initial-scale=1\">" + 
                "\r\n<link rel=\"stylesheet\" href=\"https://www.w3schools.com/w3css/4/w3.css\">\r\n<body>\r\n\r\n<div class=\"w3-container\">";

            string htmlBody = objectList.ToHtmlTable( 
                tableAttributes : new { @class = "w3-container w3-table w3-striped w3-bordered"} //this is dynamic type, support all attribute 
                ,trAttributes    : new { ID = "ID" }
                ,tdAttributes    : new { width = "120 px" }
                ,thAttributes    : new { @class = "dark-theme" }
            );

            return Encoding.ASCII.GetBytes(header + htmlBody + "</div>");

        }
    }
}

// ***********************************************************************
// Assembly         : WWI.Core6.Services
// Author           : Mustafizur Rohman
// Created          : 08-21-2021
//
// Last Modified By : Mustafizur Rohman
// Last Modified On : 08-28-2021
// ***********************************************************************
// <copyright file="HTMLFormatterService.cs" company="WWI.Core6.Services">
//     Copyright (c) Personal. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using HtmlTableHelper;

namespace WWI.Core6.Services.Services;

/// <summary>
/// Class HTMLFormatterService.
/// Implements the <see cref="IHTMLFormatterService" />
/// </summary>
/// <seealso cref="IHTMLFormatterService" />
public class HTMLFormatterService : IHTMLFormatterService
{
    /// <summary>
    /// Formats as HTML table.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="objectList">The object list.</param>
    /// <returns>System.Byte[].</returns>
    public string GenerateHtmlDocument<T>(IEnumerable<T> objectList)
    {
        string htmlBody = FormatAsHtmlTable(objectList);

        return GenerateHtmlDocument(htmlBody);
    }

    /// <summary>
    /// Generates the HTML document.
    /// </summary>
    /// <param name="htmlBody">The HTML body.</param>
    /// <returns>System.String.</returns>
    public string GenerateHtmlDocument(string htmlBody)
    {
        const string header =
            "<!DOCTYPE html>\r\n<html>\r\n<title>W3.CSS</title>\r\n<meta name=\"viewport\" content=\"width=device-width, initial-scale=1\">" + 
            "\r\n<link rel=\"stylesheet\" href=\"https://www.w3schools.com/w3css/4/w3.css\">\r\n<body>\r\n\r\n<div class=\"w3-container\">";
            
        return header + htmlBody + "</div>";
    }

    /// <summary>
    /// Formats as HTML table.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="objectEnumerable">The object enumerable.</param>
    /// <returns>System.String.</returns>
    public string FormatAsHtmlTable<T>(IEnumerable<T> objectEnumerable)
    {
        string htmlBody = objectEnumerable.ToHtmlTable( 
            tableAttributes : new { @class = "w3-container w3-table w3-striped w3-bordered"} //this is dynamic type, support all attribute 
            ,trAttributes    : new { ID = "ID" }
            ,tdAttributes    : new { width = "120 px" }
            ,thAttributes    : new { @class = "dark-theme" }
        );

        return htmlBody;
    }


}
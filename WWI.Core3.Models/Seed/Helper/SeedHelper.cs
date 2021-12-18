// ***********************************************************************
// Assembly         : WWI.Core3.Models
// Author           : Mustafizur Rohman
// Created          : 05-15-2020
//
// Last Modified By : Mustafizur Rohman
// Last Modified On : 05-15-2020
// ***********************************************************************
// <copyright file="SeedHelper.cs" company="WWI.Core3.Models">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using Serilog;
using System.IO;
using System.Text;

namespace WWI.Core3.Models.Seed.Helper
{

    /// <summary>
    /// Static class to help with generation of seed data
    /// </summary>
    public static class SeedHelper
    {

        #region -- Private Methods -- 

        /// <summary>
        /// The base path generated seed
        /// </summary>
        private const string BasePathGeneratedSeed = "../WWI.Core3.Models/Seed/Generated/";
        /// <summary>
        /// The base path
        /// </summary>
        private const string BasePath = "../WWI.Core3.Models/Seed/";

        #endregion

        /// <summary>
        /// Verifies if the seed file to be generated exists
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private static bool SeedGeneratedFileExists(string fileName)
        {
            return File.Exists(BasePathGeneratedSeed + fileName);
        }


        /// <summary>
        /// Gets the source file contents.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="ArgumentException">File does not exist.</exception>
        private static string GetSourceFileContents(string fileName)
        {
            if (!File.Exists(BasePath + fileName))
            {
                throw new ArgumentException("File does not exist.");
            }

            return File.ReadAllText(BasePath + fileName);
        }

        /// <summary>
        /// Gets the generated file contents.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="ArgumentException">File does not exist.</exception>
        private static string GetGeneratedFileContents(string fileName)
        {
            if (!File.Exists(BasePathGeneratedSeed + fileName))
            {
                throw new ArgumentException("File does not exist.");
            }

            return File.ReadAllText(BasePathGeneratedSeed + fileName);
        }

        /// <summary>
        /// Parses the source file.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>List&lt;T&gt;.</returns>
        public static List<T> ParseSourceFile<T>(string fileName)
        {
            var fileContents = GetSourceFileContents(fileName);

            return JsonConvert.DeserializeObject<List<T>>(fileContents);
        }

        /// <summary>
        /// Parses the generated file.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>List&lt;T&gt;.</returns>
        public static List<T> ParseGeneratedFile<T>(string fileName)
        {
            var fileContents = GetGeneratedFileContents(fileName);

            return JsonConvert.DeserializeObject<List<T>>(fileContents);
        }

        /// <summary>
        /// Saves the content of the generated file.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="contents">The contents.</param>
        private static void SaveGeneratedFileContent(string fileName, string contents)
        {
            File.WriteAllText(BasePathGeneratedSeed + fileName, contents, Encoding.UTF8);
        }

        /// <summary>
        /// Saves the or overwrite generated file.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <param name="contents">The contents.</param>
        /// <param name="overwrite">if set to <c>true</c> [overwrite].</param>
        public static void SaveOrOverwriteGeneratedFile(string filename, string contents, bool overwrite = false)
        {
            var fileExists = SeedGeneratedFileExists(filename);

            var save = !(fileExists || overwrite);

            if (!fileExists)
            {
                Log.Debug("Creating file because it does not exist.");
            }
            else
            {
                if (overwrite)
                {
                    Log.Debug($"Overwriting {filename} because overwrite is enabled.");
                }
            }

            if (save)
            {
                Log.Debug($"Saving {filename}");

                SaveGeneratedFileContent(filename, contents);
            }

        }



    }
}

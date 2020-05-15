using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
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

        private const string basePathGeneratedSeed = "../WWI.Core3.Models/Seed/Generated/";
        private const string basePath = "../WWI.Core3.Models/Seed/";

        #endregion

        /// <summary>
        /// Verifies if the seed file to be generated exists
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool SeedGeneratedFileExists(string fileName)
        {
            return File.Exists(basePathGeneratedSeed + fileName);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string GetSourceFileContents(string fileName)
        {
            if (!File.Exists(basePath + fileName))
            {
                throw new ArgumentException("File does not exist.");
            }

            return File.ReadAllText(basePath + fileName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string GetGeneratedFileContents(string fileName)
        {
            if (!File.Exists(basePathGeneratedSeed + fileName))
            {
                throw new ArgumentException("File does not exist.");
            }

            return File.ReadAllText(basePathGeneratedSeed + fileName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static List<T> ParseSourceFile<T>(string fileName)
        {
            var fileContents = GetSourceFileContents(fileName);

            return JsonConvert.DeserializeObject<List<T>>(fileContents);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static List<T> ParseGeneratedFile<T>(string fileName)
        {
            var fileContents = GetGeneratedFileContents(fileName);

            return JsonConvert.DeserializeObject<List<T>>(fileContents);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="contents"></param>
        public static void SaveGeneratedFileContent(string fileName, string contents)
        {
            File.WriteAllText(basePathGeneratedSeed + fileName, contents, Encoding.UTF8);

            return;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="contents"></param>
        /// <param name="overwrite"></param>
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

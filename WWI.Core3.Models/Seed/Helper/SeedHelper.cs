using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WWI.Core3.Models.Seed.Helper
{
    public static class SeedHelper
    {

        #region -- Private Methods -- 

        private const string basePathGeneratedSeed = "../WWI.Core3.Models/Seed/Generated/";
        private const string basePath = "../WWI.Core3.Models/Seed/";

        #endregion

        public static bool SeedSourceFileExists(string fileName)
        {
            return File.Exists(basePath + fileName);
        }

        public static bool GeneratedFileExists(string fileName)
        {
            return File.Exists(basePathGeneratedSeed + fileName);
        }

        public static string GetSourceFileContents(string fileName)
        {
            if (!File.Exists(basePath + fileName))
            {
                throw new ArgumentException("File does not exist.");
            }

            return File.ReadAllText(basePath + fileName);
        }

        public static string GetGeneratedFileContents(string fileName)
        {
            if (!File.Exists(basePathGeneratedSeed + fileName))
            {
                throw new ArgumentException("File does not exist.");
            }

            return File.ReadAllText(basePathGeneratedSeed + fileName);
        }

        public static List<T> ParseSourceFile<T>(string fileName)
        {
            var fileContents = GetSourceFileContents(fileName);

            return JsonConvert.DeserializeObject<List<T>>(fileContents);
        }

        public static List<T> ParseGeneratedFile<T>(string fileName)
        {
            var fileContents = GetGeneratedFileContents(fileName);

            return JsonConvert.DeserializeObject<List<T>>(fileContents);
        }

        public static void SaveGeneratedFileContent(string fileName, string contents)
        {
            File.WriteAllText(basePathGeneratedSeed + fileName, contents, Encoding.UTF8);

            return;
        }



    }
}

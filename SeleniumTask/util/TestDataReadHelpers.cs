using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace SeleniumTask.util
{
    public static class TestDataReadHelpers
    {
        public static List<T> GetRecords<T>(string fileName)
        {
            var dirName = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin"));
            var fileInfo = new FileInfo(dirName);
            var parentDirName = fileInfo?.FullName + "data\\";


            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                NewLine = Environment.NewLine,
                Delimiter = ","
            };

            using (var reader = new StreamReader(parentDirName + fileName))
            using (var csv = new CsvReader(reader, config))
            {
                return csv.GetRecords<T>().ToList();
            }
        }

        public static Dictionary<string, string> GetGenericCsvRecords(string fileName)
        {
            return GetRecords<GenericCsvRow>(fileName).ToDictionary((row) => row.Name, (row) => row.Value);
        }
    }
}

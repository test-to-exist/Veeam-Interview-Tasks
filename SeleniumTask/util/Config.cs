using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace SeleniumTask.util
{
    public class Config
    {

        public static string DefaultDriver => GetValue("defaultDriver");
        public static string BaseUrl => GetValue("baseUrl");
        public static string DefaultWaitForElement => GetValue("defaultWaitForElement");
        
        public static string[] DriverOptions =>
            GetArrayOfValues("driverOptions");

        public static string GetValue(string value)
        {
            var dirName = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin"));
            var fileInfo = new FileInfo(dirName);
            var parentDirName = fileInfo?.FullName;

            var builder = new ConfigurationBuilder()
            .SetBasePath(parentDirName)
            .AddJsonFile("appsettings.json");
            IConfigurationRoot root = builder.Build();
            return root[value];
        }

        public static string[] GetArrayOfValues(string value)
        {
            var dirName = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin"));
            var fileInfo = new FileInfo(dirName);
            var parentDirName = fileInfo?.FullName;

            var builder = new ConfigurationBuilder()
            .SetBasePath(parentDirName)
            .AddJsonFile("appsettings.json");
            return builder.Build().GetSection(value).Get<string[]>();
        }
    }
}

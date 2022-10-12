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

        private static IConfigurationRoot BuildConfig()
        {
            var dirName = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin"));
            var fileInfo = new FileInfo(dirName);
            var parentDirName = fileInfo?.FullName;

            var builder = new ConfigurationBuilder()
            .SetBasePath(parentDirName)
            .AddJsonFile("appsettings.json");
            return builder.Build();
        }

        public static string[] DriverOptions =>
            GetArrayOfValues("driverOptions");

        public static string GetValue(string value)
        {
            return BuildConfig()[value];
        }

        public static string[] GetArrayOfValues(string value)
        {
            return BuildConfig().GetSection(value).Get<string[]>();
        }
    }
}

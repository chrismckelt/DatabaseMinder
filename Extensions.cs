using System;
using System.IO;

namespace DatabaseMinder
{
    public static class Extensions
    {

        public static string ToFileName(this string databaseName, string extension = null)
        {
            return string.IsNullOrEmpty(extension) ? ($"{databaseName}_{DateTime.Now.ToString("yyyyMMdd")}") : ($"{databaseName}_{DateTime.Now.ToString("yyyyMMdd")}.{extension}");
        }

        public static string WithoutExtension(this string filepath)
        {
            return Path.GetFileNameWithoutExtension(filepath);
        }
    }
}

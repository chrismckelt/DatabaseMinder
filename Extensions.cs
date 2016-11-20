using System;
using System.IO;

namespace DatabaseMinder
{
    public static class Extensions
    {

        public static string ToFileName(this string databaseName, string extension = null, string dateTimeFormat = null)
        {
            string dateTime = DateTime.Now.ToString(dateTimeFormat ?? "yyyyMMdd_HH-mm-ss");

            return string.IsNullOrEmpty(extension) ?
                $"{databaseName}_{dateTime}" :
                $"{databaseName}_{dateTime}.{extension}";
        }

        public static string WithoutExtension(this string filepath)
        {
            return Path.GetFileNameWithoutExtension(filepath);
        }
    }
}

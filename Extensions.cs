using System.IO;

namespace DatabaseMinder
{
    public static class Extensions
    {
        public static string WithoutExtension(this string filepath)
        {
            return Path.GetFileNameWithoutExtension(filepath);
        }
    }
}

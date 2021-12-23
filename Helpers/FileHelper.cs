using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace StyleDemocracy
{
    public static class FileHelper
    {
        public static string ReadFile(this string fileName, [CallerFilePath] string filePath = "")
        {
            if (!String.IsNullOrWhiteSpace(filePath) && new FileInfo(filePath).Directory is DirectoryInfo directory)
            {
                return File.ReadAllText(Path.Combine(directory.FullName, fileName));
            }

            throw new ArgumentException("filepath missing", nameof(filePath));
        }
    }
}

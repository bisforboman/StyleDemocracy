using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace StyleDemocracy
{
    public static class FileHelper
    {
        public static string ReadFile(this string fileName, [CallerFilePath] string filePath = "")
        {
            if (!String.IsNullOrWhiteSpace(filePath))
            {
                return File.ReadAllText(Path.Combine(new FileInfo(filePath).Directory.FullName, fileName));
            }
            
            throw new ArgumentException("filepath missing", nameof(filePath));
        }
    }
}

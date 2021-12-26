using System;
using System.IO;

namespace StyleDemocracy
{
    public static class FileHelper
    {
        public static string ReadFile(this string fileName)
        {
            if (!String.IsNullOrWhiteSpace(fileName))
            {
                return File.ReadAllText(ToFilePath(fileName));
            }

            throw new ArgumentException("fileName missing", nameof(fileName));
        }

        public static void WriteFile(this string fileName, string contents)
        {
            if (!String.IsNullOrWhiteSpace(fileName))
            {
                File.WriteAllText(ToFilePath(fileName), contents);
                return;
            }

            throw new ArgumentException("fileName missing", nameof(fileName));
        }

        private static string ToFilePath(string fileName) => Path.Combine(Environment.CurrentDirectory, fileName);
    }
}

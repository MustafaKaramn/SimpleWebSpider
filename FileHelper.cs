using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Web_Spider
{
    public static class FileHelper
    {
        public static string PrepareOutputFolder(string basePath, string siteName)
        {
            string folder = Path.Combine(basePath, "outputs", siteName);
            Directory.CreateDirectory(folder);
            return folder;
        }

        public static void SavePage(string outputFolder, string url, string title, string pageSource)
        {
            string fileName = Slugify(url) + ".txt";
            string filePath = Path.Combine(outputFolder, fileName);

            string content = $"URL: {url}\nTitle: {title}\n\n{pageSource}";
            File.WriteAllText(filePath, content);
        }

        public static string Slugify(string url)
        {
            string safe = Regex.Replace(url, @"[^\w\-]", "-");
            safe = Regex.Replace(safe, @"-+", "-");
            return safe.Trim('-');
        }
    }
}

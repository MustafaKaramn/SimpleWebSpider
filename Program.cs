using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Threading;
using Web_Spider;

namespace Web_Spider
{
    class Program
    {
        static void Main()
        {
            string startUrl = "https://eksisozluk.com";
            HashSet<string> visitedUrls = new HashSet<string>();
            Queue<string> urlsToVisit = new Queue<string>();

            urlsToVisit.Enqueue(startUrl);

            string solutionDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string chromeDriverPath = System.IO.Path.Combine(solutionDirectory, "chromedriver");

            IWebDriver driver = new ChromeDriver(chromeDriverPath);
            driver.Manage().Window.Maximize();

            string siteName = new Uri(startUrl).Host;

            string outputFolder = FileHelper.PrepareOutputFolder(solutionDirectory, siteName);

            while (urlsToVisit.Count > 0)
            {
                string currentUrl = urlsToVisit.Dequeue();
                if (visitedUrls.Contains(currentUrl))
                    continue;

                try
                {
                    driver.Navigate().GoToUrl(currentUrl);
                    Thread.Sleep(200);

                    string title = driver.Title;
                    string pageSource = driver.PageSource;

                    visitedUrls.Add(currentUrl);

                    var links = driver.FindElements(By.TagName("a"));
                    foreach (var link in links)
                    {
                        string url = link.GetAttribute("href");
                        if (!string.IsNullOrEmpty(url) && url.StartsWith("https://eksisozluk.com") && !visitedUrls.Contains(url))
                        {
                            urlsToVisit.Enqueue(url);
                        }
                    }

                    FileHelper.SavePage(outputFolder, currentUrl, title, pageSource);
                    Console.WriteLine($"KAYDEDİLDİ: {currentUrl}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"HATA >> {currentUrl}: {ex.Message}");
                }
            }

            driver.Quit();
        }
    }
}
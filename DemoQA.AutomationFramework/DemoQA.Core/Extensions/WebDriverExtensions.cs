using DemoQA.Settings.Utils;
using OpenQA.Selenium;

namespace DemoQA.Core.Extensions
{
    public static class WebDriverExtensions
    {
        private static string GetScreenshotName(string fileName, ScreenshotImageFormat format) =>
            $@"{DateTime.Now:yyyy-MM-dd_HH-mm-ss}{"_" + fileName}.{format.ToString().ToLower()}";

        public static void GoToUrl(this IWebDriver webDriver, string url) => webDriver.Navigate().GoToUrl(url);

        public static string TakeScreenshot(this IWebDriver webDriver, string outputDirectory, string testName, ScreenshotImageFormat fileFormat = ScreenshotImageFormat.Png)
        {
            var screenshotName = GetScreenshotName(testName, fileFormat);
            var pathToSave = PathUtils.Combine(outputDirectory, screenshotName);

            ((ITakesScreenshot)webDriver).GetScreenshot().SaveAsFile(pathToSave, fileFormat);

            return pathToSave;
        }
    }
}

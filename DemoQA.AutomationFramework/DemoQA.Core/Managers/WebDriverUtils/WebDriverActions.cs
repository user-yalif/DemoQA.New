using DemoQA.Settings.Utils;
using OpenQA.Selenium;

namespace DemoQA.Core.Managers.WebDriverUtils
{
    public class WebDriverActions
    {
        private readonly IWebDriver _webDriver;

        public WebDriverActions(IWebDriver webDriver) => _webDriver = webDriver;
        private static string GetScreenshotName(string fileName, ScreenshotImageFormat format) =>
            $@"{DateTime.Now:yyyy-MM-dd_HH-mm-ss}{"_" + fileName}.{format.ToString().ToLower()}";

        public string TakeScreenshot(string outputDirectory, string testName, ScreenshotImageFormat fileFormat = ScreenshotImageFormat.Png)
        {
            var screenshotName = GetScreenshotName(testName, fileFormat);
            var pathToSave = PathUtils.Combine(outputDirectory, screenshotName);

            ((ITakesScreenshot)_webDriver).GetScreenshot().SaveAsFile(pathToSave, fileFormat);

            return pathToSave;
        }
    }
}

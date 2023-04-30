using DemoQA.Core.Extensions;
using OpenQA.Selenium;

namespace DemoQA.Core.Utils.WebDriverUtils
{
    public class WebDriverActions
    {
        private readonly IWebDriver _webDriver;

        public WebDriverActions(IWebDriver webDriver) => _webDriver = webDriver;

        public string TakeScreenshot(string outputDirectory, string testName, ScreenshotImageFormat fileFormat = ScreenshotImageFormat.Png) =>
            _webDriver.TakeScreenshot(outputDirectory, testName, fileFormat);
    }
}

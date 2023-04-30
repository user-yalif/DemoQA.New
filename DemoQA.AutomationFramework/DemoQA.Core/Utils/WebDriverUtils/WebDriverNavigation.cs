using DemoQA.Core.Extensions;
using OpenQA.Selenium;

namespace DemoQA.Core.Utils.WebDriverUtils
{
    public class WebDriverNavigation
    {
        private readonly IWebDriver _webDriver;

        public WebDriverNavigation(IWebDriver webDriver) => _webDriver = webDriver;

        public void GoToUrl(string url) => _webDriver.GoToUrl(url);
    }
}

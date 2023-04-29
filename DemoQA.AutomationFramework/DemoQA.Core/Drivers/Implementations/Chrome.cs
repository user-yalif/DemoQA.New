using DemoQA.Core.Drivers.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DemoQA.Core.Drivers.Implementations
{
    public sealed class Chrome : IDriver
    {
        private static ChromeOptions GetChromeOptions(string pathToDownloads)
        {
            var options = new ChromeOptions();

            options.AddArgument("--start-maximized");
            options.PageLoadStrategy = PageLoadStrategy.Normal;

            options.AddArgument("--disable-infobars");
            options.AddArgument("--disable-extensions");
            options.AddArgument("--no-sandbox");
            // Disable infobar "Chrome is being controlled by automated software"
            options.AddExcludedArgument("enable-automation");

            if (!string.IsNullOrEmpty(pathToDownloads))
            {
                options.AddUserProfilePreference("download.default_directory", pathToDownloads);
            }

            return options;
        }

        public IWebDriver SetUp(string pathToDriver, string downloadPath) =>
            new ChromeDriver(pathToDriver, GetChromeOptions(downloadPath));
    }
}

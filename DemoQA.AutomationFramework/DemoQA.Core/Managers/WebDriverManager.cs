using DemoQA.Core.Drivers.Implementations;
using DemoQA.Core.Logging;
using DemoQA.Core.Utils.WebDriverUtils;
using DemoQA.Settings.Utils;
using OpenQA.Selenium;
using static DemoQA.Settings.SettingsConfigurator;

namespace DemoQA.Core.Managers
{
    public abstract class WebDriverManager
    {
        private static readonly ThreadLocal<IWebDriver> ThreadDriver = new(true);

        private static string PathToDriver => PathUtils.ConfigureBaseDirectoryPath("");

        protected static IWebDriver WebDriver
        {
            get
            {
                if (ThreadDriver.Value == null)
                {
                    try
                    {
                        ThreadDriver.Value = new DriverFactory()
                                        .GetDriver(AppSettings.BrowserType)
                                        .SetUp(PathToDriver, PathToDownloads);

                        Logger.LogInfo($"WebDriver session ID: {((WebDriver)ThreadDriver.Value).SessionId} started");
                        return ThreadDriver.Value;
                    }
                    catch (WebDriverException ex)
                    {
                        throw new WebDriverException(ex.Message);
                    }
                }
                else
                {
                    return ThreadDriver.Value;
                }
            }
        }

        public static string PathToDownloads => PathUtils.ConfigureBaseDirectoryPath(AppSettings.Paths.DownloadsDirectory);

        public static void ReleaseDriver()
        {
            if (ThreadDriver?.Value is not null)
            {
                Logger.LogInfo($"WebDriver session ID: {((WebDriver)ThreadDriver.Value).SessionId} finished");
                ThreadDriver.Value.Quit();
                ThreadDriver.Value = null;

                Logger.LogInfo("WebDriver released");
            }
        }

        public static WebDriverNavigation Navigation => new(WebDriver);

        public static WebDriverActions Actions => new(WebDriver);
    }
}

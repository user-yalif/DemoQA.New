using OpenQA.Selenium;

namespace DemoQA.Core.Drivers.Interfaces
{
    public interface IDriver
    {
        IWebDriver SetUp(string pathToDriver, string pathToDownloads = null);
    }
}

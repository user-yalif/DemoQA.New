using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace DemoQA.Core.Managers.WebDriverUtils.Waiter
{
    public class Waiter
    {
        private readonly IWebDriver _webDriver;

        private static TimeSpan DefaultTimeout => TimeSpan.FromSeconds(20);

        private static TimeSpan SleepInterval => TimeSpan.FromMilliseconds(1000);

        public Waiter(IWebDriver driver) => _webDriver = driver;

        public BaseWaiter Wait() =>
            new(new WebDriverWait(new SystemClock(), _webDriver, DefaultTimeout, SleepInterval));
    }
}

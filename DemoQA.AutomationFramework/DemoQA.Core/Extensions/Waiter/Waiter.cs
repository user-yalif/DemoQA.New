using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace DemoQA.Core.Extensions.Waiter
{
    public static class Waiter
    {
        private static TimeSpan DefaultTimeout => TimeSpan.FromSeconds(20);

        private static TimeSpan SleepInterval => TimeSpan.FromMilliseconds(1000);

        public static BaseWaiter Wait(this IWebDriver webDriver) =>
            new(new WebDriverWait(new SystemClock(), webDriver, DefaultTimeout, SleepInterval));
    }
}

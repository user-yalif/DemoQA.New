using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace DemoQA.Core.Managers.WebDriverUtils.Waiter
{
    public class WaitBy
    {
        private readonly WebDriverWait _webDriverWait;
        private readonly By _locator;

        internal WaitBy(WebDriverWait waitDriverWait, By locator) =>
            (_webDriverWait, _locator) = (waitDriverWait, locator);

        public bool UntilAppeared() => _webDriverWait.Until(IsElementAppeared(_locator));

        private static Func<IWebDriver, bool> IsElementAppeared(By locator)
        {
            return webDriver =>
            {
                try
                {
                    webDriver.FindElement(locator);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            };
        }
    }
}

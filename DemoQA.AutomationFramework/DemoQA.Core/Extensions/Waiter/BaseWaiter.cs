using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace DemoQA.Core.Extensions.Waiter
{
    public class BaseWaiter
    {
        private readonly WebDriverWait _webDriverWait;

        internal BaseWaiter(WebDriverWait webDriverWait) => _webDriverWait = webDriverWait;

        public bool UntilCondition(Func<IWebDriver, bool> condition) => _webDriverWait.Until(condition);

        public WaitBy ForElement(By locator) => new(_webDriverWait, locator);

        public WaitWebElement ForElement(IWebElement webElement) => new(_webDriverWait, webElement);
    }
}

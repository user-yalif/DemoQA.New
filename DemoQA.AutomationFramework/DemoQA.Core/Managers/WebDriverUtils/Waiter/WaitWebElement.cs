using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace DemoQA.Core.Managers.WebDriverUtils.Waiter
{
    public class WaitWebElement
    {
        private readonly WebDriverWait _webDriverWait;
        private readonly IWebElement _webElement;

        internal WaitWebElement(WebDriverWait waitDriverWait, IWebElement element) =>
            (_webDriverWait, _webElement) = (waitDriverWait, element);

        public bool ToBeDisplayed() => _webDriverWait.Until(driver => _webElement.Displayed);
    }
}

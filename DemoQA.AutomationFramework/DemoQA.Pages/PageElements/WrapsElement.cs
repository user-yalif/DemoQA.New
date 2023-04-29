using OpenQA.Selenium;

namespace DemoQA.Pages.PageElements
{
    public abstract class WrapsElement : PageElement, IWrapsElement
    {
        public IWebElement WrappedElement { get; }

        protected WrapsElement(IWebElement webElement) : base(webElement)
        {
            WrappedElement = webElement;
        }
    }
}

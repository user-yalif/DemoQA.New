using OpenQA.Selenium;

namespace DemoQA.Pages.PageElements
{
    public class TextFieldElement : WrapsElement
    {
        public TextFieldElement(IWebElement webElement) : base(webElement)
        {
        }

        public string GetText() => WrappedElement.Text;
    }
}

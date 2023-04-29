using OpenQA.Selenium;

namespace DemoQA.Pages.PageElements
{
    public class InputElement : WrapsElement
    {
        public InputElement(IWebElement webElement) : base(webElement)
        {
        }

        public void ClearAndInput(string text, bool moveFocusAway = false)
        {
            if (moveFocusAway)
            {
                text += Keys.Tab;
            }

            WrappedElement.Clear();
            InputText(text);
        }

        public void InputText(string inputValue) => WrappedElement.SendKeys(inputValue);
    }
}

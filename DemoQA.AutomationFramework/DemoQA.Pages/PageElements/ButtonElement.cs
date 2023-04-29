using DemoQA.Settings.Utils;
using OpenQA.Selenium;

namespace DemoQA.Pages.PageElements
{
    public class ButtonElement : WrapsElement
    {
        public ButtonElement(IWebElement webElement) : base(webElement)
        {
        }

        public void Click() => WrappedElement.Click();

        public string ClickToDownload()
        {
            var fileName = WrappedElement.GetAttribute("download");
            WrappedElement.Click();

            return PathUtils.Combine(PathToDownloads, fileName);
        }

        public void UploadFile(string pathToFile) => WrappedElement.SendKeys(pathToFile);
    }
}

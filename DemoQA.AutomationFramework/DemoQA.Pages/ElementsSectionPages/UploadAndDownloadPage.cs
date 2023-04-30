using DemoQA.Core.Extensions.Waiter;
using DemoQA.Core.Logging;
using DemoQA.Core.Utils;
using DemoQA.Pages.PageElements;
using DemoQA.Settings.Utils;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace DemoQA.Pages.ElementsSectionPages
{
    public class UploadAndDownloadPage : BasePage
    {
        private const string UploadedFileLocator = "p#uploadedFilePath";

        [FindsBy(How.XPath, "//a[@id='downloadButton' and normalize-space()='Download']")]
        private ButtonElement DownloadButton { get; set; }

        [FindsBy(How.XPath, "//input[@id='uploadFile']")]
        private ButtonElement UploadButton { get; set; }

        [FindsBy(How.CssSelector, UploadedFileLocator)]
        private TextFieldElement UploadedFilePath { get; set; }

        public string DownloadFile()
        {
            var pathToFile = DownloadButton.ClickToDownload();
            var fileName = PathUtils.GetFileName(pathToFile);

            Logger.LogInfo("Start {0} file downloading", fileName);

            WebDriver.Wait().UntilCondition(driver => FileUtils.Exists(pathToFile));

            Logger.LogInfo("File {0} was downloaded", fileName);

            return pathToFile;
        }

        public UploadAndDownloadPage UploadFile(string pathToFile)
        {
            Logger.LogInfo("Start {0} file uploading", pathToFile);

            UploadButton.UploadFile(pathToFile);

            return this;
        }

        public string GetUploadedFileOutputPath()
        {
            Logger.LogInfo("Try to get uploaded file path");
            var uploadedFile = By.CssSelector(UploadedFileLocator);

            WebDriver.Wait().ForElement(uploadedFile).UntilAppeared();

            return UploadedFilePath.GetText();
        }
    }
}

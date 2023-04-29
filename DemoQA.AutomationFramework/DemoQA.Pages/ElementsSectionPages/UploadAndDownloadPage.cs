using DemoQA.Core.Logging;
using DemoQA.Pages.PageElements;
using DemoQA.Settings.Utils;
using SeleniumExtras.PageObjects;

namespace DemoQA.Pages.ElementsSectionPages
{
    public class UploadAndDownloadPage : BasePage
    {
        private const string UploadedFileOutputLocator = "p#uploadedFilePath";

        [FindsBy(How.XPath, "//a[@id='downloadButton' and normalize-space()='Download']")]
        private ButtonElement DownloadButton { get; set; }

        [FindsBy(How.XPath, "//input[@id='uploadFile']")]
        private ButtonElement UploadButton { get; set; }

        [FindsBy(How.CssSelector, UploadedFileOutputLocator)]
        private TextFieldElement UploadedFilePath { get; set; }

        public string DownloadFile()
        {
            var pathToFile = DownloadButton.ClickToDownload();
            var fileName = PathUtils.GetFileName(pathToFile);

            Logger.LogInfo("Start {0} file downloading", fileName);

            // TODO: Implement waiter
            // Waiter.Wait().UntilCondition(driver => FileUtils.Exists(pathToFile));

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

            // TODO: Implement waiter
            // Waiter.Wait().ForElement(UploadedFileOutputLocator).UntilAppeared();

            return UploadedFilePath.GetText();
        }
    }
}

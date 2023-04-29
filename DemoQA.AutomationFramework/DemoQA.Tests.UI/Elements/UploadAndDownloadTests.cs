using DemoQA.Core.Utils;
using DemoQA.Settings.Utils;
using DemoQA.Tests.Navigation.LeftPanel;
using NUnit.Framework;

namespace DemoQA.Tests.Elements
{
    public class UploadAndDownloadTests : BaseTest
    {
        [Test]
        public void DownloadFileTest()
        {
            var pathToFile = LeftPanel.Elements.UploadAndDownload()
                .DownloadFile();
            var fileName = PathUtils.GetFileName(pathToFile);

            FileInfo fileInfo = new(pathToFile);

            Assert.Multiple(() =>
            {
                Assert.That(fileInfo.Length, Is.EqualTo(4096), "Wrong file size");
                Assert.That(fileInfo.Name, Is.EqualTo(fileName), "Wrong file name");
                Assert.That(fileInfo.FullName, Is.EqualTo(pathToFile), "Wrong path to file");
            });
        }

        [Test]
        [Ignore("Test Data needs to be implemented")]
        public void UploadFileTest()
        {
            // TODO: Implement test data (DI?)
            var pathToFile = /*PathUtils.ConfigureBaseDirectoryPath(AppSettings.TestData.JpegFileToUpload.Split("\\"))*/ string.Empty;

            var uploadedFilePath = LeftPanel.Elements.UploadAndDownload()
                .UploadFile(pathToFile)
                .GetUploadedFileOutputPath();

            Assert.That(uploadedFilePath, Is.EqualTo(@"C:\fakepath\sampleFile.jpeg"), "Wrong uploaded path");
        }

        [TearDown]
        public void CleanTests()
        {
            if (nameof(UploadAndDownloadTests.DownloadFileTest) == TestName)
            {
                FileUtils.RemoveAll(PathToDownloads);
            }
        }
    }
}

using DemoQA.Core.Logging;
using DemoQA.Core.Managers;
using DemoQA.Core.Utils;
using DemoQA.Settings.Utils;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using static DemoQA.Settings.SettingsConfigurator;

namespace DemoQA.Tests
{
    public class BaseTest
    {
        private TestStatus TestStatus => TestContext.CurrentContext.Result.Outcome.Status;

        protected string TestName => TestContext.CurrentContext.Test.MethodName;

        private static string PathToScreenshots => PathUtils.ConfigureBaseDirectoryPath(AppSettings.Paths.ScreenshotsOutput);

        [SetUp]
        public void SetUpTest()
        {
            Logger.LogInfo("{0} test started", TestName);
            WebDriverManager.Navigation.GoToUrl(AppSettings.BaseUrl);

            Logger.LogInfo("Navigate to {0}", AppSettings.BaseUrl);
        }

        [TearDown]
        public void DisposeTest()
        {
            Logger.LogInfo("{0} test finished with status {1}", TestName, TestStatus.ToString().ToUpper());

            try
            {
                if (TestStatus == TestStatus.Failed)
                {
                    DirectoryUtils.CreateIfNotExist(PathToScreenshots);
                    var screenshotName = WebDriverManager.Action.TakeScreenshot(PathToScreenshots, TestName);
                    Logger.LogInfo($"Screenshot taken {screenshotName}");
                }
            }
            catch (SystemException ex)
            {
                throw new SystemException("One of posible exceptions arose."
                    + Environment.NewLine
                    + $"Output directory {PathToScreenshots} could not be created."
                    + Environment.NewLine
                    + "Screenshot could not be taken."
                    + $"Message: {ex.Message}");
            }
            finally
            {
                WebDriverManager.ReleaseDriver();
            }
        }
    }
}

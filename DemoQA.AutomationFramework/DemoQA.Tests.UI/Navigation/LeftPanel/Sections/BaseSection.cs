using DemoQA.Core.Logging;
using DemoQA.Core.Managers;
using DemoQA.Tests.Navigation.LeftPanel.Interfaces;
using static DemoQA.Settings.SettingsConfigurator;

namespace DemoQA.Tests.Navigation.LeftPanel.Sections
{
    public class BaseSection : ILeftPanelSection
    {
        protected override TPage NavigateTo<TPage>(string path)
        {
            var url = new UriBuilder(AppSettings.BaseUrl)
            {
                Path = path
            }.Uri.AbsoluteUri;

            Logger.LogInfo($"Redirected to {url}");
            WebDriverManager.Navigation.GoToUrl(url);

            return new TPage();
        }
    }
}

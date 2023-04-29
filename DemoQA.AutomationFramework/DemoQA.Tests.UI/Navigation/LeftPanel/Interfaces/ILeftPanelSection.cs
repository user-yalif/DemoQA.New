using DemoQA.Pages;

namespace DemoQA.Tests.Navigation.LeftPanel.Interfaces
{
    public abstract class ILeftPanelSection
    {
        protected abstract TPage NavigateTo<TPage>(string path) where TPage : BasePage, new();
    }
}

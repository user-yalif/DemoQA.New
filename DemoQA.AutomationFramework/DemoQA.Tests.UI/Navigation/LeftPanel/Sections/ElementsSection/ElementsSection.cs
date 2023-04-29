using DemoQA.Pages.ElementsSectionPages;

namespace DemoQA.Tests.Navigation.LeftPanel.Sections.ElementsSection
{
    public class ElementsSection : BaseSection
    {
        public TextBoxPage TextBox() => NavigateTo<TextBoxPage>("text-box");

        public UploadAndDownloadPage UploadAndDownload() => NavigateTo<UploadAndDownloadPage>("upload-download");
    }
}

using DemoQA.Settings.Enums;

namespace DemoQA.Settings.Models
{
    public class AppSettingsModel
    {
        public string BaseUrl { get; set; }

        public BrowserType BrowserType { get; set; }

        public PathsModel Paths { get; set; }

        public class PathsModel
        {
            public string ScreenshotsOutput { get; set; }

            public string DownloadsDirectory { get; set; }
        }
    }
}

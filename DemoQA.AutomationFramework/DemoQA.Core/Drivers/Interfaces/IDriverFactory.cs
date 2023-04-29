using DemoQA.Settings.Enums;

namespace DemoQA.Core.Drivers.Interfaces
{
    public abstract class IDriverFactory
    {
        public abstract IDriver GetDriver(BrowserType browser);
    }
}

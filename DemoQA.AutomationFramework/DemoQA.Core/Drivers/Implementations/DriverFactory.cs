using DemoQA.Core.Drivers.Interfaces;
using DemoQA.Settings.Enums;

namespace DemoQA.Core.Drivers.Implementations
{
    public sealed class DriverFactory : IDriverFactory
    {
        public override IDriver GetDriver(BrowserType browserType)
        {
            return browserType switch
            {
                BrowserType.Chrome => new Chrome(),
                _ => throw new PlatformNotSupportedException($"{browserType} browser is not supported!")
            };
        }
    }
}

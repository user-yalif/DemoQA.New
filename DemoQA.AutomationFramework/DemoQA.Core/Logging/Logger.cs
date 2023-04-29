using DemoQA.Settings.Utils;
using Serilog;
using Serilog.Events;

namespace DemoQA.Core.Logging
{
    public static class Logger
    {
        private static string PathToLogFile => PathUtils.ConfigureBaseDirectoryPath("Logs", "log_.log");

        static Logger() => Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .MinimumLevel.Override("System", LogEventLevel.Warning)
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .Enrich.FromLogContext()
                .Enrich.WithThreadId()
                .WriteTo.Console(outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff}] [{ThreadId}] [{Level:u3}] {Message:lj}{NewLine}{Exception}")
                .WriteTo.File(path: PathToLogFile,
                              outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff}] [{ThreadId}] [{Level:u3}] {Message:lj}{NewLine}{Exception}",
                              rollingInterval: RollingInterval.Day,
                              rollOnFileSizeLimit: true,
                              fileSizeLimitBytes: 512000,
                              shared: true)
                .CreateLogger();

        public static void LogInfo(string message) => Log.Logger.Information(message);

        public static void LogInfo(string message, params object[] args) => Log.Logger.Information(message, args);

        public static void LogWarn(string message) => Log.Logger.Warning(message);

        public static void LogWarn(string message, params object[] args) => Log.Logger.Warning(message, args);

        public static void LogError(string message) => Log.Logger.Error(message);

        public static void LogError(string message, params object[] args) => Log.Logger.Error(message, args);
    }
}

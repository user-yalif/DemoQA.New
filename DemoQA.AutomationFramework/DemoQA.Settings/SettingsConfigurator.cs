using System.Text.Json;
using System.Text.Json.Serialization;
using DemoQA.Settings.Models;
using DemoQA.Settings.Utils;

namespace DemoQA.Settings
{
    public static class SettingsConfigurator
    {
        private static string PathToEnvironment => @"environment.json";

        private static string PathToAppSettings => PathUtils.Combine("Files", "appsettings.{0}.json");

        private static readonly JsonSerializerOptions _serializerOptions = new()
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            WriteIndented = true,
            Converters = { new JsonStringEnumConverter() },
        };

        private static string GetEnvironment()
        {
            var env = File.ReadAllText(PathToEnvironment);

            return JsonSerializer.Deserialize<EnvironmentModel>(env, _serializerOptions).Environment.ToString().ToUpper();
        }

        private static AppSettingsModel GetAppSettings()
        {
            var environment = GetEnvironment();
            var appSettings = File.ReadAllText(string.Format(PathToAppSettings, environment));

            return JsonSerializer.Deserialize<AppSettingsModel>(appSettings, _serializerOptions);
        }

        public static AppSettingsModel AppSettings { get; } = GetAppSettings();
    }
}

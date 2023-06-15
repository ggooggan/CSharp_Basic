using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace OptionTestProject
{
    public class AppSettings
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        public static async void SaveChanged(AppSettings appSettings)
        {
            using FileStream stream = new FileStream("appsettings.json", FileMode.Create);
            using StreamWriter writer = new StreamWriter(stream);
            await writer.WriteAsync(JsonSerializer.Serialize(appSettings));
        }
    }
}

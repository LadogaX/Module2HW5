using System.IO;
using Module2HW5.Models;
using Module2HW5.Services.Abstractions;
using Newtonsoft.Json;

namespace Module2HW5.Services
{
    public class ConfigService : IConfigService
    {
        public ConfigService()
        {
            Config = new Config();
            LoadConfig();
        }

        public Config Config { get; set; }

        public void LoadConfig()
        {
            var configFile = File.ReadAllText("config.json");
            Config = JsonConvert.DeserializeObject<Config>(configFile);

            if (Config.CountLogFilesInFolder == 0)
            {
                Config.CountLogFilesInFolder = 3;
                SaveConfig();
            }

            if (Config.LogFolderPath == null)
            {
                Config.LogFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "Logs");
                SaveConfig();
            }
        }

        public void SaveConfig()
        {
            var json = JsonConvert.SerializeObject(Config);
            File.WriteAllText("config.json", json);
        }
    }
}

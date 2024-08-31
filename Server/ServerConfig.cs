using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public static class ServerConfig
    {
        public static string AppName { get; private set; }
        public static string Version { get; private set; }
        public static string ServerIP { get; private set; }

        static ServerConfig()
        {
            try
            {
                LoadConfig();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading configuration: {ex.Message}");
                throw;
            }
        }

        private static void LoadConfig()
        {
            // Adjust path if necessary
            var configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "serversettings.Development.json");

            if (File.Exists(configPath))
            {
                var json = File.ReadAllText(configPath);
                dynamic config = JsonConvert.DeserializeObject(json);

                Version = config.Version;
                ServerIP = config.ServerIP;
                AppName = config.AppName;
            }
            else
            {
                // Handle the case where the file does not exist
                throw new FileNotFoundException($"Configuration file '{configPath}' not found.");
            }
        }
    }
}

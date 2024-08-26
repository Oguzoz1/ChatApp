﻿using Newtonsoft.Json;
using System;
using System.IO;

namespace LauncherClient
{
    public static class AppConfig
    {
        public static string Version { get; private set; }
        public static string ServerIP { get; private set; }

        static AppConfig()
        {
            try
            {
                LoadConfig();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it
                Console.WriteLine($"Error loading configuration: {ex.Message}");
                throw;
            }
        }

        public static void LoadConfig()
        {
            // Adjust path if necessary
            var configFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appsettings.Development.json");

            if (File.Exists(configFilePath))
            {
                var json = File.ReadAllText(configFilePath);
                dynamic config = JsonConvert.DeserializeObject(json);

                Version = config.Version;
                ServerIP = config.ServerIP;
            }
            else
            {
                // Handle the case where the file does not exist
                throw new FileNotFoundException($"Configuration file '{configFilePath}' not found.");
            }
        }
    }
}
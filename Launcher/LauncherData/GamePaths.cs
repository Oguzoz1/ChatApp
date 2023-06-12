using System.IO;
using System;

namespace LauncherClient.LauncherData
{

    public class GamePaths
    {
        public string ExecutableFile;
        public string GamesDirectory;
        public string GameVersionFile;

        public GamePaths(string Version)
        {
            GamesDirectory = Path.Combine(Environment.CurrentDirectory, "Versions");
            GameVersionFile = Path.Combine(GamesDirectory, $"ver{Version}");
            ExecutableFile = Path.Combine(GameVersionFile, $"ver{Version}");
        }
    }
}

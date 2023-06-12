using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LauncherClient.LauncherData
{
    public class VersionManager
    {
        public Dictionary<string, string> VersionLinkPairs;

        private MainWindow _windowClass;
        public VersionManager(MainWindow WindowClass)
        {
            this._windowClass = WindowClass;
            Initialize();
        }

        private void Initialize()
        {

        }
    }
}

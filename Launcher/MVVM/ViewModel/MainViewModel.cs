using LauncherClient.MVVM.Core;
using LauncherClient.Net;

namespace LauncherClient.MVVM.ViewModel
{
    class MainViewModel
    {
        public RelayCommand ConnectToServerCommand { get; private set; }
        private Server _server;

        public string Username { get; set; }
        public MainViewModel()
        {
            _server = new Server();
            ConnectToServerCommand = new RelayCommand(o => _server.ConnectServer(Username),
                o => !string.IsNullOrEmpty(Username));
        }
    }
}

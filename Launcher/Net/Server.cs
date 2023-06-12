using LauncherClient.Net.IO;
using System;
using System.Net.Sockets;

namespace LauncherClient.Net
{
    class Server
    {
        private TcpClient _client;
        public Server()
        {
            _client = new TcpClient();
        }

        public void ConnectServer(string username)
        {
            //Set your local
            if (!_client.Connected)
            {
                _client.Connect("127.0.0.1", 8000);

                PacketBuilder connectPacket = new PacketBuilder();
                connectPacket.WriteOpCode(0);
                connectPacket.WriteString(username);
                _client.Client.Send(connectPacket.GetPacketBytes());
            }
        }
    }
}

using LauncherClient.Net.IO;
using System;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace LauncherClient.Net
{
    class Server
    {
        public PacketReader PacketReader;
        private TcpClient _client;

        public event Action connectedEvent;
        

        public Server()
        {
            _client = new TcpClient();
        }

        public void ConnectServer(string username)
        {
            //Set your local
            if (!_client.Connected)
            {
                //Connect to local
                _client.Connect("127.0.0.1", 8000);
                //Packet reader reads the current Network stream of the client
                PacketReader = new PacketReader(_client.GetStream());
                PacketBuilder connectPacket = new PacketBuilder();

                if (!string.IsNullOrEmpty(username))
                {
                connectPacket.WriteOpCode(0);
                connectPacket.WriteMessage(username);
                _client.Client.Send(connectPacket.GetPacketBytes());
                }
                ReadPackets();
            }
        }
        private void ReadPackets()
        {
            //Offload to a different thread to not deadlock
            //Clients reading data sent by server.
            Task.Run(() =>
            {
                while (true)
                {
                    byte opcode = PacketReader.ReadByte();
                    switch (opcode)
                    {
                        //Invoke connection event.
                        case 1:
                            connectedEvent?.Invoke();
                            break;
                    }

                }
            });
        }
        public void SendMessageToServer(string message)
        {
            PacketBuilder messagePacket = new PacketBuilder();

            messagePacket.WriteOpCode(5);
            messagePacket.WriteMessage(message);
            _client.Client.Send(messagePacket.GetPacketBytes());
        }
    }
}

using LauncherClient.Net.IO;
using System;
using System.Diagnostics;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace LauncherClient.Net
{
    //Send data to server on this class.
    //This class also reads packets that are received from the server.
    class Server
    {
        public PacketReader PacketReader;
        private TcpClient _client;

        public event Action connectedEvent;
        public event Action msgReceivedEvent;
        public event Action disconnectedEvent;
        public event Action versionReceivedEvent;

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
                //_client.Connect("34.141.136.120", 6062);
                _client.Connect(AppConfig.ServerIP, 6062);


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
                        //Invoke receive event.
                        case 5:
                            msgReceivedEvent?.Invoke();
                            break;
                        //Invoke disconnection event.
                        case 10:
                            disconnectedEvent?.Invoke();
                            break;
                        case 15:
                            versionReceivedEvent?.Invoke();
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

        internal void SendVersionToServer(string version)
        {
            PacketBuilder versionPacket = new PacketBuilder();
            versionPacket.WriteOpCode(15);
            versionPacket.WriteMessage(version);
            _client.Client.Send(versionPacket.GetPacketBytes());
        }
    }
}

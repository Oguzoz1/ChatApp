using LauncherClient.Net.IO;
using System;
using System.IO;
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

        private const int KeepAliveTime = 30000; // 30 seconds
        private const int KeepAliveInterval = 10000; // 10 seconds
        public Server()
        {
            _client = new TcpClient();
            ConfigureKeepAlive(_client.Client);
        }

        public void ConnectServer(string username)
        {
            if (!_client.Connected)
            {
                try
                {
                    _client.Connect(AppConfig.ServerIP, 6062);
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
                catch (Exception ex)
                {
                    Console.WriteLine($"Error connecting to server: {ex.Message}");

                    // Reconnection Handle Here
                }
            }
        }
        private void ReadPackets()
        {
            Task.Run(() =>
            {
                try
                {
                    while (true)
                    {
                        byte opcode = PacketReader.ReadByte();
                        switch (opcode)
                        {
                            case 1:
                                connectedEvent?.Invoke();
                                break;
                            case 5:
                                msgReceivedEvent?.Invoke();
                                break;
                            case 10:
                                disconnectedEvent?.Invoke();
                                break;
                            case 15:
                                versionReceivedEvent?.Invoke();
                                break;
                        }
                    }
                }
                catch (IOException ex)
                {
                    Console.WriteLine($"Disconnected: {ex.Message}");
                    disconnectedEvent?.Invoke();
                }
                catch (SocketException ex)
                {
                    Console.WriteLine($"Socket error: {ex.Message}");
                    disconnectedEvent?.Invoke();
                }
                finally
                {
                    _client?.Close();
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

        private void ConfigureKeepAlive(Socket socket)
        {
            // Enable keep-alive
            socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, true);

            // Configure keep-alive parameters
            byte[] keepAliveParams = new byte[12]; //Array stores keep-alive configuration
            BitConverter.GetBytes(1).CopyTo(keepAliveParams, 0); // Enable keep-alive (non-zero)
            BitConverter.GetBytes(KeepAliveTime).CopyTo(keepAliveParams, 4); // Initial keep-alive time
            BitConverter.GetBytes(KeepAliveInterval).CopyTo(keepAliveParams, 8); // Keep-alive interval

            socket.IOControl(IOControlCode.KeepAliveValues, keepAliveParams, null);
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

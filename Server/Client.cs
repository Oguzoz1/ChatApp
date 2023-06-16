using Server.Net.IO;
using System;
using System.Net.Sockets;

namespace Server
{
    class Client
    {
        public string Username { get; set; }
        public Guid UID{ get; set; }
        public TcpClient ClientSocket{ get; set; }
        private PacketReader _packetReader;
        public Client(TcpClient client)
        {
            ClientSocket = client;
            UID = Guid.NewGuid();
            _packetReader = new PacketReader(ClientSocket.GetStream());

            if (_packetReader == null) return;
            byte opcode = _packetReader.ReadByte();

            if (opcode != 0)
            {
                ClientSocket.Close();
                return;
            }


            Username = _packetReader.ReadMessage();
            Console.WriteLine($"[{DateTime.Now}]: Client has connected with the username: {Username}");
        }

        void Process()
        {
            while (true)
            {
                try
                {
                    byte opcode = _packetReader.ReadByte();
                    switch (opcode)
                    {
                        case 5:
                            string msg = _packetReader.ReadMessage();
                            Console.WriteLine($"[{DateTime.Now}]: Message received! {msg}");
                            Program.BroadcastMessage(msg);
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("");
                    throw;
                }
            }
        }
    }
}

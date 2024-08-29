using Server.Net.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    class Program
    {
        private static TcpListener _listener;
        private static string _currentVersion = "1.0.0"; 

        static void Main(string[] args)
        {
            ClientManager.Users = new List<Client>();
            _listener = new TcpListener(IPAddress.Any, 6062);
            _listener.Start();

            Console.WriteLine("Server is started");
            while (true)
            {
                try
                {
                    // Accept a new client connection
                    TcpClient tcpClient = _listener.AcceptTcpClient();
                    Client client = new Client(tcpClient);
                    ClientManager.Users.Add(client);

                    // Broadcast the connection to everyone on the server
                    BroadcastManager.BroadcastConnection();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error accepting client connection: {ex.Message}");
                }
            }
        }

        public static void OnVersionRequest(Client client)
        {
            SendVersionToClient(client, _currentVersion);
        }

        static void SendVersionToClient(Client client, string version)
        {
            PacketBuilder versionPacket = new PacketBuilder();
            versionPacket.WriteOpCode(15); 
            versionPacket.WriteMessage(version);
            client.ClientSocket.Client.Send(versionPacket.GetPacketBytes());
        }
    }
}

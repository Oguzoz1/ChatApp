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
        private static List<Client> _users;
        static void Main(string[] args)
        {
            _users = new List<Client>();
            _listener = new TcpListener(IPAddress.Parse("34.141.136.120"),6062);
            _listener.Start();

            while (true)
            {
                Client client = new Client(_listener.AcceptTcpClient());
                _users.Add(client);

                /* Broadcast the connection to everyone on the server */
                BroadcastConnection();
            }
        }


        static void BroadcastConnection()
        {
            //Server sending data of user connection to clients.
            foreach(Client user in _users)
            {
                foreach(Client usr in _users)
                {
                    //Send message to all available users (connected users) 
                    PacketBuilder broadcastPacket = new PacketBuilder();

                    broadcastPacket.WriteOpCode(1);
                    broadcastPacket.WriteMessage(usr.Username);
                    broadcastPacket.WriteMessage(usr.UID.ToString());
                    user.ClientSocket.Client.Send(broadcastPacket.GetPacketBytes());
                }
            }
        }

        public static void BroadcastDisconnect(string uid)
        {
            var disconnectedUser = _users.Where(x => x.UID.ToString() == uid).FirstOrDefault();
            _users.Remove(disconnectedUser);

            foreach (Client usr in _users)
            {
                //Send message to all available users (connected users) 
                PacketBuilder broadcastPacket = new PacketBuilder();

                broadcastPacket.WriteOpCode(10);
                broadcastPacket.WriteMessage(uid);
                usr.ClientSocket.Client.Send(broadcastPacket.GetPacketBytes());
            }
            BroadcastMessage($"[{disconnectedUser.Username}] Disconnected!");
        }


        public static void BroadcastMessage(string message)
        {
            foreach(Client user in _users)
            {
                PacketBuilder msgPacket = new PacketBuilder();
                msgPacket.WriteOpCode(5);
                msgPacket.WriteMessage(message);
                user.ClientSocket.Client.Send(msgPacket.GetPacketBytes()); 
            }
        }
        
    }
}

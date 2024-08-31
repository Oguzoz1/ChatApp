using Server.Net.IO;
using System;
using System.Linq;
using System.Net.Sockets;

namespace Server
{
    public static class BroadcastManager
    {
        internal static void BroadcastConnection()
        {
            try
            {
                // Server sending data of user connection to clients.
                foreach (Client user in ClientManager.Users.ToList()) // Use ToList() to avoid collection modification errors
                {
                    foreach (Client usr in ClientManager.Users.ToList())
                    {
                        try
                        {
                            // Send message to all available users (connected users)
                            PacketBuilder broadcastPacket = new PacketBuilder();
                            broadcastPacket.WriteOpCode(1);
                            broadcastPacket.WriteMessage(usr.Username);
                            broadcastPacket.WriteMessage(usr.UID.ToString());
                            user.ClientSocket.Client.Send(broadcastPacket.GetPacketBytes());
                        }
                        catch (SocketException)
                        {
                            // Handle client disconnection
                            Console.WriteLine($"User {user.Username} disconnected during BROADCAST CONNECTION");
                            ClientManager.HandleClientDisconnection(user);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error broadcasting connection: {ex.Message}");
            }
        }

        internal static void BroadcastMessage(string message)
        {
            foreach (Client user in ClientManager.Users.ToList())
            {
                try
                {
                    PacketBuilder msgPacket = new PacketBuilder();
                    msgPacket.WriteOpCode(5);
                    msgPacket.WriteMessage(message);
                    user.ClientSocket.Client.Send(msgPacket.GetPacketBytes());
                }
                catch (SocketException)
                {
                    Console.WriteLine($"User {user.Username} disconnected unexpectedly during BROADCAST MESSAGE.");
                    ClientManager.HandleClientDisconnection(user);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error sending message to {user.Username}: {ex.Message}");
                }
            }
        }

        internal static void BroadcastDisconnect(string uid)
        {
            var disconnectedUser = ClientManager.Users.Where(x => x.UID.ToString() == uid).FirstOrDefault();
            if (disconnectedUser != null)
            {
                ClientManager.Users.Remove(disconnectedUser);

                foreach (Client usr in ClientManager.Users.ToList())
                {
                    try
                    {
                        // Send message to all available users (connected users)
                        PacketBuilder broadcastPacket = new PacketBuilder();
                        broadcastPacket.WriteOpCode(10);
                        broadcastPacket.WriteMessage(uid);
                        usr.ClientSocket.Client.Send(broadcastPacket.GetPacketBytes());
                    }
                    catch (SocketException)
                    {
                        Console.WriteLine($"User {usr.Username} disconnected unexpectedly during BROADCAST DISCONNECTION.");
                        ClientManager.HandleClientDisconnection(usr);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error broadcasting disconnect for {uid} to {usr.Username}: {ex.Message}");
                    }
                }
                BroadcastMessage($"[{disconnectedUser.Username}] Disconnected!");
                ClientManager.HandleClientDisconnection(disconnectedUser);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public static class ClientManager
    {
        private static List<Client> _users;
        internal static List<Client> Users { get => _users; set => _users = value; }

        internal static void HandleClientDisconnection(Client client)
        {
            Users.Remove(client);
            CleanUpClient(client);
        }

        private static void CleanUpClient(Client client)
        {
            try
            {
                client.ClientSocket.Client.Shutdown(SocketShutdown.Both);
            }
            catch (SocketException)
            {

                
            }
            finally
            {
                client.ClientSocket.Close();
            }
        }
    }
}

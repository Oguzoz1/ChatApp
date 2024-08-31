using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server.Services
{
    public static class HealthCheck
    {
        public static string HandleHealthCheck(TcpClient client)
        {
            try
            {
                IPEndPoint remoteEndPoint = client.Client.RemoteEndPoint as IPEndPoint;
                if (remoteEndPoint == null || remoteEndPoint.Address.ToString() != ServerConfig.ServerIP)
                {
                    return "NO";
                }

                NetworkStream stream = client.GetStream();
                byte[] buffer = new byte[1024];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                string message = Encoding.UTF8.GetString(buffer, 0, bytesRead).Trim();

                if (message == "PING")
                {
                    return "OK";
                }
                else
                {
                    throw new InvalidOperationException("Invalid health check message.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"HealthCheck failed: {ex.Message}");
                throw;
            }
        }
    }
}

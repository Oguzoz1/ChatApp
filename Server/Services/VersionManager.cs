using Server.Net.IO;


namespace Server.Services
{
    public static class VersionManager
    {
        internal static void OnVersionRequest(Client client)
        {
            SendVersionToClient(client, ServerConfig.Version);
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

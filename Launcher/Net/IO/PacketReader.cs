﻿using System.IO;
using System.Net.Sockets;
using System.Text;

namespace LauncherClient.Net.IO
{
    class PacketReader : BinaryReader
    {
        private NetworkStream _ns;
        public PacketReader(NetworkStream ns) : base(ns)
        {
            _ns = ns;
        }

        public string ReadMessage()
        {
            //Reading Payload of the package
            byte[] msgBuffer;
            int length = ReadInt32();
            msgBuffer = new byte[length];
            _ns.Read(msgBuffer, 0, length);

            string msg = Encoding.UTF8.GetString(msgBuffer);

            return msg;
        }
    }
}

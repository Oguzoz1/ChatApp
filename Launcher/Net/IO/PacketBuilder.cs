using System;
using System.IO;
using System.Text;

namespace LauncherClient.Net.IO
{
    class PacketBuilder
    {
        MemoryStream _ms;
        public PacketBuilder()
        {
            _ms = new MemoryStream();
        }

        public void WriteOpCode(byte opcode)
        {
            //we don't need more than 255 space thus byte.
            //We don't have to reserve 4 bytes in the buffer.
            _ms.WriteByte(opcode);
        }
        public void WriteMessage(string msg)
        {
            //Including Unicode Characters
            byte[] msgBytes = Encoding.UTF8.GetBytes(msg);

            //opcode length how many bytes needed to read for package. *Payload*
            int msgLength = msgBytes.Length;

            //Length of the message
            _ms.Write(BitConverter.GetBytes(msgLength), 0 , 4);
            //Actual message
            _ms.Write(msgBytes, 0, msgBytes.Length);

            //1 byte for opcode. 4 byte for the length of the message. 
            //We allocate 4 byte since we may need to fit bigger messages.
            //Lastly we give the message.
        }

        public byte[] GetPacketBytes()
        {
            return _ms.ToArray();
        }
    }
}

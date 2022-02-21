using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtocolLib740.Packets.Client.Login
{
    [PacketHeader(0x02, 740, PacketSide.Client, PacketCategory.Login)]
    public class LoginPluginResponsePacket : IPacket
    {
        public int MessageID { get; set; }
        public byte[] Data { get; set; }

        public void Read(MinecraftStream stream)
        {
            throw new NotImplementedException();
        }

        public void Write(MinecraftStream stream)
        {
            stream.WriteVarInt(MessageID);
            if(Data!=null)
            {
                stream.WriteBoolean(true);
                stream.Write(Data);
            }
            else
            {
                stream.WriteBoolean(false);
            }
        }

        public LoginPluginResponsePacket(int messageID, byte[] data)
        {
            MessageID = messageID;
            Data = data;
        }
        public LoginPluginResponsePacket()
        {

        }
    }
}

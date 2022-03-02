﻿using MinecraftLibrary.API;
using MinecraftLibrary.API.IO;
using MinecraftLibrary.API.Networking;

namespace ProtocolLib740.Packets.Client
{
    [MinecraftLibrary.API.Protocol.PacketInfo(0x02, 740, PacketCategory.Login, PacketSide.Client)]
    public class LoginPluginResponsePacket : IPacket
    {
        public int MessageID { get; set; }
        public byte[] Data { get; set; }

        public void Read(IMinecraftStreamReader stream)
        {
            throw new NotImplementedException();
        }

        public void Write(IMinecraftStreamWriter stream)
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

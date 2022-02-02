using MinecraftLibrary.API.Helpers;
using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Helpres;
using MinecraftLibrary.API.Protocol.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftLibrary.Core.Protocol.Packets.Client.Login
{
    [PacketMetaLogin(0x02)]
    public class LoginPluginResponsePacket : ClientPacket
    {
        public int MessageId { get; set; }
        public byte[] Data { get; set; }
        public LoginPluginResponsePacket(int messageId, byte[] data)
        {
            MessageId = messageId;
            Data = data;
        }
        public override void Write(MinecraftStream output, int version)
        {
            output.WriteVarInt(MessageId);
            if (Data != null)
            {
                output.WriteBool(true);
                output.AddArray(Data);
            }
            else
            {
                output.WriteBool(false);
            }
        }
    }
}

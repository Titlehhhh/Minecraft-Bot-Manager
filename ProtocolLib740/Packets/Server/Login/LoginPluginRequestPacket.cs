using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib740.Packets.Server.Login
{
    [PacketHeader(0x04, 740, PacketSide.Server, PacketCategory.Game)]
    public class LoginPluginRequestPacket : IPacket
    {
        public int MessageID { get; set; }
        public string Channel { get; set; }
        public byte[] Data { get; set; }

        public void Read(MinecraftStream stream)
        {
            int len =(int) stream.Length;
            MessageID = stream.ReadVarInt();
            Channel = stream.ReadString();
            Data = stream.ReadUInt8Array(len - ((int)stream.Length));
        }

        public void Write(MinecraftStream stream)
        {

        }

        public LoginPluginRequestPacket()
        {

        }
    }
}

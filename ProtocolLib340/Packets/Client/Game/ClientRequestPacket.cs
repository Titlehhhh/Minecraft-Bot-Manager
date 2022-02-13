using MinecraftLibrary.API.Enums;
using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Client.Game
{

    [PacketHeader(0x03, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientRequestPacket : IPacket
    {
        public ClientRequest Request { get; set; }
        //out.writeVarInt(MagicValues.value(Integer.class, this.request));
        public void Write(MinecraftStream stream)
        {
            stream.WriteVarInt((int)Request);
        }

        public void Read(MinecraftStream stream)
        {
            
        }

        public ClientRequestPacket()
        {

        }
        public ClientRequestPacket(ClientRequest request)
        {
            Request = request;
        }
    }
}

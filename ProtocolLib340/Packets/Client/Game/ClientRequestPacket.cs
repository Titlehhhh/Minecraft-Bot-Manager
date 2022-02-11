using MinecraftLibrary.API;
using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Client.Game
{

    [PacketInfo(0x03, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientRequestPacket : IPacket
    {
        public ClientRequest Request { get; set; }
        //out.writeVarInt(MagicValues.value(Integer.class, this.request));
        public override void Write(IMinecraftStreamWriter output)
        {
            output.WriteVarInt((int)Request);
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

using MinecraftLibrary.API;
using MinecraftLibrary.API.IO;
using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Protocol;
using System.Runtime.Serialization.Json;
using System.Text;

namespace ProtocolLib754.Packets.Server
{
    [PacketInfo(0x00, 754, PacketCategory.Status, PacketSide.Server)]
    public class StatusResponsePacket : IPacket
    {
        

       

        public void Read(IMinecraftStreamReader stream)
        {
            string debug = stream.ReadString();




            

        }

        public void Write(IMinecraftStreamWriter stream)
        {

        }
    }
}

using MinecraftLibrary.API;
using MinecraftLibrary.API.IO;
using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Types.Chat;
using Newtonsoft.Json.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace ProtocolLib754.Packets.Server
{
    [PacketInfo(0x00, 754, PacketCategory.Status, PacketSide.Server)]
    public class StatusResponsePacket : IPacket
    {
        private static readonly DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(ServerInfo));

        public ServerInfo ServerStatusInfo { get; set; }

        public void Read(IMinecraftStreamReader stream)
        {
            string debug = stream.ReadString();

          


            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(debug));

            ServerStatusInfo = (ServerInfo)serializer.ReadObject(ms);

        }

        public void Write(IMinecraftStreamWriter stream)
        {

        }
    }
}

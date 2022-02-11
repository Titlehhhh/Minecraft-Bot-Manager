using MinecraftLibrary.API.Networking.Attributes;
using System.Reflection;

namespace ProtocolLib340
{
    public static class PacketPallete340
    {
        static PacketPallete340()
        {
            var Server = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.IsClass && t.Namespace.StartsWith("ProtocolLib340.Packets.Server"));
            var Client = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.IsClass && t.Namespace.StartsWith("ProtocolLib340.Packets.Client"));

            ServerLoginPackets = Server.Where(k => k.GetCustomAttribute<PacketInfoAttribute>().Category == PacketCategory.Login).ToDictionary(x => x.GetCustomAttribute<PacketInfoAttribute>().ID, v => v);
            ServerGamePackets = Server.Where(k => k.GetCustomAttribute<PacketInfoAttribute>().Category == PacketCategory.Game).ToDictionary(x => x.GetCustomAttribute<PacketInfoAttribute>().ID, v => v);

            ClientHandShakePackets = Client.Where(k => k.GetCustomAttribute<PacketInfoAttribute>().Category == PacketCategory.HandShake).ToDictionary(x => x, v => v.GetCustomAttribute<PacketInfoAttribute>().ID);
            ClientLoginPackets = Client.Where(k => k.GetCustomAttribute<PacketInfoAttribute>().Category == PacketCategory.Login).ToDictionary(x => x, v => v.GetCustomAttribute<PacketInfoAttribute>().ID);
            ClientGamePAckets = Client.Where(k => k.GetCustomAttribute<PacketInfoAttribute>().Category == PacketCategory.Game).ToDictionary(x => x, v => v.GetCustomAttribute<PacketInfoAttribute>().ID);
        }

        public static Dictionary<Type, int> ClientHandShakePackets { get; }
        public static Dictionary<Type, int> ClientLoginPackets { get; }
        public static Dictionary<Type, int> ClientGamePAckets { get; }
        public static Dictionary<int, Type> ServerLoginPackets { get; }
        public static Dictionary<int, Type> ServerGamePackets { get; }
    }
}

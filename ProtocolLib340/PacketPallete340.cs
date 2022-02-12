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

            ServerLoginPackets = Server.Where(k => k.GetCustomAttribute<PacketHeaderAttribute>().Category == PacketCategory.Login).ToDictionary(x => x.GetCustomAttribute<PacketHeaderAttribute>().ID, v => v);
            ServerGamePackets = Server.Where(k => k.GetCustomAttribute<PacketHeaderAttribute>().Category == PacketCategory.Game).ToDictionary(x => x.GetCustomAttribute<PacketHeaderAttribute>().ID, v => v);

            ClientHandShakePackets = Client.Where(k => k.GetCustomAttribute<PacketHeaderAttribute>().Category == PacketCategory.HandShake).ToDictionary(x => x, v => v.GetCustomAttribute<PacketHeaderAttribute>().ID);
            ClientLoginPackets = Client.Where(k => k.GetCustomAttribute<PacketHeaderAttribute>().Category == PacketCategory.Login).ToDictionary(x => x, v => v.GetCustomAttribute<PacketHeaderAttribute>().ID);
            ClientGamePAckets = Client.Where(k => k.GetCustomAttribute<PacketHeaderAttribute>().Category == PacketCategory.Game).ToDictionary(x => x, v => v.GetCustomAttribute<PacketHeaderAttribute>().ID);
        }

        public static Dictionary<Type, int> ClientHandShakePackets { get; }
        public static Dictionary<Type, int> ClientLoginPackets { get; }
        public static Dictionary<Type, int> ClientGamePAckets { get; }
        public static Dictionary<int, Type> ServerLoginPackets { get; }
        public static Dictionary<int, Type> ServerGamePackets { get; }
    }
}

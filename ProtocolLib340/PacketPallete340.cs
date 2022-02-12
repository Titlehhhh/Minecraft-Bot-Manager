using MinecraftLibrary.API.Common;
using MinecraftLibrary.API.Interfaces;
using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using System.Reflection;

namespace ProtocolLib340
{
    public class PacketPallete340 : IPacketProvider
    {
        private static readonly List<PacketInfo> clientpackets = new();
        private static readonly List<PacketInfo> serverpackets = new();

        static PacketPallete340()
        {
            Assembly.GetExecutingAssembly().GetTypes().ToList().ForEach(x =>
              {
                  if (!x.IsAssignableFrom(typeof(IPacket)))
                      return;

                  PacketHeaderAttribute packetHeader = x.GetCustomAttribute<PacketHeaderAttribute>();
                  if (packetHeader != null)
                  {
                      if (packetHeader.Side == PacketSide.Client)
                      {
                          clientpackets.Add(new PacketInfo(packetHeader.ID, x, packetHeader.Category));
                      }
                      else
                      {
                          serverpackets.Add(new PacketInfo(packetHeader.ID, x, packetHeader.Category));
                      }
                  }
              });

        }

        public List<PacketInfo> GetClientPackets()
        {

            return clientpackets;
        }

        public Dictionary<Type, int> GetClientPackets(PacketCategory category)
        {
            return clientpackets.Where(t => t.Category == category).ToDictionary(k => k.TPacket, v => v.ID);
        }

        public List<PacketInfo> GetServerPackets()
        {
            return serverpackets;
        }

        public Dictionary<int, Type> GetServerPackets(PacketCategory category)
        {
            return clientpackets.Where(t => t.Category == category).ToDictionary(k => k.ID, v => v.TPacket);
        }
    }
}

using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftLibrary.Core.Protocol
{
    public class DefaultPacketRepository : IPacketRepository
    {
        private  Dictionary<int, Lazy<IPacket>> packets = new Dictionary<int, Lazy<IPacket>>();

        public Dictionary<int, Lazy<IPacket>> InputPackets => packets ??= new Dictionary<int, Lazy<IPacket>>();

        public event EventHandler<RegisterPacketEventArgs> PacketRegistered;
        public event EventHandler<UnRegisterPacketEventArgs> UnregisterPacket;

        public void RegisterInputPacket<TPacket>(int id) where TPacket : IPacket,new()
        {
            Lazy<IPacket> packet = new Lazy<IPacket>(() => new TPacket());
            packets.Add(id, packet);
            PacketRegistered?.Invoke(this, new RegisterPacketEventArgs(typeof(TPacket)));
        }

        public bool TryGetPacket(int id, out IPacket packet)
        {
            if (packets.ContainsKey(id))
            {
                packet = InputPackets[id].Value;
                return true;
            }
            packet = null;
            return false;
        }

        public void UnRegisterPacket(int id)
        {
            InputPackets.Remove(id);
        }
    }
}

using MinecraftLibrary.API;
using MinecraftLibrary.API.Networking;

namespace MinecraftLibrary.Core.Utils
{
    public sealed class LazyPacket<TPacket> : ILazyPacket<TPacket> where TPacket : IPacket, new()
    {
        private readonly IPacket packet;

        public IPacket PacketValue
        {
            get
            {
                if (this.packet == null)
                {
                    IPacket packet = (IPacket)new TPacket();
                    return packet;
                }
                return this.packet;
            }
        }

    }
}

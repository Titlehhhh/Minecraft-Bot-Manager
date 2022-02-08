using MinecraftLibrary.API.Protocol;

namespace MinecraftLibrary.API.Bot
{
    public abstract class PacketListener 
    {
        protected IPacketReader reader;
        protected IPacketWriter writer;

        protected PacketListener(IPacketReader reader, IPacketWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }
        
        
    }
}

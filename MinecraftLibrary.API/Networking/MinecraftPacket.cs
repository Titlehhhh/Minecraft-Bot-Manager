using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.IO;

namespace MinecraftLibrary.API.Networking
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class MinecraftPacket : IPacket
    {
        public MinecraftPacket()
        {

        }
        public virtual void Read(IMinecraftStreamReader input)
        {

        }

        public virtual void Write(IMinecraftStreamWriter output)
        {

        }
    }    
}

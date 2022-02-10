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

        public void Deserialize(MinecraftStream input)
        {
            
        }

        public void Serialize(MinecraftStream output)
        {
            
        }
    }    
}

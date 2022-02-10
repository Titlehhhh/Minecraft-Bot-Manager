
using MinecraftLibrary.API.Networking.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MinecraftLibrary.API.Networking
{
    public interface IPacket
    {
        void Deserialize(MinecraftStream input);
        void Serialize(MinecraftStream output);
    }
}

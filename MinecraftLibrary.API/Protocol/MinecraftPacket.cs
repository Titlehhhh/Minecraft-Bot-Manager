using MinecraftLibrary.API.Protocol.Helpres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftLibrary.API.Protocol
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class MinecraftPacket : IPacket
    {
        public MinecraftPacket()
        {

        }
        public virtual void Read(MinecraftStream input)
        {
           
        }

        public virtual void Write(MinecraftStream output)
        {
            
        }
    }    
}

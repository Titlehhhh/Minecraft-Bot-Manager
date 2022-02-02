using MinecraftLibrary.API.Protocol.Helpres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftLibrary.API.Protocol
{
    /// <summary>
    /// Переопределяет так, что метод Read нельзя переопределить
    /// </summary>
    public abstract class ClientPacket : IPacket
    {
        public void Read(MinecraftStream input)
        {
           
        }

        public virtual void Write(MinecraftStream output)
        {
            
        }
    }    
}

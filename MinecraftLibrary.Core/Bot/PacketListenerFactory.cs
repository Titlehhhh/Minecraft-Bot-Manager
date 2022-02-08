using MinecraftLibrary.API.Bot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftLibrary.Core.Bot
{
    public class PacketListenerFactory
    {
        private static PacketListenerFactory factory;
        public static PacketListenerFactory Instance => factory ?? (factory = new PacketListenerFactory());
        public virtual PacketListener CreateListener(string version)
        {

        }
    }
}

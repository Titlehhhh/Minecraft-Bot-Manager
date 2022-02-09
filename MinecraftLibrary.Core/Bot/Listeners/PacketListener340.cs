using MinecraftLibrary.API.Bot;
using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftLibrary.Core.Bot.Listeners
{
    public class PacketListener340 : PacketListener
    {
        public PacketListener340(IPacketReader reader, IPacketWriter writer, ITcpClientSession session) : base(reader, writer, session)
        {
        }
    }
}

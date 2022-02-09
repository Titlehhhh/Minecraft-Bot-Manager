using MinecraftLibrary.API.Bot;
using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Proxy;
using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.Networking.Session;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtocolLib340.Bot
{

    public class ProtocolClient340 : PacketListener
    {
        public ProtocolClient340(IPacketReader reader, IPacketWriter writer, ITcpClientSession session) : base(reader, writer, session)
        {
        }

        protected override void Connected()
        {

        }

        protected override void Discconected()
        {

        }

        protected override void HandlePacket(IPacket packet)
        {

        }

        protected override void PacketSend(IPacket packet)
        {

        }

        protected override void PacketSent(IPacket packet)
        {

        }
    }
}

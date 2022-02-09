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

        public override void Connected()
        {

        }

        public override void Discconected()
        {
            UnRegisterEvents();
        }

        public override void HandlePacket(IPacket packet)
        {

        }

        public override void PacketSend(IPacket packet)
        {

        }

        public override void PacketSent(IPacket packet)
        {

        }
    }
}

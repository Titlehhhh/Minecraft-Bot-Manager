using MinecraftProtocol.IO;
using MinecraftProtocol.Packets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftLibrary.MinecraftProtocol.Packets.HandShake
{
    public class HandShakePacket : ClientPacket
    {
        HandShakeIntent intent;
        int protocolversion;
        int port;
        string hostname;


        public void Write(NetOutput output, int protocolversion)
        {
            output.WriteVarInt(this.protocolversion);
            output.WriteString(hostname);
            output.WriteUShort((ushort)port);
            output.WriteVarInt((int)intent);
        }

        public HandShakePacket(HandShakeIntent intent, int protocolversion, int port, string hostname)
        {
            this.intent = intent;
            this.protocolversion = protocolversion;
            this.port = port;
            this.hostname = hostname;
        }
    }
    public enum HandShakeIntent : int
    {
        STATUS=1,
        LOGIN=2
    }
}

using MinecraftLibrary.API;
using MinecraftLibrary.API.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtocolLib754.Packets.Server.Status
{
    [PacketInfo(0x01,754,PacketCategory.Status,PacketSide.Server)]
    public class StatusPongPacket
    {

    }
    [PacketInfo(0x00,754,PacketCategory.Status,PacketSide.Server)]
    public class StatusResponsePacket
    {

    }
}

﻿using MinecraftProtocol.IO;
using MinecraftProtocol.Packets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftLibrary.MinecraftProtocol.Packets.Client.Game
{
    public class ClientSettingsPacket : ClientPacket
    {
        public void Write(NetOutput output, int protocolversion)
        {
        }
    }
}
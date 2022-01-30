﻿
using MinecraftLibrary.API.Protocol.Helpres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftLibrary.API.Protocol
{
    public interface IPacket
    {
        void Read(MinecraftStream input, int version);
        void Write(MinecraftStream output, int version);
    }
}

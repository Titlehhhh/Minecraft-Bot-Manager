using System;
using System.Collections.Generic;

namespace MinecraftLibrary.MinecraftProtocol.PacketPalletes
{
    public abstract class PacketPallete
    {
        public abstract Dictionary<int, Type> GetInPackets();
        public abstract Dictionary<Type, int> GetOutPackets();
    }
}

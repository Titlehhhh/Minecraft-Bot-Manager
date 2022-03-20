﻿using MinecraftLibrary.API.Types.Chat;

namespace MinecraftLibrary.API.Protocol
{
    public class RegisterPacketsEventArgs : EventArgs
    {
        public IList<Type> Packets { get; private set; }

        public RegisterPacketsEventArgs(IList<Type> packets)
        {
            Packets = packets;
        }
    }

    
}

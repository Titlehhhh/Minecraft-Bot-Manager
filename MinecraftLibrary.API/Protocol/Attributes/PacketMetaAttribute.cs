using System;

namespace MinecraftLibrary.API.Protocol.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true,Inherited =true)]
    public abstract class PacketMetaAttribute : Attribute
    {
        public int ID { get; private set; }
        public int[] Protocols { get; private set; }
        public PacketState PacketState { get; private set; } = PacketState.Client;

        public PacketMetaAttribute(int iD, params int[] protocols)
        {
            ID = iD;
            Protocols = protocols;            
        }
        public PacketMetaAttribute(int iD,PacketState state = PacketState.Client, params int[] protocols)
        {
            ID = iD;
            Protocols = protocols;
            PacketState = state;            
        }

    }
    public enum PacketState : byte
    {
        Client = 0,
        Server = 1
    }


}

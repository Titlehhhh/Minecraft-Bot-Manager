using System;

namespace MinecraftLibrary.API.Protocol.Attributes
{
    [AttributeUsage(AttributeTargets.Class,Inherited =true)]
    public sealed class PacketInfoAttribute : Attribute
    {
        public int ID { get; private set; }
        public int TargetProtocol { get; private set; }
        public PacketSide PacketState { get; private set; } = PacketSide.Client;
        public PacketCategory Category { get; private set; } = PacketCategory.HandShake;

        public PacketInfoAttribute(int iD,int protocol,PacketSide state , PacketCategory  category )
        {
            ID = iD;
            TargetProtocol = protocol;
            PacketState = state;
            Category = category;
        }

    }
    public enum PacketSide : byte
    {
        Client = 0,
        Server = 1
    }
    public enum PacketCategory : byte
    {
        HandShake,
        Login,
        Game,
        Status
    }


}

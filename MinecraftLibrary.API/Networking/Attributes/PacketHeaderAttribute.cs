using System;

namespace MinecraftLibrary.API.Networking.Attributes
{
    [AttributeUsage(AttributeTargets.Class,Inherited =true)]
    public sealed class PacketHeaderAttribute : Attribute
    {
        public int ID { get; private set; }
        public int TargetProtocol { get; private set; }
        public PacketSide Side { get; private set; } = PacketSide.Client;
        public PacketCategory Category { get; private set; } = PacketCategory.HandShake;

        public PacketHeaderAttribute(int iD,int protocol,PacketSide state , PacketCategory  category )
        {
            ID = iD;
            TargetProtocol = protocol;
            Side = state;
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

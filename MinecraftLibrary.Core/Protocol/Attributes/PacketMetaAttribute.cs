using System;

namespace MinecraftLibrary.Core.Protocol.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple =true)]
    public abstract class PacketMetaAttribute : Attribute
    {
        public int ID { get; private set; }
        public int[] Protocols { get; private set; }

        public PacketMetaAttribute(int iD,params int[] protocols)
        {
            ID = iD;
            Protocols = protocols;
        }
    }


}

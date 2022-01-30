namespace MinecraftLibrary.Core.Protocol.Attributes
{
    public sealed class PacketMetaLoginAttribute : PacketMetaAttribute
    {
        public PacketMetaLoginAttribute(int iD, params int[] protocols) : base(iD, protocols)
        {
        }
    }


}

namespace MinecraftLibrary.Core.Protocol.Attributes
{
    public sealed class PacketMetaGameAttribute : PacketMetaAttribute
    {
        public PacketMetaGameAttribute(int iD, params int[] protocols) : base(iD, protocols)
        {
        }
    }


}

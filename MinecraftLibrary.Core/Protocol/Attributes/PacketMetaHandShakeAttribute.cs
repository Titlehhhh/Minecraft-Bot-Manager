namespace MinecraftLibrary.Core.Protocol.Attributes
{
    public sealed class PacketMetaHandShakeAttribute : PacketMetaAttribute
    {
        public PacketMetaHandShakeAttribute(int iD, params int[] protocols) : base(iD, protocols)
        {
        }
    }


}

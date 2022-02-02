namespace MinecraftLibrary.API.Protocol.Attributes
{
    public sealed class PacketMetaHandShakeAttribute : PacketMetaAttribute
    {
        public PacketMetaHandShakeAttribute(int iD, params int[] protocols) : base(iD, protocols)
        {
        }

        public PacketMetaHandShakeAttribute(int iD, PacketState state = PacketState.Client, params int[] protocols) : base(iD, state, protocols)
        {
        }
    }


}

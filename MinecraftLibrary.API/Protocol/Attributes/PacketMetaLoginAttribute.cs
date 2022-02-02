namespace MinecraftLibrary.API.Protocol.Attributes
{
    public sealed class PacketMetaLoginAttribute : PacketMetaAttribute
    {
        public PacketMetaLoginAttribute(int iD, params int[] protocols) : base(iD, protocols)
        {
        }

        public PacketMetaLoginAttribute(int iD, PacketState state = PacketState.Client, params int[] protocols) : base(iD, state, protocols)
        {
        }
    }


}

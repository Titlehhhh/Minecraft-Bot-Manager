namespace MinecraftLibrary.API.Protocol.Attributes
{
    public sealed class PacketMetaGameAttribute : PacketMetaAttribute
    {
        public PacketMetaGameAttribute(int iD, params int[] protocols) : base(iD, protocols)
        {
           
        }

        public PacketMetaGameAttribute(int iD, PacketState state = PacketState.Client, params int[] protocols) : base(iD, state, protocols)
        {
        }
    }


}

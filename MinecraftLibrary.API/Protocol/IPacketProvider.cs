namespace MinecraftLibrary.API.Protocol
{
    public interface IPacketProvider
    {
        IPacketProviderClient ClientPackets { get; }
        IPacketProviderServer ServerPackets { get; }
    }
}

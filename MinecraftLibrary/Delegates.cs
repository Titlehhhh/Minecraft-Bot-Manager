using MinecraftLibrary.API.Networking;

namespace MinecraftLibrary
{


    public delegate void ConnectedHandler(MinecraftClient754 client);
    public delegate void ConnectionLostedHandler(MinecraftClient754 client, Exception e);
    public delegate void LoginRejectedHandler(MinecraftClient754 client, string message);
    public delegate void GameRejectedHandler(MinecraftClient754 client, string message);
    public delegate void LoginSucessedHandler(MinecraftClient754 client, Guid uuid);
    public delegate void PacketReceivedHandler(MinecraftClient754 client, IPacket packet);
    public delegate void MessageReceivedHandler(MinecraftClient754 client, string message);

    public delegate void GameJoinedHandler(MinecraftClient754 client);
    public delegate void PositionRotationChangedHandler(MinecraftClient754 client, PositionRotationEventArgs e);


}

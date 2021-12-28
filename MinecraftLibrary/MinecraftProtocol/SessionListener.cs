using MinecraftLibrary.MinecraftProtocol;
using MinecraftProtocol.Packets;

namespace MinecraftProtocol
{
    public delegate void PacketReceive(ServerPacket packet);
    public delegate void PacketSend(ClientPacket packet);
    public delegate void PacketSent(ClientPacket packet);
    public delegate void Disconnect(DisconnectReason reason,string msg);
    public delegate void Connected();
    public delegate void LoginSucces();
}

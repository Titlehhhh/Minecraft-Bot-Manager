using MinecraftLibrary.API.Networking;
using MinecraftLibrary.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftLibrary
{
    

    public delegate void ConnectedHandler(MinecraftClient client);
    public delegate void ConnectionLostedHandler(MinecraftClient client, Exception e);
    public delegate void LoginRejectedHandler(MinecraftClient client, string message);
    public delegate void GameRejectedHandler(MinecraftClient client, string message);
    public delegate void LoginSucessedHandler(MinecraftClient client,string uuid);
    public delegate void PacketReceivedHandler(MinecraftClient client, IPacket packet);
    public delegate void MessageReceivedHandler(MinecraftClient client, string message);

    public delegate void GameJoinedHandler(MinecraftClient client);
    public delegate void PositionRotationChangedHandler(MinecraftClient client, PositionRotationEventArgs e);


}

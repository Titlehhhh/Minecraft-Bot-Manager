using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftLibrary.API.Protocol
{
    public delegate void ConnectedHandler(IMinecraftClient sender);
    public delegate void ConnectionLostHandler(IMinecraftClient sender);
    public delegate void LoginKickHandler(IMinecraftClient sender, string message);
    public delegate void GameKickHandler(IMinecraftClient sender, string message);

    public delegate void PostionRotationHandler(IMinecraftClient sender, PositionRotationEventArgs e);
    public delegate void WindowOpenHandler(IMinecraftClient sender, OpenWindowEventArgs e);
    public delegate void WindowItemsHandler(IMinecraftClient sender, )
}

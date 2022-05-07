using ProtoLib.API;
using ProtoLib.API.Networking.Proxy;

namespace MinecraftBotManagerWPF
{
    public interface IMinecraftBotBuilder
    {
        void SetProfile(GameProfile gameProfile);
        void SetProxy(string host, ushort port, ProxyType type);
        void SetProxy(string host, ushort port, ProxyType type, string login, string password);

        void SetHost(string host, ushort port);

        void SetPlugins();

        MinecraftBot Build();
    }
}

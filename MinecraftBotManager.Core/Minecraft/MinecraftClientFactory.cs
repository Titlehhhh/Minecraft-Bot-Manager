
using MinecraftBotManager.Core.Minecraft.Clients;
using System.Net.Sockets;

namespace MinecraftBotManager.Core
{
    public sealed class MinecraftClientFactory
    {
        public MinecraftClientFactory()
        {

        }

        public IMinecraftClient CreateClient(int protocolVersion, TcpClient client, string nick, ILogger logger)
        {
            if (protocolVersion == 754)
                return new MinecraftClient754(client, nick, logger);
            throw new NotImplementedException("unkown version: " + protocolVersion);
        }
    }
}

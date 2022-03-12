using MinecraftLibrary.API.Types.Chat;

namespace MinecraftLibrary.API
{
    public class ServerInfo
    {
        public int MaxPlayers { get; }
        public int OnlinePlayers { get; }
        public GameProfile[] Players { get; }


        public VersionInfo TargetVersion { get; }
        public ChatMessage Description { get; }
        public byte[] Icon { get; }

        public ServerInfo(int maxPlayers, int onlinePlayers, GameProfile[] players, VersionInfo targetVersion, ChatMessage description, byte[] icon)
        {
            MaxPlayers = maxPlayers;
            OnlinePlayers = onlinePlayers;
            Players = players;
            TargetVersion = targetVersion;
            Description = description;
            Icon = icon;
        }
    }
}

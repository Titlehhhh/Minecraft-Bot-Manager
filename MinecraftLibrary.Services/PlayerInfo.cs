using MinecraftLibrary.API;
using System.Runtime.Serialization;

namespace MinecraftLibrary.Services
{
    [DataContract]
    public class PlayerInfo
    {
        [DataMember(Name = "max")]
        public int MaxPlayers { get; set; }

        [DataMember(Name = "online")]
        public int OnlinePlayers { get; set; }

        [DataMember(Name = "sample")]
        public GameProfile[] PlayerList { get; set; }
        public PlayerInfo()
        {
            PlayerList = new GameProfile[0];
        }
    }
}
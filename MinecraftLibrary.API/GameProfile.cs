using System.Runtime.Serialization;

namespace MinecraftLibrary.API
{
    [DataContract]
    public struct GameProfile
    {
        [DataMember(Name = "id")]
        public string UUID { get; set; }

        [DataMember(Name = "name")]
        public string Nickname { get; set; }

        public GameProfile(string uUID, string nickname)
        {
            UUID = uUID;
            Nickname = nickname;
        }
    }
}

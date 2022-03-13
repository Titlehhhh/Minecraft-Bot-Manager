namespace MinecraftLibrary.API
{
    public struct GameProfile
    {
        public string UUID { get; private set; }
        public string Nickname { get; private set; }

        public GameProfile(string uUID, string nickname)
        {
            UUID = uUID;
            Nickname = nickname;
        }
    }
}

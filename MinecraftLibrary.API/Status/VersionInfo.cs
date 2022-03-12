namespace MinecraftLibrary.API
{
    public struct VersionInfo
    {
        public string StringVersion { get; }
        public int ProtocolVersion { get; }

        public VersionInfo(string stringVersion, int protocolVersion)
        {
            StringVersion = stringVersion;
            ProtocolVersion = protocolVersion;
        }
    }
}

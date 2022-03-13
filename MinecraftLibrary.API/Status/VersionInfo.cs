﻿using System.Runtime.Serialization;

namespace MinecraftLibrary.API
{
    [DataContract]
    public struct VersionInfo
    {
        [DataMember(Name ="name")]
        public string StringVersion { get; set; }
        [DataMember(Name = "protocol")]
        public int ProtocolVersion { get; set; }

        public VersionInfo(string stringVersion, int protocolVersion)
        {
            StringVersion = stringVersion;
            ProtocolVersion = protocolVersion;
        }
    }
}

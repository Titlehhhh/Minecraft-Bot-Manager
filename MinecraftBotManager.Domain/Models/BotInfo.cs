
using McProtoNet.Utils;
using System.Runtime.Serialization;

namespace MinecraftBotManager.Domain
{
    [DataContract]
    public class BotInfo
    {
        [DataMember]
        public string Nickname { get; set; }
        [DataMember]
        public bool IsAuth { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public AccountType AccType { get; set; }
        [DataMember]
        public string Host { get; set; }

        [DataMember]
        public bool ProxyEnabled { get; set; }
        [DataMember]
        public bool AutoFindProxyEnabled { get; set; }
        [DataMember]
        public string ProxyHost { get; set; }
        [DataMember]
        public ushort ProxyPort { get; set; }

        //[DataMember]
        //public ProxyType ProxyType { get; set; }




    }
}

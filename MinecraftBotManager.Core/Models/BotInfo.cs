using MinecraftBotManager.Core.Data;
using System.Runtime.Serialization;

namespace MinecraftBotManager.Core.Models
{
    public sealed class ValidationInfo
    {
        public bool IsValid { get; private set; }

        public IReadOnlyDictionary<string, string> Errors { get; private set; }
    }
    [DataContract]
    public sealed class BotInfo : ICloneable
    {
        [IgnoreDataMember]
        public Guid Id { get; }
        public BotInfo()
        {
            Id = Guid.NewGuid();
        }

        #region DataProperties
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public string Server { get; set; }
        [DataMember]
        public int ProtocolVersion { get; set; }
        [DataMember]
        public bool AuthEnabled { get; set; }


        [DataMember]
        public AccountType AccType { get; set; }

        public string Password { get; set; }
        [DataMember]
        public bool ProxyEnabled { get; set; }
        [DataMember]
        public bool OptimaleProxy { get; set; }
        [DataMember]
        public string ProxyAddress { get; set; }
        [DataMember]
        public TypeProxy ProxyType { get; set; }
        [DataMember]
        public string ProxyLogin { get; set; }
        [DataMember]
        public string ProxyPass { get; set; }
        #endregion

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}

using System;
using System.Runtime.Serialization;

namespace MinecraftBotManagerWPF
{
    [Serializable]
    public class Bot : ISerializable
    {
        public string Nickname { get; set; }
        public string Host { get; set; }

        public string Password { get; set; }



        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(Nickname), Nickname);
            info.AddValue(nameof(Host), Host);
        }
        protected Bot(SerializationInfo info, StreamingContext context)
        {
            Nickname = info.GetString(nameof(Nickname));
            Host = info.GetString(nameof(Host));
        }
        public Bot()
        {

        }

    }
}

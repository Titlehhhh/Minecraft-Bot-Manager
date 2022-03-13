using System;
using System.Runtime.Serialization;

namespace MinecraftBotManagerWPF
{
    [DataContract]
    public class Bot
    {
        [DataMember(Name = "nick", EmitDefaultValue = true)]
        public string Nickname { get; set; }

        [DataMember(Name = "host", EmitDefaultValue = true)]
        public string Host { get; set; }

        [DataMember(Name = "pass", EmitDefaultValue = true)]
        public string Password { get; set; }


        public async void StartBotAsync()
        {

        }

        public Bot()
        {

        }

    }
}

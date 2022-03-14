using MinecraftLibrary.API.Networking.Proxy;
using MinecraftLibrary.Geometry;
using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Threading.Tasks;

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

        public Bot()
        {

        }

    }
    public interface IConnectionInfo
    {
        string Nickname { get; }
        string Host { get; }
        string Password { get; }

        ProxyInfo Proxy { get; }

    }
    public interface IBotRunner : INotifyPropertyChanged
    {
        float Yaw { get; }
        float Pitch { get; }
        Rotation Rotation { get; }



        Task StartClientAsync();
        Task StopClientAsync();
    }
}

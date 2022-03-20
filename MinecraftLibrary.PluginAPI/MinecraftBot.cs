using MinecraftLibrary.API;
using MinecraftLibrary.API.Networking.Proxy;

namespace MinecraftLibrary.PluginAPI
{
    public sealed class MinecraftBot
    {
        public IProtocolClient ProtocolClient { get; private set; }


        public string Nickname { get; set; }

        public string Host { get; set; }

        public ushort Port { get; set; }

        public bool IsAuth { get; set; }

        public bool IsProxy { get; set; }

        public ProxyInfo? Proxy { get; set; }

        public AuthInfo? Auth { get; set; }

        public MinecraftBot()
        {

        }

        public void Start()
        {

            this.ProtocolClient = new ProtocolClient();
            this.ProtocolClient.Nickname = this.Nickname;
            this.ProtocolClient.Host = this.Host;

            this.ProtocolClient.Connected += () =>
            {
            };
            this.ProtocolClient.Disconnected += (s, e) =>
            {
            };
            this.ProtocolClient.LoginSucces += () =>
            {
            };

            this.ProtocolClient.Connect();



        }
        public void Stop()
        {

        }

        public void Dispose()
        {
            Stop();
            ProtocolClient.Dispose();
        }


    }


}

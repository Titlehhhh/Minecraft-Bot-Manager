using MinecraftLibrary.API;
using MinecraftLibrary.API.Networking.Proxy;
using MinecraftLibrary.Services;
using System;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace MinecraftBotManagerWPF
{
    public interface IMinecraftBotRunner
    {
        Task PreparingAsync();
        Task<bool> AuthenticationAsync();
        Task<bool> ConfigureProxyAsync();
        Task<bool> ConfigureServerAsync();
        Task<bool> RunBotAsync();
    }

    public class MinecraftBotRunner : IMinecraftBotRunner
    {
        

        private readonly BotViewModel _botViewModel;
        private readonly BotInfo info;

        private readonly IBotRepository botRepository;
        private readonly IAuthService authService;
        private IMinecraftBotBuilder builder;
        private readonly IServerResolver _resolver;

        public MinecraftBotRunner(BotViewModel botViewModel, IBotRepository botRepository, IAuthService authService, IServerResolver resolver)
        {
            _botViewModel = botViewModel;
            this.botRepository = botRepository;
            this.authService = authService;
            this.info = _botViewModel.BotInfoModel;
            _resolver = resolver;
        }


        public async Task<bool> AuthenticationAsync()
        {
            _botViewModel.AuthStatus.IsEnabled = true;
            _botViewModel.AuthStatus.Message = "Пропущено";
            _botViewModel.AuthStatus.Status = StatusCheck.Ok;
            builder.SetProfile(new GameProfile(Guid.NewGuid().ToString(), info.Nickname));
            return true;
        }

        public async Task<bool> ConfigureProxyAsync()
        {
            _botViewModel.ProxyStatus.IsEnabled = true;
            _botViewModel.ProxyStatus.Message = "Пропущено";
            _botViewModel.ProxyStatus.Status = StatusCheck.Ok;
            return true;
        }

        public async Task<bool> ConfigureServerAsync()
        {
            var hostport = info.Host.Split(':');
            string host = info.Host;
            ushort port = 25565;
            if(hostport.Length == 2)
            {
                host = hostport[0];
                try
                {
                    port = ushort.Parse(hostport[1]);
                }
                catch
                {
                    _botViewModel.ServerStatus.Error("Ошибка парсина порта");
                    return false;
                }
            }
            try
            {
                (host, port) = await _resolver.ResolveAsync(host);
            }
            catch
            {
                _botViewModel.ServerStatus.Error("Неизвестная ошибка");
                return false;
            }

            builder.SetHost(host, port);
            return true;


        }

        public async Task<bool> RunBotAsync()
        {
            return true;
        }

        public async Task PreparingAsync()
        {
            builder = new MinecraftBotBuilder();

            await this.botRepository.SaveAsync();
            _botViewModel.ReturnToOrgignalStateStatuses();
            _botViewModel.RefreshPropertis();
            _botViewModel.BotState = State.Initialized;
        }
    }
    public interface IMinecraftBotBuilder
    {
        void SetProfile(GameProfile gameProfile);
        void SetProxy(string host, ushort port, ProxyType type);
        void SetProxy(string host, ushort port, ProxyType type, string login, string password);

        void SetHost(string host, ushort port);

        void SetPlugins();

        MinecraftBot Build();
    }
    public class MinecraftBotBuilder : IMinecraftBotBuilder 
    {
        private GameProfile gameProfile;
        private string host;
        private ushort port;
        private string proxyHost;
        private ushort proxyPort;
        private ProxyType proxyType;
        private string proxyPass;
        private string proxyLogin;
        private bool proxyAuth = false;
        private bool proxyEnabled = false;

        public MinecraftBot Build()
        {
            return new MinecraftBot(gameProfile, new TcpClient(host, port));
        }

        public void SetHost(string host, ushort port)
        {
            this.host = host;
            this.port = port;
        }

        public void SetPlugins()
        {
            throw new NotImplementedException();
        }

        public void SetProfile(GameProfile gameProfile)
        {
            if (gameProfile is null)
                throw new ArgumentNullException(nameof(gameProfile));
            this.gameProfile = gameProfile;
        }

        public void SetProxy(string host, ushort port, ProxyType type)
        {
            this.proxyEnabled = true;
            this.proxyHost = host;
            this.proxyPort = port;
            this.proxyType = type;
        }

        public void SetProxy(string host, ushort port, ProxyType type, string login, string password)
        {
            this.proxyAuth = true;
            this.proxyPass = password;
            this.proxyLogin = login;
            SetProxy(host, port, type);
        }
    }
}

using McProtoNet.Utils;
using MinecraftBotManager.Core.Exceptions;
using MinecraftBotManager.Core.Models;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;

namespace MinecraftBotManager.Core
{
    public sealed class Bot : IBot
    {



        private readonly List<IBotObserver> observers = new();

        private readonly ILogger _logger;
        private BotStatus status;

        public event EventHandler<StatusChangedEventArgs> StatusChanged;

        public BotStatus Status
        {
            get => status;
            private set
            {
                var old = status;
                status = value;
                StatusChanged?.Invoke(this, new StatusChangedEventArgs(old, status));
            }
        }

        public Bot(ILogger logger)
        {
            _logger = logger;
        }

        private void Notify(Action<IBotObserver> action)
        {
            lock (observers)
            {
                foreach (var obs in observers)
                {
                    action(obs);
                }
            }
        }

        public void AddObserver(IBotObserver observer)
        {
            lock (observers)
            {
                observers.Add(observer);
            }
        }

        public void Dispose()
        {
            observers.Clear();

        }



        public async Task Start(ConnectionSettings info)
        {

            Status = BotStatus.Inizializing;
            try
            {
                await InternalStart(info);
            }
            catch (Exception e)
            {
                Status = BotStatus.None;
                Notify(n => n.OnError(e));
            }
            Status = BotStatus.Running;
            Notify(n => n.OnCompleted());


        }

        private async Task InternalStart(ConnectionSettings settings)
        {
            _logger.Info("Проверка данных для запуска...");

            Validate(settings);
            _logger.Info($"Запуск бота:" +
                $"Ник: {settings.Username}\n" +
                $"Сервер: {settings.Server}\n" +
                $"Версия протокола: {settings.ProtocolVersion}");


            (string host, ushort port) = await GetIpEndPoint(settings.Server);
            ITcpClientFactory tcpFactory = new TcpClientFactory();
            if (settings.ProxyEnabled)
            {
                //TODO
            }

            Notify(n => n.OnConnecting());
            _logger.Info($"Подключение к {host}:{port}");
            TcpClient tcpClient = tcpFactory.CreateTcpClient(host, port);
            _logger.Info($"Подключено");
            Notify(n => n.OnConnected());



            Notify(n => n.OnStarting());

        }

       


        public void Stop()
        {

        }


        #region Helpers
        private async Task<(string, ushort)> GetIpEndPoint(string address, CancellationToken cancellationToken = default)
        {
            var HostIp = address.Split(':');
            ushort port = 25565;
            string host = HostIp[0];
            if (HostIp.Length > 1)
            {
                port = ushort.Parse(HostIp[1]);
            }

            if (IPAddress.TryParse(host, out IPAddress adrr))
            {
                return (host, port);
            }


            IServerResolver resolver = new ServerResolver();
            try
            {

                Notify(n => n.SrvFinding());
                _logger.Info("Поиск srv...");

                var result = await resolver.ResolveAsync(host, cancellationToken);

                var ip = $"{result.Host}:{result.Port}";
                Notify(n => n.SrvFinded(ip));
                _logger.Info("Srv найден: " + ip);

                return (result.Host, result.Port);
            }
            catch (SrvNotFoundException)
            {
                _logger.Info($"Srv не найден.");
            }
            return (host, port);


        }
        private static void Validate(ConnectionSettings info)
        {
            Dictionary<string, string> errors = new();

            if (!string.IsNullOrEmpty(info.Username.Trim()))
            {
                errors.Add(nameof(info.Username), "Введите ник");
            }
            if (!string.IsNullOrEmpty(info.Server.Trim()))
            {
                errors.Add(nameof(info.Server), "Введите адрес");
            }
            if (info.AuthEnabled)
            {
                if (!string.IsNullOrEmpty(info.Password))
                {
                    errors.Add(nameof(info.Password), "Введите пароль");
                }
            }
            if (info.ProxyEnabled)
            {
                //TODO
                System.Diagnostics.Trace.WriteLine("TODOOOOOO");
            }

            if (errors.Any())
            {
                throw new ValidationException(errors);
            }
        }

        #endregion
    }




}

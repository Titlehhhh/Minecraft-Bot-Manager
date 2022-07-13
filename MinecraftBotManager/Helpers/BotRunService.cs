using McProtoNet.Utils;
using MinecraftBotManager.Api.Models;
using MinecraftBotManager.Data;
using MinecraftBotManager.ViewModels;
using System;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MinecraftBotManager.Helpers
{
    public class BotRunService
    {
        private readonly BotViewModel viewModel;
        private readonly BotInfo botInfo;
        public BotRunService(BotViewModel viewModel, BotInfo botInfo)
        {
            this.viewModel = viewModel;
            this.botInfo = botInfo;
        }

        private static readonly Regex IpRegex = new Regex(@"^(?<ip>[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}):(?<port>[0-9]{1,5})$");

        public async Task StartBot()
        {
            viewModel.AllStatusesDisabled();
            if (!Validate())
                return;

            LoadIcon();




            ITcpClientFactory tcpClientFactory = new TcpClientFactory();
            if (botInfo.ProxyEnabled)
            {
                throw new System.Exception("Proxy not support pass");
            }
            if (botInfo.AuthEnabled)
            {
                throw new InvalidOperationException();
            }
            var m = IpRegex.Match(botInfo.Server);
            if (m.Success)
            {
                viewModel.ServerStatus.Load("Подключение...");
                var ip = m.Groups["ip"].Value;
                ushort port = 0;
                try
                {
                    port = ushort.Parse(m.Groups["port"].Value);
                }
                catch
                {
                    viewModel.ServerStatus.Error("Ошибка парсинга адреса");

                    return;
                }
                TcpClient tcpClient = new TcpClient();
                try
                {                    
                    await tcpClient.ConnectAsync(ip, port);
                }
                catch(SocketException e)
                {
                    viewModel.ServerStatus.Error("Не удалось подключиться к серверу");
                    return;
                }

                viewModel.ServerStatus.Load("Рукопожатие");


            }




        }
        private bool Validate()
        {
            bool ok = true;
            if (string.IsNullOrEmpty(viewModel.Username))
            {
                viewModel.NickError = "Введите ник";
                ok = false;
            }
            if (string.IsNullOrEmpty(viewModel.Server))
            {
                viewModel.ServerStatus.Error("Введите адрес");
                ok = false;
            }
            if (viewModel.AuthEnabled)
            {
                if (string.IsNullOrEmpty(viewModel.Password))
                {
                    viewModel.AuthStatus.Error("Введите пароль");
                    ok = false;
                }
            }
            if (viewModel.ProxyEnabled)
            {
                if (string.IsNullOrEmpty(viewModel.ProxyAddress))
                {
                    
                    ok = false;
                }
            }
            return ok;
        }

        private void LoadIcon()
        {
            //TODO
        }
    }
}

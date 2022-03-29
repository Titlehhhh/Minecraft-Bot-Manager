using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinecraftLibrary;

namespace MinecraftBotManagerWPF
{
    internal class MinecraftClientInizializer
    {
        public BotViewModel BotViewModel { get; private set; }
        private readonly BotInfo botInfo;

        public MinecraftClientInizializer(BotViewModel botViewModel)
        {
            BotViewModel = botViewModel;
            this.botInfo = botViewModel.BotInfoModel;
        }

        public MinecraftClient CreateBot()
        {
            BotViewModel.ReturnToOrgignalStateStatuses();

            if (botInfo.IsAuth)
            {
                //TODO CheckAccount
            }
            else
            {

            }

            if (botInfo.ProxyEnabled)
            {
                if (botInfo.AutoFindProxyEnabled)
                {

                }
                //TODO FindProxy
            }
            else
            {

            }
            BotViewModel.BotState = State.Initialized;
            BotViewModel.RefreshPropertis();

            ushort port = 25565;
            var host = botInfo.Host;

            if (botInfo.Host.IndexOf(":") != -1)
            {
                var arr = botInfo.Host.Split(':');
                host = arr[0];
                try
                {
                    port = ushort.Parse(arr[1]);
                }
                catch (Exception e)
                {

                }

            }

            MinecraftClient client = new MinecraftClient()
            {
                Nickname = botInfo.Nickname,
                Host = host,
                Port = port
            };

            client.LoginSuccesed += (s, e) =>
            {
                BotViewModel.BotState = State.Running;
            };
            client.ConnectionLosted += (s, e) =>
            {
                BotViewModel.BotState = State.None;
            };
            client.GameRejected += (s, e) =>
            {
                BotViewModel.BotState = State.None;
            };
            client.LoginRejected += (s, e) =>
            {
                BotViewModel.BotState = State.None;
            };
            client.PropertyChanged += (s, e) =>
            {
                BotViewModel.OnPropertyChanged(e.PropertyName);
            };
            BotViewModel.Client = client;

            return client;

        }

        private static MinecraftClient CreateClient(BotInfo botInfo)
        {
            if (botInfo == null)
                throw new ArgumentNullException(nameof(botInfo));
            //TODO
            return null;

        }
    }
}

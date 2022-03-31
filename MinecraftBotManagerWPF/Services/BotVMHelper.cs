using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinecraftLibrary;

namespace MinecraftBotManagerWPF
{
    internal class BotVMHelper
    {
        public BotViewModel BotViewModel { get; private set; }
        private readonly BotInfo botInfo;

        public BotVMHelper(BotViewModel botViewModel)
        {
            BotViewModel = botViewModel;
            this.botInfo = botViewModel.BotInfoModel;
        }

        public async Task CreateBotAsync()
        {
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
                catch (Exception)
                {

                }

            }

            MinecraftClient754 client = new MinecraftClient754()
            {
                Nickname = botInfo.Nickname,
                Host = host,
                Port = port
            };

            
            client.ConnectionLosted += (s, e) =>
            {
                System.Windows.MessageBox.Show("Lost: \n"+e.ToString());

                BotViewModel.BotState = State.None;
            };
            client.GameRejected += (s, e) =>
            {
                System.Windows.MessageBox.Show("Kick: \n" + e.ToString());
                BotViewModel.BotState = State.None;
            };
            client.PropertyChanged += (s, e) =>
            {
                BotViewModel.OnPropertyChanged(e.PropertyName);
            };
            BotViewModel.Client = client;

            

        }

        private static MinecraftClient754 CreateClient(BotInfo botInfo)
        {
            if (botInfo == null)
                throw new ArgumentNullException(nameof(botInfo));
            //TODO
            return null;

        }
    }
}

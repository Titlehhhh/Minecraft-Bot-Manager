using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftBotManagerWPF.Commands
{
    internal class StartBotCommand : AsyncCommandBase
    {
        private readonly IServerResolver resolver;
        private readonly BotViewModel botViewModel;
        private readonly BotInfo botInfo;
        public StartBotCommand(BotViewModel botViewModel,IServerResolver resolver)
        {
            this.botViewModel = botViewModel;
            this.botInfo = botViewModel.BotInfoModel;
            this.resolver = resolver;
        }

        public async override Task ExecuteAsync(object parameter)
        {
            botViewModel.ReturnToOrgignalStateStatuses();

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

            

            
        }
    }
}

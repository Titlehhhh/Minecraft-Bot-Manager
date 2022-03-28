using MinecraftLibrary;
using System;
using System.Threading.Tasks;

namespace MinecraftBotManagerWPF
{
    internal class StartBotCommand : AsyncCommandBase
    {
        private readonly IServerResolver resolver;
        private readonly BotViewModel _botViewModel;
        private readonly BotInfo botInfo;
        public StartBotCommand(BotViewModel botViewModel, IServerResolver resolver)
        {
            this._botViewModel = botViewModel;
            this.botInfo = botViewModel.BotInfoModel;
            this.resolver = resolver;
        }

        public async override Task ExecuteAsync(object parameter)
        {
            _botViewModel.ReturnToOrgignalStateStatuses();

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
            _botViewModel.BotState = State.Initialized;
            _botViewModel.RefreshPropertis();
            try
            {
                MinecraftClient client = new MinecraftClient();

                client.LoginSuccesed += (s, e) =>
                {
                    _botViewModel.BotState = State.Running;
                };
                client.PropertyChanged += (s, e) =>
                {
                    _botViewModel.OnPropertyChanged(e.PropertyName);
                };



                _botViewModel.Client = client;
            }
            catch (Exception e)
            {
                _botViewModel.BotState = State.None;
            }


        }
    }
}

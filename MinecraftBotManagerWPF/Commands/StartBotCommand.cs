using MinecraftLibrary;
using MinecraftLibrary.API;
using MinecraftLibrary.Exceptions;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace MinecraftBotManagerWPF
{
    internal class StartBotCommand : AsyncCommandBase
    {
        private readonly IMinecraftBotRunner _runner;

        public StartBotCommand(IMinecraftBotRunner runner)
        {
            _runner = runner;
        }

        public async override Task ExecuteAsync(object parameter)
        {
            await _runner.PreparingAsync();

            if (!await _runner.AuthenticationAsync())
                return;
            if (!await _runner.ConfigureProxyAsync())
                return;
            if (!await _runner.ConfigureServerAsync())
                return;
            await _runner.RunBotAsync();

        }

    }
}

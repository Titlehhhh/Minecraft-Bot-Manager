﻿using McProtoNet.Core;
using McProtoNet.Utils;
using MinecraftBotManager.Domain;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace MinecraftBotManagerWPF
{
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


        private async Task<bool> AuthenticationAsync()
        {
            _botViewModel.AuthStatus.IsEnabled = true;
            _botViewModel.AuthStatus.Message = "Пропущено";
            _botViewModel.AuthStatus.Status = StatusCheck.Ok;
            builder.SetProfile(new GameProfile(Guid.NewGuid().ToString(), info.Nickname));
            return true;
        }

        private async Task<bool> ConfigureProxyAsync()
        {
            _botViewModel.ProxyStatus.IsEnabled = true;
            _botViewModel.ProxyStatus.Message = "Пропущено";
            _botViewModel.ProxyStatus.Status = StatusCheck.Ok;
            return true;
        }

        private async Task<bool> ConfigureServerAsync()
        {
            _botViewModel.ServerStatus.Load("Проверка сервера");
            var hostport = info.Host.Split(':');
            string host = info.Host;
            ushort port = 25565;
            if (hostport.Length == 2)
            {
                host = hostport[0];
                try
                {
                    port = ushort.Parse(hostport[1]);
                }
                catch
                {
                    _botViewModel.ServerStatus.Error("Ошибка парсинга порта");
                    return false;
                }
            }
            try
            {
                (host, port) = await _resolver.ResolveAsync(host);
                _botViewModel.ServerStatus.Succes($"Сервер найден:\n{host}:{port}");
            }
            catch
            {
                _botViewModel.ServerStatus.Error("Неизвестная ошибка");
                return false;
            }

            builder.SetHost(host, port);
            return true;


        }

        public async Task RunBotAsync()
        {
            await PreparingAsync();

            if (!await AuthenticationAsync())
                return;
            if (!await ConfigureProxyAsync())
                return;
            if (!await ConfigureServerAsync())
                return;


            try
            {
                MinecraftBot bot = builder.Build();
                IMinecraftClient client = bot.Client;

                _botViewModel.Client = client;

                

                await client.LoginAsync();

                _botViewModel.BotState = State.Running;
            }
            catch (LoginRejectException e)
            {
                _botViewModel.BotState = State.None;
            }
            catch (Exception e)
            {
                _botViewModel.BotState = State.None;
            }
        }

        private async Task PreparingAsync()
        {
            builder = new MinecraftBotBuilder();

            await this.botRepository.SaveAsync();
            _botViewModel.ReturnToOrgignalStateStatuses();
            _botViewModel.RefreshPropertis();
            _botViewModel.BotState = State.Initialized;
        }
    }
}

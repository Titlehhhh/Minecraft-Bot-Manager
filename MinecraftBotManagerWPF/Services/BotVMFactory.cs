using Microsoft.Extensions.DependencyInjection;

namespace MinecraftBotManagerWPF
{
    public class BotVMFactory : IBotVMFactory
    {
        private readonly IBotRepository botRepository;
        private readonly IServiceScopeFactory serviceScopeFactory;

        public BotVMFactory(IBotRepository botRepository, IServiceScopeFactory serviceScopeFactory)
        {
            this.botRepository = botRepository;
            this.serviceScopeFactory = serviceScopeFactory;
        }

        public BotViewModel Create(BotInfo bot)
        {
            return new BotViewModel(bot, botRepository, serviceScopeFactory);
        }
    }

}

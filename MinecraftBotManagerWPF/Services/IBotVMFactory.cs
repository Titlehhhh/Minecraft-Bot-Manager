namespace MinecraftBotManagerWPF
{
    public interface IBotVMFactory
    {
        BotViewModel Create(BotInfo bot);
    }

}

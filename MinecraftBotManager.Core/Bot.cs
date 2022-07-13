using MinecraftBotManager.Core.Minecraft;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftBotManager.Core
{
    public interface IBot
    {

    }

    public sealed class Bot: IBot
    {
        private static readonly MinecraftClientFactory factory = new();
        public Bot(BotOptions options)
        {

        }
    }
}

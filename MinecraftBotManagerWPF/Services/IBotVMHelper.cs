using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftBotManagerWPF
{
    public interface IBotVMHelper
    {
        Task StartBotAsync();
        Task StopBotAsync();
        Task RestartBotAsync();
    }
}

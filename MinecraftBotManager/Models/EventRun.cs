using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace MinecraftBotManager.Models
{
    public class EventRun : Run
    {
        private string command;
        
        public string EventCommand
        {
            get { return command; }
            set { command = value; }
        }


    }
}

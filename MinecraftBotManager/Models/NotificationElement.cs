using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftBotManager.Models
{
    public class NotificationElement
    {
        public NotifiType Type { get; set; }
        public string Message { get; set; }
        public NotificationElement()
        {

        }

        public NotificationElement(NotifiType type, string message)
        {
            Type = type;
            Message = message;
        }
    }
    public enum NotifiType : byte
    {
        OK=0,
        WARNING=1,
        ERROR=2
        
    }
}

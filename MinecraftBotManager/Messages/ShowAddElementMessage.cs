using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftBotManager.Messages
{
    public class ShowAddElementMessage : MessageBase
    {
        
        public ShowAddElementMessage()
        {

        }
        
    }
    public class CloseAddModuleMessage : MessageBase
    {
        public Type Result { get; set; }
        public CloseAddModuleMessage()
        {

        }
        public CloseAddModuleMessage(Type type)
        {
            Result = type;
        }
    }
}

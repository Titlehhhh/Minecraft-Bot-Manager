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
    public class InizializeData : MessageBase
    {
        public int MaxCount { get; private set; }
        public InizializeData(int max)
        {
            MaxCount = max;
        }
    }
    public class UpdateProgress : MessageBase
    {
        public int Progress { get;private set; }
        public string Text { get; private set; }

        public UpdateProgress(int progress, string text)
        {
            Progress = progress;
            Text = text;
        }
    }
}

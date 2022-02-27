using MinecraftLibrary.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftLibrary.API.Networking
{
    public class DisconnectedEventArgs : EventArgs
    {
        public string Message { get; private set; }
        public Exception Exception { get; private set; }        

        public DisconnectedEventArgs(string message, Exception exception=null)
        {
            Message = message;
            Exception = exception;            
        }
    }  
    
}


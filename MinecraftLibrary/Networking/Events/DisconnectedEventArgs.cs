using MinecraftLibrary.API.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftLibrary.Networking
{
    public class DisconnectedEventArgs : EventArgs
    {
        public string Message { get; private set; }
        public Exception Exception { get; private set; }
        public DisconnectReason Reason { get; private set; }

        public DisconnectedEventArgs(string message, Exception exception=null, DisconnectReason reason = DisconnectReason.ConnectionLost)
        {
            Message = message;
            Exception = exception;
            Reason = reason;
        }
    }  
    
}


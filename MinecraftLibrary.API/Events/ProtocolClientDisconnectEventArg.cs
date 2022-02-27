using MinecraftLibrary.API;
using MinecraftLibrary.API.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftLibrary.API
{
    public class ProtocolClientDisconnectEventArg : DisconnectedEventArgs
    {
        public ProtocolClientDisconnectEventArg(string message, Exception exception = null,DisconnectReason reason = DisconnectReason.ConnectionLost) : base(message, exception)
        {
            Reason = reason;
        }

        public DisconnectReason Reason { get; private set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftLibrary.API.Protocol
{
    public class JoinGameEventArgs : EventArgs
    {
        public int EntityID { get; private set; }
        public bool Hardcore { get; private set; }


    }
}

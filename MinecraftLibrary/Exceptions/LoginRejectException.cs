using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftLibrary.Exceptions
{
    public class LoginRejectException : Exception
    {
        public override string Message { get;  }

        public LoginRejectException(string message)
        {
            Message = message;
        }
    }
    
}

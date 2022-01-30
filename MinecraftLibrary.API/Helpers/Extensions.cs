using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftLibrary.API.Helpers
{
   public static class Extensions
    {
        public static List<Delegate> GetInvocationList(this Delegate d)
        {
            if (d == null)
                return new List<Delegate>();
            return d.GetInvocationList().ToList();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftLibrary.API.Networking.Attributes
{
    [AttributeUsage(AttributeTargets.Property,AllowMultiple =false)]
    public sealed class FieldAttribute : Attribute
    {
        public FieldAttribute(int order)
        {

        }
    }
}

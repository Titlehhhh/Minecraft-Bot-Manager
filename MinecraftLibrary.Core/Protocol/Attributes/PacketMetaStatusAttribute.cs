using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftLibrary.Core.Protocol.Attributes
{
    public sealed class PacketMetaStatusAttribute : PacketMetaAttribute
    {
        public PacketMetaStatusAttribute(int iD, params int[] protocols) : base(iD, protocols)
        {
        }
    }


}

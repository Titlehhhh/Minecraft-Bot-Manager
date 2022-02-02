using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftLibrary.API.Protocol.Attributes
{
    public sealed class PacketMetaStatusAttribute : PacketMetaAttribute
    {
        public PacketMetaStatusAttribute(int iD, params int[] protocols) : base(iD, protocols)
        {
        }

        public PacketMetaStatusAttribute(int iD, PacketState state = PacketState.Client, params int[] protocols) : base(iD, state, protocols)
        {
        }
    }


}

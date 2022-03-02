using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.IO;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtocolLib740.Packets.Client
{
    
    public class LoginPluginResponsePacket : IPacket
    {
        public int MessageID { get; set; }
        public byte[] Data { get; set; }

        public void Read(IMinecraftStreamReader stream)
        {
            throw new NotImplementedException();
        }

        public void Write(IMinecraftStreamWriter stream)
        {
            stream.WriteVarInt(MessageID);
            if(Data!=null)
            {
                stream.WriteBoolean(true);
                stream.Write(Data);
            }
            else
            {
                stream.WriteBoolean(false);
            }
        }

        public LoginPluginResponsePacket(int messageID, byte[] data)
        {
            MessageID = messageID;
            Data = data;
        }
        public LoginPluginResponsePacket()
        {

        }
    }
}

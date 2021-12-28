using MinecraftProtocol.IO;
using MinecraftProtocol.Packets;

namespace MinecraftLibrary.MinecraftProtocol.Packets.Server.Game
{
    public class ServerDestroyEntitiesPacket : ServerPacket
    {
        public int[] Entities { get; set; }
        public void Read(NetInput input, int version)
        {
            int count = input.ReadNextVarInt();
            Entities = new int[count];
            for(int i = 0; i < count; i++)
            {
                Entities[i] = input.ReadNextVarInt();
            }
        }
    }


}

using MinecraftLibrary.Data.Inventory;
using MinecraftProtocol.IO;
using MinecraftProtocol.Packets;

namespace MinecraftLibrary.MinecraftProtocol.Packets.Client.Game
{
    public class ClientUseItemPacket : ClientPacket
    {
        public Hand UseHand { get; set; }
        public void Write(NetOutput output, int version)
        {
            output.WriteVarInt((int)UseHand);
        }

        public ClientUseItemPacket(Hand useHand)
        {
            UseHand = useHand;
        }
    }



}

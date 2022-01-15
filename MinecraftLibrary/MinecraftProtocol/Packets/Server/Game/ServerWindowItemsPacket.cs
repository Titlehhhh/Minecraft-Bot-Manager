
using MinecraftLibrary.Data.Inventory;
using MinecraftProtocol.IO;
using MinecraftProtocol.Packets;
using System.Collections.Generic;


namespace MinecraftLibrary.MinecraftProtocol.Packets.Server.Game
{
    public class ServerWindowItemsPacket : ServerPacket
    {
        public byte WindowID { get; private set; }
        public Dictionary<int,Item> Items { get; private set; }
        public void Read(NetInput input, int version)
        {
            Items = new Dictionary<int, Item>();
            WindowID = input.ReadNextByte();
            short elements = input.ReadNextShort();
            var pallete = PalletesExtensions.GetItemPalette(version);
            for (short slot =0;slot<elements;slot++)
            {
                Item item = input.ReadNextItemSlot(pallete);
                if (item != null)
                    Items[slot] = item;
            }
        }
    }   


}

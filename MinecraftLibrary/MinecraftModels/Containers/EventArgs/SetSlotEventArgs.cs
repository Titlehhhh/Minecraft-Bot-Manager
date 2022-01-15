using MinecraftLibrary.Data.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftLibrary.MinecraftModels.Containers.EventArgs
{
    public class SetSlotEventArgs
    {
        public int Slot { get; private set; }
        public Item Item { get; private set; }
        public EventType Type { get; private set; }

        public SetSlotEventArgs(int slot, Item item, EventType type)
        {
            Slot = slot;
            Item = item;
            Type = type;
        }
    }
    public enum EventType
    {
        Changed,
        Remove
    }
}

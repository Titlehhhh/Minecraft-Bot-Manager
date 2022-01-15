using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using MinecraftLibrary.Data.Inventory;
using System.Collections.Specialized;
using MinecraftLibrary.MinecraftModels.Containers.EventArgs;
using System.ComponentModel;
using System.Collections;

namespace MinecraftLibrary.MinecraftModels.Containers
{

    public abstract class ContainerBase
    {

        public event EventHandler<SetSlotEventArgs> SetSlotChanged;
        public Dictionary<int, Item> Items { get; set; } = new Dictionary<int, Item>();

        public Item this[int slot]
        {
            set
            {
                Items[slot] = value;
                SetSlotChanged?.Invoke(this, new SetSlotEventArgs(slot, value, EventType.Changed));
            }
            get
            {
                return Items[slot];
            }
        }
        public void UpdateItem(int slot, Item item)
        {
            this[slot] = item;
        }
        public bool RemoveItem(int slot)
        {
            bool b = Items.Remove(slot);
            if (b)
            {
                SetSlotChanged?.Invoke(this, new SetSlotEventArgs(slot, null, EventType.Remove));
            }
            return b;
        }
        public Item GetItem(int slot)
        {
            return this[slot];
        }
        public void Clear()
        {
            foreach (var item in Items)
            {
                SetSlotChanged?.Invoke(this, new SetSlotEventArgs(item.Key, item.Value, EventType.Remove));
            }
            Items.Clear();
        }
    }

}

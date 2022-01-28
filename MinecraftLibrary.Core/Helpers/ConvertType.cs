
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftLibrary.API.Helpers
{
    public static class ConvertType
    {
        public static ContainerType ToNew(ContainerTypeOld type)
        {
            switch (type)
            {
                case ContainerTypeOld.CONTAINER: return ContainerType.Unknown;
                case ContainerTypeOld.CHEST: return ContainerType.Generic_9x3;
                case ContainerTypeOld.CRAFTING_TABLE: return ContainerType.Crafting;
                case ContainerTypeOld.FURNACE: return ContainerType.Furnace;
                case ContainerTypeOld.DISPENSER: return ContainerType.Generic_3x3;
                case ContainerTypeOld.ENCHANTING_TABLE: return ContainerType.Enchantment;
                case ContainerTypeOld.BREWING_STAND: return ContainerType.BrewingStand;
                case ContainerTypeOld.VILLAGER: return ContainerType.Merchant;
                case ContainerTypeOld.HOPPER: return ContainerType.Hopper;
                case ContainerTypeOld.DROPPER: return ContainerType.Generic_3x3;
                case ContainerTypeOld.SHULKER_BOX: return ContainerType.ShulkerBox;
                case ContainerTypeOld.ENTITYHORSE: return ContainerType.Unknown;
                default: return ContainerType.Unknown;
            }
        }
    }
}

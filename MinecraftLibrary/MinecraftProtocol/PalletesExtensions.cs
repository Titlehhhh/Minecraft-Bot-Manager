using MinecraftLibrary.Data.Inventory.ItemPalettes;
using MinecraftLibrary.Palletes;
using System;
using System.Collections.Generic;
using static MinecraftLibrary.MinecraftConstans;

namespace MinecraftLibrary.MinecraftProtocol
{
    public static class PalletesExtensions
    {
        private static readonly SortedDictionary<Range, EntityPalette> EntityPalletes = new SortedDictionary<Range, EntityPalette>();

        private static readonly SortedDictionary<Range, ItemPalette> ItemPalettes = new SortedDictionary<Range, ItemPalette>();

        private static readonly SortedDictionary<Range, BlockPalette> BlockPalettes = new SortedDictionary<Range, BlockPalette>();
        static PalletesExtensions()
        {
            
            EntityPalletes.Add(new Range(MC18Version, MC113Version-1), new EntityPalette112());
            EntityPalletes.Add(new Range(MC113Version , MC114Version-1), new EntityPalette113());
            EntityPalletes.Add(new Range(MC114Version, MC115Version-1), new EntityPalette114());
            EntityPalletes.Add(new Range(MC115Version, MC116Version-1), new EntityPalette115());
            EntityPalletes.Add(new Range(MC116Version, MC1162Version-1), new EntityPalette1161());
            EntityPalletes.Add(new Range(MC1162Version), new EntityPalette1162());

            ItemPalettes.Add(new Range(MC18Version, MC116Version - 1), new ItemPalette115());
            ItemPalettes.Add(new Range(MC116Version, MC1161Version-1), new ItemPalette1161());
            ItemPalettes.Add(new Range(MC1161Version, MC1162Version), new ItemPalette1162());

            BlockPalettes.Add(new Range(MC18Version,MC113Version-1),new Palette112());
            BlockPalettes.Add(new Range(MC113Version, MC114Version - 1), new Palette113());
            BlockPalettes.Add(new Range(MC114Version, MC115Version - 1), new Palette114());
            BlockPalettes.Add(new Range(MC115Version, MC1165Version), new Palette116());
            
            
        }
        public static EntityPalette GetEntityPalette(int version)
        {
            return EntityPalletes[new Range(version)];
        }
        public static ItemPalette GetItemPalette(int version)
        {
            return ItemPalettes[new Range(version)];
        }
        public static BlockPalette GetBlockPalette(int version)
        {
            return BlockPalettes[new Range(version)];
        }
        private class Range : IComparable<Range>
        {
            public int From;
            public int To;

            public Range(int from, int to)
            {
                From = from;
                To = to;
            }
            public Range(int point)
            {
                From = To = point;
            }

            public int CompareTo(Range other)
            {
                if (From <= other.To && To >= other.From)
                {
                    return 0;
                }
                return From.CompareTo(other.From);
            }
        }
    }

}

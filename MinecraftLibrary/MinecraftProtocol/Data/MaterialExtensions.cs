﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinecraftLibrary.Data
{
    /// <summary>
    /// Defines extension methods for the Material enumeration
    /// </summary>
    public static class MaterialExtensions
    {
        /// <summary>
        /// Check if the player cannot pass through the specified material
        /// </summary>
        /// <param name="m">Material to test</param>
        /// <returns>True if the material is harmful</returns>
        public static bool IsSolid(this Material m)
        {
            switch (m)
            {
                case Material.Stone:
                case Material.Granite:
                case Material.PolishedGranite:
                case Material.Diorite:
                case Material.PolishedDiorite:
                case Material.Andesite:
                case Material.PolishedAndesite:
                case Material.GrassBlock:
                case Material.Dirt:
                case Material.CoarseDirt:
                case Material.Podzol:
                case Material.Cobblestone:
                case Material.OakPlanks:
                case Material.SprucePlanks:
                case Material.BirchPlanks:
                case Material.JunglePlanks:
                case Material.AcaciaPlanks:
                case Material.DarkOakPlanks:
                case Material.Bedrock:
                case Material.Sand:
                case Material.RedSand:
                case Material.Gravel:
                case Material.GoldOre:
                case Material.IronOre:
                case Material.CoalOre:
                case Material.OakLog:
                case Material.SpruceLog:
                case Material.BirchLog:
                case Material.JungleLog:
                case Material.AcaciaLog:
                case Material.DarkOakLog:
                case Material.StrippedSpruceLog:
                case Material.StrippedBirchLog:
                case Material.StrippedJungleLog:
                case Material.StrippedAcaciaLog:
                case Material.StrippedDarkOakLog:
                case Material.StrippedOakLog:
                case Material.OakWood:
                case Material.SpruceWood:
                case Material.BirchWood:
                case Material.JungleWood:
                case Material.AcaciaWood:
                case Material.DarkOakWood:
                case Material.StrippedOakWood:
                case Material.StrippedSpruceWood:
                case Material.StrippedBirchWood:
                case Material.StrippedJungleWood:
                case Material.StrippedAcaciaWood:
                case Material.StrippedDarkOakWood:
                case Material.OakLeaves:
                case Material.SpruceLeaves:
                case Material.BirchLeaves:
                case Material.JungleLeaves:
                case Material.AcaciaLeaves:
                case Material.DarkOakLeaves:
                case Material.Sponge:
                case Material.WetSponge:
                case Material.Glass:
                case Material.LapisOre:
                case Material.LapisBlock:
                case Material.Dispenser:
                case Material.Sandstone:
                case Material.ChiseledSandstone:
                case Material.CutSandstone:
                case Material.NoteBlock:
                case Material.WhiteBed:
                case Material.OrangeBed:
                case Material.MagentaBed:
                case Material.LightBlueBed:
                case Material.YellowBed:
                case Material.LimeBed:
                case Material.PinkBed:
                case Material.GrayBed:
                case Material.LightGrayBed:
                case Material.CyanBed:
                case Material.PurpleBed:
                case Material.BlueBed:
                case Material.BrownBed:
                case Material.GreenBed:
                case Material.RedBed:
                case Material.BlackBed:
                case Material.StickyPiston:
                case Material.Piston:
                case Material.PistonHead:
                case Material.WhiteWool:
                case Material.OrangeWool:
                case Material.MagentaWool:
                case Material.LightBlueWool:
                case Material.YellowWool:
                case Material.LimeWool:
                case Material.PinkWool:
                case Material.GrayWool:
                case Material.LightGrayWool:
                case Material.CyanWool:
                case Material.PurpleWool:
                case Material.BlueWool:
                case Material.BrownWool:
                case Material.GreenWool:
                case Material.RedWool:
                case Material.BlackWool:
                case Material.MovingPiston:
                case Material.GoldBlock:
                case Material.IronBlock:
                case Material.Bricks:
                case Material.Tnt:
                case Material.Bookshelf:
                case Material.MossyCobblestone:
                case Material.Obsidian:
                case Material.Spawner:
                case Material.OakStairs:
                case Material.Chest:
                case Material.DiamondOre:
                case Material.DiamondBlock:
                case Material.CraftingTable:
                case Material.Farmland:
                case Material.Furnace:
                case Material.OakDoor:
                case Material.Ladder:
                case Material.CobblestoneStairs:
                case Material.IronDoor:
                case Material.RedstoneOre:
                case Material.Ice:
                case Material.SnowBlock:
                case Material.Cactus:
                case Material.Clay:
                case Material.Jukebox:
                case Material.OakFence:
                case Material.Pumpkin:
                case Material.Netherrack:
                case Material.SoulSand:
                case Material.Glowstone:
                case Material.CarvedPumpkin:
                case Material.JackOLantern:
                case Material.Cake:
                case Material.WhiteStainedGlass:
                case Material.OrangeStainedGlass:
                case Material.MagentaStainedGlass:
                case Material.LightBlueStainedGlass:
                case Material.YellowStainedGlass:
                case Material.LimeStainedGlass:
                case Material.PinkStainedGlass:
                case Material.GrayStainedGlass:
                case Material.LightGrayStainedGlass:
                case Material.CyanStainedGlass:
                case Material.PurpleStainedGlass:
                case Material.BlueStainedGlass:
                case Material.BrownStainedGlass:
                case Material.GreenStainedGlass:
                case Material.RedStainedGlass:
                case Material.BlackStainedGlass:
                case Material.OakTrapdoor:
                case Material.SpruceTrapdoor:
                case Material.BirchTrapdoor:
                case Material.JungleTrapdoor:
                case Material.AcaciaTrapdoor:
                case Material.DarkOakTrapdoor:
                case Material.StoneBricks:
                case Material.MossyStoneBricks:
                case Material.CrackedStoneBricks:
                case Material.ChiseledStoneBricks:
                case Material.InfestedStone:
                case Material.InfestedCobblestone:
                case Material.InfestedStoneBricks:
                case Material.InfestedMossyStoneBricks:
                case Material.InfestedCrackedStoneBricks:
                case Material.InfestedChiseledStoneBricks:
                case Material.BrownMushroomBlock:
                case Material.RedMushroomBlock:
                case Material.MushroomStem:
                case Material.IronBars:
                case Material.GlassPane:
                case Material.Melon:
                case Material.OakFenceGate:
                case Material.BrickStairs:
                case Material.StoneBrickStairs:
                case Material.Mycelium:
                case Material.LilyPad:
                case Material.NetherBricks:
                case Material.NetherBrickFence:
                case Material.NetherBrickStairs:
                case Material.EnchantingTable:
                case Material.BrewingStand:
                case Material.Cauldron:
                case Material.EndPortalFrame:
                case Material.EndStone:
                case Material.DragonEgg:
                case Material.RedstoneLamp:
                case Material.SandstoneStairs:
                case Material.EmeraldOre:
                case Material.EnderChest:
                case Material.EmeraldBlock:
                case Material.SpruceStairs:
                case Material.BirchStairs:
                case Material.JungleStairs:
                case Material.CommandBlock:
                case Material.Beacon:
                case Material.CobblestoneWall:
                case Material.MossyCobblestoneWall:
                case Material.FlowerPot:
                case Material.PottedOakSapling:
                case Material.PottedSpruceSapling:
                case Material.PottedBirchSapling:
                case Material.PottedJungleSapling:
                case Material.PottedAcaciaSapling:
                case Material.PottedDarkOakSapling:
                case Material.PottedFern:
                case Material.PottedDandelion:
                case Material.PottedPoppy:
                case Material.PottedBlueOrchid:
                case Material.PottedAllium:
                case Material.PottedAzureBluet:
                case Material.PottedRedTulip:
                case Material.PottedOrangeTulip:
                case Material.PottedWhiteTulip:
                case Material.PottedPinkTulip:
                case Material.PottedOxeyeDaisy:
                case Material.PottedCornflower:
                case Material.PottedLilyOfTheValley:
                case Material.PottedWitherRose:
                case Material.PottedRedMushroom:
                case Material.PottedBrownMushroom:
                case Material.PottedDeadBush:
                case Material.PottedCactus:
                case Material.SkeletonSkull:
                case Material.SkeletonWallSkull:
                case Material.WitherSkeletonSkull:
                case Material.WitherSkeletonWallSkull:
                case Material.ZombieHead:
                case Material.ZombieWallHead:
                case Material.PlayerHead:
                case Material.PlayerWallHead:
                case Material.CreeperHead:
                case Material.CreeperWallHead:
                case Material.DragonHead:
                case Material.DragonWallHead:
                case Material.Anvil:
                case Material.ChippedAnvil:
                case Material.DamagedAnvil:
                case Material.TrappedChest:
                case Material.DaylightDetector:
                case Material.RedstoneBlock:
                case Material.NetherQuartzOre:
                case Material.Hopper:
                case Material.QuartzBlock:
                case Material.ChiseledQuartzBlock:
                case Material.QuartzPillar:
                case Material.QuartzStairs:
                case Material.Dropper:
                case Material.WhiteTerracotta:
                case Material.OrangeTerracotta:
                case Material.MagentaTerracotta:
                case Material.LightBlueTerracotta:
                case Material.YellowTerracotta:
                case Material.LimeTerracotta:
                case Material.PinkTerracotta:
                case Material.GrayTerracotta:
                case Material.LightGrayTerracotta:
                case Material.CyanTerracotta:
                case Material.PurpleTerracotta:
                case Material.BlueTerracotta:
                case Material.BrownTerracotta:
                case Material.GreenTerracotta:
                case Material.RedTerracotta:
                case Material.BlackTerracotta:
                case Material.WhiteStainedGlassPane:
                case Material.OrangeStainedGlassPane:
                case Material.MagentaStainedGlassPane:
                case Material.LightBlueStainedGlassPane:
                case Material.YellowStainedGlassPane:
                case Material.LimeStainedGlassPane:
                case Material.PinkStainedGlassPane:
                case Material.GrayStainedGlassPane:
                case Material.LightGrayStainedGlassPane:
                case Material.CyanStainedGlassPane:
                case Material.PurpleStainedGlassPane:
                case Material.BlueStainedGlassPane:
                case Material.BrownStainedGlassPane:
                case Material.GreenStainedGlassPane:
                case Material.RedStainedGlassPane:
                case Material.BlackStainedGlassPane:
                case Material.AcaciaStairs:
                case Material.DarkOakStairs:
                case Material.SlimeBlock:
                case Material.Barrier:
                case Material.IronTrapdoor:
                case Material.Prismarine:
                case Material.PrismarineBricks:
                case Material.DarkPrismarine:
                case Material.PrismarineStairs:
                case Material.PrismarineBrickStairs:
                case Material.DarkPrismarineStairs:
                case Material.PrismarineSlab:
                case Material.PrismarineBrickSlab:
                case Material.DarkPrismarineSlab:
                case Material.SeaLantern:
                case Material.HayBlock:
                case Material.Terracotta:
                case Material.CoalBlock:
                case Material.PackedIce:
                case Material.RedSandstone:
                case Material.ChiseledRedSandstone:
                case Material.CutRedSandstone:
                case Material.RedSandstoneStairs:
                case Material.OakSlab:
                case Material.SpruceSlab:
                case Material.BirchSlab:
                case Material.JungleSlab:
                case Material.AcaciaSlab:
                case Material.DarkOakSlab:
                case Material.StoneSlab:
                case Material.SmoothStoneSlab:
                case Material.SandstoneSlab:
                case Material.CutSandstoneSlab:
                case Material.PetrifiedOakSlab:
                case Material.CobblestoneSlab:
                case Material.BrickSlab:
                case Material.StoneBrickSlab:
                case Material.NetherBrickSlab:
                case Material.QuartzSlab:
                case Material.RedSandstoneSlab:
                case Material.CutRedSandstoneSlab:
                case Material.PurpurSlab:
                case Material.SmoothStone:
                case Material.SmoothSandstone:
                case Material.SmoothQuartz:
                case Material.SmoothRedSandstone:
                case Material.SpruceFenceGate:
                case Material.BirchFenceGate:
                case Material.JungleFenceGate:
                case Material.AcaciaFenceGate:
                case Material.DarkOakFenceGate:
                case Material.SpruceFence:
                case Material.BirchFence:
                case Material.JungleFence:
                case Material.AcaciaFence:
                case Material.DarkOakFence:
                case Material.SpruceDoor:
                case Material.BirchDoor:
                case Material.JungleDoor:
                case Material.AcaciaDoor:
                case Material.DarkOakDoor:
                case Material.EndRod:
                case Material.ChorusPlant:
                case Material.ChorusFlower:
                case Material.PurpurBlock:
                case Material.PurpurPillar:
                case Material.PurpurStairs:
                case Material.EndStoneBricks:
                case Material.GrassPath:
                case Material.RepeatingCommandBlock:
                case Material.ChainCommandBlock:
                case Material.FrostedIce:
                case Material.MagmaBlock:
                case Material.NetherWartBlock:
                case Material.RedNetherBricks:
                case Material.BoneBlock:
                case Material.Observer:
                case Material.ShulkerBox:
                case Material.WhiteShulkerBox:
                case Material.OrangeShulkerBox:
                case Material.MagentaShulkerBox:
                case Material.LightBlueShulkerBox:
                case Material.YellowShulkerBox:
                case Material.LimeShulkerBox:
                case Material.PinkShulkerBox:
                case Material.GrayShulkerBox:
                case Material.LightGrayShulkerBox:
                case Material.CyanShulkerBox:
                case Material.PurpleShulkerBox:
                case Material.BlueShulkerBox:
                case Material.BrownShulkerBox:
                case Material.GreenShulkerBox:
                case Material.RedShulkerBox:
                case Material.BlackShulkerBox:
                case Material.WhiteGlazedTerracotta:
                case Material.OrangeGlazedTerracotta:
                case Material.MagentaGlazedTerracotta:
                case Material.LightBlueGlazedTerracotta:
                case Material.YellowGlazedTerracotta:
                case Material.LimeGlazedTerracotta:
                case Material.PinkGlazedTerracotta:
                case Material.GrayGlazedTerracotta:
                case Material.LightGrayGlazedTerracotta:
                case Material.CyanGlazedTerracotta:
                case Material.PurpleGlazedTerracotta:
                case Material.BlueGlazedTerracotta:
                case Material.BrownGlazedTerracotta:
                case Material.GreenGlazedTerracotta:
                case Material.RedGlazedTerracotta:
                case Material.BlackGlazedTerracotta:
                case Material.WhiteConcrete:
                case Material.OrangeConcrete:
                case Material.MagentaConcrete:
                case Material.LightBlueConcrete:
                case Material.YellowConcrete:
                case Material.LimeConcrete:
                case Material.PinkConcrete:
                case Material.GrayConcrete:
                case Material.LightGrayConcrete:
                case Material.CyanConcrete:
                case Material.PurpleConcrete:
                case Material.BlueConcrete:
                case Material.BrownConcrete:
                case Material.GreenConcrete:
                case Material.RedConcrete:
                case Material.BlackConcrete:
                case Material.WhiteConcretePowder:
                case Material.OrangeConcretePowder:
                case Material.MagentaConcretePowder:
                case Material.LightBlueConcretePowder:
                case Material.YellowConcretePowder:
                case Material.LimeConcretePowder:
                case Material.PinkConcretePowder:
                case Material.GrayConcretePowder:
                case Material.LightGrayConcretePowder:
                case Material.CyanConcretePowder:
                case Material.PurpleConcretePowder:
                case Material.BlueConcretePowder:
                case Material.BrownConcretePowder:
                case Material.GreenConcretePowder:
                case Material.RedConcretePowder:
                case Material.BlackConcretePowder:
                case Material.DriedKelpBlock:
                case Material.TurtleEgg:
                case Material.DeadTubeCoralBlock:
                case Material.DeadBrainCoralBlock:
                case Material.DeadBubbleCoralBlock:
                case Material.DeadFireCoralBlock:
                case Material.DeadHornCoralBlock:
                case Material.TubeCoralBlock:
                case Material.BrainCoralBlock:
                case Material.BubbleCoralBlock:
                case Material.FireCoralBlock:
                case Material.HornCoralBlock:
                case Material.SeaPickle:
                case Material.BlueIce:
                case Material.Conduit:
                case Material.Bamboo:
                case Material.PottedBamboo:
                case Material.BubbleColumn:
                case Material.PolishedGraniteStairs:
                case Material.SmoothRedSandstoneStairs:
                case Material.MossyStoneBrickStairs:
                case Material.PolishedDioriteStairs:
                case Material.MossyCobblestoneStairs:
                case Material.EndStoneBrickStairs:
                case Material.StoneStairs:
                case Material.SmoothSandstoneStairs:
                case Material.SmoothQuartzStairs:
                case Material.GraniteStairs:
                case Material.AndesiteStairs:
                case Material.RedNetherBrickStairs:
                case Material.PolishedAndesiteStairs:
                case Material.DioriteStairs:
                case Material.PolishedGraniteSlab:
                case Material.SmoothRedSandstoneSlab:
                case Material.MossyStoneBrickSlab:
                case Material.PolishedDioriteSlab:
                case Material.MossyCobblestoneSlab:
                case Material.EndStoneBrickSlab:
                case Material.SmoothSandstoneSlab:
                case Material.SmoothQuartzSlab:
                case Material.GraniteSlab:
                case Material.AndesiteSlab:
                case Material.RedNetherBrickSlab:
                case Material.PolishedAndesiteSlab:
                case Material.DioriteSlab:
                case Material.BrickWall:
                case Material.PrismarineWall:
                case Material.RedSandstoneWall:
                case Material.MossyStoneBrickWall:
                case Material.GraniteWall:
                case Material.StoneBrickWall:
                case Material.NetherBrickWall:
                case Material.AndesiteWall:
                case Material.RedNetherBrickWall:
                case Material.SandstoneWall:
                case Material.EndStoneBrickWall:
                case Material.DioriteWall:
                case Material.Loom:
                case Material.Barrel:
                case Material.Smoker:
                case Material.BlastFurnace:
                case Material.CartographyTable:
                case Material.FletchingTable:
                case Material.Grindstone:
                case Material.Lectern:
                case Material.SmithingTable:
                case Material.Stonecutter:
                case Material.Bell:
                case Material.Lantern:
                case Material.Campfire:
                case Material.StructureBlock:
                case Material.Jigsaw:
                case Material.Composter:
                case Material.BeeNest:
                case Material.Beehive:
                case Material.HoneyBlock:
                case Material.HoneycombBlock:
                    return true;
                default:
                    return false;
            }
        }

        /// <summary>
        /// Check if contact with the provided material can harm players
        /// </summary>
        /// <param name="m">Material to test</param>
        /// <returns>True if the material is harmful</returns>
        public static bool CanHarmPlayers(this Material m)
        {
            switch (m)
            {
                case Material.Fire:
                case Material.Cactus:
                case Material.Lava:
                case Material.MagmaBlock:
                case Material.Campfire:
                    return true;
                default:
                    return false;
            }
        }

        /// <summary>
        /// Check if the provided material is a liquid a player can swim into
        /// </summary>
        /// <param name="m">Material to test</param>
        /// <returns>True if the material is a liquid</returns>
        public static bool IsLiquid(this Material m)
        {
            switch (m)
            {
                case Material.Water:
                case Material.Lava:
                    return true;
                default:
                    return false;
            }
        }
    }
}

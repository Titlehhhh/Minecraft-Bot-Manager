﻿using MinecraftLibrary.MinecraftProtocol.Packets.Client.Game;
using MinecraftLibrary.MinecraftProtocol.Packets.Server.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftLibrary.MinecraftProtocol.PacketPalletes
{
    public class Packets1_16_5 : PacketPallete
    {
        private static readonly Dictionary<int, Type> typeIn = new Dictionary<int, Type>()
        {
            {0x00,typeof(ServerSpawnEntityPacket)},
            {0x01,typeof(ServerSpawnExpOrbPacket)},
            {0x02,typeof(ServerSpawnLivingEntityPacket)},
            {0x03,typeof(ServerSpawnPaintingPacket)},
            {0x04,typeof(ServerSpawnPlayerPacket)},
            {0x05,typeof(ServerEntityAnimationPacket)},
            {0x06,typeof(ServerStatisticsPacket)},
            {0x07,typeof(ServerPlayerActionAckPacket)},
            {0x08,typeof(ServerBlockBreakAnimPacket)},
            {0x09,typeof(ServerUpdateTileEntityPacket)},
            {0x0A,typeof(ServerBlockValuePacket)},
            {0x0B,typeof(ServerBlockChangePacket)},
            {0x0C,typeof(ServerBossBarPacket)},
            {0x0D,typeof(ServerDifficultyPacket)},
            {0x0E,typeof(ServerChatMessagePacket)},
            {0x0F,typeof(ServerTabCompletePacket)},
            {0x10,typeof(ServerDeclareCommandsPacket)},
            {0x11,typeof(ServerWindowConfirmationPacket)},
            {0x12,typeof(ServerCloseWindowPacket)},
            {0x13,typeof(ServerWindowItemsPacket)},
            {0x14,typeof(ServerWindowPropertyPacket)},
            {0x15,typeof(ServerSetSlotPacket)},
            {0x16,typeof(ServerSetCooldownPacket)},
            {0x17,typeof(ServerPluginMessagePacket)},
            {0x18,typeof(ServerPlaySoundPacket)},
            {0x19,typeof(ServerDisconnectPacket)},
            {0x1A,typeof(ServerEntityStatusPacket)},
            {0x1B,typeof(ServerExplosionPacket)},
            {0x1C,typeof(ServerUnloadChunkPacket)},
            {0x1D,typeof(ServerNotifyClientPacket)},
            {0x1E,typeof(ServerOpenHorseWindowPacket)},
            {0x1F,typeof(ServerKeepAlivePacket)},
            {0x20,typeof(ServerChunkDataPacket)},
            {0x21,typeof(ServerPlayEffectPacket)},
            {0x22,typeof(ServerSpawnParticlePacket)},
            {0x23,typeof(ServerUpdateLightPacket)},
            {0x24,typeof(ServerJoinGamePacket)},
            {0x25,typeof(ServerMapDataPacket)},
            {0x26,typeof(ServerTradeListPacket)},
            {0x27,typeof(ServerEntityPositionPacket)},
            {0x28,typeof(ServerEntityPositionAndRotationPacket)},
            {0x29,typeof(ServerEntityRotationPacket)},
            {0x2A,typeof(ServerEntityMovementPacket)},
            {0x2B,typeof(ServerVehicleMovePacket)},
            {0x2C,typeof(ServerOpenBookPacket)},
            {0x2D,typeof(ServerOpenWindowPacket)},
            {0x2E,typeof(ServerOpenTileEntityEditorPacket)},
            {0x2F,typeof(ServerPreparedCraftingGridPacket)},
            {0x30,typeof(ServerPlayerAbilitiesPacket)},
            {0x31,typeof(ServerCombatPacket)},
            {0x32,typeof(ServerPlayerInfoPacket)},
            {0x33,typeof(ServerPlayerFacingPacket)},
            {0x34,typeof(ServerPlayerPositionAndLookPacket)},
            {0x35,typeof(ServerUnlockRecipesPacket)},
            {0x36,typeof(ServerDestroyEntitiesPacket)},
            {0x37,typeof(ServerEntityRemoveEffectPacket)},
            {0x38,typeof(ServerResourcePackSendPacket)},
            {0x39,typeof(ServerRespawnPacket)},
            {0x3A,typeof(ServerEntityHeadLookPacket)},
            {0x3B,typeof(ServerMultiBlockChangePacket)},
            {0x3C,typeof(ServerAdvancementTabPacket)},
            {0x3D,typeof(ServerWorldBorderPacket)},
            {0x3E,typeof(ServerSwitchCameraPacket)},
            {0x3F,typeof(ServerHeldItemChangePacket)},
            {0x40,typeof(ServerUpdateViewPositionPacket)},
            {0x41,typeof(ServerUpdateViewDistancePacket)},
            {0x42,typeof(ServerSpawnPositionPacket)},
            {0x43,typeof(ServerDisplayScoreboardPacket)},
            {0x44,typeof(ServerEntityMetadataPacket)},
            {0x45,typeof(ServerAttachEntityPacket)},
            {0x46,typeof(ServerEntityVelocityPacket)},
            {0x47,typeof(ServerEntityEquipmentPacket)},
            {0x48,typeof(ServerSetExperiencePacket)},
            {0x49,typeof(ServerPlayerHealthPacket)},
            {0x4A,typeof(ServerScoreboardObjectivePacket)},
            {0x4B,typeof(ServerEntitySetPassengersPacket)},
            {0x4C,typeof(ServerTeamPacket)},
            {0x4D,typeof(ServerUpdateScorePacket)},
            {0x4E,typeof(ServerTimeUpdatePacket)},
            {0x4F,typeof(ServerTitlePacket)},
            {0x50,typeof(ServerSoundEffectPacket)},
            {0x51,typeof(ServerPlayBuiltinSoundPacket)},
            {0x52,typeof(ServerStopSoundPacket)},
            {0x53,typeof(ServerPlayerListDataPacket)},
            {0x54,typeof(ServerNBTResponsePacket)},
            {0x55,typeof(ServerEntityCollectItemPacket)},
            {0x56,typeof(ServerEntityTeleportPacket)},
            {0x57,typeof(ServerAdvancementsPacket)},
            {0x58,typeof(ServerEntityPropertiesPacket)},
            {0x59,typeof(ServerEntityEffectPacket)},
            {0x5A,typeof(ServerDeclareRecipesPacket)},
            {0x5B,typeof(ServerDeclareTagsPacket)}
        };
        private static readonly Dictionary<Type, int> typeOut = new Dictionary<Type, int>()
        {
            {typeof(ClientTeleportConfirmPacket),0x00},
            {typeof(ClientBlockNBTRequestPacket),0x01},
            {typeof(ClientSetDifficultyPacket),0x02},
            {typeof(ClientChatMessagePacket),0x03},
            {typeof(ClientRequestPacket),0x04},
            {typeof(ClientSettingsPacket),0x05},
            {typeof(ClientTabCompletePacket),0x06},
            {typeof(ClientWindowConfirmationPacket),0x07},
            {typeof(ClientClickWindowButtonPacket),0x08},
            {typeof(ClientWindowActionPacket),0x09},
            {typeof(ClientCloseWindowPacket),0x0A},
            {typeof(ClientPluginMessagePacket),0x0B},
            {typeof(ClientEditBookPacket),0x0C},
            {typeof(ClientEntityNBTRequestPacket),0x0D},
            {typeof(ClientEntityActionPacket),0x0E},
            {typeof(ClientGenerateStructuresPacket),0x0F},
            {typeof(ClientKeepAlivePacket),0x10},
            {typeof(ClientLockDifficultyPacket),0x11},
            {typeof(ClientPlayerPositionPacket),0x12},
            {typeof(ClientPlayerPositionAndRotationPacket),0x13},
            {typeof(ClientPlayerRotationPacket),0x14},
            {typeof(ClientPlayerMovementPacket),0x15},
            {typeof(ClientVehicleMovePacket),0x16},
            {typeof(ClientSteerBoatPacket),0x17},
            {typeof(ClientMoveItemToHotbarPacket),0x18},
            {typeof(ClientPrepareCraftingGridPacket),0x19},
            {typeof(ClientPlayerAbilitiesPacket),0x1A},
            {typeof(ClientPlayerActionPacket),0x1B},
            {typeof(ClientPlayerStatePacket),0x1C},
            {typeof(ClientSteerVehiclePacket),0x1D},
            {typeof(ClientCraftingBookStatePacket),0x1E},
            {typeof(ClientDisplayedRecipePacket),0x1F},
            {typeof(ClientRenameItemPacket),0x20},
            {typeof(ClientResourcePackStatusPacket),0x21},
            {typeof(ClientAdvancementTabPacket),0x22},
            {typeof(ClientSelectTradePacket),0x23},
            {typeof(ClientSetBeaconEffectPacket),0x24},
            {typeof(ClientHeldItemChangePacket),0x25},
            {typeof(ClientUpdateCommandBlockPacket),0x26},
            {typeof(ClientUpdateCommandBlockMinecartPacket),0x27},
            {typeof(ClientCreativeInventoryActionPacket),0x28},
            {typeof(ClientUpdateJigsawBlockPacket),0x29},
            {typeof(ClientUpdateStructureBlockPacket),0x2A},
            {typeof(ClientUpdateSignPacket),0x2B},
            {typeof(ClientPlayerSwingArmPacket),0x2C},
            {typeof(ClientSpectatePacket),0x2D},
            {typeof(ClientPlayerPlaceBlockPacket),0x2E},
            {typeof(ClientUseItemPacket),0x2F}
        };
        public override Dictionary<int, Type> GetInPackets()
        {
            return typeIn;
        }

        public override Dictionary<Type, int> GetOutPackets()
        {
            return typeOut;
        }
    }
}
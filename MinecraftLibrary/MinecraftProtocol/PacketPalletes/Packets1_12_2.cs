using MinecraftLibrary.MinecraftProtocol.Packets.Client.Game;
using MinecraftLibrary.MinecraftProtocol.Packets.Server.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftLibrary.MinecraftProtocol.PacketPalletes
{
    public class Packets1_12_2 : PacketPallete
    {
        private static readonly Dictionary<int, Type> typeIn = new Dictionary<int, Type>()
        {
            { 0x00, typeof(ServerSpawnEntityPacket) },
            { 0x01, typeof(ServerSpawnExperienceOrbPacket) },
            { 0x02, typeof(ServerSpawnWeatherEntityPacket) },
            { 0x03, typeof(ServerSpawnLivingEntityPacket) },
            { 0x04, typeof(ServerSpawnPaintingPacket) },
            { 0x05, typeof(ServerSpawnPlayerPacket) },
            { 0x06, typeof(ServerEntityAnimationPacket) },
            { 0x07, typeof(ServerStatisticsPacket) },
            { 0x08, typeof(ServerBlockBreakAnimationPacket) },
            { 0x09, typeof(ServerBlockEntityDataPacket) },
            { 0x0A, typeof(ServerBlockActionPacket) },
            { 0x0B, typeof(ServerBlockChangePacket) },
            { 0x0C, typeof(ServerBossBarPacket) },
            { 0x0D, typeof(ServerServerDifficultyPacket) },
            { 0x0E, typeof(ServerTabCompletePacket) },
            { 0x0F, typeof(ServerChatMessagePacket) },
            { 0x10, typeof(ServerMultiBlockChangePacket) },
            { 0x11, typeof(ServerConfirmTransactionPacket) },
            { 0x12, typeof(ServerCloseWindowPacket) },
            { 0x13, typeof(ServerOpenWindowPacket) },
            { 0x14, typeof(ServerWindowItemsPacket) },
            { 0x15, typeof(ServerWindowPropertyPacket) },
            { 0x16, typeof(ServerSetSlotPacket) },
            { 0x17, typeof(ServerSetCooldownPacket) },
            { 0x18, typeof(ServerPluginMessagePacket) },
            { 0x19, typeof(ServerNamedSoundEffectPacket) },
            { 0x1A, typeof(ServerDisconnectPacket) },
            { 0x1B, typeof(ServerEntityStatusPacket) },
            { 0x1C, typeof(ServerExplosionPacket) },
            { 0x1D, typeof(ServerUnloadChunkPacket) },
            { 0x1E, typeof(ServerChangeGameStatePacket) },
            { 0x1F, typeof(ServerKeepAlivePacket) },
            { 0x20, typeof(ServerChunkDataPacket) },
            { 0x21, typeof(ServerEffectPacket) },
            { 0x22, typeof(ServerParticlePacket) },
            { 0x23, typeof(ServerJoinGamePacket) },
            { 0x24, typeof(ServerMapDataPacket) },
            { 0x25, typeof(ServerEntityMovementPacket) },
            { 0x26, typeof(ServerEntityPositionPacket) },
            { 0x27, typeof(ServerEntityPositionAndRotationPacket) },
            { 0x28, typeof(ServerEntityRotationPacket) },
            { 0x29, typeof(ServerVehicleMovePacket) },
            { 0x2A, typeof(ServerOpenSignEditorPacket) },
            { 0x2B, typeof(ServerCraftRecipeResponsePacket) },
            { 0x2C, typeof(ServerPlayerAbilitiesPacket) },
            { 0x2D, typeof(ServerCombatEventPacket) },
            { 0x2E, typeof(ServerPlayerInfoPacket) },
            { 0x2F, typeof(ServerPlayerPositionAndLookPacket) },
            { 0x30, typeof(ServerUseBedPacket) },
            { 0x31, typeof(ServerUnlockRecipesPacket) },
            { 0x32, typeof(ServerDestroyEntitiesPacket) },
            { 0x33, typeof(ServerRemoveEntityEffectPacket) },
            { 0x34, typeof(ServerResourcePackSendPacket) },
            { 0x35, typeof(ServerRespawnPacket) },
            { 0x36, typeof(ServerEntityHeadLookPacket) },
            { 0x37, typeof(ServerSelectAdvancementTabPacket) },
            { 0x38, typeof(ServerWorldBorderPacket) },
            { 0x39, typeof(ServerCameraPacket) },
            { 0x3A, typeof(ServerHeldItemChangePacket) },
            { 0x3B, typeof(ServerDisplayScoreboardPacket) },
            { 0x3C, typeof(ServerEntityMetadataPacket) },
            { 0x3D, typeof(ServerAttachEntityPacket) },
            { 0x3E, typeof(ServerEntityVelocityPacket) },
            { 0x3F, typeof(ServerEntityEquipmentPacket) },
            { 0x40, typeof(ServerSetExperiencePacket) },
            { 0x41, typeof(ServerPlayerHealthPacket) },
            { 0x42, typeof(ServerScoreboardObjectivePacket) },
            { 0x43, typeof(ServerSetPassengersPacket) },
            { 0x44, typeof(ServerTeamPacket) },
            { 0x45, typeof(ServerUpdateScorePacket) },
            { 0x46, typeof(ServerSpawnPositionPacket) },
            { 0x47, typeof(ServerTimeUpdatePacket) },
            { 0x48, typeof(ServerTitlePacket) },
            { 0x49, typeof(ServerSoundEffectPacket) },
            { 0x4A, typeof(ServerPlayerListHeaderAndFooterPacket) },
            { 0x4B, typeof(ServerCollectItemPacket) },
            { 0x4C, typeof(ServerEntityTeleportPacket) },
            { 0x4D, typeof(ServerAdvancementsPacket) },
            { 0x4E, typeof(ServerEntityPropertiesPacket) },
            { 0x4F, typeof(ServerEntityEffectPacket) },
        };
        private static readonly Dictionary<Type, int> typeOut = new Dictionary<Type, int>()
        {
            { typeof(ClientTeleportConfirmPacket), 0x00 },
            { typeof(ClientTabCompletePacket), 0x01 },
            { typeof(ClientChatMessagePacket), 0x02 },
            { typeof(ClientRequestPacket), 0x03 },
            { typeof(ClientClientSettingsPacket), 0x04 },
            { typeof(ClientWindowConfirmationPacket), 0x05 },
            { typeof(ClientEnchantItemPacket), 0x06 },
            { typeof(ClientWindowActionPacket), 0x07 },
            { typeof(ClientCloseWindowPacket), 0x08 },
            { typeof(ClientPluginMessagePacket), 0x09 },
            { typeof(ClientInteractEntityPacket), 0x0A },
            { typeof(ClientKeepAlivePacket), 0x0B },
            { typeof(ClientPlayerMovementPacket), 0x0C },
            { typeof(ClientPlayerPositionPacket), 0x0D },
            { typeof(ClientPlayerPositionAndRotationPacket), 0x0E },
            { typeof(ClientPlayerRotationPacket), 0x0F },
            { typeof(ClientVehicleMovePacket), 0x10 },
            { typeof(ClientSteerBoatPacket), 0x11 },
            { typeof(ClientCraftRecipeRequestPacket), 0x12 },
            { typeof(ClientPlayerAbilitiesPacket), 0x13 },
            { typeof(ClientPlayerActionPacket), 0x14 },
            { typeof(ClientEntityActionPacket), 0x15 },
            { typeof(ClientSteerVehiclePacket), 0x16 },
            { typeof(ClientRecipeBookDataPacket), 0x17 },
            { typeof(ClientResourcePackStatusPacket), 0x18 },
            { typeof(ClientAdvancementTabPacket), 0x19 },
            { typeof(ClientHeldItemChangePacket), 0x1A },
            { typeof(ClientCreativeInventoryActionPacket), 0x1B },
            { typeof(ClientUpdateSignPacket), 0x1C },
            { typeof(ClientAnimationPacket), 0x1D },
            { typeof(ClientSpectatePacket), 0x1E },
            { typeof(ClientPlayerBlockPlacementPacket), 0x1F },
            { typeof(ClientUseItemPacket), 0x20 }
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

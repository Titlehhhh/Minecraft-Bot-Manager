using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.IO;

using System;
using System.CodeDom;
using ProtocolLib740.Packets.Client;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{



    public partial class Program
    {
        static Dictionary<int, string> Names = new Dictionary<int, string>()
        {
            { 0x00,"ServerSpawnEntityPacket" },
{ 0x01,"ServerSpawnExpOrbPacket" },
{ 0x02,"ServerSpawnLivingEntityPacket" },
{ 0x03,"ServerSpawnPaintingPacket" },
{ 0x04,"ServerSpawnPlayerPacket" },
{ 0x05,"ServerEntityAnimationPacket" },
{ 0x06,"ServerStatisticsPacket" },
{ 0x07,"ServerPlayerActionAckPacket" },
{ 0x08,"ServerBlockBreakAnimPacket" },
{ 0x09,"ServerUpdateTileEntityPacket" },
{ 0x0A,"ServerBlockValuePacket" },
{ 0x0B,"ServerBlockChangePacket" },
{ 0x0C,"ServerBossBarPacket" },
{ 0x0D,"ServerDifficultyPacket" },
{ 0x0E,"ServerChatPacket" },
{ 0x0F,"ServerTabCompletePacket" },
{ 0x10,"ServerDeclareCommandsPacket" },
{ 0x11,"ServerConfirmTransactionPacket" },
{ 0x12,"ServerCloseWindowPacket" },
{ 0x13,"ServerWindowItemsPacket" },
{ 0x14,"ServerWindowPropertyPacket" },
{ 0x15,"ServerSetSlotPacket" },
{ 0x16,"ServerSetCooldownPacket" },
{ 0x17,"ServerPluginMessagePacket" },
{ 0x18,"ServerPlaySoundPacket" },
{ 0x19,"ServerDisconnectPacket" },
{ 0x1A,"ServerEntityStatusPacket" },
{ 0x1B,"ServerExplosionPacket" },
{ 0x1C,"ServerUnloadChunkPacket" },
{ 0x1D,"ServerNotifyClientPacket" },
{ 0x1E,"ServerOpenHorseWindowPacket" },
{ 0x1F,"ServerKeepAlivePacket" },
{ 0x20,"ServerChunkDataPacket" },
{ 0x21,"ServerPlayEffectPacket" },
{ 0x22,"ServerSpawnParticlePacket" },
{ 0x23,"ServerUpdateLightPacket" },
{ 0x24,"ServerJoinGamePacket" },
{ 0x25,"ServerMapDataPacket" },
{ 0x26,"ServerTradeListPacket" },
{ 0x27,"ServerEntityPositionPacket" },
{ 0x28,"ServerEntityPositionRotationPacket" },
{ 0x29,"ServerEntityRotationPacket" },
{ 0x2A,"ServerEntityMovementPacket" },
{ 0x2B,"ServerVehicleMovePacket" },
{ 0x2C,"ServerOpenBookPacket" },
{ 0x2D,"ServerOpenWindowPacket" },
{ 0x2E,"ServerOpenTileEntityEditorPacket" },
{ 0x2F,"ServerPreparedCraftingGridPacket" },
{ 0x30,"ServerPlayerAbilitiesPacket" },
{ 0x31,"ServerCombatPacket" },
{ 0x32,"ServerPlayerListEntryPacket" },
{ 0x33,"ServerPlayerFacingPacket" },
{ 0x34,"ServerPlayerPositionRotationPacket" },
{ 0x35,"ServerUnlockRecipesPacket" },
{ 0x36,"ServerEntityDestroyPacket" },
{ 0x37,"ServerEntityRemoveEffectPacket" },
{ 0x38,"ServerResourcePackSendPacket" },
{ 0x39,"ServerRespawnPacket" },
{ 0x3A,"ServerEntityHeadLookPacket" },
{ 0x3B,"ServerMultiBlockChangePacket" },
{ 0x3C,"ServerAdvancementTabPacket" },
{ 0x3D,"ServerWorldBorderPacket" },
{ 0x3E,"ServerSwitchCameraPacket" },
{ 0x3F,"ServerPlayerChangeHeldItemPacket" },
{ 0x40,"ServerUpdateViewPositionPacket" },
{ 0x41,"ServerUpdateViewDistancePacket" },
{ 0x42,"ServerSpawnPositionPacket" },
{ 0x43,"ServerDisplayScoreboardPacket" },
{ 0x44,"ServerEntityMetadataPacket" },
{ 0x45,"ServerEntityAttachPacket" },
{ 0x46,"ServerEntityVelocityPacket" },
{ 0x47,"ServerEntityEquipmentPacket" },
{ 0x48,"ServerPlayerSetExperiencePacket" },
{ 0x49,"ServerPlayerHealthPacket" },
{ 0x4A,"ServerScoreboardObjectivePacket" },
{ 0x4B,"ServerEntitySetPassengersPacket" },
{ 0x4C,"ServerTeamPacket" },
{ 0x4D,"ServerUpdateScorePacket" },
{ 0x4E,"ServerUpdateTimePacket" },
{ 0x4F,"ServerTitlePacket" },
{ 0x50,"ServerEntitySoundEffectPacket" },
{ 0x51,"ServerPlayBuiltinSoundPacket" },
{ 0x52,"ServerStopSoundPacket" },
{ 0x53,"ServerPlayerListDataPacket" },
{ 0x54,"ServerNBTResponsePacket" },
{ 0x55,"ServerEntityCollectItemPacket" },
{ 0x56,"ServerEntityTeleportPacket" },
{ 0x57,"ServerAdvancementsPacket" },
{ 0x58,"ServerEntityPropertiesPacket" },
{ 0x59,"ServerEntityEffectPacket" },
{ 0x5A,"ServerDeclareRecipesPacket" },
{ 0x5B,"ServerDeclareTagsPacket" }
        };



        public static void Main()
        {
            Console.WriteLine("Hello");
            string path = @"C:\Users\Title\Desktop\Minecraft-Bot-Manager\ProtocolLib740\Packets\Server\Game\";

            Dictionary<string, int> reverse = Names.ToDictionary(item => item.Value, item => item.Key);

            Regex regex = new Regex(@"    public class (?<name>[a-zA-Z]+) : IPacket");
            foreach (var file in Directory.GetFiles(path, "*.cs"))
            {
                string source = "";
                using (StreamReader sr = new StreamReader(file))
                {
                    string content = sr.ReadToEnd();
                    Match match = regex.Match(content);
                    int id = reverse[match.Groups["name"].Value];
                    string attrstr = atrr("0x" + id.ToString("X2"));

                    source = content.Replace(match.Value, $"    {attrstr}\n\r{match.Value}");
                    if(source.IndexOf("using MinecraftLibrary.API;") == -1)
                    {
                        source = "using MinecraftLibrary.API;" + Environment.NewLine + source;

                    }
                    if (source.IndexOf("using MinecraftLibrary.API.Protocol;") == -1)
                    {
                        source = "using MinecraftLibrary.API.Protocol;" + Environment.NewLine + source;

                    }
                }
                using (StreamWriter sw = new StreamWriter(file))
                {
                    sw.WriteLine(source);
                }
            }
            Console.ReadKey();
        }
        static string atrr(string id)
        {
            return $"[PacketInfo("+id+", 740, PacketCategory.Game, PacketSide.Server)]";
        }
    }

}



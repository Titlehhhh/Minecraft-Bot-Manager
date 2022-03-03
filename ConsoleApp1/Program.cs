using System.Text.RegularExpressions;

namespace ConsoleApp1
{



    public partial class Program
    {
        static Dictionary<string, int> Names = new Dictionary<string, int>()
        {
            {"ClientTeleportConfirmPacket",0x00},
{"ClientBlockNBTRequestPacket",0x01},
{"ClientSetDifficultyPacket",0x02},
{"ClientChatPacket",0x03},
{"ClientRequestPacket",0x04},
{"ClientSettingsPacket",0x05},
{"ClientTabCompletePacket",0x06},
{"ClientConfirmTransactionPacket",0x07},
{"ClientClickWindowButtonPacket",0x08},
{"ClientWindowActionPacket",0x09},
{"ClientCloseWindowPacket",0x0A},
{"ClientPluginMessagePacket",0x0B},
{"ClientEditBookPacket",0x0C},
{"ClientEntityNBTRequestPacket",0x0D},
{"ClientPlayerInteractEntityPacket",0x0E},
{"ClientGenerateStructuresPacket",0x0F},
{"ClientKeepAlivePacket",0x10},
{"ClientLockDifficultyPacket",0x11},
{"ClientPlayerPositionPacket",0x12},
{"ClientPlayerPositionRotationPacket",0x13},
{"ClientPlayerRotationPacket",0x14},
{"ClientPlayerMovementPacket",0x15},
{"ClientVehicleMovePacket",0x16},
{"ClientSteerBoatPacket",0x17},
{"ClientMoveItemToHotbarPacket",0x18},
{"ClientPrepareCraftingGridPacket",0x19},
{"ClientPlayerAbilitiesPacket",0x1A},
{"ClientPlayerActionPacket",0x1B},
{"ClientPlayerStatePacket",0x1C},
{"ClientSteerVehiclePacket",0x1D},
{"ClientCraftingBookStatePacket",0x1E},
{"ClientDisplayedRecipePacket",0x1F},
{"ClientRenameItemPacket",0x20},
{"ClientResourcePackStatusPacket",0x21},
{"ClientAdvancementTabPacket",0x22},
{"ClientSelectTradePacket",0x23},
{"ClientSetBeaconEffectPacket",0x24},
{"ClientPlayerChangeHeldItemPacket",0x25},
{"ClientUpdateCommandBlockPacket",0x26},
{"ClientUpdateCommandBlockMinecartPacket",0x27},
{"ClientCreativeInventoryActionPacket",0x28},
{"ClientUpdateJigsawBlockPacket",0x29},
{"ClientUpdateStructureBlockPacket",0x2A},
{"ClientUpdateSignPacket",0x2B},
{"ClientPlayerSwingArmPacket",0x2C},
{"ClientSpectatePacket",0x2D},
{"ClientPlayerPlaceBlockPacket",0x2E},
{"ClientPlayerUseItemPacket",0x2F}
        };



        public static void Main()
        {
            Console.WriteLine("Hello");
            string path = @"C:\Users\Title\Desktop\Minecraft-Bot-Manager\ProtocolLib740\Packets\Client\Game\";

            

            Regex regex = new Regex(@"    public class (?<name>[a-zA-Z]+) : IPacket");
            foreach (var file in Directory.GetFiles(path, "*.cs"))
            {
                string source = "";
                using (StreamReader sr = new StreamReader(file))
                {
                    string content = sr.ReadToEnd();
                    Match match = regex.Match(content);
                    int id = Names[match.Groups["name"].Value];
                    string attrstr = atrr("0x" + id.ToString("X2"));

                    source = content.Replace(match.Value, $"    {attrstr}\n\r{match.Value}");
                    if (source.IndexOf("using MinecraftLibrary.API;") == -1)
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
            return $"[PacketInfo(" + id + ", 740, PacketCategory.Game, PacketSide.Client)]";
        }
    }

}



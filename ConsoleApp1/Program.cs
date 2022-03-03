using MinecraftLibrary.Client;
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
            Console.WriteLine("StartProgramm");
            MinecraftClient client = new MinecraftClient();
            client.Host = "nexus1.su";
            client.Port = 25565;
            
            client.Connect();
            Console.WriteLine("Ok");
            Console.ReadLine();
        }
        static string atrr(string id)
        {
            return $"[PacketInfo(" + id + ", 740, PacketCategory.Game, PacketSide.Client)]";
        }
    }

}



using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;
using System;
using System.CodeDom;

namespace ConsoleApp1
{



    public partial class Program
    {
        static Dictionary<int, string> Names = new Dictionary<int, string>()
        {
            { 0x00,"ClientTeleportConfirmPacket" },
            { 0x01,"ClientBlockNBTRequestPacket" },
            { 0x02,"ClientSetDifficultyPacket" },
            { 0x03,"ClientChatPacket" },
            { 0x04,"ClientRequestPacket" },
            { 0x05,"ClientSettingsPacket" },
            { 0x06,"ClientTabCompletePacket" },
            { 0x07,"ClientConfirmTransactionPacket" },
            { 0x08,"ClientClickWindowButtonPacket" },
            { 0x09,"ClientWindowActionPacket" },
            { 0x0A,"ClientCloseWindowPacket" },
            { 0x0B,"ClientPluginMessagePacket" },
            { 0x0C,"ClientEditBookPacket" },
            { 0x0D,"ClientEntityNBTRequestPacket" },
            { 0x0E,"ClientPlayerInteractEntityPacket" },
            { 0x0F,"ClientGenerateStructuresPacket" },
            { 0x10,"ClientKeepAlivePacket" },
            { 0x11,"ClientLockDifficultyPacket" },
            { 0x12,"ClientPlayerPositionPacket" },
            { 0x13,"ClientPlayerPositionRotationPacket" },
            { 0x14,"ClientPlayerRotationPacket" },
            { 0x15,"ClientPlayerMovementPacket" },
            { 0x16,"ClientVehicleMovePacket" },
            { 0x17,"ClientSteerBoatPacket" },
            { 0x18,"ClientMoveItemToHotbarPacket" },
            { 0x19,"ClientPrepareCraftingGridPacket" },
            { 0x1A,"ClientPlayerAbilitiesPacket" },
            { 0x1B,"ClientPlayerActionPacket" },
            { 0x1C,"ClientPlayerStatePacket" },
            { 0x1D,"ClientSteerVehiclePacket" },
            { 0x1E,"ClientCraftingBookStatePacket" },
            { 0x1F,"ClientDisplayedRecipePacket" },
            { 0x20,"ClientRenameItemPacket" },
            { 0x21,"ClientResourcePackStatusPacket" },
            { 0x22,"ClientAdvancementTabPacket" },
            { 0x23,"ClientSelectTradePacket" },
            { 0x24,"ClientSetBeaconEffectPacket" },
            { 0x25,"ClientPlayerChangeHeldItemPacket" },
            { 0x26,"ClientUpdateCommandBlockPacket" },
            { 0x27,"ClientUpdateCommandBlockMinecartPacket" },
            { 0x28,"ClientCreativeInventoryActionPacket" },
            { 0x29,"ClientUpdateJigsawBlockPacket" },
            { 0x2A,"ClientUpdateStructureBlockPacket" },
            { 0x2B,"ClientUpdateSignPacket" },
            { 0x2C,"ClientPlayerSwingArmPacket" },
            { 0x2D,"ClientSpectatePacket" },
            { 0x2E,"ClientPlayerPlaceBlockPacket" },
            { 0x2F,"ClientPlayerUseItemPacket" }
        };



        public static void Main()
        {
            foreach(var item in Names)
            {
                string path = Path.Combine(@"C:\Users\Title\Desktop\Minecraft-Bot-Manager\ProtocolLib740\Packets\Client\Game\", item.Value+".cs");
                string id = "0x"+item.Key.ToString("X2");

                string name = item.Value;
                string source = GenerateClass(name,id);
                using(StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine(source);
                }
            }
        }

        static string GenerateClass(string name, string id)
        {
            return $@"using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib740.Packets.Client.Game
{{
    [PacketHeader({id}, 740, PacketSide.Client, PacketCategory.Login)]
    public class {name} : IPacket
    {{        
        public void Write(MinecraftStream stream)
        {{
            
        }}
        public void Read(MinecraftStream stream)
        {{

        }}
        public {name}() {{ }}
    }}
}}";
        }
    }
    
}



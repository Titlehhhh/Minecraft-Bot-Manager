using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Game
{

    [PacketInfo(0x31, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerUnlockRecipesPacket : MinecraftPacket
    {
        //this.action = MagicValues.key(UnlockRecipesAction.class, in.readVarInt());
       //
       //this.openCraftingBook = in.readBoolean();
       //this.activateFiltering = in.readBoolean();
       //
       //if(this.action == UnlockRecipesAction.INIT) {
       //int size = in.readVarInt();
       //this.alreadyKnownRecipes = new ArrayList<>(size);
       //for(int i = 0; i < size; i++) {
       //this.alreadyKnownRecipes.add(in.readVarInt());
       //}
       //}
       //
       //int size = in.readVarInt();
       //this.recipes = new ArrayList<>(size);
       //for(int i = 0; i < size; i++) {
       //this.recipes.add(in.readVarInt());
       //}
        public override void Read(IMinecraftStreamReader input)
        {
            
        }
        public ServerUnlockRecipesPacket() {}
    }

}

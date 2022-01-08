
using MinecraftLibrary.Data;
using MinecraftLibrary.Data.Inventory;
using MinecraftLibrary.Data.Inventory.ItemPalettes;
using MinecraftLibrary.Geometri;
using MinecraftLibrary.MinecraftProtocol.Data.Inventory;
using MinecraftLibrary.Palletes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftProtocol.IO
{
    public interface NetInput
    {
        byte[] ReadData(int offset);

        /// <summary>
        /// Read a string from a cache of bytes and remove it from the cache
        /// </summary>
        /// <param name="cache">Cache of bytes to read from</param>
        /// <returns>The string</returns>
        string ReadNextString();

        /// <summary>
        /// Read a boolean from a cache of bytes and remove it from the cache
        /// </summary>
        /// <returns>The boolean value</returns>
        bool ReadNextBool();

        /// <summary>
        /// Read a short integer from a cache of bytes and remove it from the cache
        /// </summary>
        /// <returns>The short integer value</returns>
        short ReadNextShort();

        /// <summary>
        /// Read an integer from a cache of bytes and remove it from the cache
        /// </summary>
        /// <returns>The integer value</returns>
        int ReadNextInt();

        /// <summary>
        /// Read a long integer from a cache of bytes and remove it from the cache
        /// </summary>
        /// <returns>The unsigned long integer value</returns>
        long ReadNextLong();

        /// <summary>
        /// Read an unsigned short integer from a cache of bytes and remove it from the cache
        /// </summary>
        /// <returns>The unsigned short integer value</returns>
        ushort ReadNextUShort();

        /// <summary>
        /// Read an unsigned long integer from a cache of bytes and remove it from the cache
        /// </summary>
        /// <returns>The unsigned long integer value</returns>
        ulong ReadNextULong();

        /// <summary>
        /// Read a Location encoded as an ulong field and remove it from the cache
        /// </summary>
        /// <returns>The Location value</returns>
        Location ReadNextLocation();
        

        /// <summary>
        /// Read several little endian unsigned short integers at once from a cache of bytes and remove them from the cache
        /// </summary>
        /// <returns>The unsigned short integer value</returns>
        ushort[] ReadNextUShortsLittleEndian(int amount);

        /// <summary>
        /// Read a uuid from a cache of bytes and remove it from the cache
        /// </summary>
        /// <param name="cache">Cache of bytes to read from</param>
        /// <returns>The uuid</returns>
        Guid ReadNextUUID();

        /// <summary>
        /// Read a byte array from a cache of bytes and remove it from the cache
        /// </summary>
        /// <param name="cache">Cache of bytes to read from</param>
        /// <returns>The byte array</returns>
        byte[] ReadNextByteArray();

        /// <summary>
        /// Reads a length-prefixed array of unsigned long integers and removes it from the cache
        /// </summary>
        /// <returns>The unsigned long integer values</returns>
        ulong[] ReadNextULongArray();

        /// <summary>
        /// Read a double from a cache of bytes and remove it from the cache
        /// </summary>
        /// <returns>The double value</returns>
        double ReadNextDouble();

        /// <summary>
        /// Read a float from a cache of bytes and remove it from the cache
        /// </summary>
        /// <returns>The float value</returns>
        float ReadNextFloat();


        /// <summary>
        /// Read an integer from a cache of bytes and remove it from the cache
        /// </summary>
        /// <param name="cache">Cache of bytes to read from</param>
        /// <returns>The integer</returns>
        int ReadNextVarInt();

        /// <summary>
        /// Skip a VarInt from a cache of bytes with better performance
        /// </summary>
        /// <param name="cache">Cache of bytes to read from</param>


        /// <summary>
        /// Read an "extended short", which is actually an int of some kind, from the cache of bytes.
        /// This is only done with forge.  It looks like it's a normal short, except that if the high
        /// bit is set, it has an extra byte.
        /// </summary>
        /// <param name="cache">Cache of bytes to read from</param>
        /// <returns>The int</returns>
        int ReadNextVarShort();
        /// <summary>
        /// Read a long from a cache of bytes and remove it from the cache
        /// </summary>
        /// <param name="cache">Cache of bytes to read from</param>
        /// <returns>The long value</returns>
        long ReadNextVarLong();

        /// <summary>
        /// Read a single byte from a cache of bytes and remove it from the cache
        /// </summary>
        /// <returns>The byte that was read</returns>
        byte ReadNextByte();

        /// <summary>
        /// Read an uncompressed Named Binary Tag blob and remove it from the cache
        /// </summary>
        Dictionary<string, object> ReadNextNbt();

        /// <summary>
        /// Read a single item slot from a cache of bytes and remove it from the cache
        /// </summary>
        /// <returns>The item that was read or NULL for an empty slot</returns>
        Item ReadNextItemSlot(ItemPalette itemPalette);

        /// <summary>
        /// Read entity information from a cache of bytes and remove it from the cache
        /// </summary>
        /// <param name="entityPalette">Mappings for converting entity type Ids to EntityType</param>
        /// <param name="living">TRUE for living entities (layout differs)</param>
        /// <returns>Entity information</returns>
        Entity ReadNextEntity(EntityPalette entityPalette, bool living);


        Dictionary<int, object> ReadNextMetadata(ItemPalette itemPalette);

        /// <summary>
        /// Read a single villager trade from a cache of bytes and remove it from the cache
        /// </summary>
        /// <returns>The item that was read or NULL for an empty slot</returns>
        VillagerTrade ReadNextTrade(ItemPalette itemPalette);
    }
}

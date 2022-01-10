
using MinecraftLibrary.Data;
using MinecraftLibrary.Data.Inventory;
using MinecraftLibrary.Data.Inventory.ItemPalettes;
using MinecraftLibrary.Geometri;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftProtocol.IO
{
    public interface NetOutput
    {
        void WriteNbt(Dictionary<string, object> nbt);


        /// <summary>
        /// Build an integer for sending over the network
        /// </summary>
        /// <param name="paramInt">Integer to encode</param>
        /// <returns>Byte array for this integer</returns>
        void WriteVarInt(int paramInt);

        /// <summary>
        /// Build an boolean for sending over the network
        /// </summary>
        /// <param name="paramBool">Boolean to encode</param>
        /// <returns>Byte array for this boolean</returns>
        void WriteBool(bool paramBool);

        /// <summary>
        /// Write byte array representing a long integer
        /// </summary>
        /// <param name="number">Long to process</param>
        /// <returns>Array ready to send</returns>
        void WriteLong(long number);

        /// <summary>
        /// Write byte array representing an integer
        /// </summary>
        /// <param name="number">Integer to process</param>
        /// <returns>Array ready to send</returns>
        void WriteInt(int number);

        /// <summary>
        /// Write byte array representing a short
        /// </summary>
        /// <param name="number">Short to process</param>
        /// <returns>Array ready to send</returns>
        void WriteShort(short number);

        /// <summary>
        /// Write byte array representing an unsigned short
        /// </summary>
        /// <param name="number">Short to process</param>
        /// <returns>Array ready to send</returns>
        void WriteUShort(ushort number);

        /// <summary>
        /// Write byte array representing a double
        /// </summary>
        /// <param name="number">Double to process</param>
        /// <returns>Array ready to send</returns>
        void WriteDouble(double number);

        /// <summary>
        /// Write byte array representing a float
        /// </summary>
        /// <param name="number">Floalt to process</param>
        /// <returns>Array ready to send</returns>
        void WriteFloat(float number);

        /// <summary>
        /// Write byte array with length information prepended to it
        /// </summary>
        /// <param name="array">Array to process</param>
        /// <returns>Array ready to send</returns>
        void WriteArray(byte[] array);

        /// <summary>
        /// Write a byte array from the given string for sending over the network, with length information prepended.
        /// </summary>
        /// <param name="text">String to process</param>
        /// <returns>Array ready to send</returns>
        void WriteString(string text);

        /// <summary>
        /// Write a byte array representing the given location encoded as an unsigned long
        /// </summary>
        /// <remarks>
        /// A modulo will be applied if the location is outside the following ranges:
        /// X: -33,554,432 to +33,554,431
        /// Y: -2,048 to +2,047
        /// Z: -33,554,432 to +33,554,431
        /// </remarks>
        /// <returns>Location representation as ulong</returns>
        void WriteLocation(Point3 location);

        /// <summary>
        /// Write a byte array representing the given item as an item slot
        /// </summary>
        /// <param name="item">Item</param>
        /// <param name="itemPalette">Item Palette</param>
        /// <returns>Item slot representation</returns>
        void WriteItemSlot(Item item, ItemPalette itemPalette);

        /// <summary>
        /// Write protocol block face from Direction
        /// </summary>
        /// <param name="direction">Direction</param>
        /// <returns>Block face byte enum</returns>
        void WriteBlockFace(Direction direction);

        void AddArray(byte[] array);
    }
}

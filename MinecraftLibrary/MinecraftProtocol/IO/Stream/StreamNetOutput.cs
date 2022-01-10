
using MinecraftLibrary.Data;
using MinecraftLibrary.Data.Inventory;
using MinecraftLibrary.Data.Inventory.ItemPalettes;
using MinecraftLibrary.Geometri;
using MinecraftProtocol.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftLibrary.MinecraftProtocol.IO.Stream
{
    public class StreamNetOutput : NetOutput
    {
        List<byte> cache = new List<byte>();
        int protocolversion;
        public byte[] Data => cache.ToArray();
        public StreamNetOutput(int version)
        {
            protocolversion = version;
        }

        public void WriteNbt(Dictionary<string, object> nbt)
        {
            cache.AddRange(GetNbt(nbt));
        }

        /// <summary>
        /// Build an uncompressed Named Binary Tag blob for sending over the network (internal)
        /// </summary>
        /// <param name="nbt">Dictionary to encode as Nbt</param>
        /// <param name="root">TRUE if starting a new NBT tag, FALSE if processing a nested NBT tag</param>
        /// <returns>Byte array for this NBT tag</returns>
        private byte[] GetNbt(Dictionary<string, object> nbt)
        {
            return GetNbt(nbt, true);
        }

        /// <summary>
        /// Build an uncompressed Named Binary Tag blob for sending over the network (internal)
        /// </summary>
        /// <param name="nbt">Dictionary to encode as Nbt</param>
        /// <param name="root">TRUE if starting a new NBT tag, FALSE if processing a nested NBT tag</param>
        /// <returns>Byte array for this NBT tag</returns>
        private byte[] GetNbt(Dictionary<string, object> nbt, bool root)
        {
            if (nbt == null || nbt.Count == 0)
                return new byte[] { 0 }; // TAG_End

            List<byte> bytes = new List<byte>();

            if (root)
            {
                bytes.Add(10); // TAG_Compound

                // NBT root name
                string rootName = null;
                if (nbt.ContainsKey(""))
                    rootName = nbt[""] as string;
                if (rootName == null)
                    rootName = "";
                bytes.AddRange(GetUShort((ushort)rootName.Length));
                bytes.AddRange(Encoding.ASCII.GetBytes(rootName));
            }

            foreach (var item in nbt)
            {
                // Skip NBT root name
                if (item.Key == "" && root)
                    continue;

                byte fieldType;
                byte[] fieldNameLength = GetUShort((ushort)item.Key.Length);
                byte[] fieldName = Encoding.ASCII.GetBytes(item.Key);
                byte[] fieldData = GetNbtField(item.Value, out fieldType);
                bytes.Add(fieldType);
                bytes.AddRange(fieldNameLength);
                bytes.AddRange(fieldName);
                bytes.AddRange(fieldData);
            }

            bytes.Add(0); // TAG_End
            return bytes.ToArray();
        }

        /// <summary>
        /// Convert a single object into its NBT representation (internal)
        /// </summary>
        /// <param name="obj">Object to convert</param>
        /// <param name="fieldType">Field type for the passed object</param>
        /// <returns>Binary data for the passed object</returns>
        private byte[] GetNbtField(object obj, out byte fieldType)
        {
            if (obj is byte)
            {
                fieldType = 1; // TAG_Byte
                return new[] { (byte)obj };
            }
            else if (obj is short)
            {
                fieldType = 2; // TAG_Short
                return GetShort((short)obj);
            }
            else if (obj is int)
            {
                fieldType = 3; // TAG_Int
                return GetInt((int)obj);
            }
            else if (obj is long)
            {
                fieldType = 4; // TAG_Long
                return GetLong((long)obj);
            }
            else if (obj is float)
            {
                fieldType = 5; // TAG_Float
                return GetFloat((float)obj);
            }
            else if (obj is double)
            {
                fieldType = 6; // TAG_Double
                return GetDouble((double)obj);
            }
            else if (obj is byte[])
            {
                fieldType = 7; // TAG_Byte_Array
                return (byte[])obj;
            }
            else if (obj is string)
            {
                fieldType = 8; // TAG_String
                byte[] stringBytes = Encoding.UTF8.GetBytes((string)obj);
                return ConcatBytes(GetUShort((ushort)stringBytes.Length), stringBytes);
            }
            else if (obj is object[])
            {
                fieldType = 9; // TAG_List

                List<object> list = new List<object>((object[])obj);
                int arrayLengthTotal = list.Count;

                // Treat empty list as TAG_Byte, length 0
                if (arrayLengthTotal == 0)
                    return ConcatBytes(new[] { (byte)1 }, GetInt(0));

                // Encode first list item, retain its type
                byte firstItemType;
                string firstItemTypeString = list[0].GetType().Name;
                byte[] firstItemBytes = GetNbtField(list[0], out firstItemType);
                list.RemoveAt(0);

                // Encode further list items, check they have the same type
                byte subsequentItemType;
                List<byte> subsequentItemsBytes = new List<byte>();
                foreach (object item in list)
                {
                    subsequentItemsBytes.AddRange(GetNbtField(item, out subsequentItemType));
                    if (subsequentItemType != firstItemType)
                        throw new System.IO.InvalidDataException(
                            "GetNbt: Cannot encode object[] list with mixed types: " + firstItemTypeString + ", " + item.GetType().Name + " into NBT!");
                }

                // Build NBT list: type, length, item array
                return ConcatBytes(new[] { firstItemType }, GetInt(arrayLengthTotal), firstItemBytes, subsequentItemsBytes.ToArray());
            }
            else if (obj is Dictionary<string, object>)
            {
                fieldType = 10; // TAG_Compound
                return GetNbt((Dictionary<string, object>)obj, false);
            }
            else if (obj is int[])
            {
                fieldType = 11; // TAG_Int_Array

                int[] srcIntList = (int[])obj;
                List<byte> encIntList = new List<byte>();
                encIntList.AddRange(GetInt(srcIntList.Length));
                foreach (int item in srcIntList)
                    encIntList.AddRange(GetInt(item));
                return encIntList.ToArray();
            }
            else if (obj is long[])
            {
                fieldType = 12; // TAG_Long_Array

                long[] srcLongList = (long[])obj;
                List<byte> encLongList = new List<byte>();
                encLongList.AddRange(GetInt(srcLongList.Length));
                foreach (long item in srcLongList)
                    encLongList.AddRange(GetLong(item));
                return encLongList.ToArray();
            }
            else
            {
                throw new System.IO.InvalidDataException("GetNbt: Cannot encode data type " + obj.GetType().Name + " into NBT!");
            }
        }

        /// <summary>
        /// Build an integer for sending over the network
        /// </summary>
        /// <param name="paramInt">Integer to encode</param>
        /// <returns>Byte array for this integer</returns>
        public void WriteVarInt(int paramInt)
        {

            while ((paramInt & -128) != 0)
            {
                cache.Add((byte)(paramInt & 127 | 128));
                paramInt = (int)(((uint)paramInt) >> 7);
            }
            cache.Add((byte)paramInt);


        }

        /// <summary>
        /// Build an boolean for sending over the network
        /// </summary>
        /// <param name="paramBool">Boolean to encode</param>
        /// <returns>Byte array for this boolean</returns>
        public void WriteBool(bool paramBool)
        {
            cache.Add((byte)Convert.ToByte(paramBool));
        }

        /// <summary>
        /// Write byte array representing a long integer
        /// </summary>
        /// <param name="number">Long to process</param>
        /// <returns>Array ready to send</returns>
        public void WriteLong(long number)
        {
            byte[] theLong = BitConverter.GetBytes(number);
            Array.Reverse(theLong);
            cache.AddRange(theLong);

        }

        /// <summary>
        /// Write byte array representing an integer
        /// </summary>
        /// <param name="number">Integer to process</param>
        /// <returns>Array ready to send</returns>
        public void WriteInt(int number)
        {
            byte[] theInt = BitConverter.GetBytes(number);
            Array.Reverse(theInt);
            cache.AddRange(theInt);
        }

        /// <summary>
        /// Write byte array representing a short
        /// </summary>
        /// <param name="number">Short to process</param>
        /// <returns>Array ready to send</returns>
        public void WriteShort(short number)
        {
            byte[] theShort = BitConverter.GetBytes(number);
            Array.Reverse(theShort);
            cache.AddRange(theShort);
        }

        /// <summary>
        /// Write byte array representing an unsigned short
        /// </summary>
        /// <param name="number">Short to process</param>
        /// <returns>Array ready to send</returns>
        public void WriteUShort(ushort number)
        {
            byte[] theShort = BitConverter.GetBytes(number);
            Array.Reverse(theShort);
            cache.AddRange(theShort);
        }

        /// <summary>
        /// Write byte array representing a double
        /// </summary>
        /// <param name="number">Double to process</param>
        /// <returns>Array ready to send</returns>
        public void WriteDouble(double number)
        {
            byte[] theDouble = BitConverter.GetBytes(number);
            Array.Reverse(theDouble); //Endianness
            cache.AddRange(theDouble);
        }

        /// <summary>
        /// Write byte array representing a float
        /// </summary>
        /// <param name="number">Floalt to process</param>
        /// <returns>Array ready to send</returns>
        public void WriteFloat(float number)
        {
            byte[] theFloat = BitConverter.GetBytes(number);
            Array.Reverse(theFloat); //Endianness
            cache.AddRange(theFloat);
        }
        

        /// <summary>
        /// Write byte array with length information prepended to it
        /// </summary>
        /// <param name="array">Array to process</param>
        /// <returns>Array ready to send</returns>
        public void WriteArray(byte[] array)
        {
            if (protocolversion < MinecraftConstans.MC18Version)
            {
                byte[] length = BitConverter.GetBytes((short)array.Length);
                Array.Reverse(length); //Endianness
                cache.AddRange(length);
                cache.AddRange(array);
            }
            else { WriteVarInt(array.Length); cache.AddRange(array); }
        }

        public void AddArray(byte[] array)
        {
            cache.AddRange(array);
        }

        /// <summary>
        /// Write a byte array from the given string for sending over the network, with length information prepended.
        /// </summary>
        /// <param name="text">String to process</param>
        /// <returns>Array ready to send</returns>
        public void WriteString(string text)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            WriteVarInt(bytes.Length);
            cache.AddRange(bytes);
        }

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
        public void WriteLocation(Point3 location)
        {
            byte[] locationBytes;
            if (protocolversion >= MinecraftConstans.MC114Version)
            {
                locationBytes = BitConverter.GetBytes(((((ulong)location.X) & 0x3FFFFFF) << 38) | ((((ulong)location.Z) & 0x3FFFFFF) << 12) | (((ulong)location.Y) & 0xFFF));
            }
            else locationBytes = BitConverter.GetBytes(((((ulong)location.X) & 0x3FFFFFF) << 38) | ((((ulong)location.Y) & 0xFFF) << 26) | (((ulong)location.Z) & 0x3FFFFFF));
            Array.Reverse(locationBytes); //Endianness
            cache.AddRange(locationBytes);
        }

        /// <summary>
        /// Write a byte array representing the given item as an item slot
        /// </summary>
        /// <param name="item">Item</param>
        /// <param name="itemPalette">Item Palette</param>
        /// <returns>Item slot representation</returns>
        public void WriteItemSlot(Item item, ItemPalette itemPalette)
        {

            if (protocolversion > MinecraftConstans.MC113Version)
            {
                // MC 1.13 and greater
                if (item == null || item.IsEmpty)
                    cache.Add(0); // No item
                else
                {
                    cache.Add(1); // Item is present
                    WriteVarInt(itemPalette.ToId(item.Type));
                    cache.Add((byte)item.Count);
                    WriteNbt(item.NBT);
                }
            }
            else
            {
                // MC 1.12.2 and lower
                if (item == null || item.IsEmpty)
                    WriteShort(-1);
                else
                {
                    WriteShort((short)itemPalette.ToId(item.Type));
                    cache.Add((byte)item.Count);
                    WriteNbt(item.NBT);
                }
            }

        }

        /// <summary>
        /// Write protocol block face from Direction
        /// </summary>
        /// <param name="direction">Direction</param>
        /// <returns>Block face byte enum</returns>
        public void WriteBlockFace(Direction direction)
        {
            cache.Add((byte)direction);
        }

        #region Gets
        public static byte[] GetVarInt(int paramInt)
        {
            List<byte> bytes = new List<byte>();
            while ((paramInt & -128) != 0)
            {
                bytes.Add((byte)(paramInt & 127 | 128));
                paramInt = (int)(((uint)paramInt) >> 7);
            }
            bytes.Add((byte)paramInt);
            return bytes.ToArray();
        }

        public static byte[] GetBool(bool paramBool)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add((byte)Convert.ToByte(paramBool));
            return bytes.ToArray();
        }


        public static byte[] GetLong(long number)
        {
            byte[] theLong = BitConverter.GetBytes(number);
            Array.Reverse(theLong);
            return theLong;
        }

        public static byte[] GetInt(int number)
        {
            byte[] theInt = BitConverter.GetBytes(number);
            Array.Reverse(theInt);
            return theInt;
        }


        public static byte[] GetShort(short number)
        {
            byte[] theShort = BitConverter.GetBytes(number);
            Array.Reverse(theShort);
            return theShort;
        }

        public static byte[] GetUShort(ushort number)
        {
            byte[] theShort = BitConverter.GetBytes(number);
            Array.Reverse(theShort);
            return theShort;
        }


        public static byte[] GetDouble(double number)
        {
            byte[] theDouble = BitConverter.GetBytes(number);
            Array.Reverse(theDouble); //Endianness
            return theDouble;
        }


        public static byte[] GetFloat(float number)
        {
            byte[] theFloat = BitConverter.GetBytes(number);
            Array.Reverse(theFloat); //Endianness
            return theFloat;
        }

        public static byte[] GetArray(byte[] array,int protocolversion)
        {
            if (protocolversion < MinecraftConstans.MC18Version)
            {
                byte[] length = BitConverter.GetBytes((short)array.Length);
                Array.Reverse(length); //Endianness
                return ConcatBytes(length, array);
            }
            else return ConcatBytes(GetVarInt(array.Length), array);
        }


        public static byte[] GetString(string text)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            return ConcatBytes(GetVarInt(bytes.Length), bytes);
        }

        public static byte[] ConcatBytes(params byte[][] bytes)
        {
            List<byte> result = new List<byte>();
            foreach (byte[] array in bytes)
                result.AddRange(array);
            return result.ToArray();
        }
        #endregion
    }
}

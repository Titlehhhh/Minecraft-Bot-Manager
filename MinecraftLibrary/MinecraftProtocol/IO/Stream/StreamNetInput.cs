
using GeometRi;
using MinecraftLibrary;
using MinecraftLibrary.Data;
using MinecraftLibrary.Data.Inventory;
using MinecraftLibrary.Data.Inventory.ItemPalettes;
using MinecraftLibrary.MinecraftProtocol.Data.Inventory;
using MinecraftLibrary.Palletes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftProtocol.IO.Stream
{
    public class StreamNetInput : NetInput
    {
        private byte[] buffer;
        public byte[] IntactData => buffer;
        private Queue<byte> cache;
        public byte[] Data => cache.ToArray();
        public StreamNetInput(Queue<byte> data,int version)
        {
            buffer = data.ToArray();
            cache = data;
            protocolversion = version;
        }

        /// <summary>
        /// Protocol version for adjusting data types
        /// </summary>
        private int protocolversion;

        /// <summary>
        /// Initialize a new DataTypes instance
        /// </summary>
        /// <param name="protocol">Protocol version</param>
        /// <summary>
        /// Read some data from a cache of bytes and remove it from the cache
        /// </summary>
        /// <param name="offset">Amount of bytes to read</param>
        /// <param name="cache">Cache of bytes to read from</param>
        /// <returns>The data read from the cache as an array</returns>
        public byte[] ReadData(int offset)
        {
            byte[] result = new byte[offset];
            for (int i = 0; i < offset; i++)
                result[i] = cache.Dequeue();
            return result;
        }

        /// <summary>
        /// Read a string from a cache of bytes and remove it from the cache
        /// </summary>
        /// <param name="cache">Cache of bytes to read from</param>
        /// <returns>The string</returns>
        public string ReadNextString()
        {
            int length = ReadNextVarInt();
            if (length > 0)
            {
                return Encoding.UTF8.GetString(ReadData(length));
            }
            else return "";
        }

        /// <summary>
        /// Read a boolean from a cache of bytes and remove it from the cache
        /// </summary>
        /// <returns>The boolean value</returns>
        public bool ReadNextBool()
        {
            return ReadNextByte() != 0x00;
        }

        /// <summary>
        /// Read a short integer from a cache of bytes and remove it from the cache
        /// </summary>
        /// <returns>The short integer value</returns>
        public short ReadNextShort()
        {
            byte[] rawValue = ReadData(2);
            Array.Reverse(rawValue); //Endianness
            return BitConverter.ToInt16(rawValue, 0);
        }

        /// <summary>
        /// Read an integer from a cache of bytes and remove it from the cache
        /// </summary>
        /// <returns>The integer value</returns>
        public int ReadNextInt()
        {
            byte[] rawValue = ReadData(4);
            Array.Reverse(rawValue); //Endianness
            return BitConverter.ToInt32(rawValue, 0);
        }

        /// <summary>
        /// Read a long integer from a cache of bytes and remove it from the cache
        /// </summary>
        /// <returns>The unsigned long integer value</returns>
        public long ReadNextLong()
        {
            byte[] rawValue = ReadData(8);
            Array.Reverse(rawValue); //Endianness
            return BitConverter.ToInt64(rawValue, 0);
        }

        /// <summary>
        /// Read an unsigned short integer from a cache of bytes and remove it from the cache
        /// </summary>
        /// <returns>The unsigned short integer value</returns>
        public ushort ReadNextUShort()
        {
            byte[] rawValue = ReadData(2);
            Array.Reverse(rawValue); //Endianness
            return BitConverter.ToUInt16(rawValue, 0);
        }

        /// <summary>
        /// Read an unsigned long integer from a cache of bytes and remove it from the cache
        /// </summary>
        /// <returns>The unsigned long integer value</returns>
        public ulong ReadNextULong()
        {
            byte[] rawValue = ReadData(8);
            Array.Reverse(rawValue); //Endianness
            return BitConverter.ToUInt64(rawValue, 0);
        }

        /// <summary>
        /// Read a Location encoded as an ulong field and remove it from the cache
        /// </summary>
        /// <returns>The Location value</returns>
        public Point3D_I32 ReadNextLocation()
        {
            ulong locEncoded = ReadNextULong();
            int x, y, z;
            if (protocolversion >= MinecraftConstans.MC114Version)
            {
                x = (int)(locEncoded >> 38);
                y = (int)(locEncoded & 0xFFF);
                z = (int)(locEncoded << 26 >> 38);
            }
            else
            {
                x = (int)(locEncoded >> 38);
                y = (int)((locEncoded >> 26) & 0xFFF);
                z = (int)(locEncoded << 38 >> 38);
            }
            if (x >= 33554432)
                x -= 67108864;
            if (y >= 2048)
                y -= 4096;
            if (z >= 33554432)
                z -= 67108864;
            return new Point3D_I32(x, y, z);
        }
        
        /// <summary>
        /// Read several little endian unsigned short integers at once from a cache of bytes and remove them from the cache
        /// </summary>
        /// <returns>The unsigned short integer value</returns>
        public ushort[] ReadNextUShortsLittleEndian(int amount)
        {
            byte[] rawValues = ReadData(2 * amount);
            ushort[] result = new ushort[amount];
            for (int i = 0; i < amount; i++)
                result[i] = BitConverter.ToUInt16(rawValues, i * 2);
            return result;
        }

        /// <summary>
        /// Read a uuid from a cache of bytes and remove it from the cache
        /// </summary>
        /// <param name="cache">Cache of bytes to read from</param>
        /// <returns>The uuid</returns>
        public Guid ReadNextUUID()
        {
            byte[] javaUUID = ReadData(16);
            Guid guid = new Guid(javaUUID);
            if (BitConverter.IsLittleEndian)
                guid = guid.ToLittleEndian();
            return guid;
        }

        /// <summary>
        /// Read a byte array from a cache of bytes and remove it from the cache
        /// </summary>
        /// <param name="cache">Cache of bytes to read from</param>
        /// <returns>The byte array</returns>
        public byte[] ReadNextByteArray()
        {
            int len = protocolversion >= MinecraftConstans.MC18Version
                ? ReadNextVarInt()
                : ReadNextShort();
            return ReadData(len);
        }

        /// <summary>
        /// Reads a length-prefixed array of unsigned long integers and removes it from the cache
        /// </summary>
        /// <returns>The unsigned long integer values</returns>
        public ulong[] ReadNextULongArray()
        {
            int len = ReadNextVarInt();
            ulong[] result = new ulong[len];
            for (int i = 0; i < len; i++)
                result[i] = ReadNextULong();
            return result;
        }

        /// <summary>
        /// Read a double from a cache of bytes and remove it from the cache
        /// </summary>
        /// <returns>The double value</returns>
        public double ReadNextDouble()
        {
            byte[] rawValue = ReadData(8);
            Array.Reverse(rawValue); //Endianness
            return BitConverter.ToDouble(rawValue, 0);
        }

        /// <summary>
        /// Read a float from a cache of bytes and remove it from the cache
        /// </summary>
        /// <returns>The float value</returns>
        public float ReadNextFloat()
        {
            byte[] rawValue = ReadData(4);
            Array.Reverse(rawValue); //Endianness
            return BitConverter.ToSingle(rawValue, 0);
        }


        /// <summary>
        /// Read an integer from a cache of bytes and remove it from the cache
        /// </summary>
        /// <param name="cache">Cache of bytes to read from</param>
        /// <returns>The integer</returns>
        public int ReadNextVarInt()
        {
            int i = 0;
            int j = 0;
            int k = 0;
            while (true)
            {
                k = cache.Dequeue();
                i |= (k & 0x7F) << j++ * 7;
                if (j > 5) throw new OverflowException("VarInt too big ");
                if ((k & 0x80) != 128) break;
            }
            return i;
        }

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
        public int ReadNextVarShort()
        {
            ushort low = ReadNextUShort();
            byte high = 0;
            if ((low & 0x8000) != 0)
            {
                low &= 0x7FFF;
                high = ReadNextByte();
            }
            return ((high & 0xFF) << 15) | low;
        }

        /// <summary>
        /// Read a long from a cache of bytes and remove it from the cache
        /// </summary>
        /// <param name="cache">Cache of bytes to read from</param>
        /// <returns>The long value</returns>
        public long ReadNextVarLong()
        {
            int numRead = 0;
            long result = 0;
            byte read;
            do
            {
                read = ReadNextByte();
                long value = (read & 0x7F);
                result |= (value << (7 * numRead));

                numRead++;
                if (numRead > 10)
                {
                    throw new OverflowException("VarLong is too big");
                }
            } while ((read & 0x80) != 0);
            return result;
        }

        /// <summary>
        /// Read a single byte from a cache of bytes and remove it from the cache
        /// </summary>
        /// <returns>The byte that was read</returns>
        public byte ReadNextByte()
        {
            byte result = cache.Dequeue();
            return result;
        }

        /// <summary>
        /// Read an uncompressed Named Binary Tag blob and remove it from the cache
        /// </summary>
        public Dictionary<string, object> ReadNextNbt()
        {
            return ReadNextNbt(true);
        }

        /// <summary>
        /// Read a single item slot from a cache of bytes and remove it from the cache
        /// </summary>
        /// <returns>The item that was read or NULL for an empty slot</returns>
        public Item ReadNextItemSlot(ItemPalette itemPalette)
        {
            List<byte> slotData = new List<byte>();
            if (protocolversion > MinecraftConstans.MC113Version)
            {
                // MC 1.13 and greater
                bool itemPresent = ReadNextBool();
                if (itemPresent)
                {
                    ItemType type = itemPalette.FromId(ReadNextVarInt());
                    byte itemCount = ReadNextByte();
                    Dictionary<string, object> nbt = ReadNextNbt();
                    return new Item(type, itemCount, nbt);
                }
                else return null;
            }
            else
            {
                // MC 1.12.2 and lower
                short itemID = ReadNextShort();
                if (itemID == -1)
                    return null;
                byte itemCount = ReadNextByte();
                short itemDamage = ReadNextShort();
                Dictionary<string, object> nbt = ReadNextNbt();
                return new Item(itemPalette.FromId(itemID), itemCount, nbt);
            }
        }

        /// <summary>
        /// Read entity information from a cache of bytes and remove it from the cache
        /// </summary>
        /// <param name="entityPalette">Mappings for converting entity type Ids to EntityType</param>
        /// <param name="living">TRUE for living entities (layout differs)</param>
        /// <returns>Entity information</returns>
        public Entity ReadNextEntity(EntityPalette entityPalette, bool living)
        {
            int entityID = ReadNextVarInt();
            Guid entityUUID = Guid.Empty;

            if (protocolversion > MinecraftConstans.MC18Version)
            {
                entityUUID = ReadNextUUID();
            }

            EntityType entityType;
            // Entity type data type change from byte to varint after 1.14
            if (protocolversion > MinecraftConstans.MC113Version)
            {
                entityType = entityPalette.FromId(ReadNextVarInt(), living);
            }
            else
            {
                entityType = entityPalette.FromId(ReadNextByte(), living);
            }

            Double entityX = ReadNextDouble();
            Double entityY = ReadNextDouble();
            Double entityZ = ReadNextDouble();
            byte entityYaw = ReadNextByte();
            byte entityPitch = ReadNextByte();

            if (living)
            {
                entityPitch = ReadNextByte();
            }
            else
            {
                int metadata = ReadNextInt();
            }

            short velocityX = ReadNextShort();
            short velocityY = ReadNextShort();
            short velocityZ = ReadNextShort();

            return new Entity(entityID, entityType, new Point3d(entityX, entityY, entityZ), entityYaw, entityPitch);
        }

        /// <summary>
        /// Read an uncompressed Named Binary Tag blob and remove it from the cache (public)
        /// </summary>
        private Dictionary<string, object> ReadNextNbt(bool root)
        {
            Dictionary<string, object> nbtData = new Dictionary<string, object>();

            if (root)
            {
                if (cache.Peek() == 0) // TAG_End
                {
                    cache.Dequeue();
                    return nbtData;
                }
                if (cache.Peek() != 10) // TAG_Compound
                    throw new System.IO.InvalidDataException("Failed to decode NBT: Does not start with TAG_Compound");
                ReadNextByte(); // Tag type (TAG_Compound)

                // NBT root name
                string rootName = Encoding.ASCII.GetString(ReadData(ReadNextUShort()));
                if (!String.IsNullOrEmpty(rootName))
                    nbtData[""] = rootName;
            }

            while (true)
            {
                int fieldType = ReadNextByte();

                if (fieldType == 0) // TAG_End
                    return nbtData;

                int fieldNameLength = ReadNextUShort();
                string fieldName = Encoding.ASCII.GetString(ReadData(fieldNameLength));
                object fieldValue = ReadNbtField(fieldType);

                // This will override previous tags with the same name
                nbtData[fieldName] = fieldValue;
            }
        }

        /// <summary>
        /// Read a single Named Binary Tag field of the specified type and remove it from the cache
        /// </summary>
        private object ReadNbtField(int fieldType)
        {
            switch (fieldType)
            {
                case 1: // TAG_Byte
                    return ReadNextByte();
                case 2: // TAG_Short
                    return ReadNextShort();
                case 3: // TAG_Int
                    return ReadNextInt();
                case 4: // TAG_Long
                    return ReadNextLong();
                case 5: // TAG_Float
                    return ReadNextFloat();
                case 6: // TAG_Double
                    return ReadNextDouble();
                case 7: // TAG_Byte_Array
                    return ReadData(ReadNextInt());
                case 8: // TAG_String
                    return Encoding.UTF8.GetString(ReadData(ReadNextUShort()));
                case 9: // TAG_List
                    int listType = ReadNextByte();
                    int listLength = ReadNextInt();
                    object[] listItems = new object[listLength];
                    for (int i = 0; i < listLength; i++)
                        listItems[i] = ReadNbtField(listType);
                    return listItems;
                case 10: // TAG_Compound
                    return ReadNextNbt(false);
                case 11: // TAG_Int_Array
                    listType = 3;
                    listLength = ReadNextInt();
                    listItems = new object[listLength];
                    for (int i = 0; i < listLength; i++)
                        listItems[i] = ReadNbtField(listType);
                    return listItems;
                case 12: // TAG_Long_Array
                    listType = 4;
                    listLength = ReadNextInt();
                    listItems = new object[listLength];
                    for (int i = 0; i < listLength; i++)
                        listItems[i] = ReadNbtField(listType);
                    return listItems;
                default:
                    throw new System.IO.InvalidDataException("Failed to decode NBT: Unknown field type " + fieldType);
            }
        }

        public Dictionary<int, object> ReadNextMetadata(ItemPalette itemPalette)
        {
            Dictionary<int, object> data = new Dictionary<int, object>();
            byte key = ReadNextByte();
            while (key != 0xff)
            {
                int type = ReadNextVarInt();

                // starting from 1.13, Optional Chat is inserted as number 5 in 1.13 and IDs after 5 got shifted.
                // Increase type ID by 1 if
                // - below 1.13
                // - type ID larger than 4
                if (protocolversion < MinecraftConstans.MC113Version)
                {
                    if (type > 4)
                    {
                        type += 1;
                    }
                }
                // Value's data type is depended on Type
                object value = null;

                // This is backward compatible since new type is appended to the end
                // Version upgrade note
                // - Check type ID got shifted or not
                // - Add new type if any
                switch (type)
                {
                    case 0: // byte
                        value = ReadNextByte();
                        break;
                    case 1: // VarInt
                        value = ReadNextVarInt();
                        break;
                    case 2: // Float
                        value = ReadNextFloat();
                        break;
                    case 3: // String
                        value = ReadNextString();
                        break;
                    case 4: // Chat
                        value = ReadNextString();
                        break;
                    case 5: // Optional Chat
                        if (ReadNextBool())
                        {
                            value = ReadNextString();
                        }
                        break;
                    case 6: // Slot
                        value = ReadNextItemSlot(itemPalette);
                        break;
                    case 7: // Boolean
                        value = ReadNextBool();
                        break;
                    case 8: // Rotation (3x floats)
                        List<float> t = new List<float>();
                        t.Add(ReadNextFloat());
                        t.Add(ReadNextFloat());
                        t.Add(ReadNextFloat());
                        value = t;
                        break;
                    case 9: // Position
                        value = ReadNextLocation();
                        break;
                    case 10: // Optional Position
                        if (ReadNextBool())
                        {
                            value = ReadNextLocation();
                        }
                        break;
                    case 11: // Direction (VarInt)
                        value = ReadNextVarInt();
                        break;
                    case 12: // Optional UUID
                        if (ReadNextBool())
                        {
                            value = ReadNextUUID();
                        }
                        break;
                    case 13: // Optional BlockID (VarInt)
                        value = ReadNextVarInt();
                        break;
                    case 14: // NBT
                        value = ReadNextNbt();
                        break;
                    case 15: // Particle
                             // Currecutly not handled. Reading data only
                        int ParticleID = ReadNextVarInt();
                        switch (ParticleID)
                        {
                            case 3:
                                ReadNextVarInt();
                                break;
                            case 14:
                                ReadNextFloat();
                                ReadNextFloat();
                                ReadNextFloat();
                                ReadNextFloat();
                                break;
                            case 23:
                                ReadNextVarInt();
                                break;
                            case 32:
                                ReadNextItemSlot(itemPalette);
                                break;
                        }
                        break;
                    case 16: // Villager Data (3x VarInt)
                        List<int> d = new List<int>();
                        d.Add(ReadNextVarInt());
                        d.Add(ReadNextVarInt());
                        d.Add(ReadNextVarInt());
                        value = d;
                        break;
                    case 17: // Optional VarInt
                        if (ReadNextBool())
                        {
                            value = ReadNextVarInt();
                        }
                        break;
                    case 18: // Pose
                        value = ReadNextVarInt();
                        break;
                    default:
                        throw new System.IO.InvalidDataException("Unknown Metadata Type ID " + type + ". Is this up to date for new MC Version?");
                }
                data[key] = value;
                key = ReadNextByte();
            }
            return data;
        }

        /// <summary>
        /// Read a single villager trade from a cache of bytes and remove it from the cache
        /// </summary>
        /// <returns>The item that was read or NULL for an empty slot</returns>
        public VillagerTrade ReadNextTrade(ItemPalette itemPalette)
        {
            Item inputItem1 = ReadNextItemSlot(itemPalette);
            Item outputItem = ReadNextItemSlot(itemPalette);
            Item inputItem2 = null;
            if (ReadNextBool()) //check if villager has second item
            {
                inputItem2 = ReadNextItemSlot(itemPalette);
            }
            bool tradeDisabled = ReadNextBool();
            int numberOfTradeUses = ReadNextInt();
            int maximumNumberOfTradeUses = ReadNextInt();
            int xp = ReadNextInt();
            int specialPrice = ReadNextInt();
            float priceMultiplier = ReadNextFloat();
            int demand = ReadNextInt();
            return new VillagerTrade(inputItem1, outputItem, inputItem2, tradeDisabled, numberOfTradeUses, maximumNumberOfTradeUses, xp, specialPrice, priceMultiplier, demand);
        }

    }

    public static class GuidExtensions
    {
        /// <summary>
        /// A CLSCompliant method to convert a Java big-endian Guid to a .NET 
        /// little-endian Guid.
        /// The Guid Constructor (UInt32, UInt16, UInt16, Byte, Byte, Byte, Byte,
        ///  Byte, Byte, Byte, Byte) is not CLSCompliant.
        /// </summary>
        public static Guid ToLittleEndian(this Guid javaGuid)
        {
            byte[] net = new byte[16];
            byte[] java = javaGuid.ToByteArray();
            for (int i = 8; i < 16; i++)
            {
                net[i] = java[i];
            }
            net[3] = java[0];
            net[2] = java[1];
            net[1] = java[2];
            net[0] = java[3];
            net[5] = java[4];
            net[4] = java[5];
            net[6] = java[7];
            net[7] = java[6];
            return new Guid(net);
        }

        /// <summary>
        /// Converts little-endian .NET guids to big-endian Java guids:
        /// </summary>
        public static Guid ToBigEndian(this Guid netGuid)
        {
            byte[] java = new byte[16];
            byte[] net = netGuid.ToByteArray();
            for (int i = 8; i < 16; i++)
            {
                java[i] = net[i];
            }
            java[0] = net[3];
            java[1] = net[2];
            java[2] = net[1];
            java[3] = net[0];
            java[4] = net[5];
            java[5] = net[4];
            java[6] = net[7];
            java[7] = net[6];
            return new Guid(java);
        }

        /// <summary>
        /// Converts little-endian .NET guids to big-endian Java guids:
        /// </summary>
        public static byte[] ToBigEndianBytes(this Guid netGuid)
        {
            byte[] java = new byte[16];
            byte[] net = netGuid.ToByteArray();
            for (int i = 8; i < 16; i++)
            {
                java[i] = net[i];
            }
            java[0] = net[3];
            java[1] = net[2];
            java[2] = net[1];
            java[3] = net[0];
            java[4] = net[5];
            java[5] = net[4];
            java[6] = net[7];
            java[7] = net[6];
            return java;
        }
    }

}

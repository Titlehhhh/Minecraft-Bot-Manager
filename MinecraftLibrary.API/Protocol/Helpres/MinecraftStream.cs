
using MinecraftLibrary.API.Helpers;
using MinecraftLibrary.NBT.Tags;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftLibrary.API.Protocol.Helpres
{
    public sealed class MinecraftStream : Stream
    {
        public int ProtocollVersion { get; private set; }
        public Stream BaseStream { get; private set; }

        public override bool CanRead => BaseStream.CanRead;

        public override bool CanSeek => BaseStream.CanSeek;

        public override bool CanWrite => BaseStream.CanWrite;

        public override long Length => BaseStream.Length;

        public override long Position { get => BaseStream.Position; set => BaseStream.Position = value; }

        public MinecraftStream(Stream stream, int version)
        {
            this.ProtocollVersion = version;
            BaseStream = stream;            
        }        
        #region Reads
        public byte[] ReadData(int offset)
        {
            byte[] result = null;
            int len = BaseStream.Read(result, 0, offset);
            if (len == 0)
                throw new NotSupportedException("Поток завершился");
            return result;
        }

        public string ReadNextString()
        {
            int length = ReadNextVarInt();
            if (length > 0)
            {
                return Encoding.UTF8.GetString(ReadData(length));
            }
            else return "";
        }

        public bool ReadNextBool()
        {
            return ReadByte() == 1;
        }

        public short ReadNextShort()
        {
            byte[] rawValue = ReadData(2);
            Array.Reverse(rawValue); //Endianness
            return BitConverter.ToInt16(rawValue, 0);
        }

        public int ReadNextInt()
        {
            byte[] rawValue = ReadData(4);
            Array.Reverse(rawValue); //Endianness
            return BitConverter.ToInt32(rawValue, 0);
        }

        public long ReadNextLong()
        {
            byte[] rawValue = ReadData(8);
            Array.Reverse(rawValue); //Endianness
            return BitConverter.ToInt64(rawValue, 0);
        }

        public ushort ReadNextUShort()
        {
            byte[] rawValue = ReadData(2);
            Array.Reverse(rawValue); //Endianness
            return BitConverter.ToUInt16(rawValue, 0);
        }

        public ulong ReadNextULong()
        {
            byte[] rawValue = ReadData(8);
            Array.Reverse(rawValue); //Endianness
            return BitConverter.ToUInt64(rawValue, 0);

        }

        public ushort[] ReadNextUShortsLittleEndian(int amount)
        {
            byte[] rawValues = ReadData(2 * amount);
            ushort[] result = new ushort[amount];
            for (int i = 0; i < amount; i++)
                result[i] = BitConverter.ToUInt16(rawValues, i * 2);
            return result;
        }

        public Guid ReadNextUUID()
        {
            byte[] javaUUID = ReadData(16);
            Guid guid = new Guid(javaUUID);
            if (BitConverter.IsLittleEndian)
                guid = guid.ToLittleEndian();
            return guid;
        }

        public byte[] ReadNextByteArray()
        {
            return ReadData(ReadNextVarInt());
        }

        public ulong[] ReadNextULongArray()
        {
            int len = ReadNextVarInt();
            ulong[] result = new ulong[len];
            for (int i = 0; i < len; i++)
                result[i] = ReadNextULong();
            return result;
        }

        public double ReadNextDouble()
        {
            byte[] rawValue = ReadData(8);
            Array.Reverse(rawValue); //Endianness
            return BitConverter.ToDouble(rawValue, 0);
        }

        public float ReadNextFloat()
        {
            byte[] rawValue = ReadData(4);
            Array.Reverse(rawValue); //Endianness
            return BitConverter.ToSingle(rawValue, 0);
        }

        public int ReadNextVarInt()
        {
            int i = 0;
            int j = 0;
            int k = 0;
            while (true)
            {
                k = ReadByte();
                i |= (k & 0x7F) << j++ * 7;
                if (j > 5) throw new OverflowException("VarInt too big ");
                if ((k & 0x80) != 128) break;
            }
            return i;
        }

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

        public byte ReadNextByte()
        {
            int nextByte = BaseStream.ReadByte();
            if (nextByte == -1)
                throw new NotSupportedException("Поток завершен");
            return (byte)nextByte;
        }
        public NbtCompound ReadNbt()
        {
            throw new NotImplementedException();
        }
        
        #endregion
        #region Write
        public void WriteVarInt(int paramInt)
        {
            AddArray(DataTypes.GetVarInt(paramInt));
        }


        public void WriteBool(bool paramBool)
        {
            BaseStream.WriteByte(Convert.ToByte(paramBool));
        }


        public void WriteLong(long number)
        {
            byte[] theLong = BitConverter.GetBytes(number);
            Array.Reverse(theLong);
            AddArray(theLong);

        }

        public void WriteInt(int number)
        {
            byte[] theInt = BitConverter.GetBytes(number);
            Array.Reverse(theInt);
            AddArray(theInt);
        }


        public void WriteShort(short number)
        {
            byte[] theShort = BitConverter.GetBytes(number);
            Array.Reverse(theShort);
            AddArray(theShort);
        }


        public void WriteUShort(ushort number)
        {
            byte[] theShort = BitConverter.GetBytes(number);
            Array.Reverse(theShort);
            AddArray(theShort);
        }

        public void WriteDouble(double number)
        {
            byte[] theDouble = BitConverter.GetBytes(number);
            Array.Reverse(theDouble); //Endianness
            AddArray(theDouble);
        }

        public void WriteFloat(float number)
        {
            byte[] theFloat = BitConverter.GetBytes(number);
            Array.Reverse(theFloat); //Endianness
            AddArray(theFloat);
        }

        public void WriteArray(byte[] array)
        {
            WriteVarInt(array.Length);
            AddArray(array);
        }

        public void AddArray(byte[] array)
        {
            BaseStream.Write(array, 0, array.Length);
        }

        public void WriteString(string text)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            WriteVarInt(bytes.Length);
            AddArray(bytes);
        }
        public void WriteNbt(NbtCompound nbt)
        {
            
        }

        #endregion


        public override void Flush()
        {
            BaseStream.Flush();
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return BaseStream.Seek(offset, origin);
        }

        public override void SetLength(long value)
        {
            BaseStream.SetLength(value);
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            return BaseStream.Read(buffer, offset, count);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            BaseStream.Write(buffer, offset, count);
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

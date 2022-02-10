using MinecraftLibrary.NBT.Tags;
using MinecraftLibrary.Utils;
using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftLibrary.API.Networking.IO
{
    public partial class MinecraftStream
    {
        public sbyte ReadSignedByte() => (sbyte)this.ReadUnsignedByte();

        public async Task<sbyte> ReadByteAsync() => (sbyte)await this.ReadUnsignedByteAsync();

        
        public byte ReadUnsignedByte()
        {
            Span<byte> buffer = stackalloc byte[1];
            BaseStream.Read(buffer);
            return buffer[0];
        }

        public async Task<byte> ReadUnsignedByteAsync()
        {
            var buffer = new byte[1];
            await this.ReadAsync(buffer);
            return buffer[0];
        }

        
        public bool ReadBoolean()
        {
            return ReadUnsignedByte() == 0x01;
        }

        public async Task<bool> ReadBooleanAsync()
        {
            var value = (int)await this.ReadByteAsync();
            if (value == 0x00)
            {
                return false;
            }
            else if (value == 0x01)
            {
                return true;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Byte returned by stream is out of range (0x00 or 0x01)", nameof(BaseStream));
            }
        }

        
        public ushort ReadUnsignedShort()
        {
            Span<byte> buffer = stackalloc byte[2];
            this.Read(buffer);
            return BinaryPrimitives.ReadUInt16BigEndian(buffer);
        }

        public async Task<ushort> ReadUnsignedShortAsync()
        {
            var buffer = new byte[2];
            await this.ReadAsync(buffer);
            return BinaryPrimitives.ReadUInt16BigEndian(buffer);
        }

        
        public short ReadShort()
        {
            Span<byte> buffer = stackalloc byte[2];
            this.Read(buffer);
            return BinaryPrimitives.ReadInt16BigEndian(buffer);
        }

        public async Task<short> ReadShortAsync()
        {
            using var buffer = new RentedArray<byte>(sizeof(short));
            await this.ReadAsync(buffer);
            return BinaryPrimitives.ReadInt16BigEndian(buffer);
        }

        
        public int ReadInt()
        {
            Span<byte> buffer = stackalloc byte[4];
            this.Read(buffer);
            return BinaryPrimitives.ReadInt32BigEndian(buffer);
        }

        public async Task<int> ReadIntAsync()
        {
            using var buffer = new RentedArray<byte>(sizeof(int));
            await this.ReadAsync(buffer);
            return BinaryPrimitives.ReadInt32BigEndian(buffer);
        }

        
        public long ReadLong()
        {
            Span<byte> buffer = stackalloc byte[8];
            this.Read(buffer);
            return BinaryPrimitives.ReadInt64BigEndian(buffer);
        }

        public async Task<long> ReadLongAsync()
        {
            using var buffer = new RentedArray<byte>(sizeof(long));
            await this.ReadAsync(buffer);
            return BinaryPrimitives.ReadInt64BigEndian(buffer);
        }

        
        public ulong ReadUnsignedLong()
        {
            Span<byte> buffer = stackalloc byte[8];
            this.Read(buffer);
            return BinaryPrimitives.ReadUInt64BigEndian(buffer);
        }

        public async Task<ulong> ReadUnsignedLongAsync()
        {
            using var buffer = new RentedArray<byte>(sizeof(ulong));
            await this.ReadAsync(buffer);
            return BinaryPrimitives.ReadUInt64BigEndian(buffer);
        }

        
        public float ReadFloat()
        {
            Span<byte> buffer = stackalloc byte[4];
            this.Read(buffer);
            return BinaryPrimitives.ReadSingleBigEndian(buffer);
        }

        public async Task<float> ReadFloatAsync()
        {
            using var buffer = new RentedArray<byte>(sizeof(float));
            await this.ReadAsync(buffer);
            return BinaryPrimitives.ReadSingleBigEndian(buffer);
        }

        
        public double ReadDouble()
        {
            Span<byte> buffer = stackalloc byte[8];
            this.Read(buffer);
            return BinaryPrimitives.ReadDoubleBigEndian(buffer);
        }

        public async Task<double> ReadDoubleAsync()
        {
            using var buffer = new RentedArray<byte>(sizeof(double));
            await this.ReadAsync(buffer);
            return BinaryPrimitives.ReadDoubleBigEndian(buffer);
        }

        
        public string ReadString(int maxLength = 32767)
        {
            var length = ReadVarInt();
            var buffer = new byte[length];
            this.Read(buffer, 0, length);

            var value = Encoding.UTF8.GetString(buffer);
            if (maxLength > 0 && value.Length > maxLength)
            {
                throw new ArgumentException($"string ({value.Length}) exceeded maximum length ({maxLength})", nameof(value));
            }
            return value;
        }

        public async Task<string> ReadStringAsync(int maxLength = 32767)
        {
            var length = await this.ReadVarIntAsync();
            using var buffer = new RentedArray<byte>(length);
            if (BitConverter.IsLittleEndian)
            {
                buffer.Span.Reverse();
            }
            await this.ReadAsync(buffer);

            var value = Encoding.UTF8.GetString(buffer);
            if (maxLength > 0 && value.Length > maxLength)
            {
                throw new ArgumentException($"string ({value.Length}) exceeded maximum length ({maxLength})", nameof(maxLength));
            }
            return value;
        }

       
        public int ReadVarInt()
        {
            int numRead = 0;
            int result = 0;
            byte read;
            do
            {
                read = this.ReadUnsignedByte();
                int value = read & 0b01111111;
                result |= value << (7 * numRead);

                numRead++;
                if (numRead > 5)
                {
                    throw new InvalidOperationException("VarInt is too big");
                }
            } while ((read & 0b10000000) != 0);

            return result;
        }

        public virtual async Task<int> ReadVarIntAsync()
        {
            int numRead = 0;
            int result = 0;
            byte read;
            do
            {
                read = await this.ReadUnsignedByteAsync();
                int value = read & 0b01111111;
                result |= value << (7 * numRead);

                numRead++;
                if (numRead > 5)
                {
                    throw new InvalidOperationException("VarInt is too big");
                }
            } while ((read & 0b10000000) != 0);

            return result;
        }

        
        public byte[] ReadUInt8Array(int length = 0)
        {
            if (length == 0)
                length = ReadVarInt();

            var result = new byte[length];
            if (length == 0)
                return result;

            int n = length;
            while (true)
            {
                n -= Read(result, length - n, n);
                if (n == 0)
                    break;
            }
            return result;
        }

        public async Task<byte[]> ReadUInt8ArrayAsync(int length = 0)
        {
            if (length == 0)
                length = await this.ReadVarIntAsync();

            var result = new byte[length];
            if (length == 0)
                return result;

            int n = length;
            while (true)
            {
                n -= await this.ReadAsync(result, length - n, n);
                if (n == 0)
                    break;
            }
            return result;
        }
        public async Task<byte> ReadUInt8Async()
        {
            int value = await this.ReadByteAsync();
            if (value == -1)
                throw new EndOfStreamException();
            return (byte)value;
        }       
        public long ReadVarLong()
        {
            int numRead = 0;
            long result = 0;
            byte read;
            do
            {
                read = this.ReadUnsignedByte();
                int value = (read & 0b01111111);
                result |= (long)value << (7 * numRead);

                numRead++;
                if (numRead > 10)
                {
                    throw new InvalidOperationException("VarLong is too big");
                }
            } while ((read & 0b10000000) != 0);

            return result;
        }

        public async Task<long> ReadVarLongAsync()
        {
            int numRead = 0;
            long result = 0;
            byte read;
            do
            {
                read = await this.ReadUnsignedByteAsync();
                int value = (read & 0b01111111);
                result |= (long)value << (7 * numRead);

                numRead++;
                if (numRead > 10)
                {
                    throw new InvalidOperationException("VarLong is too big");
                }
            } while ((read & 0b10000000) != 0);

            return result;
        }

    }
}

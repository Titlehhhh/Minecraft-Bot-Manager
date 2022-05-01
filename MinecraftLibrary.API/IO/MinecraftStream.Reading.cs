﻿using MinecraftLibrary.API.Utils;
using System.Buffers.Binary;
using System.Runtime.InteropServices;
using System.Text;

namespace MinecraftLibrary.API.IO
{

    public sealed partial class MinecraftStream
    {


        public sbyte ReadSignedByte() => (sbyte)this.ReadUnsignedByte();

        public async Task<sbyte> ReadByteAsync(CancellationToken cancellationToken = default) => (sbyte)await this.ReadUnsignedByteAsync(cancellationToken);

        public ulong[] ReadULongArray()
        {
            int len = this.ReadVarInt();
            Span<byte> buffer = stackalloc byte[len * 8];
            this.Read(buffer);
            Span<ulong> result = MemoryMarshal.Cast<byte, ulong>(buffer);
            return result.ToArray();
        }
        public byte ReadUnsignedByte()
        {
            Span<byte> buffer = stackalloc byte[1];
            this.Read(buffer);
            return buffer[0];
        }

        public Guid ReadGuid()
        {
            return GuidFromTwoLong(ReadLong(), ReadLong());
        }
        private static unsafe Guid GuidFromTwoLong(long x, long y)
        {
            long* ptr = stackalloc long[2];
            ptr[0] = x;
            ptr[1] = y;
            return *(Guid*)ptr;
        }

        public async Task<byte> ReadUnsignedByteAsync(CancellationToken cancellationToken = default)
        {
            var buffer = new byte[1];
            await this.ReadAsync(buffer, cancellationToken);
            return buffer[0];
        }


        public bool ReadBoolean()
        {
            return ReadUnsignedByte() == 0x01;
        }




        public ushort ReadUnsignedShort()
        {
            Span<byte> buffer = stackalloc byte[2];
            this.Read(buffer);
            return BinaryPrimitives.ReadUInt16BigEndian(buffer);
        }




        public short ReadShort()
        {
            Span<byte> buffer = stackalloc byte[2];
            this.Read(buffer);
            return BinaryPrimitives.ReadInt16BigEndian(buffer);
        }




        public int ReadInt()
        {
            Span<byte> buffer = stackalloc byte[4];
            this.Read(buffer);
            
            
            return BinaryPrimitives.ReadInt32BigEndian(buffer);
        }




        public long ReadLong()
        {
            Span<byte> buffer = stackalloc byte[8];
            this.Read(buffer);
            return BinaryPrimitives.ReadInt64BigEndian(buffer);
        }




        public ulong ReadUnsignedLong()
        {
            Span<byte> buffer = stackalloc byte[8];
            this.Read(buffer);
            return BinaryPrimitives.ReadUInt64BigEndian(buffer);
        }




        public float ReadFloat()
        {
            Span<byte> buffer = stackalloc byte[4];
            this.Read(buffer);
            return BinaryPrimitives.ReadSingleBigEndian(buffer);
        }



        public double ReadDouble()
        {
            Span<byte> buffer = stackalloc byte[8];
            this.Read(buffer);
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



        public byte[] ReadByteArray()
        {
            int len = ReadVarInt();
            byte[] buf = new byte[len];
            Read(buf, 0, len);
            return buf;
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
    }
}

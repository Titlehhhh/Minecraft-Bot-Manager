using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftLibrary.API.IO
{
    public interface IMinecraftStreamReader
    {
        long Length { get; }

        int Read(byte[] buffer, int offset, int count);
        bool ReadBoolean();
        Task<bool> ReadBooleanAsync(CancellationToken cancellationToken = default);
        byte[] ReadByteArray();
        Task<sbyte> ReadByteAsync(CancellationToken cancellationToken = default);
        double ReadDouble();
        Task<double> ReadDoubleAsync(CancellationToken cancellationToken = default);
        float ReadFloat();
        Task<float> ReadFloatAsync(CancellationToken cancellationToken = default);
        Guid ReadGuid();
        int ReadInt();
        Task<int> ReadIntAsync(CancellationToken cancellationToken = default);
        long ReadLong();
        Task<long> ReadLongAsync(CancellationToken cancellationToken = default);
        short ReadShort();
        Task<short> ReadShortAsync(CancellationToken cancellationToken = default);
        sbyte ReadSignedByte();
        string ReadString(int maxLength = 32767);
        Task<string> ReadStringAsync(int maxLength = 32767, CancellationToken cancellationToken = default);
        byte[] ReadUInt8Array(int length = 0);
        Task<byte[]> ReadUInt8ArrayAsync(int length = 0, CancellationToken cancellationToken = default);
        Task<byte> ReadUInt8Async(CancellationToken cancellationToken = default);
        ulong[] ReadULongArray();
        byte ReadUnsignedByte();
        Task<byte> ReadUnsignedByteAsync(CancellationToken cancellationToken = default);
        ulong ReadUnsignedLong();
        Task<ulong> ReadUnsignedLongAsync(CancellationToken cancellationToken = default);
        ushort ReadUnsignedShort();
        Task<ushort> ReadUnsignedShortAsync(CancellationToken cancellationToken = default);
        int ReadVarInt();
        Task<int> ReadVarIntAsync(CancellationToken cancellationToken = default);
        long ReadVarLong();
        Task<long> ReadVarLongAsync(CancellationToken cancellationToken = default);
    }
}

using MinecraftLibrary.NBT;

namespace MinecraftLibrary.API.IO
{
    public interface IMinecraftStreamWriter
    {
        void Write(byte[] buffer);
        void Write(byte[] buffer, int offset, int count);
        void WriteBoolean(bool value);
        Task WriteBooleanAsync(bool value);
        void WriteByte(sbyte value);
        void WriteByteArray(byte[] values);
        Task WriteByteAsync(sbyte value);
        void WriteDouble(double value);
        Task WriteDoubleAsync(double value);
        void WriteFloat(float value);
        Task WriteFloatAsync(float value);
        void WriteInt(int value);
        Task WriteIntAsync(int value);
        void WriteLong(long value);
        void WriteLongArray(long[] values);
        Task WriteLongArrayAsync(long[] values);
        Task WriteLongArrayAsync(ulong[] values);
        Task WriteLongAsync(long value);
        void WriteNbt(NbtTag nbt);
        void WriteNbtCompound(NbtCompound compound);
        void WriteShort(short value);
        Task WriteShortAsync(short value);
        void WriteString(string value, int maxLength = 32767);
        Task WriteStringAsync(string value, int maxLength = 32767);
        void WriteUnsignedByte(byte value);
        Task WriteUnsignedByteAsync(byte value);
        void WriteUnsignedShort(ushort value);
        Task WriteUnsignedShortAsync(ushort value);
        void WriteUuid(Guid value);
        Task WriteUuidAsync(Guid value);
        void WriteVarInt(Enum value);
        void WriteVarInt(int value);
        Task WriteVarIntAsync(Enum value);
        Task WriteVarIntAsync(int value);
        void WriteVarLong(long value);
        Task WriteVarLongAsync(long value);
    }

    public interface IMinecraftStream : IMinecraftStreamReader, IMinecraftStreamWriter
    {

    }
    
}

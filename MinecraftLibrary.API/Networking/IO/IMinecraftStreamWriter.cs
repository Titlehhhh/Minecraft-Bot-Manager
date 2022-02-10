using MinecraftLibrary.NBT.Tags;

namespace MinecraftLibrary.API.Networking.IO
{
    public interface IMinecraftStreamWriter
    {
        void AddArray(byte[] array);
        void Write(byte[] buffer, int offset, int count);
        void WriteArray(byte[] array);
        void WriteBool(bool paramBool);
        void WriteDouble(double number);
        void WriteFloat(float number);
        void WriteInt(int number);
        void WriteLong(long number);
        void WriteNbt(NbtCompound nbt);
        void WriteShort(short number);
        void WriteString(string text);
        void WriteUShort(ushort number);
        void WriteVarInt(int paramInt);
        void WriteByte(byte value);
    }
}
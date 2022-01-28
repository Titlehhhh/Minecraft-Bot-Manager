using fNbt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftLibrary.API.Networking.IO
{
    public interface NetOutput
    {
        void WriteNbt(NbtCompound nbt);
        void WriteVarInt(int paramInt);
        void WriteBool(bool paramBool);
        void WriteLong(long number);
        void WriteInt(int number);
        void WriteShort(short number);
        void WriteUShort(ushort number);
        void WriteDouble(double number);
        void WriteFloat(float number);
        void WriteArray(byte[] array);
        void WriteString(string text);
    }
}

using fNbt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftLibrary.API.Networking.IO
{
    public interface NetInput
    {
        byte[] ReadData(int offset);
        string ReadNextString();
        bool ReadNextBool();
        short ReadNextShort();
        int ReadNextInt();
        long ReadNextLong();
        ushort ReadNextUShort();
        ulong ReadNextULong();
        ushort[] ReadNextUShortsLittleEndian(int amount);
        Guid ReadNextUUID();
        byte[] ReadNextByteArray();
        ulong[] ReadNextULongArray();
        double ReadNextDouble();
        float ReadNextFloat();
        int ReadNextVarInt();
        int ReadNextVarShort();
        long ReadNextVarLong();
        byte ReadNextByte();
        NbtCompound ReadNextNbt();
    }
}

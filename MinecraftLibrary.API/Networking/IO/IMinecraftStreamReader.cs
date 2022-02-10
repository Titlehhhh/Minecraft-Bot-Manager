using MinecraftLibrary.NBT.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftLibrary.API.Networking.IO
{
    public interface IMinecraftStreamReader
    {
        int Read(byte[] buffer, int offset, int count);
        byte[] ReadData(int offset);
        NbtCompound ReadNbt();
        bool ReadNextBool();
        byte ReadNextByte();
        byte[] ReadNextByteArray();
        double ReadNextDouble();
        float ReadNextFloat();
        int ReadNextInt();
        long ReadNextLong();
        short ReadNextShort();
        string ReadNextString();
        ulong ReadNextULong();
        ulong[] ReadNextULongArray();
        ushort ReadNextUShort();
        ushort[] ReadNextUShortsLittleEndian(int amount);
        Guid ReadNextUUID();
        int ReadNextVarInt();
        long ReadNextVarLong();
        int ReadNextVarShort();

    }
}

using System;

namespace MinecraftLibrary.API.Networking
{
    public struct ByteBlock
    {
        public int ID { get; private set; }
        public byte[] Data { get; private set; }

        public ByteBlock(int iD, byte[] data)
        {

            ID = iD;
            Data = data.Clone() as byte[];
            if (Data == null)
                throw new Exception("Не удалось клонировать массив");
        }
    }


}

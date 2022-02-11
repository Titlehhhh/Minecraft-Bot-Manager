using System;
using System.Runtime.InteropServices;

namespace MinecraftLibrary.API.Networking
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public sealed class FieldAttribute : Attribute
    {
        public FieldAttribute(int order)
        {
        }
    }
    
    public struct ByteBlock
    {      
        [Field(0)]
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

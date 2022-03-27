using Ionic.Zlib;
using MinecraftLibrary.API.IO;

namespace MinecraftLibrary.API.Networking
{
    public sealed class PacketReaderWriter : IPacketReaderWriter
    {
        private static readonly int ZERO_VARLENGTH = 0.GetVarIntLength();
        private readonly NetworkMinecraftStream netmcStream;




        public PacketReaderWriter(NetworkMinecraftStream netstream)
        {
            this.netmcStream = netstream;
        }

        public int CompressionThreshold { get; set; }

        public NetworkMinecraftStream NetStream => netmcStream;

        public void Dispose()
        {
            NetStream.Dispose();
        }


        public async Task<(int, MinecraftStream)> ReadNextPacketAsync()
        {
            int len = await NetStream.ReadVarIntAsync();
            // Console.WriteLine("len " + len);
            byte[] receivedata = new byte[len];
            await NetStream.ReadAsync(receivedata.AsMemory(0, len));


            var mcs = new MinecraftStream(receivedata);
            if (CompressionThreshold > 0)
            {

                int sizeUncompressed = mcs.ReadVarInt();
                if (sizeUncompressed != 0)
                {
                    ZlibStream zlibStream = new ZlibStream(mcs.BaseStream, CompressionMode.Decompress);
                    byte[] uncompressdata = new byte[sizeUncompressed];
                    zlibStream.Read(uncompressdata);
                    zlibStream.Close();
                    mcs.BaseStream = new MemoryStream(uncompressdata);
                }

            }
            int id = mcs.ReadVarInt();
            return (id, mcs);
        }


        public async Task WritePacketAsync(IPacket packet, int id)
        {
            ArgumentNullException.ThrowIfNull(packet, nameof(packet));
            if (CompressionThreshold > 0)
            {
                using (MinecraftStream packetStream = new MinecraftStream())
                {
                    packetStream.WriteVarInt(id);
                    packet.Write(packetStream);

                    int to_Packetlength = (int)packetStream.Length;

                    if (to_Packetlength >= CompressionThreshold)
                    {
                        await SendLongPacket(packetStream, to_Packetlength);
                    }
                    else
                    {
                        await SendShortPacket(packetStream);
                    }
                }
            }
            else
            {
                await SendPacketWithoutCompression(packet, id);
            }
        }
        private async Task SendPacketWithoutCompression(IPacket packet, int id)
        {
            using (MinecraftStream packetStream = new MinecraftStream())
            {
                packet.Write(packetStream);
                int Packetlength = (int)packetStream.Length;
                NetStream.Lock.Wait();
                await NetStream.WriteVarIntAsync(id.GetVarIntLength() + Packetlength);
                await NetStream.WriteVarIntAsync(id);
                packetStream.Position = 0;
                packetStream.CopyTo(NetStream);
                NetStream.Lock.Release();
            }
        }

        private async Task SendLongPacket(MinecraftStream packetStream, int to_Packetlength)
        {
            using (MemoryStream memstream = new MemoryStream())
            {
                using (ZlibStream stream = new ZlibStream(memstream, CompressionMode.Compress))
                {
                    packetStream.CopyTo(stream);
                }
                packetStream.BaseStream = memstream;
            }
            int fullSize = (int)packetStream.Length + to_Packetlength.GetVarIntLength();
            await NetStream.WriteVarIntAsync(fullSize);
            await NetStream.WriteVarIntAsync(to_Packetlength);
            packetStream.Position = 0;
            packetStream.CopyTo(NetStream);
        }
        private async Task SendShortPacket(MinecraftStream packetStream)
        {
            int fullSize = (int)packetStream.Length + ZERO_VARLENGTH;
            await NetStream.WriteVarIntAsync(fullSize);
            await NetStream.WriteVarIntAsync(0);
            packetStream.Position = 0;
            packetStream.CopyTo(NetStream);
        }
    }


}

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.IO;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Parameters;
using System.Net.Sockets;

namespace MinecraftLibrary.API.Networking
{
    /// <summary>
    ///  <see cref="System.Net.Sockets.NetworkStream"/>
    /// </summary>
    public sealed class NetworkMinecraftStream : Stream
    {
        public NetworkStream NetStream { get;private set; }

        public bool EncryptionEnabled { get; private set; } = false;

        private Stream BaseStream;

        public override bool CanRead => BaseStream.CanRead;

        public override bool CanSeek => BaseStream.CanSeek;

        public override bool CanWrite => BaseStream.CanWrite;

        public override long Length => BaseStream.Length;

        public override long Position { get => BaseStream.Position; set => BaseStream.Position = value; }

        public NetworkMinecraftStream(NetworkStream networkStream)
        {
            ArgumentNullException.ThrowIfNull(networkStream, nameof(networkStream));

            NetStream = networkStream;
            this.BaseStream = NetStream;
        }

        public async Task<int> ReadVarIntAsync()
        {
            int numRead = 0;
            int result = 0;
            byte read;
            do
            {
                read = await this.ReadUnsignedByteAsync();

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

        public async Task WriteVarIntAsync(int value)
        {
            var unsigned = (uint)value;
            do
            {
                var temp = (byte)(unsigned & 127);

                unsigned >>= 7;

                if (unsigned != 0)
                    temp |= 128;

                await WriteUnsignedByteAsync(temp);
            }
            while (unsigned != 0);
        }



        #region Приватные
        private async Task<byte> ReadUnsignedByteAsync()
        {
            var buffer = new byte[1];
            await this.ReadAsync(buffer);
            return buffer[0];
        }
        private async Task WriteUnsignedByteAsync(byte value)
        {
            await WriteAsync(new[] { value });
        }
        private IBufferedCipher EncryptCipher { get; set; }
        private IBufferedCipher DecryptCipher { get; set; }
        #endregion
        /// <summary>
        /// Включает AES шифрование
        /// </summary>
        /// <param name="privatekey">Ключ</param>
        /// <exception cref="InvalidOperationException"></exception>
        public void SwitchEncryption(byte[] privatekey)
        {
            if (EncryptionEnabled)
            {
                throw new InvalidOperationException("Шифрование уже включено");
            }

            EncryptCipher = new BufferedBlockCipher(new CfbBlockCipher(new AesEngine(), 8));
            EncryptCipher.Init(true, new ParametersWithIV(new KeyParameter(privatekey), privatekey, 0, 16));

            DecryptCipher = new BufferedBlockCipher(new CfbBlockCipher(new AesEngine(), 8));
            DecryptCipher.Init(false, new ParametersWithIV(new KeyParameter(privatekey), privatekey, 0, 16));

            this.BaseStream = new CipherStream(NetStream, DecryptCipher, EncryptCipher);
        }

        public override void Flush()
        {
            BaseStream.Flush();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            return BaseStream.Read(buffer, offset, count);
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return BaseStream.Seek(offset, origin);
        }

        public override void SetLength(long value)
        {
            BaseStream.SetLength(value);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            BaseStream.Write(buffer, offset, count);
        }
    }
}

﻿using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.IO;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftLibrary.API.Networking.IO
{
    public class AesStream : MinecraftStream
    {
        private IBufferedCipher EncryptCipher { get; set; }
        private IBufferedCipher DecryptCipher { get; set; }
        public AesStream(byte[] key, CancellationTokenSource tokenSource) : base(tokenSource)
        {
            EncryptCipher = new BufferedBlockCipher(new CfbBlockCipher(new AesEngine(), 8));
            EncryptCipher.Init(true, new ParametersWithIV(new KeyParameter(key), key, 0, 16));

            DecryptCipher = new BufferedBlockCipher(new CfbBlockCipher(new AesEngine(), 8));
            DecryptCipher.Init(false, new ParametersWithIV(new KeyParameter(key), key, 0, 16));

            var oldStream = this.BaseStream;
            this.BaseStream = new CipherStream(oldStream, DecryptCipher, EncryptCipher);
        }

        public AesStream(Stream stream, byte[] key, CancellationTokenSource tokenSource) : base(stream,tokenSource)
        {
            EncryptCipher = new BufferedBlockCipher(new CfbBlockCipher(new AesEngine(), 8));
            EncryptCipher.Init(true, new ParametersWithIV(new KeyParameter(key), key, 0, 16));

            DecryptCipher = new BufferedBlockCipher(new CfbBlockCipher(new AesEngine(), 8));
            DecryptCipher.Init(false, new ParametersWithIV(new KeyParameter(key), key, 0, 16));

            var oldStream = this.BaseStream;
            this.BaseStream = new CipherStream(oldStream, DecryptCipher, EncryptCipher);
        }

        public AesStream(byte[] data, byte[] key,CancellationTokenSource tokenSource) : base(new MemoryStream(data),tokenSource)
        {
            EncryptCipher = new BufferedBlockCipher(new CfbBlockCipher(new AesEngine(), 8));
            EncryptCipher.Init(true, new ParametersWithIV(new KeyParameter(key), key, 0, 16));

            DecryptCipher = new BufferedBlockCipher(new CfbBlockCipher(new AesEngine(), 8));
            DecryptCipher.Init(false, new ParametersWithIV(new KeyParameter(key), key, 0, 16));

            var oldStream = this.BaseStream;
            this.BaseStream = new CipherStream(oldStream, DecryptCipher, EncryptCipher);
        }

        public override int ReadByte()
        {
            int value = BaseStream.ReadByte();

            if (value == -1)
                return value;

            return value;
        }

        public override int Read(byte[] buffer, int offset, int count) => BaseStream.Read(buffer, offset, count);

        public override async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken = default) => await this.BaseStream.ReadAsync(buffer, offset, count, cancellationToken);
        public override async Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken = default) => await BaseStream.WriteAsync(buffer, offset, count, cancellationToken);
        public override void Write(byte[] buffer, int offset, int count) => BaseStream.Write(buffer, offset, count);

        public override long Seek(long offset, SeekOrigin origin) => BaseStream.Seek(offset, origin);

        public override void SetLength(long value) => BaseStream.SetLength(value);

        public override void Close() => BaseStream.Close();
    }
}

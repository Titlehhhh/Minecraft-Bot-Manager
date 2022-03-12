﻿using Ionic.Zlib;
using MinecraftLibrary.API.IO;
using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Proxy;
using MinecraftLibrary.API.Protocol;
using System.Net.Sockets;

namespace MinecraftLibrary.Client.Networking;

public class TcpClientSession : IDisposable, ITcpClientSession
{
    private static readonly int ZERO_VARLENGTH = GetVarIntLength(0);
    public NetworkMinecraftStream NetStream { get; private set; }

    public string Host { get; set; }
    public int Port { get; set; }
    public ProxyInfo? Proxy { get; set; }


    public CancellationTokenSource Cancellation { get; private set; } = new();
    public int CompressionThreshold { get; set; } = 0;

    public IPacketProducer PacketFactory { get; set; }

    public event Action<ITcpClientSession>? Connected;
    public event EventHandler<DisconnectedEventArgs>? Disconnected;
    public event EventHandler<PacketReceivedEventArgs>? PacketReceived;
    public event EventHandler<PacketSendEventArgs>? PacketSend;
    public event EventHandler<PacketSentEventArgs>? PacketSent;

    private TcpClient tcpClient;

    public void Connect()
    {
        tcpClient = new TcpClient(Host, Port);
        NetStream = new NetworkMinecraftStream(tcpClient.GetStream());

        Connected?.Invoke(this);
        ReadLoop();
    }
    private async Task<(int, MinecraftStream)> ReadNextPacketAsync()
    {
        int len = await NetStream.ReadVarIntAsync();
        Console.WriteLine("len " + len);
        byte[] receivedata = new byte[len];
        await NetStream.ReadAsync(receivedata.AsMemory(0, len));
        int id = 0;

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
        id = mcs.ReadVarInt();
        return (id, mcs);
    }
    private async void ReadLoop()
    {
        try
        {
            while (tcpClient.Connected && !Cancellation.IsCancellationRequested)
            {
                (int id, MinecraftStream dataStream) = await ReadNextPacketAsync();
                Lazy<IPacket> packet = null;
                if (PacketFactory.TryGetInputPacket(id, out packet))
                {
                    packet.Value.Read(dataStream);
                    PacketReceived?.Invoke(this, new PacketReceivedEventArgs(id, packet.Value));
                }
            }
        }
        catch (SocketException e)
        {
            Disconnected?.Invoke(this, new DisconnectedEventArgs("Ошибка при чтении", e));
        }
        catch (Exception e)
        {

        }
        finally
        {
            Cancellation.Cancel();
        }
    }


    public void Disconnect()
    {
        Cancellation.Cancel();
    }
    public void SendPacket(IPacket packet, int id)
    {
        ArgumentNullException.ThrowIfNull(packet, nameof(packet));
        PacketSend?.Invoke(this, new PacketSendEventArgs(packet));
        if (CompressionThreshold > 0)
        {
            using (MinecraftStream packetStream = new MinecraftStream())
            {
                packetStream.WriteVarInt(id);
                packet.Write(packetStream);

                int to_Packetlength = (int)packetStream.Length;

                if (to_Packetlength >= CompressionThreshold)
                {
                    SendLongPacket(packetStream, to_Packetlength);
                }
                else
                {
                    SendShortPacket(packetStream);
                }
            }
        }
        else
        {
            SendPacketWithoutCompression(packet, id);
        }
        PacketSent?.Invoke(this, new PacketSentEventArgs(packet));

    }
    private async void SendPacketWithoutCompression(IPacket packet, int id)
    {
        Console.WriteLine("dis");
        using (MinecraftStream packetStream = new MinecraftStream())
        {
            packet.Write(packetStream);
            int Packetlength = (int)packetStream.Length;

            NetStream.Lock.Wait();
            await NetStream.WriteVarIntAsync(GetVarIntLength(id) + Packetlength);
            await NetStream.WriteVarIntAsync(id);
            packetStream.Position = 0;
            packetStream.CopyTo(NetStream);
            NetStream.Lock.Release();
        }
    }

    private async void SendLongPacket(MinecraftStream packetStream, int to_Packetlength)
    {

        using (MemoryStream memstream = new MemoryStream())
        {
            using (ZlibStream stream = new ZlibStream(memstream, CompressionMode.Compress))
            {
                packetStream.CopyTo(stream);
            }
            packetStream.BaseStream = memstream;
        }
        int fullSize = (int)packetStream.Length + GetVarIntLength(to_Packetlength);
        await NetStream.WriteVarIntAsync(fullSize);
        await NetStream.WriteVarIntAsync(to_Packetlength);
        packetStream.Position = 0;
        packetStream.CopyTo(NetStream);
    }
    private async void SendShortPacket(MinecraftStream packetStream)
    {
        Console.WriteLine("short");
        int fullSize = (int)packetStream.Length + ZERO_VARLENGTH;
        await NetStream.WriteVarIntAsync(fullSize);
        await NetStream.WriteVarIntAsync(0);
        packetStream.Position = 0;
        packetStream.CopyTo(NetStream);
    }


    public void SwitchEncryption(byte[] key)
    {
        NetStream.SwitchEncryption(key);
    }
    public void Dispose()
    {
        Cancellation.Dispose();
        tcpClient?.Dispose();
        NetStream?.Dispose();

        Connected = null;
        Disconnected = null;

        tcpClient = null;
        NetStream = null;
        Cancellation = null;

        GC.SuppressFinalize(this);
    }

    private static int GetVarIntLength(int val)
    {
        int amount = 0;
        do
        {
            val >>= 7;
            amount++;
        } while (val != 0);

        return amount;
    }

    public void SendPacket(IPacket packet)
    {
        if (PacketFactory.TryGetOutputId(packet.GetType(), out int id))
        {
            this.SendPacket(packet, id);
        }
    }

    ~TcpClientSession()
    {
        Dispose();
    }
}


using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Events;

namespace MinecraftLibrary.API.Networking
{
    public interface IPacketProtocol
    {
        #region Методы       
        void SendPacket(IPacket packet);
        void SendPacket(IPacket packet, int id);

        void RegisterPacketInput(int id, Type t);
        void RegisterPacketOutput(int id, Type t);
        void EnabledEncryption(byte[] key);
        #endregion
        #region Функции
        bool UnRegisterPacketInput(int id);
        bool UnRegisterPacketOutput(Type t);
        #endregion
        #region Свойства
        int CompressionThreshold { get; set; }
        bool IsEncryption { get; }

        string Host { get; }
        int Port { get; }

        Dictionary<int, Type> RegisteredInputPakets { get; }
        Dictionary<Type, int> RegisteredOutputPakets { get; }
        #endregion
        #region События
        event EventHandler<PacketProcessedEventArgs> PacketProcessedEvent;
        event EventHandler<PacketSendEventArgs> PacketSendEvent;
        event EventHandler<PacketSentEventArgs> PacketSentEvent;
        #endregion
    }

}

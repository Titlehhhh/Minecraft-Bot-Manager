namespace MinecraftLibrary.API.Protocol
{
    public class UnRegisterPacketEventArgs : EventArgs
    {
        public Type Packet { get; private set; }

        public UnRegisterPacketEventArgs(Type packet)
        {
            Packet = packet;
        }
    }
}

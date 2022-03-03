namespace MinecraftLibrary.API.Protocol
{
    public class RegisterPacketEventArgs : EventArgs
    {
        public Type Packet { get; private set; }

        public RegisterPacketEventArgs(Type packet)
        {
            Packet = packet;
        }
    }
}

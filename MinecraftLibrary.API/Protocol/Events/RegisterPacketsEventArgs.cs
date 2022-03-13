using MinecraftLibrary.API.Types.Chat;
using MinecraftLibrary.Geometry;

namespace MinecraftLibrary.API.Protocol
{
    public class RegisterPacketsEventArgs : EventArgs
    {
        public IList<Type> Packets { get; private set; }

        public RegisterPacketsEventArgs(IList<Type> packets)
        {
            Packets = packets;
        }
    }

    public class ServerChatEventArgs : EventArgs
    {
        public ChatMessage Message { get; private set; }

        public ServerChatEventArgs(ChatMessage message)
        {
            Message = message;
        }
    }
    public class ServerUpdateLocationEventArgs : EventArgs
    {
        public Point3 NewLocation { get; private set; }
        public bool IsGround { get; private set; }

        public ServerUpdateLocationEventArgs(Point3 newLocation, bool isGround)
        {
            NewLocation = newLocation;
            IsGround = isGround;
        }
    }
    public class ServerUpdateRotationEventArgs : EventArgs
    {
        public Rotation Rotation { get; private set; }
        public bool IsGround { get; private set; }

        public ServerUpdateRotationEventArgs(Rotation rotation, bool isGround)
        {
            Rotation = rotation;
            IsGround = isGround;
        }
    }
    public class ServerUpdateRotationPositonEventArgs : EventArgs
    {
        public Rotation Rotation { get; private set; }
        public Point3 Position { get; private set; }
        public bool IsGround { get; private set; }

        public ServerUpdateRotationPositonEventArgs(Rotation rotation, Point3 position, bool isGround)
        {
            Rotation = rotation;
            Position = position;
            IsGround = isGround;
        }
    }


}

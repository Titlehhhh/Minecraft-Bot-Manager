using MinecraftLibrary.API.Inventory;
using MinecraftLibrary.API.Networking;
using MinecraftLibrary.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftLibrary.API
{
    public interface IMinecraftClient 
    {
        string Nickname { get; set; }
        string Host { get; set; }
        ushort Port { get; set; }
        ITcpClientSession Session { get; }

        ProtocolState SubProtocol { get; }

        IContainer CurrentContainer { get; }

        //IContainer Inventory { get; }

        Point3 Location { get; }
        Point3_Int ChunkLocation { get; }
        Point3_Int CnunkBlockLocation { get; }


        void Connect();
        void Disconnect();

        void SendChat(string msg);

        void SendLocation(bool isGround);        
        void SendLocation(Point3 position, bool isGround);
        void SendLocation(Vector3 vector, bool isGround);

        void SendLocation(Point3 position,float yaw,float pitch, bool isGround);
        void SendLocation(Vector3 body,Vector3 head, bool isGround);

        void LookHead(float yaw, float pitch);
        void LookHead(Point3 targetBlock);
        void LookHead(Vector3 vector);

        event EventHandler<ProtocolClientDisconnectEventArg> Disconnected;        
    }
    
}

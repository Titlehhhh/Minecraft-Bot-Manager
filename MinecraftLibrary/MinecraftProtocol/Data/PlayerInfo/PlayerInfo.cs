using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftLibrary.MinecraftProtocol.Data.PlayerInfo
{
    public abstract class PlayerInfo
    {
        public Guid UUID { get; private set; }
        public PlayerInfo(Guid uuid)
        {
            UUID = uuid;
        }
    }
    public class PlayerJoin : GamemodeUpdate
    {
        
        public string Nickname { get; private set; }
        public PlayerJoin(string nick,int gamemode,Guid uuid) : base(gamemode,uuid)
        {            
            Nickname = nick;
        }
    }
    public class GamemodeUpdate : PlayerInfo
    {
        public int Gamemode { get; private set; }
        
        public GamemodeUpdate( int gamemode, Guid uuid) : base(uuid)
        {
            Gamemode = gamemode;
            
        }
    }
    public class UpdateDisplayname : PlayerInfo
    {
        public string Name { get; private set; }
        public UpdateDisplayname(string name,Guid uuid) : base(uuid)
        {
            Name = name;
        }
    }
    public class UpdateLatency : PlayerInfo
    {
        public int Latency { get; private set; }
        public UpdateLatency(int latency, Guid uuid) : base(uuid)
        {
            Latency = latency;
        }
    }
    public class PlayerLeave : PlayerInfo
    {
        public PlayerLeave(Guid uuid) : base(uuid)
        {
        }
    }
}

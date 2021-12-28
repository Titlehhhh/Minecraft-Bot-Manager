using MinecraftLibrary.MinecraftProtocol.Data.PlayerInfo;
using MinecraftProtocol.IO;
using MinecraftProtocol.Packets;
using System;
using System.Collections.Generic;

namespace MinecraftLibrary.MinecraftProtocol.Packets.Server.Game
{
    public class ServerPlayerInfoPacket : ServerPacket
    {
        public Dictionary<Guid,PlayerInfo> PlayerInfos { get; private set; }
        public void Read(NetInput input, int version)
        {
            int action = input.ReadNextVarInt();
            int numActions = input.ReadNextVarInt();
            PlayerInfos = new Dictionary<Guid, PlayerInfo>(numActions);
            for (int i = 0; i < numActions; i++)
            {
                Guid uuid = input.ReadNextUUID();
                switch (action)
                {
                    case 0x00: //Player Join
                        string name = input.ReadNextString();
                        int propNum = input.ReadNextVarInt();
                        for (int p = 0; p < propNum; p++)
                        {
                            string key = input.ReadNextString();
                            string val = input.ReadNextString();
                            if (input.ReadNextBool())
                                input.ReadNextString();
                        }
                        int gamemode = input.ReadNextVarInt();
                        input.ReadNextVarInt();
                        if (input.ReadNextBool())
                            input.ReadNextString();                       
                        PlayerInfos[uuid] = new PlayerJoin(name, gamemode, uuid);
                        break;
                    case 0x01: //Update gamemode
                        PlayerInfos[uuid] = new GamemodeUpdate(input.ReadNextVarInt(), uuid);
                        break;
                    case 0x02: //Update latency
                        int latency = input.ReadNextVarInt();
                        PlayerInfos[uuid] = new UpdateLatency(latency,uuid);
                        break;
                    case 0x03: //Update display name
                        if (input.ReadNextBool())
                            PlayerInfos[uuid] = new UpdateDisplayname(input.ReadNextString(), uuid);
                        break;
                    case 0x04: //Player Leave
                        PlayerInfos[uuid] = new PlayerLeave(uuid);
                        break;
                    default:
                        //Unknown player list item type
                        break;
                }
            }
        }
    }


}

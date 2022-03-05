﻿using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Protocol;
using System;
using System.Reflection;
using System.Reflection.Emit;

namespace ProtocolLib754
{
    public sealed class PacketProvider754 : IPacketProvider
    {
        private static readonly IPacketProviderClient CLIENTPACKETS;
        private static readonly IPacketProviderServer SERVERPACKETS;

        static PacketProvider754()
        {
            try
            {
                Type tpacket = typeof(IPacket);
                var list = new List<Type>();
                foreach (var item in Assembly.GetExecutingAssembly().GetTypes())
                {
                    if (tpacket.IsAssignableFrom(item))
                    {
                        list.Add(item);
                    }
                }

                CLIENTPACKETS = new DefaultPacketProviderClient();
                SERVERPACKETS = new DefaultPacketProviderServer();

                foreach (var item in list)
                {
                    PacketInfoAttribute packetInfo = item.GetCustomAttribute<PacketInfoAttribute>();
                    if (packetInfo.Side == MinecraftLibrary.API.PacketSide.Client)
                    {


                        switch (packetInfo.Category)
                        {
                            case MinecraftLibrary.API.PacketCategory.Status:
                                CLIENTPACKETS.StatusPackets.Add(packetInfo.ID, item);
                                break;
                            case MinecraftLibrary.API.PacketCategory.HandShake:
                                CLIENTPACKETS.HandShakePackets.Add(packetInfo.ID, item);
                                break;
                            case MinecraftLibrary.API.PacketCategory.Login:
                                CLIENTPACKETS.LoginPackets.Add(packetInfo.ID, item);
                                break;
                            case MinecraftLibrary.API.PacketCategory.Game:
                                CLIENTPACKETS.GamePackets.Add(packetInfo.ID, item);
                                break;
                        }

                    }
                    else
                    {


                        switch (packetInfo.Category)
                        {
                            case MinecraftLibrary.API.PacketCategory.Status:
                                SERVERPACKETS.StatusPackets.Add(packetInfo.ID, item);
                                break;
                            case MinecraftLibrary.API.PacketCategory.Login:
                                SERVERPACKETS.LoginPackets.Add(packetInfo.ID, item);
                                break;
                            case MinecraftLibrary.API.PacketCategory.Game:
                                SERVERPACKETS.GamePackets.Add(packetInfo.ID, item);
                                break;
                        }

                    }
                }
            } catch(Exception e)
            {
                using(StreamWriter sw = new StreamWriter("error.txt"))
                {
                    sw.WriteLine(e.StackTrace);
                }
            }
        }

        public IPacketProviderClient ClientPackets => CLIENTPACKETS;

        public IPacketProviderServer ServerPackets => SERVERPACKETS;

        public int TargetVersion => 754;
    }
}

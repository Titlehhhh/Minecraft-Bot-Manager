
using MinecraftLibrary.Data.Inventory;
using MinecraftLibrary.Geometri;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace MinecraftLibrary.Data
{
    /// <summary>
    /// Represents an entity evolving into a Minecraft world
    /// </summary>
    public class Entity : System.ComponentModel.INotifyPropertyChanged
    {
        public Vector3 Velocity;
        /// <summary>
        /// ID of the entity on the Minecraft server
        /// </summary>
        private int iD;

        /// <summary>
        /// UUID of the entity if it is a player.
        /// </summary>
        public Guid UUID;

        /// <summary>
        /// Nickname of the entity if it is a player.
        /// </summary>
        public string Name;
        
        /// <summary>
        /// CustomName of the entity.
        /// </summary>
        public string CustomNameJson;
        
        /// <summary>
        /// IsCustomNameVisible of the entity.
        /// </summary>
        public bool IsCustomNameVisible;

        /// <summary>
        /// CustomName of the entity.
        /// </summary>
        public string CustomName;
        
        /// <summary>
        /// Latency of the entity if it is a player.
        /// </summary>
        public int Latency;

        /// <summary>
        /// Entity type
        /// </summary>
        public EntityType Type;

        /// <summary>
        /// Entity location in the Minecraft world
        /// </summary>
        public Location Location;

        /// <summary>
        /// Entity head yaw
        /// </summary>
        /// <remarks>Untested</remarks>
        public float Yaw = 0;

        /// <summary>
        /// Entity head pitch
        /// </summary>
        /// <remarks>Untested</remarks>
        public float Pitch = 0;

        /// <summary>
        /// Health of the entity
        /// </summary>
        public float Health;
        
        /// <summary>
        /// Item of the entity if ItemFrame or Item
        /// </summary>
        public Item Item;
        
        /// <summary>
        /// Entity pose in the Minecraft world
        /// </summary>
        public EntityPose Pose;
        
        /// <summary>
        /// Entity metadata
        /// </summary>
        public Dictionary<int, object> Metadata;

        /// <summary>
        /// Entity equipment
        /// </summary>
        public Dictionary<int, Item> Equipment;

        public event PropertyChangedEventHandler PropertyChanged;

        public int ID
        {
            get
            {
                return iD;
            }

            set
            {
                iD = value;
            }
        }

        /// <summary>
        /// Create a new entity based on Entity ID, Entity Type and location
        /// </summary>
        /// <param name="ID">Entity ID</param>
        /// <param name="type">Entity Type Enum</param>
        /// <param name="location">Entity location</param>
        public Entity(int ID, EntityType type, Location location)
        {
            this.ID = ID;
            this.Type = type;
            this.Location = location;
            this.Health = 1.0f;
            this.Equipment = new Dictionary<int, Item>();
            this.Item = new Item(ItemType.Air, 0, null);
        }

        /// <summary>
        /// Create a new entity based on Entity ID, Entity Type and location
        /// </summary>
        /// <param name="ID">Entity ID</param>
        /// <param name="type">Entity Type Enum</param>
        /// <param name="location">Entity location</param>
        public Entity(int ID, EntityType type, Location location, float yaw, float pitch)
        {
            this.ID = ID;
            this.Type = type;
            this.Location = location;
            this.Health = 1.0f;
            this.Equipment = new Dictionary<int, Item>();
            this.Item = new Item(ItemType.Air, 0, null);
            this.Yaw = yaw;
            this.Pitch = pitch;
        }

        /// <summary>
        /// Create a new entity based on Entity ID, Entity Type, location, name and UUID
        /// </summary>
        /// <param name="ID">Entity ID</param>
        /// <param name="type">Entity Type Enum</param>
        /// <param name="location">Entity location</param>
        /// <param name="uuid">Player uuid</param>
        /// <param name="name">Player name</param>
        public Entity(int ID, EntityType type, Location location, Guid uuid, string name)
        {
            this.ID = ID;
            this.Type = type;
            this.Location = location;
            this.UUID = uuid;
            this.Name = name;
            this.Health = 1.0f;
            this.Equipment = new Dictionary<int, Item>();
            this.Item = new Item(ItemType.Air, 0, null);
        }
        public Entity(int ID, EntityType type, Location location,float yaw,float pitch, Guid uuid, string name)
        {
            this.ID = ID;
            this.Type = type;
            this.Location = location;
            this.UUID = uuid;
            this.Name = name;
            this.Yaw = yaw;
            this.Pitch = pitch;
            this.Health = 1.0f;
            this.Equipment = new Dictionary<int, Item>();
            this.Item = new Item(ItemType.Air, 0, null);
        }
        private void OnRaisePropertyChanged([CallerMemberName]string name = "")
        {            
           // PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}

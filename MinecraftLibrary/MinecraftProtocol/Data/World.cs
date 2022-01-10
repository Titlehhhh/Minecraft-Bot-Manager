using MinecraftLibrary.Geometri;
using MinecraftLibrary.MinecraftProtocol.Data.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinecraftLibrary.Data
{
    /// <summary>
    /// Represents a Minecraft World
    /// </summary>
    public class World
    {

        /// <summary>
        /// The chunks contained into the Minecraft world
        /// </summary>
        private Dictionary<long, ChunkColumn> chunks = new Dictionary<long, ChunkColumn>();

        /// <summary>
        /// Read, set or unload the specified chunk column
        /// </summary>
        /// <param name="chunkX">ChunkColumn X</param>
        /// <param name="chunkY">ChunkColumn Y</param>
        /// <returns>chunk at the given location</returns>
        /// 
        public bool IsValidPosition(Coordinates3D position)
        {
            return position.Y >= 0 && position.Y <256;
        }

        public BoundingBox? GetBox(Coordinates3D coordinates)
        {
            Block block = GetBlock(new Point3(coordinates.X, coordinates.Y, coordinates.Z));
            if(block.Type == Material.Air)
            {
                return null;
            }
            else
            {
                return new BoundingBox(Vector3.Zero, Vector3.One);
            }
        }
        public ChunkColumn this[int chunkX, int chunkZ]
        {
            get
            {
                long key = TwoIntToLong(chunkX, chunkZ);
                if (chunks.ContainsKey(key))
                    return chunks[key];                
                return null;
            }
            set
            {
                long key = TwoIntToLong(chunkX, chunkZ);
                chunks[key] = value;
            }
        }

        /// <summary>
        /// Get chunk column at the specified location
        /// </summary>
        /// <param name="location">Location to retrieve chunk column</param>
        /// <returns>The chunk column</returns>
        public ChunkColumn GetChunkColumn(Point3 location)
        {
            return this[location.ChunkX, location.ChunkZ];
        }

        /// <summary>
        /// Get block at the specified location
        /// </summary>
        /// <param name="location">Location to retrieve block from</param>
        /// <returns>Block at specified location or Air if the location is not loaded</returns>
        public Block GetBlock(Point3 location)
        {
            if (location.Y > 255 || location.Y<0)
               return new Block(0, location);
                
            ChunkColumn column = GetChunkColumn(location);
            if (column != null)
            {
                Chunk chunk = column.GetChunk(location);
                if (chunk != null)
                    return chunk.GetBlock(location);
            }
            return new Block(0,location); //Air
        }

        /// <summary>
        /// Look for a block around the specified location
        /// </summary>
        /// <param name="from">Start location</param>
        /// <param name="block">Block type</param>
        /// <param name="radius">Search radius - larger is slower: O^3 complexity</param>
        /// <returns>Block matching the specified block type</returns>
        public List<Point3> FindBlock(Point3 from, Material block, int radius)
        {
            return FindBlock(from, block, radius, radius, radius);
        }

        /// <summary>
        /// Look for a block around the specified location
        /// </summary>
        /// <param name="from">Start location</param>
        /// <param name="block">Block type</param>
        /// <param name="radiusx">Search radius on the X axis</param>
        /// <param name="radiusy">Search radius on the Y axis</param>
        /// <param name="radiusz">Search radius on the Z axis</param>
        /// <returns>Block matching the specified block type</returns>
        public List<Point3> FindBlock(Point3 from, Material block, int radiusx, int radiusy, int radiusz)
        {
            Point3 minPoint = new Point3(from.X - radiusx, from.Y - radiusy, from.Z - radiusz);
            Point3 maxPoint = new Point3(from.X + radiusx, from.Y + radiusy, from.Z + radiusz);
            List<Point3> list = new List<Point3> { };
            for (double x = minPoint.X; x <= maxPoint.X; x++)
            {
                for (double y = minPoint.Y; y <= maxPoint.Y; y++)
                {
                    for (double z = minPoint.Z; z <= maxPoint.Z; z++)
                    {
                        Point3 doneloc = new Point3(x, y, z);
                        Block doneblock = GetBlock(doneloc);
                        Material blockType = GetBlock(doneloc).Type;
                        if (blockType == block)
                        {
                            list.Add(doneloc);
                        }
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// Set block at the specified location
        /// </summary>
        /// <param name="location">Location to set block to</param>
        /// <param name="block">Block to set</param>
        public void SetBlock(Point3 location, Block block)
        {
            ChunkColumn column = this[location.ChunkX, location.ChunkZ];
            if (column != null)
            {
                Chunk chunk = column[location.ChunkY];
                if (chunk == null)
                    column[location.ChunkY] = chunk = new Chunk();
                chunk[location.ChunkBlockX, location.ChunkBlockY, location.ChunkBlockZ] = block;
            }
        }

        /// <summary>
        /// Clear all terrain data from the world
        /// </summary>
        public void Clear()
        {
            chunks = new Dictionary<long, ChunkColumn>();
        }

        /// <summary>
        /// Get the location of block of the entity is looking
        /// </summary>
        /// <param name="location">Location of the entity</param>
        /// <param name="yaw">Yaw of the entity</param>
        /// <param name="pitch">Pitch of the entity</param>
        /// <returns>Location of the block or empty Location if no block was found</returns>
        public Point3 GetLookingBlockLocation(Point3 location, double yaw, double pitch)
        {
            double rotX = (Math.PI / 180) * yaw;
            double rotY = (Math.PI / 180) * pitch;
            double x = -Math.Cos(rotY) * Math.Sin(rotX);
            double y = -Math.Sin(rotY);
            double z = Math.Cos(rotY) * Math.Cos(rotX);
            Point3 vector = new Point3(x, y, z);
            for (int i = 0; i < 5; i++)
            {
                Point3 newVector = vector * i;
                Point3 blockLocation = location.EyesLocation() + new Point3(newVector.X, newVector.Y, newVector.Z);
                blockLocation.X = Math.Floor(blockLocation.X);
                blockLocation.Y = Math.Floor(blockLocation.Y);
                blockLocation.Z = Math.Floor(blockLocation.Z);
                Block b = GetBlock(blockLocation);
                if (b.Type != Material.Air)
                {
                    return blockLocation;
                }
            }
            return new Point3();
        }
        public static long TwoIntToLong(int val1,int val2)
        {
            long res = val1;
            res = res << 32;
            res = res | (long)(uint)val2;
            return res;
        }
    }
}

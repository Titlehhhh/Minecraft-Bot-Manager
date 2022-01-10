﻿using MinecraftLibrary.Geometri;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinecraftLibrary.Data
{
    /// <summary>
    /// Represent a column of chunks of terrain in a Minecraft world
    /// </summary>
    public class ChunkColumn
    {
        public int ChunkX { get; set; }
        public int ChunkZ { get; set; }

        public const int ColumnSize = 16;

        /// <summary>
        /// Blocks contained into the chunk
        /// </summary>
        private readonly Chunk[] chunks = new Chunk[ColumnSize];

        /// <summary>
        /// Get or set the specified chunk column
        /// </summary>
        /// <param name="chunkX">ChunkColumn X</param>
        /// <param name="chunkY">ChunkColumn Y</param>
        /// <returns>chunk at the given location</returns>
        public Chunk this[int chunkY]
        {
            get
            {
                return chunks[chunkY];
            }
            set
            {
                chunks[chunkY] = value;
            }
        }

        /// <summary>
        /// Get chunk at the specified location
        /// </summary>
        /// <param name="location">Location, a modulo will be applied</param>
        /// <returns>The chunk, or null if not loaded</returns>
        public Chunk GetChunk(Point3 location)
        {
            if (location.Y >= 0 && location.Y <= 255)
            {
                int c = (int)location.Y;
                int b = c >> 4;
                return chunks[b];

            }
            else
            {
                return null;
            }

        }
    }
}

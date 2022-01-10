using MinecraftLibrary.MinecraftModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using MinecraftLibrary.Interfaces;
using MinecraftLibrary.Data;
using MinecraftLibrary;
using System.Text.RegularExpressions;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;
using MinecraftLibrary.Geometri;

namespace ModulesLibrary
{
    

    public interface IModule
    {
        void UpdatePos(Point3 pos, bool isGround);

    }

    public class Player
    {
        public Vector3 Velocity { get; set; }
        public Vector3 Position { get; set; }
        public Size HitBox { get; set; }

        public float TerminalVelocity => 78.4f;
        public Player()
        {

        }
        public float AccelerationDueToGravity => 1.6f;

        public float Drag => 0.40f;
        public float Yaw { get; set; }
        public float Pitch { get; set; }
        public const double Width = 0.6;
        public const double Height = 1.62;
        public const double Depth = 0.6;
        public BoundingBox BoundingBox
        {
            get
            {
                var pos = Position - new Vector3(Width / 2, 0, Depth / 2);
                return new BoundingBox(pos, pos + Size);
            }
        }
        public void TerrainCollision(Vector3 collisionPoint, Vector3 collisionDirection)
        {
            // This space intentionally left blank
        }

        public Size Size
        {
            get { return new Size(Width, Height, Depth); }
        }
    }



}

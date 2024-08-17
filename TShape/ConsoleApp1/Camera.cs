using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace TShape
{
    public class Camera
    {


        Vector3 front = -Vector3.UnitZ;
        Vector3 up = Vector3.UnitY;
        Vector3 right = Vector3.UnitX;

        private float pitch;
        private float yaw=-MathHelper.PiOver2;


        public Vector3 Position { get; set; }
        public Vector3 Front => front;
        public Vector3 Up => up;
        public Vector3 Right => right;

        public Camera(Vector3 position)
        {
            Position = position;
        }
        public Matrix4 GetViewMatrix()
        {
            return Matrix4.LookAt(Position, Position + front, up);
        }
        
        public float Yaw
        {
            get => MathHelper.RadiansToDegrees(yaw);
            set
            {
                yaw = MathHelper.DegreesToRadians(value);
                UpdateVectors();
            }
        }

        public float Pitch
        {
            get => MathHelper.RadiansToDegrees(pitch);
            set
            {
                
                var angle = MathHelper.Clamp(value, -89f, 89f);
                pitch = MathHelper.DegreesToRadians(angle);
                UpdateVectors();
            }
        }

        private void UpdateVectors()
        {
            front.X = MathF.Cos(pitch) * MathF.Cos(yaw);
            front.Y = MathF.Sin(pitch);
            front.Z = MathF.Cos(pitch) * MathF.Sin(yaw);

            front = Vector3.Normalize(front);

            right = Vector3.Normalize(Vector3.Cross(front, Vector3.UnitY));
            up = Vector3.Normalize(Vector3.Cross(right, front));
        }
    }
}

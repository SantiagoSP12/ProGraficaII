using Newtonsoft.Json;
using OpenTK.Mathematics;
using System.Runtime.Serialization;

namespace TShape
{
    [JsonObjectAttribute]
    public class Objeto
    {
        public Dictionary<string, Parte> partes=new();
        public float posX, posY, posZ = 0.0f;
        private Matrix4 Traslation, Rotation, Scalation;

        public Objeto(float posX = 0.0f, float posY = 0.0f, float posZ = 0.0f)
        {
            this.posX = posX; this.posY = posY; this.posZ = posZ;
            GenMatrix(new StreamingContext());
        }
        [OnDeserialized]
        private void GenMatrix(StreamingContext context)
        {
            this.Traslation = Matrix4.CreateTranslation(posX, posY, posZ);
            this.Rotation = this.Scalation = Matrix4.Identity;
        }
        public void Draw(Shader shader, Matrix4 model)
        {
            foreach (Parte parte in partes.Values)
            {
                parte.Draw(shader, Scalation * Rotation * Traslation * model);
            }
        }
        public void setPos(float x = 0.0f, float y = 0.0f, float z = 0.0f)
        {
            Traslation = Matrix4.CreateTranslation(x, y, z);
        }
        public void scale(float x = 1.0f, float y = 1.0f, float z = 1.0f)
        {
            Scalation = Scalation * Matrix4.CreateScale(x, y, z);
        }

        public void move(float x = 0.0f, float y = 0.0f, float z = 0.0f)
        {
            Traslation = Traslation * Matrix4.CreateTranslation(x, y, z);
        }

        public void rotate(float x = 0.0f, float y = 0.0f, float z = 0.0f)
        {
            Rotation = Rotation
                     * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(x))
                     * Matrix4.CreateRotationY(MathHelper.DegreesToRadians(y))
                     * Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(z));
        }
    }
}

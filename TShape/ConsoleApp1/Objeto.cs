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
        private Matrix4 pos;

        public Objeto(float posX = 0.0f, float posY = 0.0f, float posZ = 0.0f)
        {
            this.posX = posX; this.posY = posY; this.posZ = posZ;
            GenMatrix(new StreamingContext());
        }
        [OnDeserialized]
        private void GenMatrix(StreamingContext context) { pos = Matrix4.CreateTranslation(posX, posY, posZ); }
        public void Draw(Shader shader, Matrix4 model)
        {
            foreach (Parte parte in partes.Values)
            {
                parte.Draw(shader, pos*model);
            }
        }
        public void scale(float x = 1.0f, float y = 1.0f, float z = 1.0f)
        {
            pos = Matrix4.CreateScale(x, y, z) * pos;
        }

        public void move(float x=0.0f, float y=0.0f, float z = 0.0f)
        {
            pos=Matrix4.CreateTranslation(x, y, z); 
        }
    }
}

using Newtonsoft.Json;
using OpenTK.Mathematics;
using System.Runtime.Serialization;

namespace TShape
{
    [JsonObjectAttribute]
    public class Parte
    {
        public Dictionary<string, Poligono> poligonos=new();
        public float posX, posY, posZ = 0.0f;
        private Matrix4 pos;

        public Parte(float posX = 0.0f, float posY = 0.0f, float posZ = 0.0f)
        {
            this.posX= posX; this.posY= posY; this.posZ= posZ;
            GenMatrix(new StreamingContext());
        }
        [OnDeserialized]
        private void GenMatrix(StreamingContext context)
        {
            pos = Matrix4.CreateTranslation(posX, posY, posZ);
        }
        public void Draw(Shader shader, Matrix4 model)
        {
            foreach (Poligono poligono in poligonos.Values)
            {
                poligono.Draw(shader, pos*model);
            }
        }
    }
}

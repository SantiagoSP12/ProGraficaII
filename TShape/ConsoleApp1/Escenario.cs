using OpenTK.Mathematics;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace TShape
{
    [JsonObjectAttribute]
    public class Escenario
    {
        public Dictionary<string, Objeto> objetos=new();
        public float posX, posY, posZ = 0.0f;
        private float CMX, CMY, CMZ = 0.0f;
        private Matrix4 model;


        public Escenario(float posX = 0.0f, float posY = 0.0f, float posZ = 0.0f)
        {
            this.posX = posX; this.posY = posY; this.posZ = posZ;
            GenMatrix(new StreamingContext());
        }
        [OnDeserialized]
        private void GenMatrix (StreamingContext context) { model = Matrix4.CreateTranslation(posX, posY, posZ); }
        public void Draw(Shader shader)
        {
            foreach (Objeto objeto in objetos.Values)
            {
                objeto.Draw(shader, model);
            }
        }
    }
}

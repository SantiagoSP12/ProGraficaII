using OpenTK.Mathematics;
using Newtonsoft.Json;

namespace TShape
{
    [JsonObjectAttribute]
    public class Escenario:InterfazObjeto
    {
        public Dictionary<string, Objeto> objetos=new();
        public float posX, posY, posZ = 0.0f;
        public Matrix4 CM;

        Matrix4 InterfazObjeto.CM => this.CM;

        //preparar matrices, no usarlas en la clase directamente
        public Escenario(float posX = 0.0f, float posY = 0.0f, float posZ = 0.0f)
        {
            this.posX = posX; this.posY = posY; this.posZ = posZ;
            CM = Matrix4.CreateTranslation(posX, posY, posZ);
        }

        public void Draw(Shader shader)
        {
            foreach (Objeto objeto in objetos.Values)
            {
                objeto.Draw(shader);
            }
        }
        public void scale(float x = 1.0f, float y = 1.0f, float z = 1.0f)
        {
            foreach (Objeto objeto in objetos.Values)
            {
                objeto.scale(x, y, z);
            }
        }

        public void move(float x = 0.0f, float y = 0.0f, float z = 0.0f)
        {
            foreach (Objeto objeto in objetos.Values)
            {
                objeto.move(x,y,z);
            }
        }

        public void rotate(Matrix4 CM, float x = 0.0f, float y = 0.0f, float z = 0.0f)
        {
            foreach (Objeto objeto in objetos.Values)
            {
                objeto.rotate(CM,x, y, z);
            }
        }

        public void setPos(float x = 0, float y = 0, float z = 0)
        {
            foreach (Objeto objeto in objetos.Values)
            {
                objeto.setPos(x, y, z);
            }
        }

        
    }
}

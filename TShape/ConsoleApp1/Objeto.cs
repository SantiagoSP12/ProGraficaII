using Newtonsoft.Json;
using OpenTK.Mathematics;

namespace TShape
{
    [JsonObjectAttribute]
    public class Objeto:InterfazObjeto
    {
        public Dictionary<string, Parte> partes=new();
        public float posX, posY, posZ = 0.0f;
        public Matrix4 CM;

        Matrix4 InterfazObjeto.CM => this.CM;
        public Objeto(float posX = 0.0f, float posY = 0.0f, float posZ = 0.0f)
        {
            this.posX = posX; this.posY = posY; this.posZ = posZ;
            CM = Matrix4.CreateTranslation(posX, posY, posZ);
        }
        public void Draw(Shader shader)
        {
            foreach (Parte parte in partes.Values)
            {
                parte.Draw(shader);
            }
        }
        public void setPos(float x = 0.0f, float y = 0.0f, float z = 0.0f)
        {
            foreach (Parte parte in partes.Values)
            {
                parte.setPos(this.posX+x, this.posY+y, this.posZ+z);
            }
        }
        public void scale(float x = 1.0f, float y = 1.0f, float z = 1.0f)
        {
            foreach (Parte parte in partes.Values)
            {
                parte.scale(x, y, z);
            }
        }

        public void move(float x = 0.0f, float y = 0.0f, float z = 0.0f)
        {
            foreach (Parte parte in partes.Values)
            {
                parte.move(x,y,z);
            }
        }

        public void rotate(Matrix4 CM, float x = 0.0f, float y = 0.0f, float z = 0.0f)
        {
            foreach (Parte parte in partes.Values)
            {
                parte.rotate(CM, x, y, z);
            }
        }
    }
}

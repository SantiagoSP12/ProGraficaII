using Newtonsoft.Json;
using OpenTK.Mathematics;

namespace TShape
{
    [JsonObjectAttribute]
    public class Parte:InterfazObjeto
    {
        public Dictionary<string, Poligono> poligonos=new();
        public float posX, posY, posZ = 0.0f;
        public Matrix4 CM;

        Matrix4 InterfazObjeto.CM => this.CM;
        public Parte(float posX = 0.0f, float posY = 0.0f, float posZ = 0.0f)
        {
            this.posX= posX; this.posY= posY; this.posZ= posZ;
            CM = Matrix4.CreateTranslation(posX, posY, posZ);
        }
        public void Draw(Shader shader)
        {
            foreach (Poligono poligono in poligonos.Values)
            {
                poligono.Draw(shader);
            }
        }
        public void scale(float x = 1.0f, float y = 1.0f, float z = 1.0f)
        {
            foreach (Poligono poligono in poligonos.Values)
            {
                poligono.scale(x, y, z);
            }
        }

        public void move(float x = 0.0f, float y = 0.0f, float z = 0.0f)
        {
            foreach (Poligono poligono in poligonos.Values)
            {
                poligono.move(x,y,z);
            }
        }

        public void rotate(Matrix4 CM, float x = 0.0f, float y = 0.0f, float z = 0.0f)
        {
            foreach (Poligono poligono in poligonos.Values)
            {
                poligono.rotate(CM, x, y, z);
            }
        }

        public void setPos(float x = 0, float y = 0, float z = 0)
        {
            foreach (Poligono poligono in poligonos.Values)
            {
                poligono.setPos(this.posX + x, this.posY + y, this.posZ + z);
            }
        }
    }
}

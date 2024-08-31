using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Parte
    {
        public Dictionary<string, Poligono> poligonos=new();
        private Matrix4 pos;
        public Parte(float posX = 0.0f, float posY = 0.0f, float posZ = 0.0f)
        {
            pos = Matrix4.Identity * Matrix4.CreateTranslation(posX, posY, posZ);
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

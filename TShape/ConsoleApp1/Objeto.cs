using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Objeto
    {
        public Dictionary<string, Parte> partes=new();
        private Matrix4 pos;
        public Objeto(float posX = 0.0f, float posY = 0.0f, float posZ = 0.0f)
        {
            pos = Matrix4.Identity * Matrix4.CreateTranslation(posX, posY, posZ);
        }
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

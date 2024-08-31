using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Escenario
    {
        public Dictionary<string, Objeto> objetos=new();
        private Matrix4 pos;

        public Escenario(float posX = 0.0f, float posY = 0.0f, float posZ = 0.0f)
        {
            pos=Matrix4.Identity*Matrix4.CreateTranslation(posX,posY,posZ);
        }
        public void Draw(Shader shader)
        {
            foreach (Objeto objeto in objetos.Values)
            {
                objeto.Draw(shader, pos);
            }
        }

    }
}

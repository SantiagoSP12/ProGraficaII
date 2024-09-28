using OpenTK.Mathematics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TShape
{
    public interface InterfazObjeto
    {
        Matrix4 CM { get; }
        public void Draw(Shader shader);

        public void setPos(float x = 0.0f, float y = 0.0f, float z = 0.0f);
        public void move(float x = 0.0f, float y = 0.0f, float z = 0.0f);
        public void scale(float x = 1.0f, float y = 1.0f, float z = 1.0f);
        public void rotate(Matrix4 CM, float x = 0.0f, float y = 0.0f, float z = 0.0f);
    }
}

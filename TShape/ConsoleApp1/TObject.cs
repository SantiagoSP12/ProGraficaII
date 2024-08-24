using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Mathematics;
using System.Reflection;
using TShape;

namespace ConsoleApp1
{
    internal class TObject
    {
        private readonly float[] vertices =
        {
            //top face
            -1.5f, 3.0f, -0.5f,  1.0f, 1.0f, 1.0f,
             1.5f, 3.0f, -0.5f,  1.0f, 1.0f, 1.0f,
            -1.5f, 3.0f,  0.5f,  0.0f, 0.0f, 0.0f,
             1.5f, 3.0f,  0.5f,  0.0f, 0.0f, 0.0f,
            //bottom left face
            -1.5f, 2.0f, -0.5f,  1.0f, 1.0f, 1.0f,
            -0.5f, 2.0f, -0.5f,  1.0f, 1.0f, 1.0f,
            -1.5f, 2.0f,  0.5f,  0.0f, 0.0f, 0.0f,
            -0.5f, 2.0f,  0.5f,  0.0f, 0.0f, 0.0f,
            //bottom right face
             1.5f, 2.0f, -0.5f,  1.0f, 1.0f, 1.0f,
             0.5f, 2.0f, -0.5f,  1.0f, 1.0f, 1.0f,
             1.5f, 2.0f,  0.5f,  0.0f, 0.0f, 0.0f,
             0.5f, 2.0f,  0.5f,  0.0f, 0.0f, 0.0f,
            //bottom middle face
            -0.5f, 0.0f, -0.5f,  1.0f, 1.0f, 1.0f,
             0.5f, 0.0f, -0.5f,  1.0f, 1.0f, 1.0f,
            -0.5f, 0.0f,  0.5f,  0.0f, 0.0f, 0.0f,
             0.5f, 0.0f,  0.5f,  0.0f, 0.0f, 0.0f,
            //front head
            -1.5f, 3.0f,  0.5f,  0.0f, 0.0f, 0.0f,
             1.5f, 3.0f,  0.5f,  0.0f, 0.0f, 0.0f,
            -1.5f, 2.0f,  0.5f,  0.0f, 0.0f, 0.0f,
             1.5f, 2.0f,  0.5f,  0.0f, 0.0f, 0.0f,
            //front body
            -0.5f, 2.0f,  0.5f,  0.0f, 0.0f, 0.0f,
             0.5f, 2.0f,  0.5f,  0.0f, 0.0f, 0.0f,
            -0.5f, 0.0f,  0.5f,  0.0f, 0.0f, 0.0f,
             0.5f, 0.0f,  0.5f,  0.0f, 0.0f, 0.0f,
            //back head
            -1.5f, 3.0f, -0.5f,  1.0f, 1.0f, 1.0f,
             1.5f, 3.0f, -0.5f,  1.0f, 1.0f, 1.0f,
            -1.5f, 2.0f, -0.5f,  1.0f, 1.0f, 1.0f,
             1.5f, 2.0f, -0.5f,  1.0f, 1.0f, 1.0f,
            //back body
            -0.5f, 2.0f, -0.5f,  1.0f, 1.0f, 1.0f,
             0.5f, 2.0f, -0.5f,  1.0f, 1.0f, 1.0f,
            -0.5f, 0.0f, -0.5f,  1.0f, 1.0f, 1.0f,
             0.5f, 0.0f, -0.5f,  1.0f, 1.0f, 1.0f,
            //left side head
            -1.5f, 3.0f, -0.5f,  1.0f, 1.0f, 1.0f,
            -1.5f, 3.0f,  0.5f,  0.0f, 0.0f, 0.0f,
            -1.5f, 2.0f, -0.5f,  1.0f, 1.0f, 1.0f,
            -1.5f, 2.0f,  0.5f,  0.0f, 0.0f, 0.0f,
            //right side head
             1.5f, 3.0f, -0.5f,  1.0f, 1.0f, 1.0f,
             1.5f, 3.0f,  0.5f,  0.0f, 0.0f, 0.0f,
             1.5f, 2.0f, -0.5f,  1.0f, 1.0f, 1.0f,
             1.5f, 2.0f,  0.5f,  0.0f, 0.0f, 0.0f,
            //left side body
            -0.5f, 2.0f, -0.5f,  1.0f, 1.0f, 1.0f,
            -0.5f, 2.0f,  0.5f,  0.0f, 0.0f, 0.0f,
            -0.5f, 0.0f, -0.5f,  1.0f, 1.0f, 1.0f,
            -0.5f, 0.0f,  0.5f,  0.0f, 0.0f, 0.0f,
            //right side head
             0.5f, 2.0f, -0.5f,  1.0f, 1.0f, 1.0f,
             0.5f, 2.0f,  0.5f,  0.0f, 0.0f, 0.0f,
             0.5f, 0.0f, -0.5f,  1.0f, 1.0f, 1.0f,
             0.5f, 0.0f,  0.5f,  0.0f, 0.0f, 0.0f


        };
        uint[] indices = {
            //top face
            0, 1, 2,
            1, 2, 3,
            //bottom left face
            4, 5, 6,
            5, 6, 7,
            //bottom right face
            8, 9, 10,
            9, 10, 11,
            //bottom middle face
            12, 13, 14,
            13, 14, 15,
            //front head
            16, 17, 18,
            17, 18, 19,
            //front body
            20, 21, 22,
            21, 22, 23,
            //back head
            24, 25, 26,
            25, 26, 27,
            //back body
            28, 29, 30,
            29, 30, 31,
            //left side head
            32, 33, 34,
            33, 34, 35,
            //right side head
            36, 37, 38,
            37, 38, 39,
            //left side body
            40, 41, 42,
            41, 42, 43,
            //right side head
            44, 45, 46,
            45, 46, 47
        };
        private int ElementBufferObject;
        private int VertexBufferObject;
        private int VertexArrayObject;
        private Matrix4 model;
        private Vector4 pos;


        public TObject(float x = 0.0f, float y = 0.0f, float z = 0.0f)
        {
            VertexArrayObject = GL.GenVertexArray();
            GL.BindVertexArray(VertexArrayObject);

            VertexBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, VertexBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);

            ElementBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, ElementBufferObject);
            GL.BufferData(BufferTarget.ElementArrayBuffer, indices.Length * sizeof(uint), indices, BufferUsageHint.StaticDraw);

            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 6 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);

            GL.VertexAttribPointer(1, 3, VertexAttribPointerType.Float, false, 6 * sizeof(float), 3 * sizeof(float));
            GL.EnableVertexAttribArray(1);

            pos = new Vector4(x, y, z, 1.0f);
            model= Matrix4.Identity*Matrix4.CreateTranslation(pos.X, pos.Y, pos.Z);
        }

        public void draw(Shader shader,Matrix4 view, Matrix4 projection)
        {
            GL.BindVertexArray(VertexArrayObject);
            shader.Use();
            shader.SetMatrix4("model", model);
            shader.SetMatrix4("view", view);
            shader.SetMatrix4("projection", projection);
            GL.DrawElements(PrimitiveType.Triangles, indices.Length, DrawElementsType.UnsignedInt, 0);
        }

        public void move(float x, float y, float z)
        {
            model = Matrix4.CreateTranslation(x, y, z);
        }

        public void scale(float x, float y, float z)
        {
            model *= Matrix4.CreateScale(x, y, z);
        }
    }
}

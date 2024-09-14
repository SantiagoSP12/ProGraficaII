using System.Runtime.Serialization;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

namespace TShape
{
    public class Poligono
    {
        public float[] vertices;
        public float posX,posY,posZ=0.0f;
        private Matrix4 pos;

        private int VertexBufferObject;
        private int VertexArrayObject;
        public Poligono() { }

        public Poligono(float v0x, float v0y, float v0z, float v0cR, float v0cG, float v0cB,
                        float v1x, float v1y, float v1z, float v1cR, float v1cG, float v1cB,
                        float v2x, float v2y, float v2z, float v2cR, float v2cG, float v2cB,
                        float v3x, float v3y, float v3z, float v3cR, float v3cG, float v3cB,
                        float posX=0.0f, float posY = 0.0f, float posZ = 0.0f)
        {
            vertices = new float[24];
            vertices[0] = v0x; vertices[1] = v0y; vertices[2] = v0z;
            vertices[3] = v0cR; vertices[4] = v0cG; vertices[5] = v0cB;

            vertices[6] = v1x; vertices[7] = v1y; vertices[8] = v1z;
            vertices[9] = v1cR; vertices[10] = v1cG; vertices[11] = v1cB;

            vertices[12] = v2x; vertices[13] = v2y; vertices[14] = v2z;
            vertices[15] = v2cR; vertices[16] = v2cG; vertices[17] = v2cB;

            vertices[18] = v3x; vertices[19] = v3y; vertices[20] = v3z;
            vertices[21] = v3cR; vertices[22] = v3cG; vertices[23] = v3cB;

            this.posX = posX;this.posY = posY;this.posZ = posZ;
            Cargar(new StreamingContext());
        }
        [OnDeserialized]
        public void Cargar(StreamingContext context)
        {
            VertexArrayObject = GL.GenVertexArray();
            GL.BindVertexArray(VertexArrayObject);

            VertexBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, VertexBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);

            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 6 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);

            GL.VertexAttribPointer(1, 3, VertexAttribPointerType.Float, false, 6 * sizeof(float), 3 * sizeof(float));
            GL.EnableVertexAttribArray(1);
            pos = Matrix4.CreateTranslation(posX, posY, posZ);
        }

        public void Draw(Shader shader, Matrix4 model)
        {
            GL.BindVertexArray(VertexArrayObject);
            shader.Use();
            shader.SetMatrix4("model", pos * model);
            GL.DrawArrays(PrimitiveType.TriangleFan, 0, 4);
        }
    }
}

using ConsoleApp1;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using static System.Net.Mime.MediaTypeNames;

namespace TShape
{
    public class Game:GameWindow
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

        int ElementBufferObject;
        int VertexBufferObject;
        int VertexArrayObject;
        private Shader shader;
        private Camera camara;

        float speed = 1.5f;

        Matrix4 model, view, projection;
        Vector2 lastPos;
        bool firstMove = true;

        public Game(int width, int height, string title):base(GameWindowSettings.Default,
            new NativeWindowSettings() {Size=(width,height), Title=title})
        {
        }

        protected override void OnLoad()
        {
            base.OnLoad();

            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);
            GL.Enable(EnableCap.DepthTest);

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

            shader = new Shader("../../../shader.vert", "../../../shader.frag");
            shader.Use();

            model = view = projection = Matrix4.Identity;

            speed = 1.5f;

            camara = new Camera(Vector3.UnitZ * 3);

            projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(45.0f), Size.X/(float)Size.Y, 0.1f, 100.0f);

            CursorState = CursorState.Grabbed;

        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            shader.Use();
            shader.SetMatrix4("model",model);
            shader.SetMatrix4("view",camara.GetViewMatrix());
            shader.SetMatrix4("projection",projection);

            GL.DrawElements(PrimitiveType.Triangles, indices.Length, DrawElementsType.UnsignedInt, 0);

            SwapBuffers();

        }

        protected override void OnFramebufferResize(FramebufferResizeEventArgs args)
        {
            base.OnFramebufferResize(args);

            GL.Viewport(0,0,args.Width,args.Height);
        }

        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            base.OnUpdateFrame(args);
            if (!IsFocused) 
            {
                return;
            }


            if (KeyboardState.IsKeyDown(Keys.W))
            {
                camara.Position += camara.Front * speed * (float)args.Time; //Forward 
            }

            if (KeyboardState.IsKeyDown(Keys.S))
            {
                camara.Position -= camara.Front * speed * (float)args.Time; //Backwards
            }

            if (KeyboardState.IsKeyDown(Keys.A))
            {
                camara.Position -= Vector3.Normalize(Vector3.Cross(camara.Front, camara.Up)) * speed * (float)args.Time; //Left
            }

            if (KeyboardState.IsKeyDown(Keys.D))
            {
                camara.Position += Vector3.Normalize(Vector3.Cross(camara.Front, camara.Up)) * speed * (float)args.Time; //Right
            }

            if (KeyboardState.IsKeyDown(Keys.Space))
            {
                camara.Position += camara.Up * speed * (float)args.Time; //Up 
            }

            if (KeyboardState.IsKeyDown(Keys.LeftShift))
            {
                camara.Position -= camara.Up * speed * (float)args.Time; //Down
            }
            if (KeyboardState.IsKeyDown(Keys.Escape))
            {
                GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
                GL.DeleteBuffer(VertexBufferObject);
                shader.Dispose();
                Close();
            }
            const float sensitivity = 0.2f;

            if (firstMove)
            {
                lastPos = new Vector2(MouseState.X, MouseState.Y);
                firstMove = false;
            }
            else
            {
                {
                    var deltaX = MouseState.X - lastPos.X;
                    var deltaY = MouseState.Y - lastPos.Y;
                    lastPos = new Vector2(MouseState.X, MouseState.Y);

                    camara.Yaw += deltaX * sensitivity;
                    camara.Pitch -= deltaY * sensitivity;
                }
            }
        }
    }
}

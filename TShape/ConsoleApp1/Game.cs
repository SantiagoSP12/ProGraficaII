using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace TShape
{
    //Investigar serializacion //aun no
    //Implentacion  por interfaz  //definitivamente no, investigar como hacer una interfaz en C

    //serializar
    //sacar los vertices fuera, en un archivo
    public class Game:GameWindow
    {

        private Escenario t;
        private Shader shader;
        private Camera camara;

        float speed = 1.5f;

        Matrix4 projection;
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
            //TObject.Serialize(TObject.Ts(), "TShape");
            t = new(0.0f, 0.0f, 0.0f);
            t.objetos.Add("TShape", TObject.LoadObject<Objeto>("../../../assets/objects/TShape.json"));
            t.objetos.Add("Center", TObject.LoadObject<Objeto>("../../../assets/objects/TShape.json"));
            t.objetos["Center"].scale(0.05f, 0.05f, 0.05f);
            
            shader = new Shader("../../../shader.vert", "../../../shader.frag");
            shader.Use();

            speed = 1.5f;

            camara = new Camera(Vector3.UnitZ * 3);

            projection = Matrix4.Identity*Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(45.0f), Size.X/(float)Size.Y, 0.1f, 100.0f);
            shader.SetMatrix4("projection", projection);

            CursorState = CursorState.Grabbed;
        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            shader.SetMatrix4("view", camara.GetViewMatrix());
            t.Draw(shader);
            shader.Use();
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
                Close();
            }
            if (KeyboardState.IsKeyDown(Keys.P))
            {
                t.objetos["TShape"].move(camara.Position.X,camara.Position.Y,camara.Position.Z-3.0f);
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

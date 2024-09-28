using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace TShape
{
    //Implentacion  por interfaz  //definitivamente no, investigar como hacer una interfaz en C
    //Esc->Obj->Par->Pol
    //Ejecutar transformaciones a todo nivel (R,T,E)
    //¿como hago la interfaz de usuario?
    //R,T,E sobre que eje(x,y,z) y cuanto (pitch,yaw,roll)
    //E(x>0), no multiplicar a si mismo, porque se escala exponencialmente
    //pasar 3 parametros donde 2 pueden iniciar en 0 a las transformaciones (R(x o xy o xyz)(ejemplo))
    //combinar transformaciones, ¿como? preparar matrices para mulitplicar antes de pasarselo al objeto
    //inicializar matrices R,T,E en la identidad
    //volver las partes sólidas(cerrar los agujeros que los conectan)//talvez no
    //centro de masa dinamico(objeto y parte)

    public class Game:GameWindow
    {

        private Escenario t;
        private Shader shader;
        private Camera camara;

        float speed = 0.005f;

        Matrix4 projection;
        Vector2 lastPos;
        bool firstMove = true;

        List<string> nombreObjetos;
        List<string> nombrePartes;
        List<string> nombreEfectos;
        List<string> sujetosDePrueba;

        string objetoActual;
        string parteActual;
        string selected_transformation;
        string sujetoActual;
        sbyte direccionActual;

        InterfazObjeto target;

        public Game(int width, int height, string title):base(GameWindowSettings.Default,
            new NativeWindowSettings() {Size=(width,height), Title=title})
        {
        }

        protected override void OnLoad()
        {
            base.OnLoad();
            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);
            GL.Enable(EnableCap.DepthTest);

            t = TObject.LoadObject<Escenario>("Escenario");
            t.objetos.Add("Center", TObject.LoadObject<Objeto>("TShape"));
            t.objetos["Center"].setPos(0,0,0);
            t.objetos["Center"].scale(0.05f, 0.05f, 0.05f);
            
            iniciarInterfazTemporal();


            shader = new Shader("../../../shader.vert", "../../../shader.frag");
            shader.Use();

            speed = 1.5f;
            camara = new Camera(Vector3.UnitZ * 3);

            projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(45.0f), Size.X / (float)Size.Y, 0.1f, 100.0f);
            shader.SetMatrix4("projection", projection);

            CursorState = CursorState.Grabbed;
            displayTemporal();

            target = t;
        }

        private void iniciarInterfazTemporal()
        {
            nombreEfectos = ["Rotacion", "Escalacion", "Traslacion"];
            sujetosDePrueba = ["Escenario", "Objeto", "Parte"];
            nombreObjetos = new List<string>(t.objetos.Keys);
            sujetoActual = sujetosDePrueba.ElementAtOrDefault(0);
            selected_transformation = nombreEfectos.ElementAtOrDefault(0);
            direccionActual = 1;
            objetoActual = nombreObjetos.ElementAtOrDefault(0);
            nombrePartes = new List<string>(t.objetos[objetoActual].partes.Keys);
            parteActual = nombrePartes.ElementAtOrDefault(0);
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

            //Movement 
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
            //Closing
            if (KeyboardState.IsKeyDown(Keys.Escape))
            {
                Close();
            }

            //modifying
            if (KeyboardState.IsKeyPressed(Keys.P))
            {
                t.objetos["TShape"].setPos(camara.Position.X,camara.Position.Y,camara.Position.Z-3.0f);
            }

            if (KeyboardState.IsKeyDown(Keys.X))
            {
                if (selected_transformation == "Rotacion")
                {
                    target.rotate(target.CM, (float)direccionActual * 15f * (float)args.Time, 0f, 0f);
                }
                else if (selected_transformation == "Traslacion")
                {
                    target.move(direccionActual * speed * (float)args.Time, 0f, 0f);
                }
                else if (selected_transformation == "Escalacion")
                {
                    target.scale(1f + (float)direccionActual * (float)args.Time, 1f, 1f);
                }
            }

            if (KeyboardState.IsKeyDown(Keys.Y))
            {
                if (selected_transformation == "Rotacion")
                {
                    target.rotate(target.CM, 0f, (float)direccionActual * 15f * (float)args.Time, 0f);
                }
                else if (selected_transformation == "Traslacion")
                {
                    target.move(0f, (float)direccionActual * speed * (float)args.Time, 0f);

                }
                else if (selected_transformation == "Escalacion")
                {
                    target.scale(1f, 1f + (float)direccionActual * (float)args.Time, 1f );
                }
            }

            if (KeyboardState.IsKeyDown(Keys.Z))
            {
                if (selected_transformation == "Rotacion")
                {
                    target.rotate(target.CM, 0f, 0f, (float)direccionActual * 15f * (float)args.Time);
                }
                else if (selected_transformation == "Traslacion")
                {
                    target.move(0f, 0f, (float)direccionActual * speed * (float)args.Time);
                }
                else if (selected_transformation == "Escalacion")
                {
                    target.scale(1f, 1f, 1f + (float)direccionActual*(float)args.Time);
                }
            }

            if (KeyboardState.IsKeyPressed(Keys.V))
            {
                if (direccionActual == 1) direccionActual = -1;
                else direccionActual = 1;

                displayTemporal();
            }

            if (KeyboardState.IsKeyPressed(Keys.T))
            {
                try
                {
                    selected_transformation = nombreEfectos.ElementAt(nombreEfectos.IndexOf(selected_transformation) + 1);
                }
                catch
                {
                    selected_transformation = nombreEfectos.ElementAt(0);
                }
                displayTemporal();

            }

            if (KeyboardState.IsKeyPressed(Keys.M))
            {
                try
                {
                    sujetoActual = sujetosDePrueba.ElementAt(sujetosDePrueba.IndexOf(sujetoActual) + 1);
                }
                catch
                {
                    sujetoActual = sujetosDePrueba.ElementAt(0);
                }
                if (sujetoActual == "Escenario") target = t;
                else if (sujetoActual == "Objeto") target = t.objetos[objetoActual];
                else if (sujetoActual == "Parte") target = t.objetos[objetoActual].partes[parteActual];
                displayTemporal();

            }

            if (KeyboardState.IsKeyPressed(Keys.O))
            {
                try
                {
                    objetoActual = nombreObjetos.ElementAt(nombreObjetos.IndexOf(objetoActual) + 1);
                }
                catch
                {
                    objetoActual = nombreObjetos.ElementAt(0);
                }
                nombrePartes = new List<string>(t.objetos[objetoActual].partes.Keys);
                if (sujetoActual == "Objeto") target = t.objetos[objetoActual];
                parteActual = nombrePartes.ElementAt(0);
                displayTemporal();
            }

            if (KeyboardState.IsKeyPressed(Keys.L))
            {
                try
                {
                    parteActual = nombrePartes.ElementAt(nombrePartes.IndexOf(parteActual) + 1);
                }
                catch
                {
                    parteActual = nombrePartes.ElementAt(0);
                }
                if (sujetoActual == "Parte") target = t.objetos[objetoActual].partes[parteActual];
                displayTemporal();

            }

        }

        private void displayTemporal()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Sujeto de Pruebas(M): " + sujetoActual);
            Console.WriteLine("Objeto(O): " + objetoActual);
            Console.WriteLine("Parte(L): " + parteActual);
            Console.WriteLine("Efecto(T): " + selected_transformation);
            Console.WriteLine("Direccion(V): " + direccionActual.ToString()) ;
        }

        protected override void OnMouseMove(MouseMoveEventArgs e)
        {
            base.OnMouseMove(e);
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

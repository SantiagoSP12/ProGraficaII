using Newtonsoft.Json;

namespace TShape
{
    public class TObject
    {
        public static void Serialize<T>(T Object, string nameOfTheObject)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize
            };
            try
            {

                if (!Directory.Exists(@"D:\Santiago\ProGraficaII\TShape\ConsoleApp1\assets")) { Directory.CreateDirectory(@"D:\Santiago\ProGraficaII\TShape\ConsoleApp1\assets"); }
                if (!Directory.Exists(@"D:\Santiago\ProGraficaII\TShape\ConsoleApp1\assets\objects")) { Directory.CreateDirectory(@"D:\Santiago\ProGraficaII\TShape\ConsoleApp1\assets\objects"); }

                string FileNameToArchive = "../../../assets/objects/" + nameOfTheObject + ".json";

                using (StreamWriter sw = File.CreateText(FileNameToArchive))
                {
                    sw.Write(JsonConvert.SerializeObject(Object, Formatting.Indented, settings));
                }
            }catch
            {
                return;
            }

        }
        public static T LoadObject<T>(string path)
        {
            using (StreamReader sr = File.OpenText(path))
            {
                T objectOut = JsonConvert.DeserializeObject<T>(sr.ReadToEnd());
                return objectOut;
            }
        }

        public static Objeto Ts(float x = 0.0f, float y = 0.0f, float z = 0.0f, string name = "TShape")
        {
            Objeto TShape = new(x, y, z);
            Parte cabeza = new(0.0f,2.5f,0.0f);
            cabeza.poligonos.Add("Top",
                new(-1.5f, 0.0f, -0.5f, 1.0f, 1.0f, 1.0f,
                     1.5f, 0.0f, -0.5f, 1.0f, 1.0f, 1.0f,
                    -1.5f, 0.0f, 0.5f, 0.0f, 0.0f, 0.0f,
                     1.5f, 0.0f, 0.5f, 0.0f, 0.0f, 0.0f,
                     0.0f, 0.5f, 0.0f));
            cabeza.poligonos.Add("Bottom Left",
                new(-0.5f, 0.0f, -0.5f, 1.0f, 1.0f, 1.0f,
                     0.5f, 0.0f, -0.5f, 1.0f, 1.0f, 1.0f,
                    -0.5f, 0.0f, 0.5f, 0.0f, 0.0f, 0.0f,
                     0.5f, 0.0f, 0.5f, 0.0f, 0.0f, 0.0f,
                    -1.0f, -0.5f, 0.0f));
            cabeza.poligonos.Add("Bottom Right",
                new( 0.5f, 0.0f, -0.5f, 1.0f, 1.0f, 1.0f,
                    -0.5f, 0.0f, -0.5f, 1.0f, 1.0f, 1.0f,
                     0.5f, 0.0f, 0.5f, 0.0f, 0.0f, 0.0f,
                    -0.5f, 0.0f, 0.5f, 0.0f, 0.0f, 0.0f,
                     1.0f, -0.5f, 0.0f));
            cabeza.poligonos.Add("Front",
                new(-1.5f, 0.5f, 0.0f, 0.0f, 0.0f, 0.0f,
                     1.5f, 0.5f, 0.0f, 0.0f, 0.0f, 0.0f,
                    -1.5f, -0.5f, 0.0f, 0.0f, 0.0f, 0.0f,
                     1.5f, -0.5f, 0.0f, 0.0f, 0.0f, 0.0f,
                     0.0f, 0.0f, 0.5f));
            cabeza.poligonos.Add("Back",
                new(-1.5f, 0.5f, 0.0f, 1.0f, 1.0f, 1.0f,
                     1.5f, 0.5f, 0.0f, 1.0f, 1.0f, 1.0f,
                    -1.5f, -0.5f, 0.0f, 1.0f, 1.0f, 1.0f,
                     1.5f, -0.5f, 0.0f, 1.0f, 1.0f, 1.0f,
                     0.0f, 0.0f, -0.5f));
            cabeza.poligonos.Add("Left Side",
                new( 0.0f, 0.5f, -0.5f, 1.0f, 1.0f, 1.0f,
                     0.0f, 0.5f, 0.5f, 0.0f, 0.0f, 0.0f,
                     0.0f, -0.5f, -0.5f, 1.0f, 1.0f, 1.0f,
                     0.0f, -0.5f, 0.5f, 0.0f, 0.0f, 0.0f,
                    -1.5f, 0.0f, 0.0f));
            cabeza.poligonos.Add("Right Side",
                new(0.0f, 0.5f, -0.5f, 1.0f, 1.0f, 1.0f,
                    0.0f, 0.5f, 0.5f, 0.0f, 0.0f, 0.0f,
                    0.0f, -0.5f, -0.5f, 1.0f, 1.0f, 1.0f,
                    0.0f, -0.5f, 0.5f, 0.0f, 0.0f, 0.0f,
                    1.5f, 0.0f, 0.0f));
            TShape.partes.Add("Cabeza", cabeza);
            Parte cuerpo = new(0.0f, 1.0f, 0.0f);
            cuerpo.poligonos.Add("Bottom",
                new(-0.5f, 0.0f, -0.5f, 1.0f, 1.0f, 1.0f,
                     0.5f, 0.0f, -0.5f, 1.0f, 1.0f, 1.0f,
                    -0.5f, 0.0f, 0.5f, 0.0f, 0.0f, 0.0f,
                     0.5f, 0.0f, 0.5f, 0.0f, 0.0f, 0.0f,
                     0.0f, -1.0f, 0.0f));
            cuerpo.poligonos.Add("Front",
                new(-0.5f, 1.0f, 0.0f, 0.0f, 0.0f, 0.0f,
                     0.5f, 1.0f, 0.0f, 0.0f, 0.0f, 0.0f,
                    -0.5f, -1.0f, 0.0f, 0.0f, 0.0f, 0.0f,
                     0.5f, -1.0f, 0.0f, 0.0f, 0.0f, 0.0f,
                     0.0f, 0.0f, 0.5f));
            cuerpo.poligonos.Add("Back",
                new(-0.5f, 1.0f, 0.0f, 1.0f, 1.0f, 1.0f,
                     0.5f, 1.0f, 0.0f, 1.0f, 1.0f, 1.0f,
                    -0.5f, -1.0f, 0.0f, 1.0f, 1.0f, 1.0f,
                     0.5f, -1.0f, 0.0f, 1.0f, 1.0f, 1.0f,
                     0.0f, 0.0f, -0.5f));
            cuerpo.poligonos.Add("Left Side",
                new( 0.0f, 1.0f, -0.5f, 1.0f, 1.0f, 1.0f,
                     0.0f, 1.0f, 0.5f, 0.0f, 0.0f, 0.0f,
                     0.0f, -1.0f, -0.5f, 1.0f, 1.0f, 1.0f,
                     0.0f, -1.0f, 0.5f, 0.0f, 0.0f, 0.0f,
                    -0.5f, 0.0f, 0.0f));
            cuerpo.poligonos.Add("Right Side",
                new(0.0f, 1.0f, -0.5f, 1.0f, 1.0f, 1.0f,
                     0.0f, 1.0f, 0.5f, 0.0f, 0.0f, 0.0f,
                     0.0f, -1.0f, -0.5f, 1.0f, 1.0f, 1.0f,
                     0.0f, -1.0f, 0.5f, 0.0f, 0.0f, 0.0f,
                     0.5f, 0.0f, 0.0f));
            TShape.partes.Add("Cuerpo", cuerpo);
            return TShape;
        }

        public TObject() { }

    }
}

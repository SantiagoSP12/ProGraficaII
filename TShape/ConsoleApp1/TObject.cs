using Newtonsoft.Json;

namespace TShape
{
    public class TObject
    {
        private static float[] TVert =
        {
            //top face
            -1.5f, 0.0f, -0.5f,  1.0f, 1.0f, 1.0f,
             1.5f, 0.0f, -0.5f,  1.0f, 1.0f, 1.0f,
             1.5f, 0.0f,  0.5f,  0.0f, 0.0f, 0.0f,
            -1.5f, 0.0f,  0.5f,  0.0f, 0.0f, 0.0f,
            //bottom left face
            -0.5f, 0.0f, -0.5f,  1.0f, 1.0f, 1.0f,
             0.5f, 0.0f, -0.5f,  1.0f, 1.0f, 1.0f,
             0.5f, 0.0f,  0.5f,  0.0f, 0.0f, 0.0f,
            -0.5f, 0.0f,  0.5f,  0.0f, 0.0f, 0.0f,
            //bottom middle face
            -0.5f, 0.0f, -0.5f,  1.0f, 1.0f, 1.0f,
             0.5f, 0.0f, -0.5f,  1.0f, 1.0f, 1.0f,
             0.5f, 0.0f,  0.5f,  0.0f, 0.0f, 0.0f,
            -0.5f, 0.0f,  0.5f,  0.0f, 0.0f, 0.0f,
            //front head
            -1.5f, 0.5f,  0.0f,  0.0f, 0.0f, 0.0f,
             1.5f, 0.5f,  0.0f,  0.0f, 0.0f, 0.0f,
             1.5f,-0.5f,  0.0f,  0.0f, 0.0f, 0.0f,
            -1.5f,-0.5f,  0.0f,  0.0f, 0.0f, 0.0f,
            //back head
            -1.5f, 0.5f,  0.0f,  1.0f, 1.0f, 1.0f,
             1.5f, 0.5f,  0.0f,  1.0f, 1.0f, 1.0f,
             1.5f,-0.5f,  0.0f,  1.0f, 1.0f, 1.0f,
            -1.5f,-0.5f,  0.0f,  1.0f, 1.0f, 1.0f,
            //left side head
             0.0f, 0.5f, -0.5f,  1.0f, 1.0f, 1.0f,
             0.0f, 0.5f,  0.5f,  0.0f, 0.0f, 0.0f,
             0.0f,-0.5f,  0.5f,  0.0f, 0.0f, 0.0f,
             0.0f,-0.5f, -0.5f,  1.0f, 1.0f, 1.0f,
            //right side head
             0.0f, 0.5f, -0.5f,  1.0f, 1.0f, 1.0f,
             0.0f, 0.5f,  0.5f,  0.0f, 0.0f, 0.0f,
             0.0f,-0.5f,  0.5f,  0.0f, 0.0f, 0.0f,
             0.0f,-0.5f, -0.5f,  1.0f, 1.0f, 1.0f,
             //bottom right face
             0.5f, 0.0f, -0.5f,  1.0f, 1.0f, 1.0f,
            -0.5f, 0.0f, -0.5f,  1.0f, 1.0f, 1.0f,
            -0.5f, 0.0f,  0.5f,  0.0f, 0.0f, 0.0f,
             0.5f, 0.0f,  0.5f,  0.0f, 0.0f, 0.0f,
            //front body
            -0.5f, 1.0f,  0.0f,  0.0f, 0.0f, 0.0f,
             0.5f, 1.0f,  0.0f,  0.0f, 0.0f, 0.0f,
             0.5f,-1.0f,  0.0f,  0.0f, 0.0f, 0.0f,
            -0.5f,-1.0f,  0.0f,  0.0f, 0.0f, 0.0f,
             //back body
            -0.5f, 1.0f,  0.0f,  1.0f, 1.0f, 1.0f,
             0.5f, 1.0f,  0.0f,  1.0f, 1.0f, 1.0f,
             0.5f,-1.0f,  0.0f,  1.0f, 1.0f, 1.0f,
            -0.5f,-1.0f,  0.0f,  1.0f, 1.0f, 1.0f,
             //left side body
             0.0f, 1.0f, -0.5f,  1.0f, 1.0f, 1.0f,
             0.0f, 1.0f,  0.5f,  0.0f, 0.0f, 0.0f,
             0.0f,-1.0f,  0.5f,  0.0f, 0.0f, 0.0f,
             0.0f,-1.0f, -0.5f,  1.0f, 1.0f, 1.0f,
            //right side body
             0.0f, 1.0f, -0.5f,  1.0f, 1.0f, 1.0f,
             0.0f, 1.0f,  0.5f,  0.0f, 0.0f, 0.0f,
             0.0f,-1.0f,  0.5f,  0.0f, 0.0f, 0.0f,
             0.0f,-1.0f, -0.5f,  1.0f, 1.0f, 1.0f
        };
        public static void Serialize<T>(T Object, string nombre)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize
            };
            try
            {
                if (!Directory.Exists("../../../objetos")) { Directory.CreateDirectory("../../../objetos"); }
                string FileName = "../../../objetos/" + nombre + ".json";
                using (StreamWriter sw = File.CreateText(FileName))
                {
                    sw.Write(JsonConvert.SerializeObject(Object, Formatting.Indented, settings));
                }
            } catch
            {
                throw new FileNotFoundException();
            }

        }
        public static T LoadObject<T>(string path)
        {
            path = "../../../objetos/" + path + ".json";
            using (StreamReader sr = File.OpenText(path))
            {
                T objectOut = JsonConvert.DeserializeObject<T>(sr.ReadToEnd());
                return objectOut;
            }
        }

        public static Objeto Ts(float x = 0.0f, float y = 0.0f, float z = 0.0f, string name = "TShape")
        {
            Objeto TShape = new(x, y, z);
            Parte cabeza = new(0.0f, 2.5f, 0.0f);
            int n = 0;
            cabeza.poligonos.Add("Top",
                new(TVert[0 + 24 * n], TVert[1 + 24 * n], TVert[2 + 24 * n], TVert[3 + 24 * n], TVert[4 + 24 * n], TVert[5 + 24 * n],
                    TVert[6 + 24 * n], TVert[7 + 24 * n], TVert[8 + 24 * n], TVert[9 + 24 * n], TVert[10 + 24 * n], TVert[11 + 24 * n],
                    TVert[12 + 24 * n], TVert[13 + 24 * n], TVert[14 + 24 * n], TVert[15 + 24 * n], TVert[16 + 24 * n], TVert[17 + 24 * n],
                    TVert[18 + 24 * n], TVert[19 + 24 * n], TVert[20 + 24 * n], TVert[21 + 24 * n], TVert[22 + 24 * n], TVert[23 + 24 * n],
                     0.0f, 0.5f, 0.0f));
            n++;
            cabeza.poligonos.Add("Bottom Left",
                new(TVert[0 + 24 * n], TVert[1 + 24 * n], TVert[2 + 24 * n], TVert[3 + 24 * n], TVert[4 + 24 * n], TVert[5 + 24 * n],
                    TVert[6 + 24 * n], TVert[7 + 24 * n], TVert[8 + 24 * n], TVert[9 + 24 * n], TVert[10 + 24 * n], TVert[11 + 24 * n],
                    TVert[12 + 24 * n], TVert[13 + 24 * n], TVert[14 + 24 * n], TVert[15 + 24 * n], TVert[16 + 24 * n], TVert[17 + 24 * n],
                    TVert[18 + 24 * n], TVert[19 + 24 * n], TVert[20 + 24 * n], TVert[21 + 24 * n], TVert[22 + 24 * n], TVert[23 + 24 * n],
                    -1.0f, -0.5f, 0.0f));
            n++;
            cabeza.poligonos.Add("Bottom Right",
                new(TVert[0 + 24 * n], TVert[1 + 24 * n], TVert[2 + 24 * n], TVert[3 + 24 * n], TVert[4 + 24 * n], TVert[5 + 24 * n],
                    TVert[6 + 24 * n], TVert[7 + 24 * n], TVert[8 + 24 * n], TVert[9 + 24 * n], TVert[10 + 24 * n], TVert[11 + 24 * n],
                    TVert[12 + 24 * n], TVert[13 + 24 * n], TVert[14 + 24 * n], TVert[15 + 24 * n], TVert[16 + 24 * n], TVert[17 + 24 * n],
                    TVert[18 + 24 * n], TVert[19 + 24 * n], TVert[20 + 24 * n], TVert[21 + 24 * n], TVert[22 + 24 * n], TVert[23 + 24 * n],
                     1.0f, -0.5f, 0.0f));
            n++;
            cabeza.poligonos.Add("Front",
                new(TVert[0 + 24 * n], TVert[1 + 24 * n], TVert[2 + 24 * n], TVert[3 + 24 * n], TVert[4 + 24 * n], TVert[5 + 24 * n],
                    TVert[6 + 24 * n], TVert[7 + 24 * n], TVert[8 + 24 * n], TVert[9 + 24 * n], TVert[10 + 24 * n], TVert[11 + 24 * n],
                    TVert[12 + 24 * n], TVert[13 + 24 * n], TVert[14 + 24 * n], TVert[15 + 24 * n], TVert[16 + 24 * n], TVert[17 + 24 * n],
                    TVert[18 + 24 * n], TVert[19 + 24 * n], TVert[20 + 24 * n], TVert[21 + 24 * n], TVert[22 + 24 * n], TVert[23 + 24 * n],
                     0.0f, 0.0f, 0.5f));
            n++;
            cabeza.poligonos.Add("Back",
                new(TVert[0 + 24 * n], TVert[1 + 24 * n], TVert[2 + 24 * n], TVert[3 + 24 * n], TVert[4 + 24 * n], TVert[5 + 24 * n],
                    TVert[6 + 24 * n], TVert[7 + 24 * n], TVert[8 + 24 * n], TVert[9 + 24 * n], TVert[10 + 24 * n], TVert[11 + 24 * n],
                    TVert[12 + 24 * n], TVert[13 + 24 * n], TVert[14 + 24 * n], TVert[15 + 24 * n], TVert[16 + 24 * n], TVert[17 + 24 * n],
                    TVert[18 + 24 * n], TVert[19 + 24 * n], TVert[20 + 24 * n], TVert[21 + 24 * n], TVert[22 + 24 * n], TVert[23 + 24 * n],
                     0.0f, 0.0f, -0.5f));
            n++;
            cabeza.poligonos.Add("Left Side",
                new(TVert[0 + 24 * n], TVert[1 + 24 * n], TVert[2 + 24 * n], TVert[3 + 24 * n], TVert[4 + 24 * n], TVert[5 + 24 * n],
                    TVert[6 + 24 * n], TVert[7 + 24 * n], TVert[8 + 24 * n], TVert[9 + 24 * n], TVert[10 + 24 * n], TVert[11 + 24 * n],
                    TVert[12 + 24 * n], TVert[13 + 24 * n], TVert[14 + 24 * n], TVert[15 + 24 * n], TVert[16 + 24 * n], TVert[17 + 24 * n],
                    TVert[18 + 24 * n], TVert[19 + 24 * n], TVert[20 + 24 * n], TVert[21 + 24 * n], TVert[22 + 24 * n], TVert[23 + 24 * n],
                    -1.5f, 0.0f, 0.0f));
            n++;
            cabeza.poligonos.Add("Right Side",
                new(TVert[0 + 24 * n], TVert[1 + 24 * n], TVert[2 + 24 * n], TVert[3 + 24 * n], TVert[4 + 24 * n], TVert[5 + 24 * n],
                    TVert[6 + 24 * n], TVert[7 + 24 * n], TVert[8 + 24 * n], TVert[9 + 24 * n], TVert[10 + 24 * n], TVert[11 + 24 * n],
                    TVert[12 + 24 * n], TVert[13 + 24 * n], TVert[14 + 24 * n], TVert[15 + 24 * n], TVert[16 + 24 * n], TVert[17 + 24 * n],
                    TVert[18 + 24 * n], TVert[19 + 24 * n], TVert[20 + 24 * n], TVert[21 + 24 * n], TVert[22 + 24 * n], TVert[23 + 24 * n],
                    1.5f, 0.0f, 0.0f));
            TShape.partes.Add("Cabeza", cabeza);
            Parte cuerpo = new(0.0f, 1.0f, 0.0f);
            n++;
            cuerpo.poligonos.Add("Bottom",
                new(TVert[0 + 24 * n], TVert[1 + 24 * n], TVert[2 + 24 * n], TVert[3 + 24 * n], TVert[4 + 24 * n], TVert[5 + 24 * n],
                    TVert[6 + 24 * n], TVert[7 + 24 * n], TVert[8 + 24 * n], TVert[9 + 24 * n], TVert[10 + 24 * n], TVert[11 + 24 * n],
                    TVert[12 + 24 * n], TVert[13 + 24 * n], TVert[14 + 24 * n], TVert[15 + 24 * n], TVert[16 + 24 * n], TVert[17 + 24 * n],
                    TVert[18 + 24 * n], TVert[19 + 24 * n], TVert[20 + 24 * n], TVert[21 + 24 * n], TVert[22 + 24 * n], TVert[23 + 24 * n],
                     0.0f, -1.0f, 0.0f));
            n++;
            cuerpo.poligonos.Add("Front",
                new(TVert[0 + 24 * n], TVert[1 + 24 * n], TVert[2 + 24 * n], TVert[3 + 24 * n], TVert[4 + 24 * n], TVert[5 + 24 * n],
                    TVert[6 + 24 * n], TVert[7 + 24 * n], TVert[8 + 24 * n], TVert[9 + 24 * n], TVert[10 + 24 * n], TVert[11 + 24 * n],
                    TVert[12 + 24 * n], TVert[13 + 24 * n], TVert[14 + 24 * n], TVert[15 + 24 * n], TVert[16 + 24 * n], TVert[17 + 24 * n],
                    TVert[18 + 24 * n], TVert[19 + 24 * n], TVert[20 + 24 * n], TVert[21 + 24 * n], TVert[22 + 24 * n], TVert[23 + 24 * n],
                     0.0f, 0.0f, 0.5f));
            n++;
            cuerpo.poligonos.Add("Back",
                new(TVert[0 + 24 * n], TVert[1 + 24 * n], TVert[2 + 24 * n], TVert[3 + 24 * n], TVert[4 + 24 * n], TVert[5 + 24 * n],
                    TVert[6 + 24 * n], TVert[7 + 24 * n], TVert[8 + 24 * n], TVert[9 + 24 * n], TVert[10 + 24 * n], TVert[11 + 24 * n],
                    TVert[12 + 24 * n], TVert[13 + 24 * n], TVert[14 + 24 * n], TVert[15 + 24 * n], TVert[16 + 24 * n], TVert[17 + 24 * n],
                    TVert[18 + 24 * n], TVert[19 + 24 * n], TVert[20 + 24 * n], TVert[21 + 24 * n], TVert[22 + 24 * n], TVert[23 + 24 * n],
                     0.0f, 0.0f, -0.5f));
            n++;
            cuerpo.poligonos.Add("Left Side",
                new(TVert[0 + 24 * n], TVert[1 + 24 * n], TVert[2 + 24 * n], TVert[3 + 24 * n], TVert[4 + 24 * n], TVert[5 + 24 * n],
                    TVert[6 + 24 * n], TVert[7 + 24 * n], TVert[8 + 24 * n], TVert[9 + 24 * n], TVert[10 + 24 * n], TVert[11 + 24 * n],
                    TVert[12 + 24 * n], TVert[13 + 24 * n], TVert[14 + 24 * n], TVert[15 + 24 * n], TVert[16 + 24 * n], TVert[17 + 24 * n],
                    TVert[18 + 24 * n], TVert[19 + 24 * n], TVert[20 + 24 * n], TVert[21 + 24 * n], TVert[22 + 24 * n], TVert[23 + 24 * n],
                    -0.5f, 0.0f, 0.0f));
            n++;
            cuerpo.poligonos.Add("Right Side",
                new(TVert[0 + 24 * n], TVert[1 + 24 * n], TVert[2 + 24 * n], TVert[3 + 24 * n], TVert[4 + 24 * n], TVert[5 + 24 * n],
                    TVert[6 + 24 * n], TVert[7 + 24 * n], TVert[8 + 24 * n], TVert[9 + 24 * n], TVert[10 + 24 * n], TVert[11 + 24 * n],
                    TVert[12 + 24 * n], TVert[13 + 24 * n], TVert[14 + 24 * n], TVert[15 + 24 * n], TVert[16 + 24 * n], TVert[17 + 24 * n],
                    TVert[18 + 24 * n], TVert[19 + 24 * n], TVert[20 + 24 * n], TVert[21 + 24 * n], TVert[22 + 24 * n], TVert[23 + 24 * n],
                     0.5f, 0.0f, 0.0f));
            TShape.partes.Add("Cuerpo", cuerpo);
            return TShape;
        }

        public TObject() { }

    }
}

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
            -1.5f, 0.0f, -0.5f,  1.0f, 1.0f, 1.0f,
             1.5f, 0.0f, -0.5f,  1.0f, 1.0f, 1.0f,
            -1.5f, 0.0f,  0.5f,  0.0f, 0.0f, 0.0f,
             1.5f, 0.0f,  0.5f,  0.0f, 0.0f, 0.0f,
            //bottom left face
            -0.5f, 0.0f, -0.5f,  1.0f, 1.0f, 1.0f,
             0.5f, 0.0f, -0.5f,  1.0f, 1.0f, 1.0f,
            -0.5f, 0.0f,  0.5f,  0.0f, 0.0f, 0.0f,
             0.5f, 0.0f,  0.5f,  0.0f, 0.0f, 0.0f,
            //bottom right face
             0.5f, 0.0f, -0.5f,  1.0f, 1.0f, 1.0f,
            -0.5f, 0.0f, -0.5f,  1.0f, 1.0f, 1.0f,
             0.5f, 0.0f,  0.5f,  0.0f, 0.0f, 0.0f,
            -0.5f, 0.0f,  0.5f,  0.0f, 0.0f, 0.0f,
            //bottom middle face
            -0.5f, 0.0f, -0.5f,  1.0f, 1.0f, 1.0f,
             0.5f, 0.0f, -0.5f,  1.0f, 1.0f, 1.0f,
            -0.5f, 0.0f,  0.5f,  0.0f, 0.0f, 0.0f,
             0.5f, 0.0f,  0.5f,  0.0f, 0.0f, 0.0f,
            //front head
            -1.5f, 0.5f,  0.0f,  0.0f, 0.0f, 0.0f,
             1.5f, 0.5f,  0.0f,  0.0f, 0.0f, 0.0f,
            -1.5f,-0.5f,  0.0f,  0.0f, 0.0f, 0.0f,
             1.5f,-0.5f,  0.0f,  0.0f, 0.0f, 0.0f,
            //front body
            -0.5f, 1.0f,  0.0f,  0.0f, 0.0f, 0.0f,
             0.5f, 1.0f,  0.0f,  0.0f, 0.0f, 0.0f,
            -0.5f,-1.0f,  0.0f,  0.0f, 0.0f, 0.0f,
             0.5f,-1.0f,  0.0f,  0.0f, 0.0f, 0.0f,
            //back head
            -1.5f, 0.5f,  0.0f,  1.0f, 1.0f, 1.0f,
             1.5f, 0.5f,  0.0f,  1.0f, 1.0f, 1.0f,
            -1.5f,-0.5f,  0.0f,  1.0f, 1.0f, 1.0f,
             1.5f,-0.5f,  0.0f,  1.0f, 1.0f, 1.0f,
            //back body
            -0.5f, 1.0f,  0.0f,  1.0f, 1.0f, 1.0f,
             0.5f, 1.0f,  0.0f,  1.0f, 1.0f, 1.0f,
            -0.5f,-1.0f,  0.0f,  1.0f, 1.0f, 1.0f,
             0.5f,-1.0f,  0.0f,  1.0f, 1.0f, 1.0f,
            //left side head
             0.0f, 0.5f, -0.5f,  1.0f, 1.0f, 1.0f,
             0.0f, 0.5f,  0.5f,  0.0f, 0.0f, 0.0f,
             0.0f,-0.5f, -0.5f,  1.0f, 1.0f, 1.0f,
             0.0f,-0.5f,  0.5f,  0.0f, 0.0f, 0.0f,
            //right side head
             0.0f, 0.5f, -0.5f,  1.0f, 1.0f, 1.0f,
             0.0f, 0.5f,  0.5f,  0.0f, 0.0f, 0.0f,
             0.0f,-0.5f, -0.5f,  1.0f, 1.0f, 1.0f,
             0.0f,-0.5f,  0.5f,  0.0f, 0.0f, 0.0f,
            //left side body
             0.0f, 1.0f, -0.5f,  1.0f, 1.0f, 1.0f,
             0.0f, 1.0f,  0.5f,  0.0f, 0.0f, 0.0f,
             0.0f,-1.0f, -0.5f,  1.0f, 1.0f, 1.0f,
             0.0f,-1.0f,  0.5f,  0.0f, 0.0f, 0.0f,
            //right side head
             0.0f, 1.0f, -0.5f,  1.0f, 1.0f, 1.0f,
             0.0f, 1.0f,  0.5f,  0.0f, 0.0f, 0.0f,
             0.0f,-1.0f, -0.5f,  1.0f, 1.0f, 1.0f,
             0.0f,-1.0f,  0.5f,  0.0f, 0.0f, 0.0f


        };

        private Vector4 pos;
        public Escenario escenario;

        public void forgot(float x = 0.0f, float y = 0.0f, float z = 0.0f, string name = "TShape")
        {
            escenario.objetos.Add(name, new(x, y, z));
            escenario.objetos[name].partes.Add("cabeza", new(0.0f, 2.5f, 0.0f));
            escenario.objetos[name].partes["cabeza"].poligonos.Add("Top",
                new(vertices[0], vertices[1], vertices[2], vertices[3], vertices[4], vertices[5],
                    vertices[6], vertices[7], vertices[8], vertices[9], vertices[10], vertices[11],
                    vertices[12], vertices[13], vertices[14], vertices[15], vertices[16], vertices[17],
                    vertices[18], vertices[19], vertices[20], vertices[21], vertices[22], vertices[23],
                     0.0f, 0.5f, 0.0f));
            escenario.objetos[name].partes["cabeza"].poligonos.Add("Bottom Left",
                new(vertices[24], vertices[25], vertices[26], vertices[27], vertices[28], vertices[29],
                    vertices[30], vertices[31], vertices[32], vertices[33], vertices[34], vertices[35],
                    vertices[36], vertices[37], vertices[38], vertices[39], vertices[40], vertices[41],
                    vertices[42], vertices[43], vertices[44], vertices[45], vertices[46], vertices[47],
                    -1.0f, -0.5f, 0.0f));
            escenario.objetos[name].partes["cabeza"].poligonos.Add("Bottom Right",
                new(vertices[48], vertices[49], vertices[50], vertices[51], vertices[52], vertices[53],
                    vertices[54], vertices[55], vertices[56], vertices[57], vertices[58], vertices[59],
                    vertices[60], vertices[61], vertices[62], vertices[63], vertices[64], vertices[65],
                    vertices[66], vertices[67], vertices[68], vertices[69], vertices[70], vertices[71],
                     1.0f, -0.5f, 0.0f));
            escenario.objetos[name].partes["cabeza"].poligonos.Add("Front",
                new(vertices[96], vertices[97], vertices[98], vertices[99], vertices[100], vertices[101],
                    vertices[102], vertices[103], vertices[104], vertices[105], vertices[106], vertices[107],
                    vertices[108], vertices[109], vertices[110], vertices[111], vertices[112], vertices[113],
                    vertices[114], vertices[115], vertices[116], vertices[117], vertices[118], vertices[119],
                     0.0f, 0.0f, 0.5f));
            escenario.objetos[name].partes["cabeza"].poligonos.Add("Back",
                new(vertices[144], vertices[145], vertices[146], vertices[147], vertices[148], vertices[149],
                    vertices[150], vertices[151], vertices[152], vertices[153], vertices[154], vertices[155],
                    vertices[156], vertices[157], vertices[158], vertices[159], vertices[160], vertices[161],
                    vertices[162], vertices[163], vertices[164], vertices[165], vertices[166], vertices[167],
                     0.0f, 0.0f, -0.5f));
            escenario.objetos[name].partes["cabeza"].poligonos.Add("Left Side",
                new(vertices[192], vertices[193], vertices[194], vertices[195], vertices[196], vertices[197],
                    vertices[198], vertices[199], vertices[200], vertices[201], vertices[202], vertices[203],
                    vertices[204], vertices[205], vertices[206], vertices[207], vertices[208], vertices[209],
                    vertices[210], vertices[211], vertices[212], vertices[213], vertices[214], vertices[215],
                    -1.5f, 0.0f, 0.0f));
            escenario.objetos[name].partes["cabeza"].poligonos.Add("Right Side",
                new(vertices[216], vertices[217], vertices[218], vertices[219], vertices[220], vertices[221],
                    vertices[222], vertices[223], vertices[224], vertices[225], vertices[226], vertices[227],
                    vertices[228], vertices[229], vertices[230], vertices[231], vertices[232], vertices[233],
                    vertices[234], vertices[235], vertices[236], vertices[237], vertices[238], vertices[239],
                    1.5f, 0.0f, 0.0f));

            escenario.objetos[name].partes.Add("cuerpo", new(0.0f, 1.0f, 0.0f));
            escenario.objetos[name].partes["cuerpo"].poligonos.Add("Bottom",
                new(vertices[72], vertices[73], vertices[74], vertices[75], vertices[76], vertices[77],
                    vertices[78], vertices[79], vertices[80], vertices[81], vertices[82], vertices[83],
                    vertices[84], vertices[85], vertices[86], vertices[87], vertices[88], vertices[89],
                    vertices[90], vertices[91], vertices[92], vertices[93], vertices[94], vertices[95],
                    0.0f, -1.0f, 0.0f));
            escenario.objetos[name].partes["cuerpo"].poligonos.Add("Front",
                new(vertices[120], vertices[121], vertices[122], vertices[123], vertices[124], vertices[125],
                    vertices[126], vertices[127], vertices[128], vertices[129], vertices[130], vertices[131],
                    vertices[132], vertices[133], vertices[134], vertices[135], vertices[136], vertices[137],
                    vertices[138], vertices[139], vertices[140], vertices[141], vertices[142], vertices[143],
                     0.0f, 0.0f, 0.5f));
            escenario.objetos[name].partes["cuerpo"].poligonos.Add("Back",
                new(vertices[168], vertices[169], vertices[170], vertices[171], vertices[172], vertices[173],
                    vertices[174], vertices[175], vertices[176], vertices[177], vertices[178], vertices[179],
                    vertices[180], vertices[181], vertices[182], vertices[183], vertices[184], vertices[185],
                    vertices[186], vertices[187], vertices[188], vertices[189], vertices[190], vertices[191],
                     0.0f, 0.0f, -0.5f));
            escenario.objetos[name].partes["cuerpo"].poligonos.Add("Left Side",
                new(vertices[240], vertices[241], vertices[242], vertices[243], vertices[244], vertices[245],
                    vertices[246], vertices[247], vertices[248], vertices[249], vertices[250], vertices[251],
                    vertices[252], vertices[253], vertices[254], vertices[255], vertices[256], vertices[257],
                    vertices[258], vertices[259], vertices[260], vertices[261], vertices[262], vertices[263],
                    -0.5f, 0.0f, 0.0f));
            escenario.objetos[name].partes["cuerpo"].poligonos.Add("Right Side",
                new(vertices[264], vertices[265], vertices[266], vertices[267], vertices[268], vertices[269],
                    vertices[270], vertices[271], vertices[272], vertices[273], vertices[274], vertices[275],
                    vertices[276], vertices[277], vertices[278], vertices[279], vertices[280], vertices[281],
                    vertices[282], vertices[283], vertices[284], vertices[285], vertices[286], vertices[287],
                     0.5f, 0.0f, 0.0f));
        }
        public TObject(float x = 0.0f, float y = 0.0f, float z = 0.0f)
        {
            escenario = new();
            forgot(x,y,z);
        }

        public void draw(Shader shader)
        {
            escenario.Draw(shader);
        }

    }
}

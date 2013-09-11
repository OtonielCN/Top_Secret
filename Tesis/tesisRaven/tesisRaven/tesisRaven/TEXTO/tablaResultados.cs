using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace tesisRaven.TEXTO
{
    class tablaResultados:Text
    {
        private string result;
        private Rectangle[] rectTabla;
        private Vector2[,] vect;
        private int posx = 330;
        private int posy = 125;
        private string[] res;
        private int[] numeros;
        private int posicion2;
        private Vector2[] posicionNum;
        private int numR;
        //private int[]

        public tablaResultados(string ruta)
            : base(ruta)
        {
            rectTabla = new Rectangle[40];
            vect = new Vector2[10,4];
            res = new string[41];
            posicionNum = new Vector2[10];
            crearRectangulos();
            
            //crearRectangulos();
        }

        public override void LoadContent(ContentManager Content)
        {
            base.LoadContent(Content);
        }

        public override void Draw(SpriteBatch sprite)
        {
            //base.Draw(sprite);
            int p = 0;
            sprite.Begin();

            for (int j = (posicion2-1)*10; j <(posicion2*10); j++)
            {
                if (j < numR)
                {
                    sprite.DrawString(fuente, numeros[j].ToString(), posicionNum[p], Color.Red);
                    p++;
                    if (p == 10)
                        p = 0;
                }
                else
                    break;
            }

            int e=1;
                for (int n = 0; n < res.Length/4; n++)
                {
                    for (int m = 0; m < 4; m++)
                    {
                        sprite.DrawString(fuente, res[e], vect[n,m], color);
                        e++;
                    }
                }
            sprite.End();
        }

        public override void UpDate(string r,int numReg,int pos)
        {
            numR = numReg;
            numeros = new int[numReg];
            for (int i = 0; i < numReg; i++)
            {
                numeros[i] = (i + 1);
            }
            posicion2 = pos;
            result = r;
            if (result.Length > 0)
            {
                //calcular el ancho de cada uno de los datos de la tabla
                //calcularAnchoTabla();
            }
            res = result.Split('-');
            //base.UpDate();
        }

        public string _Resultados
        {
            get { return result; }
            set { result = value; }
        }

        private void crearRectangulos()
        {
            for(int i=0; i<10; i++)
            {
                    for (int j = 0; j < 4; j++)
                    {
                        vect[i,j] = new Vector2(posx, posy);
                        switch (j)
                        {
                            case 0:
                                posx += 300;
                                break;
                            case 1:
                                posx += 60;
                                break;
                            case 2:
                                posx += 160;
                                break;
                            case 3:
                                posx += 210;
                                break;
                        }
                    }
                    posx = 330;
                    posy += 45;
            }

            for (int i = 0; i < 10; i++)
            {
                posicionNum[i] = new Vector2(250, 125 + i*45);
            }

        }

    }
}

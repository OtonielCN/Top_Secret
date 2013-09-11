using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace tesisRaven.SPRITE.Plantilla
{
    class plantillaRectResp
    {
        private int aciertos;
        private int altoRectResp;
        private int anchoRectResp;
        private int totalPlantillas;
        private int[] respuestas = new int[36]; // Total de respuestas
        private int[] resp_correct = new int[36] {4, 5, 1, 2, 6, 3, 6, 2, 1, 3, 4, 5, 
                                          4, 5, 1, 6, 2, 1, 3, 4, 6, 3, 5, 2, 
                                            2, 6, 1, 2, 1, 3, 5, 6, 4, 3, 4, 5}; //Respuestas correctas
        private int posicion;

        private Rectangle resp1;
        private Rectangle resp2;
        private Rectangle resp3;
        private Rectangle resp4;
        private Rectangle resp5;
        private Rectangle resp6;
        private Rectangle colision;

        private bool regresar = false;// I
        private bool llave;
        private bool fin = false;// I

        public plantillaRectResp()
        {
            totalPlantillas = 36;
            llave = true; //I
            posicion = 0;// I
            anchoRectResp = 141;
            altoRectResp = 86;
            aciertos = 0;// I
            crearRectagunlosResp();
        }

        public void UpDate(Rectangle rectColision, MouseState mouse,bool activar)
        {
            colision = rectColision;
            if (!activar)
            {
                if (mouse.LeftButton == ButtonState.Pressed && llave)
                {
                    llave = false;
                    if (posicion < totalPlantillas && detectarEleccion())
                    {
                        posicion += 1;
                    }
                }
            }
            else
                regresar = false;
                if (mouse.LeftButton == ButtonState.Released)
                {
                    //regresar = false;
                    llave = true;
                }

            //}
            if (posicion == totalPlantillas)
            {
                for (int f = 0; f < totalPlantillas; f++)
                    if (respuestas[f] == resp_correct[f])
                        aciertos += 1;
                fin = true;
            }//Cambiar el estado a fin
        }

        private void crearRectagunlosResp()
        {
            resp1 = new Rectangle(449, 423, anchoRectResp, altoRectResp);
            resp2 = new Rectangle(619, 423, anchoRectResp, altoRectResp);
            resp3 = new Rectangle(789, 423, anchoRectResp, altoRectResp);
            resp4 = new Rectangle(449, 561, anchoRectResp, altoRectResp);
            resp5 = new Rectangle(619, 561, anchoRectResp, altoRectResp);
            resp6 = new Rectangle(789, 561, anchoRectResp, altoRectResp);
        }

        private bool detectarEleccion()
        {
            if (colision.Intersects(resp1))
            {
                respuestas[posicion] = 1;
                regresar = true;
                return true;
            }

            else if (colision.Intersects(resp2))
            {
                respuestas[posicion] = 2;
                regresar = true;
                return true;
            }

            else if (colision.Intersects(resp3))
            {
                respuestas[posicion] = 3;
                regresar = true;
                return true;
            }

            else if (colision.Intersects(resp4))
            {
                respuestas[posicion] = 4;
                regresar = true;
                return true;
            }

            else if (colision.Intersects(resp5))
            {
                respuestas[posicion] = 5;
                regresar = true;
                return true;
            }

            else if (colision.Intersects(resp6))
            {
                respuestas[posicion] = 6;
                regresar = true;
                return true;
            }

            else
                return false;
        }

        public int _Posicion
        {
            get { return posicion; }
        }

        public int _Aciertos
        {
            get { return aciertos; }
        }

        public bool _Fin
        {
            get { return fin; }
        }

        public bool _Regresar
        {
            get { return regresar; }
        }

        public void reIniciar()
        {
            fin = false;
            regresar = false;
            aciertos = 0;
            posicion = 0;
        }
    }
}

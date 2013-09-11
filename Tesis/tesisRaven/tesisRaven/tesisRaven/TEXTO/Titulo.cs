using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace tesisRaven
{
    class Titulo : Text
    {
        private int altoVentana;
        private int anchoVentana;

        private int Red;
        private int Green;
        private int Blue;

        private float altoMensaje;
        private float anchoMensaje;

        private bool controlR = true;
        private bool controlG = true;
        private bool controlB = true;

        private Color colorActual;

        //private SpriteBatch sprite;

        //public Titulo(string texto) : base(texto) { }

        public Titulo(string texto, int alto, int ancho, string ruta, ContentManager Content)
            : base(texto, Content, ruta)
        {
            this.altoVentana = alto;
            this.anchoVentana = ancho;

            //this.colorActual = new Color(0, 0, 0, 1000);
            this.Red = 0;
            this.Green = 80;
            this.Blue = 160;
            //this.sprite = new SpriteBatch(grd);
        }

        public Titulo(string texto, ContentManager Content, string ruta, int x, int y)
            : base(texto, Content, ruta, x, y)
        { }

        public override void LoadContent(Microsoft.Xna.Framework.Content.ContentManager Content)
        {
            base.LoadContent(Content);
            this.anchoMensaje = calcular_Ancho_y_Alto_String.CalcularDimensiones(base.Fuente, base.Texto).X;
            this.altoMensaje = calcular_Ancho_y_Alto_String.CalcularDimensiones(base.Fuente, base.Texto).Y;
            //base.Posicion = new Vector2(anchoMensaje, altoMensaje);
        }

        public override void UpDate()
        {
            cambiarColor();
            //base.UpDate();
        }

        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch sprite)
        {
            colorActual = new Color(0, 0, 0, 20);
            base.posicion = new Vector2((anchoVentana - (anchoMensaje / 2) / 2), 100/*(((altoVentana) - altoMensaje) / 2) - altoMensaje*/);
            sprite.Begin();
            crearSombra(sprite);
            colorActual = Color.Silver;
            efecto(sprite);
            sprite.DrawString(base.Fuente, base.Texto, base.Posicion, new Color(Red, Green, Blue));
            sprite.End();
            //base.Draw(sprite);
        }

        public override void Draw2(SpriteBatch sprite)
        {
            colorActual = new Color(0, 0, 0, 20);
            base.posicion = new Vector2(300, 130);
            sprite.Begin();
            //crearSombra(sprite);
            colorActual = Color.Silver;
            efecto(sprite);
            sprite.DrawString(base.Fuente, base.Texto, base.Posicion, new Color(Red, Green, Blue));
            sprite.End();
            //base.Draw2(sprite);
        }

        private void cambiarColor()
        {
            if (Red == 200)
                controlR = false;
            if (Red == 50)
                controlR = true;
            if (controlR)
                Red++;
            else
                Red--;

            if (Green == 255)
                controlG = false;
            if (Green == 10)
                controlG = true;
            if (controlG)
                Green++;
            else
                Green--;

            if (Blue == 250)
                controlB = false;
            if (Blue == 100)
                controlB = true;
            if (controlB)
                Blue++;
            else
                Blue--;
        }

        private void crearSombra(SpriteBatch sprite)
        {
            for (int i = 0; i < 10; i++)
            {
                //sprite.Begin();
                sprite.DrawString(base.fuente, base.Texto, base.Posicion, colorActual);
                //sprite.End();
                base.posicion.X++;
                base.posicion.Y++;
            }
        }

        private void efecto(SpriteBatch sprite)
        {
            for (int i = 0; i < 5; i++)
            {
                //sprite.Begin();
                sprite.DrawString(base.fuente, base.Texto, base.Posicion, colorActual);
                //sprite.End();
                base.posicion.X++;
                base.posicion.Y++;
            }
        }
    }
}

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
    class Menu : Text
    {
        private int numeroElementos;
        private int elementoActivo = 0;

        private int separacion;

        private string[] elementos;

        private Color elementoSeleccionado;
        private Color elementonoSeleccionado;

        private bool teclaUppresionada;
        private bool teclaDownpresionada;
        private bool activarSonido;
        private bool darClick = false;

        private Rectangle[] rectangulosOpciones;
        private Rectangle rectMouse;

        private generaSonido sonido;

        public Menu(int x, int y, int separacion, string ruta, string[] opcsMenu)
            : base(x, y, ruta)
        {
            this.elementos = new string[opcsMenu.Length];
            this.numeroElementos = opcsMenu.Length;
            this.elementoSeleccionado = Color.Red;
            this.elementonoSeleccionado = Color.Blue;
            this.elementos = new string[this.numeroElementos];
            this.separacion = separacion;
            this.rectangulosOpciones = new Rectangle[numeroElementos];

            for (int i = 0; i < numeroElementos; i++)
            {
                rectangulosOpciones[i] = new Rectangle();
                this.elementos[i] = opcsMenu[i];
            }

            sonido = new generaSonido("Content\\Sonido\\gameAudio.xgs", "Content\\Sonido\\");
        }

        //public Menu(string texto, int x, int y, string ruta) : base(texto, x, y,ruta) { }

        public override void LoadContent(Microsoft.Xna.Framework.Content.ContentManager Content)
        {
            base.LoadContent(Content);
            tamanyoMenu();
        }

        public override void UpDate()
        {
            KeyboardState tecla = Keyboard.GetState();
            MouseState estMouse = Mouse.GetState();
            rectMouse = new Rectangle(estMouse.X, estMouse.Y, 1, -10);
            Click();
            Teclas(tecla);
            //base.UpDate();
        }

        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch sprite)
        {
            sprite.Begin();

            for (int i = 0; i < numeroElementos; i++)
            {
                if (elementoActivo == i)
                {
                    sprite.DrawString(base.Fuente, elementos[i].ToString(), new Vector2(rectangulosOpciones[i].X,rectangulosOpciones[i].Y), elementoSeleccionado);

                }
                else
                {
                    sprite.DrawString(base.Fuente, elementos[i].ToString(), new Vector2(rectangulosOpciones[i].X, rectangulosOpciones[i].Y), elementonoSeleccionado);
                }
            }

            //sprite.DrawString(fuente, rectangulosOpciones[0].X.ToString()+" "+rectangulosOpciones[0].Y.ToString()+" "+rectangulosOpciones[0].Width+" "+rectangulosOpciones[0].Height, new Vector2(300, 100), Color.Black);
            //sprite.DrawString(fuente, rectangulosOpciones[1].X.ToString() + " " + rectangulosOpciones[1].Y.ToString() + " " + rectangulosOpciones[1].Width + " " + rectangulosOpciones[1].Height, new Vector2(300, 150), Color.Black);
            //sprite.DrawString(fuente, rectangulosOpciones[2].X.ToString() + " " + rectangulosOpciones[2].Y.ToString() + " " + rectangulosOpciones[2].Width + " " + rectangulosOpciones[2].Height, new Vector2(300, 200), Color.Black);
            //sprite.DrawString(fuente, rectangulosOpciones[3].X.ToString() + " " + rectangulosOpciones[3].Y.ToString() + " " + rectangulosOpciones[3].Width + " " + rectangulosOpciones[3].Height, new Vector2(300, 250), Color.Black);
            //sprite.DrawString(fuente, Mouse.GetState().X.ToString() + " " + Mouse.GetState().Y.ToString(), new Vector2(300, 300), Color.Black);
            sprite.End();
            //base.Draw(sprite);
        }

        public void agregarElementos(int indice, string elemento)
        {
            if ((indice > -1) && (indice < numeroElementos))
            {
                elementos[indice] = elemento;
            }
        }

        private void Teclas(KeyboardState tecla)
        {
            if (tecla.IsKeyDown(Keys.Up) && teclaUppresionada)
            {
                this.elementoPrevio();
                teclaUppresionada = false;
                sonido.playSonido("item");
            }
            else
            {
                if (tecla.IsKeyUp(Keys.Up))
                {
                    teclaUppresionada = true;
                }
            }

            if (tecla.IsKeyDown(Keys.Down) && teclaDownpresionada)
            {
                this.proximoElemento();
                teclaDownpresionada = false;
                sonido.playSonido("item");
            }
            else
            {
                if (tecla.IsKeyUp(Keys.Down))
                {
                    teclaDownpresionada = true;
                }
            }
        }

        private void proximoElemento()
        {
            if (elementoActivo < numeroElementos - 1)
            {
                elementoActivo++;
            }
            else
                elementoActivo = 0;
        }

        private void elementoPrevio()
        {
            if (elementoActivo > 0)
            {
                elementoActivo--;
            }
            else
                elementoActivo = numeroElementos - 1;
        }

        public void tamanyoMenu()
        {
            float ancho = 0, alto = 0;
            for (int i = 0; i < numeroElementos; i++)
            {
                ancho = calcular_Ancho_y_Alto_String.CalcularDimensiones(fuente, elementos[i]).X;
                alto = calcular_Ancho_y_Alto_String.CalcularDimensiones(fuente, elementos[i]).Y-20;
                rectangulosOpciones[i] = new Rectangle((800 / 2) + 100, 300+((int)alto+separacion)*i, (int)ancho, (int)alto);
            }
        }

        public string obtenerOpcion()
        {
            return elementos[elementoActivo];
        }

        public bool _darClick
        {
            get { return darClick; }
        }

        private void Click()
        {
            if (rectangulosOpciones[0].Intersects(rectMouse))
            {

                if (activarSonido || elementoActivo != 0)
                {
                    sonido.playSonido("item");
                    activarSonido = false;
                }
                elementoActivo = 0;
                darClick = true;
            }
            else if (rectangulosOpciones[1].Intersects(rectMouse))
            {
                if (activarSonido || elementoActivo != 1)
                {
                    sonido.playSonido("item");
                    activarSonido = false;
                }
                elementoActivo = 1;
                darClick = true;
            }
            else if (rectangulosOpciones[2].Intersects(rectMouse))
            {

                if (activarSonido || elementoActivo != 2)
                {
                    sonido.playSonido("item");
                    activarSonido = false;
                }
                elementoActivo = 2;
                darClick = true;
            }
            else if (rectangulosOpciones[3].Intersects(rectMouse))
            {
                if (activarSonido || elementoActivo != 3)
                {
                    sonido.playSonido("item");
                    activarSonido = false;
                }
                elementoActivo = 3;
                darClick = true;
            }
            else
            {
                activarSonido = true;
                darClick = false;
            }
        }
    }
}

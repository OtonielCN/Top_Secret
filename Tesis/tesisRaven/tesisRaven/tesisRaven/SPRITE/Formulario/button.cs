using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace tesisRaven.SPRITE.Formulario
{
    class button : Sprite
    {
        private bool llave = true;
        private bool posicionado = false;
        protected bool enable;
        private bool empezar = false;
        private bool presionarBoton = false;

        protected string btText;

        private SpriteFont fuenteText;
        private Vector2 posicionText;
        private Color pulsado;
        protected Color noPulsado;


        public button(int ancho, int alto, int x, int y, int xString, int yString, string ruta, bool enable, string texto)
            : base(ancho, alto, x, y, ruta)
        {
            this.enable = enable;
            if (this.enable == false)
                this.noPulsado = Color.Silver;
            else
                this.noPulsado = Color.Black;
            this.btText = texto;
            this.posicionText = new Vector2(x + xString, y + yString);
            this.pulsado = Color.Red;
        }

        public override void LoadContent(ContentManager Content)
        {
            fuenteText = Content.Load<SpriteFont>(@"Fuentes\fuenteLb");
            base.LoadContent(Content);
        }

        public override void UpDate(Rectangle colision, MouseState mouse)
        {

            if (enable)
            {
                noPulsado = Color.Black;
                if (rectanguloColision.Intersects(colision))
                {
                    llave = false;
                    posicionado = true;
                    noPulsado = pulsado;

                    if (mouse.LeftButton == ButtonState.Pressed)
                    {
                        presionarBoton = true;
                    }

                    else if (mouse.LeftButton == ButtonState.Released && presionarBoton)
                    {
                        presionarBoton = false;
                        empezar = true;
                    }

                }
                else if (posicionado)
                {
                    //presionarBoton = false;
                    llave = true;
                    posicionado = false;
                    noPulsado = Color.Black;
                }

            }
            else
            {
                noPulsado = Color.Silver;
                posicionado = false;
                llave = true;
            }
        }

        public override void Draw(SpriteBatch sprite)
        {
            if (llave && !posicionado)
            {
                base.Draw(sprite);
            }
            
            else if (posicionado)
            {
                sprite.Begin();
                sprite.Draw(imagen, posicionImagen, new Color(217, 238, 246));
                sprite.End();
            }

            sprite.Begin();
            sprite.DrawString(fuenteText, btText, posicionText, noPulsado);
            sprite.End();
        }

        public bool _Empezar
        {
            get { return this.empezar; }
            set { empezar = value; }
        }

        public bool _Posicionado
        {
            get { return posicionado; }
            set { posicionado = value; }
        }

        
    }
}

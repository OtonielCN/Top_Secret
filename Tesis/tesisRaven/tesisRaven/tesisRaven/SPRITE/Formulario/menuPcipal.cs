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
    class menuPcipal:Sprite
    {
        private bool over = false;
        private bool pulsado = false;
        public menuPcipal(int ancho, int alto, int x, int y, string ruta)
            : base(ancho, alto, x, y, ruta)
        {
        }

        public override void LoadContent(ContentManager Content)
        {
            base.LoadContent(Content);
        }

        public override void UpDate(Rectangle colision, MouseState mouse)
        {
            //base.UpDate(colision);
            mouseOver(colision,mouse);
        }

        public override void Draw(SpriteBatch sprite)
        {
            sprite.Begin();
            if (over)
            {
                sprite.Draw(imagen, posicionImagen, Color.White);               
            }
            else
            {
                sprite.Draw(imagen, posicionImagen, new Color(240, 194, 194, 150));
                //base.Draw(sprite);
            }
            sprite.End();
        }

        public void mouseOver(Rectangle colision,MouseState mouse)
        {
            if (rectanguloColision.Intersects(colision))
            {
                over = true;
                if (mouse.LeftButton == ButtonState.Pressed)
                {
                    pulsado = true;
                }
            }
            else
            {
                over = false;
                if (mouse.LeftButton == ButtonState.Released)
                {
                    pulsado = false;
                }
            }
        }

        public bool Click
        {
            get { return pulsado; }
            set { pulsado = value; }
        }

        public bool _Pulsado
        {
            set { over = value; }
        }
    }
}

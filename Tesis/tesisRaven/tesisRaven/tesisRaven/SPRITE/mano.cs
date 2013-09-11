using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace tesisRaven.SPRITE
{
    class mano:Sprite
    {
        private Texture2D manopulsada;
        private bool chooseImg = true;

        public mano(int x, int y, int ancho, int alto, string ruta)
            : base(alto, ancho, x, y, ruta)
        { }

        public override void LoadContent(ContentManager Content)
        {
            manopulsada = Content.Load<Texture2D>(@"Imagenes\manoP");
            base.LoadContent(Content);
        }

        public override void UpDate(MouseState mouseEstado)
        {
            if (mouseEstado.LeftButton == ButtonState.Pressed)
            {
                chooseImg = false;
            }
            if (mouseEstado.LeftButton == ButtonState.Released)
            {
                chooseImg = true;
            }

            base.UpDate(mouseEstado);
        }

        public override void Draw(SpriteBatch sprite)
        {
            if (chooseImg)
            {
                base.Draw(sprite);
            }
            else
            {
                sprite.Begin();
                sprite.Draw(manopulsada, base.posicionImagen, Color.White);
                sprite.End();
            }
        }
    }
}

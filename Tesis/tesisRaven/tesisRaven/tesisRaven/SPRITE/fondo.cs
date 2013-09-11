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
    class fondo : Sprite
    {
        private Vector2 posicionFondo;
        private Vector2 posicionFondo2;
        private Vector2 posicionFondo3;

        private bool llave = true;

        private int velocidad = 2;
        private int velocidad2 = 3;

        public fondo(string ruta)
            : base(ruta)
        {
            this.anchoImagen = 1280;
            this.altoImagen = 704;
            this.rectanguloColision = new Rectangle(0, 0, anchoImagen, altoImagen);
            this.posicionImagen = new Vector2(0, 0);
            this.posicionFondo = new Vector2(0, -704);
            this.posicionFondo2 = new Vector2(1280, -704);
            this.posicionFondo3 = new Vector2(1280, 0);
        }

        public override void LoadContent(ContentManager Content)
        {
            base.LoadContent(Content);
        }

        public override void UpDate()
        {
            posicion();
            //base.UpDate();
        }

        private void posicion()
        {
            if (llave)
            {
                posicionImagen.X -= velocidad2;
                posicionImagen.Y += velocidad;
                posicionFondo.X -= velocidad2;
                posicionFondo.Y += velocidad;
                posicionFondo2.X -= velocidad2;
                posicionFondo2.Y += velocidad;
                posicionFondo3.X -= velocidad2;
                posicionFondo3.Y += velocidad;

                if (posicionFondo2.Y == 0)
                    llave = false;
            }

            else
            {
                posicionImagen.X += velocidad2;
                posicionImagen.Y -= velocidad;
                posicionFondo.X += velocidad2;
                posicionFondo.Y -= velocidad;
                posicionFondo2.X += velocidad2;
                posicionFondo2.Y -= velocidad;
                posicionFondo3.X += velocidad2;
                posicionFondo3.Y -= velocidad;

                if (posicionImagen.Y == 0)
                    llave = true;
            }
        }

        public override void Draw(SpriteBatch sprite)
        {
            //base.Draw(sprite);
            sprite.Begin();
            sprite.Draw(imagen, posicionImagen, rectanguloColision, Color.Orange);
            sprite.Draw(imagen, posicionFondo, rectanguloColision, Color.Green);
            sprite.Draw(imagen, posicionFondo2, rectanguloColision, Color.Blue);
            sprite.Draw(imagen, posicionFondo3, rectanguloColision, Color.Red);
            sprite.End();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace tesisRaven.SPRITE.Ayuda
{
    class respuesta : Sprite
    {
        public respuesta(string ruta)
            : base(ruta)
        {
            this.anchoImagen = 143;
            this.altoImagen = 88;
            this.posicionImagen = new Vector2(569, 394);
            this.rectanguloColision = new Rectangle(239, 394, anchoImagen, altoImagen);
        }

        public override void LoadContent(ContentManager Content)
        {
            base.LoadContent(Content);
        }

        public override void UpDate(int time)
        {
            //base.UpDate();
            if (time == 0)
            {
                this.posicionImagen = new Vector2(569, 394);
                this.rectanguloColision = new Rectangle(239, 394, anchoImagen, altoImagen);
            }

            else if (time == 18)
                this.posicionImagen = new Vector2(644, 196);

            else if (time == 20)
            {
                this.posicionImagen = new Vector2(748, 394);
                this.rectanguloColision = new Rectangle(418, 394, anchoImagen, altoImagen);
            }

            else if (time == 23)
                this.posicionImagen = new Vector2(644, 196);

        }

        public override void Draw2(SpriteBatch sprite)
        {
            base.Draw2(sprite);
        }

        public void inicializar()
        {
            this.anchoImagen = 143;
            this.altoImagen = 88;
            this.posicionImagen = new Vector2(569, 394);
            this.rectanguloColision = new Rectangle(239, 394, anchoImagen, altoImagen);
        }
    }
}

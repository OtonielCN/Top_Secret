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
    class lamina:Sprite 
    {
        public lamina(string ruta)
            : base(ruta)
        {
            this.altoImagen = 642;
            this.anchoImagen = 617;
            this.posicionImagen = new Vector2(330, 0);
            this.rectanguloColision = new Rectangle(0, 0, anchoImagen, altoImagen);
        }

        public override void LoadContent(ContentManager Content)
        {
            base.LoadContent(Content);
        }

        public override void UpDate(int time)
        {
            //base.UpDate();
        }

        public override void Draw2(SpriteBatch sprite)
        {
            base.Draw2(sprite);
        }
    }
}

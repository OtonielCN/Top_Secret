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
    class seleccion : Sprite
    {
        int tiempo;

        public seleccion(string ruta)
            : base(ruta)
        {
            this.anchoImagen = 178;
            this.altoImagen = 228;
            this.posicionImagen = new Vector2(540, 282);
            this.rectanguloColision = new Rectangle(431, 671, anchoImagen, altoImagen);
        }

        public override void LoadContent(ContentManager Content)
        {
            base.LoadContent(Content);
        }

        public override void UpDate(int time)
        {
            tiempo = time;
            if (time == 0)
            {
                this.posicionImagen = new Vector2(540, 282);
                this.rectanguloColision = new Rectangle(431, 671, anchoImagen, altoImagen);
            }

            else if (time == 20)
            {
                this.posicionImagen = new Vector2(720, 282);
                this.rectanguloColision = new Rectangle(248, 671, anchoImagen, altoImagen);
            }
            base.UpDate(time);
        }

        public override void Draw2(SpriteBatch sprite)
        {
            //base.Draw2(sprite);
            if (tiempo > 15 && tiempo < 20)
                base.Draw2(sprite);
            else if (tiempo >= 21 && tiempo < 26)
                base.Draw2(sprite);
        }

        public void inicializar()
        {
            this.anchoImagen = 178;
            this.altoImagen = 228;
            this.posicionImagen = new Vector2(540, 282);
            this.rectanguloColision = new Rectangle(431, 671, anchoImagen, altoImagen);
            tiempo = 0;
        }
    }
}

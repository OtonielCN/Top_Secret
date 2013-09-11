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
    class acierto_desacierto:Sprite
    {
        int tiempo;

        public acierto_desacierto(string ruta)
            : base(ruta)
        {
            this.anchoImagen = 169;
            this.altoImagen = 121;
            this.posicionImagen = new Vector2(619, 178);
            this.rectanguloColision = new Rectangle(42, 846, anchoImagen, altoImagen);
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
                this.anchoImagen = 169;
                this.altoImagen = 121;
                this.posicionImagen = new Vector2(619, 178);
                this.rectanguloColision = new Rectangle(42, 846, anchoImagen, altoImagen);
            }

            else if (time == 20)
            {
                this.anchoImagen = 158;
                this.altoImagen = 109;
                this.posicionImagen = new Vector2(630, 178);
                this.rectanguloColision = new Rectangle(65, 683, anchoImagen, altoImagen);
            }
            base.UpDate(time);
        }

        public override void Draw2(SpriteBatch sprite)
        {
            //base.Draw2(sprite);
            if (tiempo == 19)
                base.Draw2(sprite);
            else if (tiempo == 24)
                base.Draw2(sprite);
        }

        public void inicializar()
        {
            this.anchoImagen = 169;
            this.altoImagen = 121;
            this.posicionImagen = new Vector2(619, 178);
            this.rectanguloColision = new Rectangle(42, 846, anchoImagen, altoImagen);
            tiempo = 0;
        }
    }
}

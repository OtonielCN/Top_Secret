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
    class albert : Sprite
    {
        private int estado = 0;

        public albert(int ancho, int alto, int x, int y, string ruta)
            : base(ancho, alto, x, y, ruta)
        { }

        public override void LoadContent(ContentManager Content)
        {
            base.LoadContent(Content);
        }

        public override void UpDate()
        {
            Estado(estado);
            base.UpDate();
        }

        public override void Draw(SpriteBatch sprite)
        {
            base.Draw2(sprite);
        }

        private void Estado(int est)
        {
            if (est >= 160)
            {
                estado = 0;
            }
            else if (est > 140)
            {
                rectanguloColision.X = 929;
                rectanguloColision.Y = 477;
            }
            else if (est > 120)
            {
                rectanguloColision.X = 642;
                rectanguloColision.Y = 477;
            }
            else if (est > 100)
            {
                rectanguloColision.X = 304;
                rectanguloColision.Y = 477;

            }
            else if (est > 80)
            {
                rectanguloColision.X = 20;
                rectanguloColision.Y = 477;

            }
            else if (est > 60)
            {
                rectanguloColision.X = 926;
                rectanguloColision.Y = 0;
            }
            else if (est > 40)
            {
                rectanguloColision.X = 639;
                rectanguloColision.Y = 0;
            }
            else if (est > 20)
            {
                rectanguloColision.X = 284;
                rectanguloColision.Y = 0;
            }
            else
            {
                rectanguloColision.X = 0;
                rectanguloColision.Y = 0;
            }
            estado += 1;
            CrearRectangulo(rectanguloColision.X, rectanguloColision.Y);
        }

        private void CrearRectangulo(int x, int y)
        {
            rectanguloColision = new Rectangle(x, y, anchoImagen, altoImagen);
        }

        public override Texture2D _Imagen
        {
            get
            {
                return base._Imagen;
            }
        }
    }
}

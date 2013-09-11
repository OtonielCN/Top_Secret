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
    class mensajeIMG : Sprite
    {
        private int estadoMensaje;

        public mensajeIMG()
            : base()
        {
            anchoImagen = 430;
            altoImagen = 400;
            posicionImagen = new Vector2(650, 5);
            estadoMensaje = 0;
        }

        public override void UpDate(Texture2D imgPlan, bool back)
        {
            Estadomen(estadoMensaje);
            base.UpDate(imgPlan, back);
        }

        public override void Draw2(SpriteBatch sprite)
        {
            base.Draw2(sprite);
        }

        public void Estadomen(int est)
        {
            if (est > 16)
            {
                rectanguloColision.X = 1319;
                rectanguloColision.Y = 1347;
            }
            else if (est > 13)
            {
                rectanguloColision.X = 885;
                rectanguloColision.Y = 1347;
            }
            else if (est > 10)
            {
                rectanguloColision.X = 451;
                rectanguloColision.Y = 1347;
            }
            else if (est > 8)
            {
                rectanguloColision.X = 17;
                rectanguloColision.Y = 1347;
            }
            else if (est > 5)
            {
                rectanguloColision.X = 1221;
                rectanguloColision.Y = 827;
            }
            else if (est > 2)
            {
                rectanguloColision.X = 1221;
                rectanguloColision.Y = 423;
            }
            else
            {
                rectanguloColision.X = 1221;
                rectanguloColision.Y = 18;
            }
            estadoMensaje += 1;
            rectanguloColision = new Rectangle((int)rectanguloColision.X, (int)rectanguloColision.Y, anchoImagen, altoImagen);
            //return estadomen;
        }

        public int _Estado
        {
            get { return estadoMensaje; }
            set { estadoMensaje = value; }
        }

    }
}

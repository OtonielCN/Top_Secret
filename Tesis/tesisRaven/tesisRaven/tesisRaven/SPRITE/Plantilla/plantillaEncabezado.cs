using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace tesisRaven.SPRITE.Plantilla
{
    class plantillaEncabezado : Sprite
    {
        private bool desplazar_plant;// I

        public plantillaEncabezado()
            : base()
        {
            posicionImagen = new Vector2(490, -318);// I
            anchoImagen = 364;
            altoImagen = 318;
            desplazar_plant = true;// I
            rectanguloColision = new Rectangle(77, 0, anchoImagen, altoImagen);
        }

        public override void UpDate(Texture2D imgPlantilla,bool back)
        {
            if (back)
            {
                valoresIniciales();
            }
            if (desplazar_plant)
            {
                posicionImagen.Y += 15;
                if (posicionImagen.Y >= 20)
                    desplazar_plant = false;
            }
            base.UpDate(imgPlantilla, back);
        }

        public override void Draw2(SpriteBatch sprite)
        {
            base.Draw2(sprite);
        }

        public void valoresIniciales()
        {
            posicionImagen = new Vector2(490, -318);
            rectanguloColision = new Rectangle(77, 0, anchoImagen, altoImagen);
            desplazar_plant = true;
        }

        public bool darClick
        {
            get { return desplazar_plant; }
        }
    }
}

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
    class plantillaRespuestas :Sprite
    {
        private List<Texture2D> plantillas;
        private int poscision;

        private bool desplazar_resp;
        private bool regresar;

        public plantillaRespuestas()
            : base()
        {
            plantillas = new List<Texture2D>();
            poscision = 0;// I
            posicionImagen = new Vector2(-481, 400);// I
            desplazar_resp = true;// I
            altoImagen = 249;
            anchoImagen = 481;
            rectanguloColision = new Rectangle(10, 377, anchoImagen, altoImagen);
        }

        public override void LoadContent(ContentManager Content)
        {
            for (int i = 1; i <= 36; i++)
            {
                plantillas.Add(Content.Load<Texture2D>(@"Imagenes\Laminas\" + i.ToString()));
            }
            //base.LoadContent(Content);
        }

        public override void UpDate(int pos,bool back)
        {
            regresar = back;
            if (regresar)
            {
                valoresIniciales();
            }
            if (desplazar_resp)
            {
                posicionImagen.X += 20;
                if (posicionImagen.X >= 430)
                    desplazar_resp = false;

            }
            if (pos < 36)
            {
                poscision = pos;
            }
            base.UpDate(pos,back);
        }

        public override void Draw2(SpriteBatch sprite)
        {
            imagen = plantillas[poscision];
            base.Draw2(sprite);
        }

        public Texture2D Imagen
        {
            get { return plantillas[poscision]; }
        }

        public void valoresIniciales()
        {
            posicionImagen = new Vector2(-481, 400);
            rectanguloColision = new Rectangle(10, 377, anchoImagen, altoImagen);
            desplazar_resp = true;
        }

        public bool darClick
        {
            get { return desplazar_resp; }
        }
    }
}

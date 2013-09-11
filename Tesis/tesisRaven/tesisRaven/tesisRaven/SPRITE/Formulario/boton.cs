using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace tesisRaven.SPRITE.Formulario
{
    class boton : button
    {
        public boton(int ancho, int alto, int x, int y, int xString, int yString, string ruta, bool enable, string texto)
            : base(ancho, alto, x, y, xString, yString, ruta, enable, texto)
        { }

        public override void LoadContent(ContentManager Content)
        {
            base.LoadContent(Content);
        }

        public override void UpDate(Rectangle colision, MouseState mouse)
        {
            base.UpDate(colision, mouse);
        }

        public override void Draw(SpriteBatch sprite)
        {
            base.Draw(sprite);
        }

        public void activarBoton(string nombre, string edad, string sexo)
        {
            if (nombre.Length > 0 && edad.Length > 0 && sexo.Length > 0)
            {
                enable = true;
                //noPulsado = Color.Black;
            }
            else
            {
                enable = false;
                noPulsado = Color.Silver;
            }
        }

        public void activarBoton(string pass)
        {
            if (pass.Length > 0)
            {
                enable = true;
            }
            else
            {
                enable = false;
                noPulsado = Color.Silver;
            }
        }

        public string _Text
        {
            get { return btText; }
            set { btText = value; }
        }

        public bool _Enable
        {
            get { return enable; }
            set { enable = value; }
        }

        /*public bool _prueba
        {
            set { enable = value; }
        }*/
    }
}

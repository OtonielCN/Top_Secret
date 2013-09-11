using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace tesisRaven.TEXTO
{
    class mensajeAyuda:Text
    {
        private Vector2[] posicionMensaje;
        private string[] mensajes;
        private int timer;
        private int[] transparencia;
        private int velocidadTrasnparencia;

        public mensajeAyuda(string ruta)
            : base(ruta)
        {
            mensajes = new string[5];
            posicionMensaje = new Vector2[5];
            transparencia = new int[5];
            velocidadTrasnparencia = 20;
            crearMensajes();
            crearPosiciones();
        }

        public override void LoadContent(ContentManager Content)
        {
            base.LoadContent(Content);
        }

        public override void UpDate(int tim)
        {
            timer = tim;
            //if (timer > 0 && timer < 2)
            //    transparencia[0] += velocidadTrasnparencia;
            //if (timer > 2 && timer < 4)
            //    transparencia[1] += velocidadTrasnparencia;
            //if (timer > 3 && timer < 5)
            //    transparencia[2] += velocidadTrasnparencia;
            //if (timer > 4 && timer < 6)
            //    transparencia[3] += velocidadTrasnparencia;
            //if (timer > 5 && timer < 11)
            //    transparencia[4] += velocidadTrasnparencia;
            if (timer ==1)
                transparencia[0] += velocidadTrasnparencia;
            if (timer ==2)
                transparencia[1] += velocidadTrasnparencia;
            if (timer ==3)
                transparencia[2] += velocidadTrasnparencia;
            if (timer ==4)
                transparencia[3] += velocidadTrasnparencia;
            if (timer ==5)
                transparencia[4] += velocidadTrasnparencia;
            //base.UpDate();
        }

        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch sprite)
        {
            sprite.Begin();
            for (int i = 0; i < 5; i++)
            {
                sprite.DrawString(fuente, mensajes[i], posicionMensaje[i], new Color(0,0,0,transparencia[i]));
            }
                //sprite.DrawString();
            sprite.End();
            //base.Draw(sprite);
        }

        private void crearPosiciones()
        {
            posicionMensaje[0] = new Vector2(40, 100);
            posicionMensaje[1] = new Vector2(40, 200);
            posicionMensaje[2] = new Vector2(40, 300);
            posicionMensaje[3] = new Vector2(920, 100);
            posicionMensaje[4] = new Vector2(920, 200);

            for (int i = 0; i < 5; i++)
            {
                transparencia[i] = 0;
            }
        }

        private void crearMensajes()
        {
            mensajes[0] = "Al iniciar el test se mostrará\nuna lámina como esta.";
            mensajes[1] = "A dicha lámina le hara falta\nuna pieza.";
            mensajes[2] = "Usted deberá  elegir la pieza\nque       crea       conveniente,\nutilizando el ratón y moviendo\nla mano hasta la pieza para\ncompletar la lámina.";
            mensajes[3] = "En el ejemplo la primera\nelección es incorrecta.";
            mensajes[4] = "Y al elegir la otra pieza si\nconcuerda con la lámina.";
        }

        public void inicializarTransparencia()
        {
            for (int i = 0; i < 5; i++)
            {
                transparencia[i] = 0;
            }
        }

    }
}

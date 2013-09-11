using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace tesisRaven
{
    public abstract class Text
    {
        protected SpriteFont fuente;
        protected Vector2 posicion;
        protected Color color = Color.White;
        private string texto;
        private string rutaFuente;
        //private string ruta;


        public Text(string texto, ContentManager Content, string ruta)
        {
            this.texto = texto;
           // posicion = new Vector2(200, 50);
            this.rutaFuente = ruta;
            this.LoadContent(Content);
        }

        public Text(string texto, ContentManager Content, string ruta, int x, int y)
        {
            this.texto = texto;
            this.rutaFuente = ruta;
            this.LoadContent(Content);
            this.posicion = new Vector2(x, y);
        }

        public Text(string texto, int X, int Y, string ruta)
        {
            this.texto = texto;
            posicion = new Vector2(X, Y);
            this.rutaFuente = ruta;
        }

        public Text()
        { 
        }

        public Text(int X, int Y,string ruta)
        {
            this.posicion = new Vector2(X, Y);
            this.rutaFuente = ruta;
        }

        public Text(string ruta)
        {
            this.rutaFuente = ruta;
        }

        public virtual void LoadContent(ContentManager Content)
        {
            fuente = Content.Load<SpriteFont>(rutaFuente);
        }

        public virtual void UpDate()
        {
        }

        public virtual void UpDate(int tim)
        {
        }

        public virtual void UpDate(string r, int x,int y)
        {
        }

        public virtual void Draw(SpriteBatch sprite)
        {
            sprite.Begin();
            sprite.DrawString(fuente, texto, posicion, color);
            sprite.End();
        }

        public virtual void Draw2(SpriteBatch sprite)
        {
            sprite.Begin();
            sprite.DrawString(fuente, texto, posicion, color);
            sprite.End();
        }

        public string Texto
        {
            get { return texto; }
            set { texto = value; }
        }

        public Vector2 Posicion
        {
            get { return posicion; }
            set { posicion = value; }
        }

        public SpriteFont Fuente
        {
            get { return fuente; }
        }

        public Color _Color
        {
            set { color = value; }
        }
    }
}

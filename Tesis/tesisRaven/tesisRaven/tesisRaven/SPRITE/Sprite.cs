using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace tesisRaven
{
    public abstract class Sprite
    {
        protected Texture2D imagen;
        protected Vector2 posicionImagen;
        protected Rectangle rectanguloColision;
        protected int anchoImagen;
        protected int altoImagen;
        protected Color colorImagen = Color.White;
        private string rutaImagen;

        public Sprite(int ancho, int alto, int posX, int posY, string ruta)
        {
            this.anchoImagen = ancho;
            this.altoImagen = alto;
            this.posicionImagen = new Vector2(posX, posY);
            this.rectanguloColision = new Rectangle(posX, posY, anchoImagen, altoImagen);
            this.rutaImagen = ruta;
        }

        public Sprite(string rutaImg)
        {
            this.rutaImagen = rutaImg;
        }

        public Sprite()
        {
        }

        public virtual void LoadContent(ContentManager Content)
        {
            imagen = Content.Load<Texture2D>(rutaImagen);
        }

        public virtual void UpDate()
        { }

        public virtual void UpDate(MouseState mouseEstado)
        {
            this.posicionImagen.X = mouseEstado.X;
            this.posicionImagen.Y = mouseEstado.Y;
            this.rectanguloColision = new Rectangle((int)this.posicionImagen.X, (int)this.posicionImagen.Y, this.anchoImagen, this.altoImagen);
            //verificar si hay colision, si hay poner a true una variable
        }

        public virtual void UpDate(int time)
        {
        }

        public virtual void UpDate(int pos,bool back)
        {
        }

        public virtual void UpDate(Texture2D imgPlan, bool back)
        {
            this.imagen = imgPlan;
        }

        public virtual void UpDate(Rectangle colision,MouseState mouse)
        {
            //if(this.rectanguloColision.Intersects(colision))

        }

        public virtual void UpDate(Rectangle colision)
        { }

        public virtual void Draw(SpriteBatch sprite)
        {
            sprite.Begin();
            sprite.Draw(imagen, posicionImagen, colorImagen);
            sprite.End();
        }

        public virtual void Draw2(SpriteBatch sprite)
        {
            sprite.Begin();
            sprite.Draw(imagen, posicionImagen, rectanguloColision, colorImagen);
            sprite.End();
        }

        public Rectangle _RectColision
        {
            get { return this.rectanguloColision; }
        }

        public Vector2 _Posicion
        {
            get { return posicionImagen; }
            set { posicionImagen = value; }
        }

        public virtual Texture2D _Imagen
        {
            get { return imagen; }
            set { imagen = value; }
        }

        public Color _ColorImagen
        {
            get { return colorImagen; }
            set { colorImagen = value; }
        }

    }
}

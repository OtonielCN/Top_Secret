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
    class imagenStatic:Sprite
    {
        public imagenStatic(int ancho, int alto, int x, int y, string ruta)
            : base(ancho, alto, x, y, ruta)
        { }

        public override void LoadContent(ContentManager Content)
        {
            base.LoadContent(Content);
        }

        public override void Draw(SpriteBatch sprite)
        {
            base.Draw(sprite);
        }
    }
}

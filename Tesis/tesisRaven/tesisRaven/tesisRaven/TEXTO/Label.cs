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
    class Label : Text
    {
        public Label(string texto, int x, int y, string ruta)
            : base(texto, x, y, ruta)
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

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
    class calcular_Ancho_y_Alto_String
    {
        public static Vector2 CalcularDimensiones(SpriteFont letra, string cadena)
        {
            return letra.MeasureString(cadena);
        }
    }
}

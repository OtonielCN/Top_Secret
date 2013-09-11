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
    class ComboBox
    {
        private Texture2D comboImg1;
        private Texture2D comboImg2;
        private Texture2D fondoCombo;
        private SpriteFont font;

        private Rectangle click;
        private Rectangle mouse;
        private Rectangle rectangleFondo;
        private Rectangle comboBoxCerrado = new Rectangle(0, 431, 235, 1);
        private Vector2 posicionCombo;
        private Vector2[] vectorOpcAnchoAlto;
        private Rectangle[] rectOpciones;

        private string[] opcionesCombo;
        private string opcElegida = "";

        private int comboX;
        private int comboY;
        private int anchoComboImg = 235;
        private int altoComboImg = 34;
        private int puntoInicialOpc = 0;
        private int separacion = 5;
        private int alto1Opc = 0;

        private int altoComboFondo = 432;
        private float altoCadenas = 0;

        MouseState mouseState;

        private bool mouseOver = false;
        private bool estado = true;
        private bool cerrado = true;
        private bool abierto = false;

        private Color colorSobre = Color.Red;
        private Color[] colorOpc;

        public ComboBox(int X, int Y, string[] opcs)
        {
            comboX = X;
            comboY = Y;
            this.posicionCombo = new Vector2(X, Y);
            this.opcionesCombo = opcs;
            rectangleFondo = new Rectangle(0, 431, 235, 1);
            click = new Rectangle(X + anchoComboImg - 27, Y, 26, 34);
            mouse = new Rectangle(100, 100, 5, 5);
            //opcElegida = opcionesCombo[0];
            colorOpc = new Color[opcionesCombo.Length];
            for (int i = 0; i < opcionesCombo.Length; i++)
            {
                colorOpc[i] = Color.Black;
            }
        }

        public string _RetornarOpcElegida
        {
            get { return opcElegida; }
            set { opcElegida = value; }
        }

        public void LoadContent(ContentManager Content)
        {
            comboImg1 = Content.Load<Texture2D>(@"Imagenes\Formulario\comboBox");
            fondoCombo = Content.Load<Texture2D>(@"Imagenes\Formulario\fondoCombo");
            comboImg2 = Content.Load<Texture2D>(@"Imagenes\Formulario\comboBoxR");
            font = Content.Load<SpriteFont>(@"Fuentes\fuenteComboBox");

            puntoInicialOpc = comboY + altoComboImg + 10;
            anchoAltoOpc();
            alto1Opc = (int)vectorOpcAnchoAlto[0].Y - 15;
            crearRectOpcs();
            calcularAltoCombo();
        }

        public void UpdateComboBox()
        {
            mouseState = Mouse.GetState();
            mouse.X = mouseState.X;
            mouse.Y = mouseState.Y;

            if (mouse.Intersects(click))
            {
                mouseOver = true;
                //Si le da click hacer mas grande el rectángulo del fondo
                if (mouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed && estado)
                {
                    estado = false;
                    if (cerrado)
                    {
                        rectangleFondo.Y = altoComboFondo - (int)altoCadenas-5;
                        rectangleFondo.Height = (int)altoCadenas+5;
                        cerrado = false;
                        abierto = true;
                    }
                    else if (abierto)
                    {
                        rectangleFondo = comboBoxCerrado;
                        abierto = false;
                        cerrado = true;
                    }
                }

                if (mouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Released && !estado)
                {
                    estado = true;
                }
            }
            else if (!abierto)
            {
                mouseOver = false;
            }

            for (int i = 0; i < opcionesCombo.Length; i++)
            {
                if (mouse.Intersects(rectOpciones[i]) && abierto)
                {
                    colorOpc[i] = colorSobre;
                    if (mouseState.LeftButton == ButtonState.Pressed)
                    {
                        opcElegida = opcionesCombo[i];
                        abierto = false;
                        cerrado = true;
                        rectangleFondo = comboBoxCerrado;
                        break;
                    }
                }
                else
                    colorOpc[i] = Color.Black;
            }
        }

        public void DrawComboBox(SpriteBatch sprite)
        {
            sprite.Begin();
            if (!mouseOver)
            {
                sprite.Draw(comboImg1, posicionCombo, Color.White);
            }
            else
            {
                sprite.Draw(comboImg2, posicionCombo, Color.White);
            }
            sprite.DrawString(font, opcElegida, new Vector2(comboX + 10, comboY+3 ), Color.White);
            sprite.Draw(fondoCombo, new Vector2(comboX, comboY + altoComboImg), rectangleFondo, Color.White);
            if (abierto)
            {
                //sprite.Draw(fondoCombo, new Vector2(comboX, comboY + altoComboImg), rectangleFondo, Color.White);
                for (int i = 0; i < opcionesCombo.Length; i++)
                {
                    sprite.DrawString(font, opcionesCombo[i], new Vector2(rectOpciones[i].X, rectOpciones[i].Y - 10), colorOpc[i]);
                }
            }
           //else
                //sprite.Draw(fondoCombo, new Vector2(comboX, comboY + altoComboImg), rectangleFondo, Color.White);
            sprite.End();
        }

        private void crearRectOpcs()
        {
            rectOpciones = new Rectangle[opcionesCombo.Length];

            for (int i = 0; i < opcionesCombo.Length; i++)
            {
                rectOpciones[i] = new Rectangle(comboX + 10, puntoInicialOpc, /*(int)vectorOpcAnchoAlto[i].X*/220, /*(int)vectorOpcAnchoAlto[i].Y*/alto1Opc);
                puntoInicialOpc += alto1Opc + separacion;
            }
        }
        private void calcularAltoCombo()
        {
            for (int i = 0; i < opcionesCombo.Length; i++)
            {
                altoCadenas += vectorOpcAnchoAlto[i].Y - 10;
            }
        }
        private void anchoAltoOpc()
        {
            vectorOpcAnchoAlto = new Vector2[opcionesCombo.Length];
            for (int i = 0; i < opcionesCombo.Length; i++)
            {
                vectorOpcAnchoAlto[i] = calcular_Ancho_y_Alto_String.CalcularDimensiones(font, opcionesCombo[i]);
            }
        }
    }
}

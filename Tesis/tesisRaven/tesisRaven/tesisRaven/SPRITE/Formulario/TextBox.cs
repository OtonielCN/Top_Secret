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

namespace tesisRaven.SPRITE.Formulario
{
    class TextBox
    {
        private string texto = "";
        private string letra = "";
        private string password = "";
        private char asterisco;
        private Keys[] pulsadas = new Keys[0];
        private SpriteFont fuente;
        private Texture2D imgTextBox;
        //private Texture2D TextBoxFocus;
        private Rectangle rectangulo;
        private Rectangle rectNombre;
        private Color colorFocus;
        private Color color;
        private int velocidadBorrado = 0;
        private bool focus = false;
        private bool passW;
        private int posicionX;
        private int posicionY;

        public TextBox(int posX, int posY, bool pass)
        {
            posicionX = posX;
            posicionY = posY;
            color = Color.White;
            passW = pass;
            asterisco = '*';
            colorFocus = new Color(79, 169, 245);
            rectNombre = new Rectangle(posicionX, posicionY, 420, 38);
        }

        public void LoadContent(ContentManager Content)
        {
            fuente = Content.Load<SpriteFont>(@"Fuentes/fuenteTextBox");
            imgTextBox = Content.Load<Texture2D>(@"Imagenes/TextBox");
            //TextBoxFocus = Content.Load<Texture2D>(@"Imagenes/TextBoxFocus");
        }
        public void Update(MouseState mouse)
        {
            //Preguntar primero si esta enfocado if(Focus)
            enfocarCajaTexto(mouse);
            if (focus)
            {
                KeyboardState estado = Keyboard.GetState();
                Keys[] teclasPresionadas;
                teclasPresionadas = estado.GetPressedKeys();
                for (int i = 0; i < teclasPresionadas.Length; i++)
                {
                    if (Keyboard.GetState().IsKeyDown(Keys.Back) && velocidadBorrado >= 7)
                    {
                        obtenerLetra(teclasPresionadas[i]);
                        velocidadBorrado = 0;
                    }
                    else if (Keyboard.GetState().IsKeyUp(Keys.Back))
                    {
                        obtenerLetra(teclasPresionadas[i]);
                        velocidadBorrado = 0;
                    }
                    velocidadBorrado += 1;

                    bool encontrada = false;
                    for (int j = 0; j < pulsadas.Length; j++)
                    {
                        if (teclasPresionadas[i] == pulsadas[j])
                        {
                            encontrada = true;
                            break;
                        }
                    }
                    if (encontrada == false)
                    {
                        if (passW && letra.Length > 0 && texto.Length < 25)
                        {
                            password = password + asterisco.ToString();
                            texto = texto + letra.ToLower();
                        }
                        else if (texto.Length < 24)
                        {
                            texto = texto + letra.ToLower();
                        }
                    }
                    letra = "";
                }

                pulsadas = teclasPresionadas;
            }
        }

        public string Text
        {
            get { return texto; }
            set { texto = value; }
        }

        public string _PassWord
        {
            get { return password; }
            set { password = value; }
        }

        public void Draw(SpriteBatch sprite)
        {
            sprite.Begin();
            sprite.Draw(imgTextBox, new Vector2(posicionX, posicionY), color);
            if(passW)
                sprite.DrawString(fuente, password, new Vector2(posicionX + 10, posicionY - 5), Color.Black);
            else
                sprite.DrawString(fuente, texto, new Vector2(posicionX + 10, posicionY - 5), Color.Black);
            sprite.End();
        }

        private void obtenerLetra(Keys letra)
        {
            KeyboardState keystate = Keyboard.GetState();
            switch (letra)
            {
                #region DIGITOS
                case Keys.D0:
                    this.letra = "0";
                    break;
                case Keys.D1:
                    this.letra = "1";
                    break;
                case Keys.D2:
                    this.letra = "2";
                    break;
                case Keys.D3:
                    this.letra = "3";
                    break;
                case Keys.D4:
                    this.letra = "4";
                    break;
                case Keys.D5:
                    this.letra = "5";
                    break;
                case Keys.D6:
                    this.letra = "6";
                    break;
                case Keys.D7:
                    this.letra = "7";
                    break;
                case Keys.D8:
                    this.letra = "8";
                    break;
                case Keys.D9:
                    this.letra = "9";
                    break;
                #endregion

                #region ABECEDARIO
                case Keys.A:
                    this.letra = "A";
                    break;
                case Keys.B:
                    this.letra = "B";
                    break;
                case Keys.C:
                    this.letra = "C";
                    break;
                case Keys.D:
                    this.letra = "D";
                    break;
                case Keys.E:
                    this.letra = "E";
                    break;
                case Keys.F:
                    this.letra = "F";
                    break;
                case Keys.G:
                    this.letra = "G";
                    break;
                case Keys.H:
                    this.letra = "H";
                    break;
                case Keys.I:
                    this.letra = "I";
                    break;
                case Keys.J:
                    this.letra = "J";
                    break;
                case Keys.K:
                    this.letra = "K";
                    break;
                case Keys.L:
                    this.letra = "L";
                    break;
                case Keys.M:
                    this.letra = "M";
                    break;
                case Keys.N:
                    this.letra = "N";
                    break;
                case Keys.O:
                    this.letra = "O";
                    break;
                case Keys.P:
                    this.letra = "P";
                    break;
                case Keys.Q:
                    this.letra = "Q";
                    break;
                case Keys.R:
                    this.letra = "R";
                    break;
                case Keys.S:
                    this.letra = "S";
                    break;
                case Keys.T:
                    this.letra = "T";
                    break;
                case Keys.U:
                    this.letra = "U";
                    break;
                case Keys.V:
                    this.letra = "V";
                    break;
                case Keys.W:
                    this.letra = "W";
                    break;
                case Keys.X:
                    this.letra = "X";
                    break;
                case Keys.Y:
                    this.letra = "Y";
                    break;
                case Keys.Z:
                    this.letra = "Z";
                    break;
                #endregion

                case Keys.Space:
                    this.letra = " ";
                    break;
                case Keys.Back:
                    this.letra = "";
                    if (passW)
                    {
                        if (password.Length > 0 && texto.Length > 0)
                        {
                            password = password.Remove(password.Length - 1);
                            texto = texto.Remove(texto.Length - 1);
                        }
                    }
                    else
                    {
                        if (texto.Length > 0)
                            texto = texto.Remove(texto.Length - 1);
                    }
                    break;
                case Keys.Enter:
                    this.letra = "";
                    break;

            }
        }

        private void enfocarCajaTexto(MouseState mouse)
        {
            rectangulo = new Rectangle((int)mouse.X, (int)mouse.Y, 5, 5);
            if (rectNombre.Intersects(rectangulo))
            {
                if (mouse.LeftButton == ButtonState.Pressed)
                {
                    color = colorFocus;
                    //imgTextBox = TextBoxFocus;
                    focus = true;
                }
            }
            else
            {
                if (mouse.LeftButton == ButtonState.Pressed)
                {
                    focus = false;
                    color = Color.White;
                }
            }
        }
    }
}

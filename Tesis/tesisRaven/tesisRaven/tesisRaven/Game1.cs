using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using tesisRaven.SPRITE;
using tesisRaven.TEXTO;
using tesisRaven.SPRITE.Formulario;
using tesisRaven.SPRITE.Ayuda;
using tesisRaven.SPRITE.Plantilla;
using tesisRaven.SQLITE;

namespace tesisRaven
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        TextBox textBox;
        Titulo title;
        Titulo datosPers;
        Menu menu;
        mano hand;
        fondo fondoTest;
        albert albertIMG;

        imagenStatic cabeceraTabla;
        imagenStatic lateralTabla;
        imagenStatic logoUM;

        ComboBox comboboxSexo;
        ComboBox comboboxEdad;

        Label lbNombre;
        Label lbEdad;
        Label lbSexo;
        Label lbIq;
        Label lbNumero;
        Label lbPassword;
        Label lbMensaje;
        //No lbNumero;
        mensajeAyuda ayudaMen;

        //fondoDatosPersonales fondoDatos;
        imagenStatic fondoDatos;
        imagenStatic marcoFondoDatos;
        //marcoDatosPersonales marcoFondoDatos;
        //fondoFormulario fondoForm;
        imagenStatic fondoForm;
        imagenStatic marcoFondo;
        //marcoFondoForm marcoFondo;
        imagenStatic fondoContra;
        //fondoContrasenya fondoContra;
        imagenStatic marcoFondoContra;
        //marcoFondoContrasenya marcoFondoContra;
        //fondoTabla fondoTable;
        imagenStatic fondoTable;
        imagenStatic marcoFondoTable;
        //marcoFondoTabla marcoFondoTable;
        List<imagenStatic> separadorHorizontal;
        List<imagenStatic> separadorVertical;

        menuPcipal btMenuPcipal;
        menuPcipal btSalir;
        boton btComenzar;
        boton btAceptar;
        boton btError;
        boton btAnterior;
        boton btSiguiente;

        lamina img_lamina;
        respuesta img_respuesta;
        seleccion img_seleccion;
        acierto_desacierto img_aciertodesacierto;

        plantillaRectResp rectResp;
        plantillaRespuestas respuestas;
        plantillaEncabezado encabezado;

        //mensaje lbMensaje;
        //datosPersonales lbDatosPersonal;
        mensajeIMG mensajeNube;
        TextBox passWord;
        //passWord lbPassword;
        List<paciente> pacientes;
        tablaResultados tableResult;

        private double _timer;
        private bool guardar;

        private string capacidad;
        private string estado = "Menu";
        private string rutaFuente = @"Fuentes\fuenteMenu";
        private string[] opcMenu = { "Aplicar", "Resultados", "Ayuda", "Salir" };
        private string[] opcsSexo = { "MASCULINO", "FEMENINO" };
        private string[] opcsEdad = { "6", "7", "8", "9", "10", "11" };
        private string resultados;

        private int posicion;
        private int numRegistros;
        private int pagina;

        private float control,control2;

        private bool cargar;
        private bool calcularRegistros;
        private bool controlarEnter;

        private generaSonido sonidoFondo;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            //graphics.IsFullScreen = true;
            Window.AllowUserResizing = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            construirTitulo();
            construirFormulario();
            construirPlantilla();
            guardar = true;
            posicion = 0;
            pagina = 1;
            calcularRegistros = true;
            controlarEnter = true;
            cargar = true;
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            textBox.LoadContent(Content);
            passWord.LoadContent(Content);
            hand.LoadContent(Content);
            fondoTest.LoadContent(Content);
            albertIMG.LoadContent(Content);
            //logoUM.LoadContent(Content);
            logoUM.LoadContent(Content);
            comboboxSexo.LoadContent(Content);
            comboboxEdad.LoadContent(Content);
            lbNombre.LoadContent(Content);
            lbEdad.LoadContent(Content);
            //lbEdad.LoadContent(Content);
            lbSexo.LoadContent(Content);
            lbIq.LoadContent(Content);
            lbNumero.LoadContent(Content);
            ayudaMen.LoadContent(Content);
            //lbDatosPersonal.LoadContent(Content);

            fondoDatos.LoadContent(Content);
            marcoFondoDatos.LoadContent(Content);
            fondoForm.LoadContent(Content);
            marcoFondo.LoadContent(Content);
            fondoContra.LoadContent(Content);
            marcoFondoContra.LoadContent(Content);
            fondoTable.LoadContent(Content);
            marcoFondoTable.LoadContent(Content);
            cargarSeparadores();

            btComenzar.LoadContent(Content);
            btAceptar.LoadContent(Content);
            btMenuPcipal.LoadContent(Content);
            btSalir.LoadContent(Content);
            btError.LoadContent(Content);
            btAnterior.LoadContent(Content);
            btSiguiente.LoadContent(Content);

            img_lamina.LoadContent(Content);
            img_respuesta.LoadContent(Content);
            img_seleccion.LoadContent(Content);
            img_aciertodesacierto.LoadContent(Content);
            respuestas.LoadContent(Content);
            lbMensaje.LoadContent(Content);
            lbPassword.LoadContent(Content);
            tableResult.LoadContent(Content);
            cabeceraTabla.LoadContent(Content);
            lateralTabla.LoadContent(Content);

            sonidoFondo.playSong();
            // TODO: use this.Content to load your game content here
        }



        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (Keyboard.GetState().IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Escape))
                this.Exit();
            KeyboardState estadoTeclado = Keyboard.GetState();
            MouseState mouse = Mouse.GetState();
            
            hand.UpDate(mouse);

            #region MENU
            if (estado == "Menu")
            {
                albertIMG._Posicion = new Vector2(830, 300);
                fondoTest.UpDate();
                title.UpDate();
                menu.UpDate();
                albertIMG.UpDate();
                if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                {
                    estado = menu.obtenerOpcion();
                }

                if (Mouse.GetState().LeftButton == ButtonState.Pressed && menu._darClick)
                {
                    estado = menu.obtenerOpcion();
                }
            }
            #endregion

            #region APLICAR
            if (estado == "Aplicar")
            {
                fondoForm._ColorImagen = new Color(0, 0, 0, 200);
                lbEdad.Texto = "Edad: ";
                lbEdad._Color = Color.White;
                lbEdad.Posicion = new Vector2(610, 275);

                //lbNombre.Texto = "Nombre: ";
                //lbNombre.Posicion = new Vector2(230, 230);
                lbNombre.Texto = "Nombre: ";
                lbNombre._Color = Color.White;
                lbNombre.Posicion = new Vector2(230, 230);

                lbSexo.Texto = "Sexo: ";
                lbSexo._Color = Color.White;
                lbSexo.Posicion = new Vector2(320, 275);

                datosPers.UpDate();
                btComenzar._Text = "Comenzar";
                btComenzar.UpDate(hand._RectColision, mouse);
                btComenzar.activarBoton(textBox.Text, comboboxEdad._RetornarOpcElegida, comboboxSexo._RetornarOpcElegida);
                if (btMenuPcipal.Click)
                {
                    btMenuPcipal.Click = false;
                    textBox.Text = "";
                    comboboxEdad._RetornarOpcElegida = "";
                    comboboxSexo._RetornarOpcElegida = "";
                    estado = "Menu";//estado = "Empezar";
                }
                if (btComenzar._Empezar)
                {
                    // AQUI ES DONDE EMPIEZAN A APARECER LAS LAMINAS
                    btComenzar._Empezar = false;
                    estado = "Empezar";//estado = "Empezar";
                }
                fondoTest.UpDate();
                albertIMG.UpDate();
                textBox.Update(mouse);
                comboboxSexo.UpdateComboBox();
                comboboxEdad.UpdateComboBox();
                btMenuPcipal.UpDate(hand._RectColision, mouse);
            }
            #endregion

            #region AYUDA

            if (estado == "Ayuda")
            {
                _timer += gameTime.ElapsedGameTime.TotalMilliseconds;
                if (((int)_timer / 1000) >= 26)
                    _timer = 00.0f;
                ayudaMen.UpDate((int)_timer / 1000);
                img_respuesta.UpDate((int)_timer / 1000);
                img_seleccion.UpDate((int)_timer / 1000);
                img_aciertodesacierto.UpDate((int)_timer / 1000);
                
                btMenuPcipal.UpDate(hand._RectColision, mouse);
                if (btMenuPcipal.Click)
                {
                    img_respuesta.inicializar();
                    img_seleccion.inicializar();
                    img_aciertodesacierto.inicializar();
                    _timer = 0;
                    btMenuPcipal.Click = false;
                    ayudaMen.inicializarTransparencia();
                    estado = "Menu";
                }
            }
            #endregion

            #region EMPEZAR

            if (estado == "Empezar")
            {
                lbMensaje.Texto = "Elija la pieza correspondiente";
                lbMensaje._Color = Color.Black;
                lbMensaje.Posicion = new Vector2(20, 15);
                rectResp.UpDate(hand._RectColision, mouse,respuestas.darClick);
                if (rectResp._Fin)
                {
                    estado = "Fin";
                }
                respuestas.UpDate(rectResp._Posicion, rectResp._Regresar);
                encabezado.UpDate(respuestas.Imagen, rectResp._Regresar);
                btMenuPcipal.UpDate(hand._RectColision, mouse);
                if (btMenuPcipal.Click)
                {
                    btMenuPcipal.Click = false;
                    textBox.Text = "";
                    comboboxEdad._RetornarOpcElegida = "";
                    comboboxSexo._RetornarOpcElegida = "";
                    rectResp.reIniciar();
                    respuestas.valoresIniciales();
                    encabezado.valoresIniciales();
                    estado = "Menu";
                }
            }
            #endregion

            #region FIN

            if (estado == "Fin")
            {
                fondoTest.UpDate();
                btSalir.UpDate(hand._RectColision, mouse);
                if (btSalir.Click)
                {
                    this.Exit();
                }
                btMenuPcipal.UpDate(hand._RectColision, mouse);
                if (btMenuPcipal.Click)
                {
                    // Guardar en la base de datos
                    btMenuPcipal.Click = false;
                    textBox.Text = "";
                    comboboxEdad._RetornarOpcElegida = "";
                    comboboxSexo._RetornarOpcElegida = "";
                    rectResp.reIniciar();
                    respuestas.valoresIniciales();
                    encabezado.valoresIniciales();
                    mensajeNube._Estado = 0;
                    lbMensaje.Texto = "Elija la pieza que corresponde";
                    lbMensaje.Posicion = new Vector2(20, 15);
                    lbMensaje._Color = Color.Black;
                    guardar = true;
                    estado = "Menu";
                    // Inicializar todo con respecto a las plantillas
                }
                mensajeNube.UpDate(albertIMG._Imagen, true);
                if (mensajeNube._Estado > 16 && guardar)
                {

                    bd_Raven._Conexion("Data Source=raven;Version=3;New=False;Compress=True;");
                    capacidad = bd_Raven._Select("select capacidad from baremo where edad='" + comboboxEdad._RetornarOpcElegida + "' and aciertos='" + rectResp._Aciertos + "'");
                    string percentil = bd_Raven._Select("select percentil from baremo where edad='" + comboboxEdad._RetornarOpcElegida + "' and aciertos='" + rectResp._Aciertos + "'");
                    int iq = (100 + (Int32.Parse(percentil) - 50));
                    bd_Raven._Insert("insert into paciente(nombre, edad, genero, iq) values('" + textBox.Text + "','" + comboboxEdad._RetornarOpcElegida + "','" + comboboxSexo._RetornarOpcElegida + "','" + iq.ToString() + "');");
                    lbMensaje.Texto = textBox.Text + " tu\ncoeficiente intelecutal es: " + iq.ToString() + "\nEste resultado significa que\ntu capacidad intelectual es: \n" + capacidad.ToString();
                    lbMensaje._Color = Color.White;
                    lbMensaje.Posicion = new Vector2(710, 83);
                    
                    guardar = false;
                }
                albertIMG._Posicion = new Vector2(500, 250);
                albertIMG.UpDate();

            }
            #endregion

            #region RESULTADOS

            if (estado == "Resultados")
            {
                fondoContra._ColorImagen = new Color(0, 0, 0, 200);
                fondoTest.UpDate();
                passWord.Update(mouse);
                lbMensaje.Posicion = new Vector2(515, 280);
                lbMensaje._Color = Color.White;
                lbMensaje.Texto = "Ingrese clave de acceso";
                btAceptar.UpDate(hand._RectColision, mouse);
                btAceptar.activarBoton(passWord.Text);
                if (btAceptar._Empezar)
                {
                    
                    //Comprobar la contraseña introducida

                    bd_Raven._Conexion("Data Source=raven;Version=3;New=False;Compress=True;");
                    if (passWord.Text == bd_Raven._Select("select contraseña from analista"))
                    {
                        // Mostrar resultados
                        passWord.Text = "";
                        passWord._PassWord = "";
                        btAceptar._Empezar = false;
                       
                        estado = "verResultado";
                    }
                    else 
                    {
                        passWord.Text = "";
                        passWord._PassWord = "";
                        //btAceptar._Posicionado = false;
                        btAceptar._Empezar = false;
                        estado = "Error";
                        //Mostrar mensaje de error
                    }
                    btAceptar._Empezar = false;
                }

                if (Keyboard.GetState().IsKeyDown(Keys.Enter)&&passWord.Text.Length>0&&controlarEnter)
                {
                    controlarEnter = false;
                    bd_Raven._Conexion("Data Source=raven;Version=3;New=False;Compress=True;");
                    if (passWord.Text == bd_Raven._Select("select contraseña from analista"))
                    {
                        // Mostrar resultados
                        passWord.Text = "";
                        passWord._PassWord = "";
                        btAceptar._Empezar = false;
                        controlarEnter = true;

                        estado = "verResultado";
                    }
                    else
                    {
                        passWord.Text = "";
                        passWord._PassWord = "";
                        //btAceptar._Posicionado = false;
                        btAceptar._Empezar = false;
                        estado = "Error";
                        //Mostrar mensaje de error
                    }
                }
                if (Keyboard.GetState().IsKeyUp(Keys.Enter))
                {
                    //controlarEnter = true;
                }

                btMenuPcipal.UpDate(hand._RectColision, mouse);
                if (btMenuPcipal.Click)
                {
                    passWord.Text = "";
                    passWord._PassWord = "";
                    btAceptar._Empezar = false;
                    btMenuPcipal.Click = false;
                    estado = "Menu";
                }
            }
            #endregion

            #region verResultado
            if (estado == "verResultado")
            {
                fondoTable._ColorImagen = new Color(0, 0, 0, 200);
                marcoFondoTable._ColorImagen = new Color(79, 169, 245);
                fondoTest.UpDate();
                tableResult._Color = Color.White;
                //lbNombre.Texto = "Nombre";
                //lbNombre._Color = Color.Red;
                lbNombre.Texto = "Nombre";
                lbNombre._Color = Color.Red;
                lbNombre.Posicion = new Vector2(350, 80);
                lbEdad.Texto = "Edad";
                lbEdad._Color = Color.Red;
                lbEdad.Posicion = new Vector2(610, 80);
                lbSexo.Texto = "Sexo";
                lbSexo._Color = Color.Red;
                lbSexo.Posicion = new Vector2(725, 80);
                lbIq._Color = Color.Red;
                lbNumero._Color = Color.Red;

                if (calcularRegistros)
                {
                    bd_Raven._Conexion("Data Source=raven;Version=3;New=False;Compress=True;");
                    control = bd_Raven._NumRegistros("select count(nombre) from paciente");
                    control2 = control;
                    control = control / 10;
                    numRegistros = (Int32)Math.Ceiling(control);
                    calcularRegistros = false;
                }


                if (cargar)
                {
                    bd_Raven._Conexion("Data Source=raven;Version=3;New=False;Compress=True;");
                    pacientes = bd_Raven._Resultados("SELECT nombre, edad, genero, iq FROM paciente ORDER BY edad LIMIT " + posicion + " , 10");
                    //menSaje._Color = Color.Black;
                    for (int i = 0; i < pacientes.Count; i++)
                    {
                        if (pacientes[i]._Nombre.Length > 0 && pacientes[i]._Edad.Length > 0 && pacientes[i]._Genero.Length > 0 && pacientes[i]._IQ.Length > 0)
                        {
                            resultados += "-" + pacientes[i]._Nombre + "-" + pacientes[i]._Edad + "-" + pacientes[i]._Genero + "-" + pacientes[i]._IQ;

                        }
                    }
                    cargar = false;
                }

                btAnterior.UpDate(hand._RectColision, mouse);
                btSiguiente.UpDate(hand._RectColision, mouse);

                if (pagina > 1)
                {
                    btAnterior._Enable = true;
                    if (btAnterior._Empezar)
                    {
                        pagina--;
                        cargar = true;
                        resultados = "";
                        posicion -= 10;
                        btAnterior._Empezar = false;
                    }
                }
                else
                {
                    btAnterior._Enable = false;
                }

                if (pagina < numRegistros)
                {
                    btSiguiente._Enable = true;
                    if (btSiguiente._Empezar)
                    {
                        pagina++;
                        cargar = true;
                        resultados = "";
                        posicion += 10;
                        btSiguiente._Empezar = false;
                    }
                }
                else
                {
                    btSiguiente._Enable = false;
                }

                tableResult.UpDate(resultados,(int)control2,pagina);
                btMenuPcipal.UpDate(hand._RectColision, mouse);
                if (btMenuPcipal.Click)
                {
                    passWord.Text = "";
                    passWord._PassWord = "";
                    btAceptar._Enable = false;
                    btAceptar._Empezar = false;
                    btMenuPcipal.Click = false;
                    pagina = 1;
                    cargar = true;
                    posicion = 0;
                    resultados = "";
                    calcularRegistros = true;

                    estado = "Menu";
                }

                btSalir.UpDate(hand._RectColision, mouse);
                if (btSalir.Click)
                {
                    this.Exit();
                }
            }
            #endregion

            #region Error
            if (estado == "Error")
            {
                fondoTest.UpDate();
                lbMensaje.Posicion = new Vector2(400, 280);
                lbMensaje._Color = Color.Red;
                lbMensaje.Texto = "Clave erronea porfavor ingresela de nuevo.\nPresione aceptar para volver a intentarlo";
                btError.UpDate(hand._RectColision, mouse);
                if (btError._Empezar)
                {
                    btError._Empezar = false;
                    estado = "Resultados";
                }

                if (Keyboard.GetState().IsKeyDown(Keys.Enter)&&controlarEnter)
                {
                    //controlarEnter = false;
                    estado = "Resultados";
                }
                if (Keyboard.GetState().IsKeyUp(Keys.Enter))
                {
                    controlarEnter = true;
                }

                btMenuPcipal.UpDate(hand._RectColision, mouse);
                if (btMenuPcipal.Click)
                {
                    btError._Empezar = false;
                    //btAceptar._Enable = false;
                    btMenuPcipal.Click = false;
                    estado = "Menu";
                }
            }
            #endregion

            if (estado == "Salir")
            {
                this.Exit();
            }
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            #region Menu
            if (estado == "Menu")
            {
                fondoTest.Draw(spriteBatch);
                title.Draw(spriteBatch);
                menu.Draw(spriteBatch);
                albertIMG.Draw(spriteBatch);
            }
            #endregion

            #region Aplicar
            if (estado == "Aplicar")
            {
                fondoTest.Draw(spriteBatch);
                marcoFondo.Draw(spriteBatch);
                fondoForm.Draw(spriteBatch);
                textBox.Draw(spriteBatch);
                albertIMG.Draw(spriteBatch);
                btComenzar.Draw(spriteBatch);
                comboboxSexo.DrawComboBox(spriteBatch);
                comboboxEdad.DrawComboBox(spriteBatch);
                //lbNombre.Draw(spriteBatch);
                lbNombre.Draw(spriteBatch);
                lbEdad.Draw(spriteBatch);
                lbSexo.Draw(spriteBatch);
                btMenuPcipal.Draw(spriteBatch);
                marcoFondoDatos.Draw(spriteBatch);
                fondoDatos.Draw(spriteBatch);
                //lbDatosPersonal.Draw(spriteBatch);
                datosPers.Draw2(spriteBatch);
            }
            #endregion

            #region Ayuda
            if (estado == "Ayuda")
            {
                img_lamina.Draw2(spriteBatch);
                img_respuesta.Draw2(spriteBatch);
                img_seleccion.Draw2(spriteBatch);
                img_aciertodesacierto.Draw2(spriteBatch);
                ayudaMen.Draw(spriteBatch);
                btMenuPcipal.Draw(spriteBatch);
            }
            #endregion

            #region Empezar
            if (estado == "Empezar")
            {
                lbMensaje.Draw(spriteBatch);
                respuestas.Draw2(spriteBatch);
                encabezado.Draw2(spriteBatch);
                btMenuPcipal.Draw(spriteBatch);
            }
            #endregion

            #region Fin
            if (estado == "Fin")
            {
                fondoTest.Draw(spriteBatch);              
                albertIMG.Draw2(spriteBatch);
                btMenuPcipal.Draw(spriteBatch);
                btSalir.Draw(spriteBatch);
                mensajeNube.Draw2(spriteBatch);
                if (mensajeNube._Estado > 16)
                {
                    lbMensaje.Draw(spriteBatch);
                }
            }
            #endregion

            #region Resultados
            if (estado == "Resultados")
            {
                fondoTest.Draw(spriteBatch);
                btMenuPcipal.Draw(spriteBatch);
                fondoContra.Draw(spriteBatch);
                marcoFondoContra.Draw(spriteBatch);
                lbMensaje.Draw(spriteBatch);
                            
                passWord.Draw(spriteBatch);
                lbPassword.Draw(spriteBatch);
                
                btAceptar.Draw(spriteBatch);
            }
            #endregion

            #region Error
            if (estado == "Error")
            {
                fondoTest.Draw(spriteBatch);
                btMenuPcipal.Draw(spriteBatch);
                fondoContra.Draw(spriteBatch);
                marcoFondoContra.Draw(spriteBatch);
                btError.Draw(spriteBatch);
                lbMensaje.Draw(spriteBatch);
            }
            #endregion

            #region verResultado
            if (estado == "verResultado")
            {
                //menSaje.Draw(spriteBatch);
                fondoTest.Draw(spriteBatch);
                marcoFondoTable.Draw(spriteBatch);
                fondoTable.Draw(spriteBatch);
                cabeceraTabla.Draw(spriteBatch);
                lateralTabla.Draw(spriteBatch);
                tableResult.Draw(spriteBatch);
                for (int i = 0; i < 11; i++)
                {
                    separadorHorizontal[i].Draw(spriteBatch);
                    
                }
                for (int i = 0; i < 4; i++)
                {
                    separadorVertical[i].Draw(spriteBatch);
                }
                lbNombre.Draw(spriteBatch);
                //lbNombre.Draw(spriteBatch);
                lbEdad.Draw(spriteBatch);
                lbSexo.Draw(spriteBatch);
                lbIq.Draw(spriteBatch);
                lbNumero.Draw(spriteBatch);
                btMenuPcipal.Draw(spriteBatch);
                btAnterior.Draw(spriteBatch);
                btSiguiente.Draw(spriteBatch);
                btSalir.Draw(spriteBatch);
            }
            #endregion

            //logoUM.Draw(spriteBatch);
            logoUM.Draw(spriteBatch);
            hand.Draw(spriteBatch);
            base.Draw(gameTime);
        }

        private void construirTitulo()
        {
            pacientes = new List<paciente>();
            title = new Titulo("Test Raven", 100, 500, @"Fuentes\fuenteTitulo", Content);
            datosPers = new Titulo("Datos Personales", Content, @"Fuentes\fuenteMenu", 230, 140);
            menu = new Menu(800, 100, 10, rutaFuente, opcMenu);
            menu.LoadContent(Content);//1
            hand = new mano(12, 3, 5, 5, @"Imagenes\mano");
            fondoTest = new fondo(@"Imagenes\fondo");
            albertIMG = new albert(269, 413, 830, 300, @"Imagenes\albert");
            //logoUM = new logos(210, 75, 10, 620, @"Imagenes\logos");
            logoUM = new imagenStatic(210, 75, 10, 620, @"Imagenes\logos");
            tableResult = new tablaResultados(@"Fuentes\fuenteLb");
            sonidoFondo = new generaSonido(@"Sonido\house", Content, true);
        }

        private void construirFormulario()
        {
            textBox = new TextBox(338, 230, false);
            passWord = new TextBox(460, 330, true);
            comboboxSexo = new ComboBox(230, 310, opcsSexo);
            comboboxEdad = new ComboBox(525, 310, opcsEdad);

            //lbNombre = new nombre("Nombre: ", 230, 230, @"Fuentes\fuenteLb");
            lbNombre = new Label("Nombre: ", 230, 230, @"Fuentes\fuenteLb");
            lbEdad = new Label("Edad: ", 610, 275, @"Fuentes\fuenteLb");
            lbSexo = new Label("Sexo: ", 320, 275, @"Fuentes\fuenteLb");
            lbIq = new Label("IQ", 900, 80, @"Fuentes\fuenteLb");
            lbNumero = new Label("Nº", 250, 80, @"Fuentes\fuenteLb");
            lbPassword = new Label("Clave: ", 370, 330, @"Fuentes\fuenteLb");//F
            ayudaMen = new mensajeAyuda(@"Fuentes\fuenteLb");
            //lbDatosPersonal = new datosPersonales("Datos Personales", 230, 140, @"Fuentes\fuenteMenu");

            fondoDatos = new imagenStatic(586, 79, 200, 129, @"Imagenes\Tabla\FondoDatosPersonales");
            marcoFondoDatos = new imagenStatic(586, 79, 200, 129, @"Imagenes\Tabla\marcoDatosPersonales");
            fondoForm = new imagenStatic(600, 320, 200, 200, @"Imagenes\Formulario\fondoFormulario");
            marcoFondo = new imagenStatic(610, 330, 200, 200, @"Imagenes\Formulario\marcoFondoForm");
            //fondoContra = new fondoContrasenya(586, 188, graphics.GraphicsDevice.ScissorRectangle.Width / 2 - 586 / 2, graphics.GraphicsDevice.ScissorRectangle.Height / 2 - 188 / 2, @"Imagenes\Formulario\fondoContrasenya");
            fondoContra = new imagenStatic(586, 188, graphics.GraphicsDevice.ScissorRectangle.Width / 2 - 586 / 2, graphics.GraphicsDevice.ScissorRectangle.Height / 2 - 188 / 2, @"Imagenes\Formulario\fondoContrasenya");
            marcoFondoContra = new imagenStatic(586, 188, graphics.GraphicsDevice.ScissorRectangle.Width / 2 - 586 / 2, graphics.GraphicsDevice.ScissorRectangle.Height / 2 - 188 / 2, @"Imagenes\Formulario\marcoFondoContrasenya");
            fondoTable = new imagenStatic(900, 590, 200, 60, @"Imagenes\Tabla\fondoTabla");
            marcoFondoTable = new imagenStatic(900, 590, 200, 60, @"Imagenes\Tabla\marcoFondoTabla");
            separadorHorizontal = new List<imagenStatic>();
            separadorVertical = new List<imagenStatic>();
            cabeceraTabla = new imagenStatic(949, 49, 207, 66, @"Imagenes\Tabla\cabeceraTabla");
            lateralTabla = new imagenStatic(99, 448, 207, 117, @"Imagenes\Tabla\lateralTabla");
            createSeparadores();

            btComenzar = new boton(150, 40, 430, 490, 20, 2, @"Imagenes\Formulario\btComenzar", false, "Comenzar");
            btAceptar = new boton(150, 40, (graphics.GraphicsDevice.ScissorRectangle.Width / 2) - (150 / 2), 390, 30, 2, @"Imagenes\Formulario\btComenzar", false, "Aceptar");
            btError = new boton(150, 40, (graphics.GraphicsDevice.ScissorRectangle.Width / 2) - (150 / 2), 390, 30, 2, @"Imagenes\Formulario\btComenzar", true, "Aceptar");
            btMenuPcipal = new menuPcipal(380, 40, (graphics.GraphicsDevice.ScissorRectangle.Width / 2) - (380 / 2), 650, @"Imagenes\Formulario\menuPrincipal");
            btSalir = new menuPcipal(136, 40, (graphics.GraphicsDevice.ScissorRectangle.Width) - 136 * 2, 650, @"Imagenes\Formulario\salir");
            btAnterior = new boton(150, 40, 450, 583, 70, 3, @"Imagenes\Formulario\btComenzar", true, "<");
            btSiguiente = new boton(150, 40, 750, 583, 70, 3, @"Imagenes\Formulario\btComenzar", true, ">");
            

        }

        private void construirPlantilla()
        {
            img_lamina = new lamina(@"Imagenes\Ayuda\ayuda");
            img_respuesta = new respuesta(@"Imagenes\Ayuda\ayuda");
            img_seleccion = new seleccion(@"Imagenes\Ayuda\ayuda");
            img_aciertodesacierto = new acierto_desacierto(@"Imagenes\Ayuda\ayuda");
            _timer = 0.0f;
            rectResp = new plantillaRectResp();
            respuestas = new plantillaRespuestas();
            encabezado = new plantillaEncabezado();
            lbMensaje = new Label("Elija la pieza que corresponde", 20, 15, @"Fuentes\fuenteLb");
            mensajeNube = new mensajeIMG();
        }

        private void createSeparadores()
        {
            imagenStatic sepH;
            imagenStatic sepV;
            int yH = 115;
            int xV = 310;
            for (int i = 0; i < 11; i++)
            {
                sepH = new imagenStatic(947, 7, 202, yH, @"Imagenes\Tabla\separadorHorizontal");
                separadorHorizontal.Add(sepH);
                yH += 45;
            }
            for (int i = 0; i < 4; i++)
            {
                sepV = new imagenStatic(4, 502, xV, 67, @"Imagenes\Tabla\separadorVertical");
                separadorVertical.Add(sepV);
                switch (i)
                {
                    case 0:
                        xV += 280;
                        break;
                    case 1:
                        xV += 90;
                        break;
                    case 2:
                        xV += 158;
                        break;
                    case 3:
                        xV += 100;
                        break;
                }
                //xV += 100;
            }
        }

        private void cargarSeparadores()
        {
            for (int i = 0; i < 11; i++)
            {
                separadorHorizontal[i].LoadContent(Content);
                
            }

            for (int i = 0; i < 4; i++)
            {
                separadorVertical[i].LoadContent(Content);
            }
        }
    }
}

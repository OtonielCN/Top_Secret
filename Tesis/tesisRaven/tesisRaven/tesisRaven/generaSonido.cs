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
    class generaSonido
    {
        private AudioEngine engine;
        private WaveBank wave;
        private SoundBank sound;
        private Cue trackSound;
        private Song musica;

        private string rutaArchivo;

        public generaSonido(string rutaArchivoXAP, string filename)
        {
            engine = new AudioEngine(rutaArchivoXAP);
            sound = new SoundBank(engine, filename + "Sound Bank.xsb");
            wave = new WaveBank(engine, filename + "Wave Bank.xwb");
        }

        public generaSonido(string ruta, ContentManager Content,bool rep)
        {
            rutaArchivo = ruta;
            MediaPlayer.IsRepeating = rep;
            musica = Content.Load<Song>(rutaArchivo);
        }

        public void playSong()
        {
            MediaPlayer.Play(musica);
        }

        public void playSonido(string sonido)
        {
            trackSound = sound.GetCue(sonido);
            trackSound.Play();
            engine.Update();
        }
    }
}

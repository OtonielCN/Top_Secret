using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tesisRaven
{
    class paciente
    {
        private string nombre;
        private string genero;
        private string edad;
        private string iq;

        public paciente()
        {
            nombre = "";
            genero = "";
            edad = "";
            iq = "";
        }

        public string _Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string _Genero
        {
            get { return genero; }
            set { genero = value; }
        }

        public string _Edad
        {
            get { return edad; }
            set { edad = value; }
        }

        public string _IQ
        {
            get { return iq; }
            set { iq = value; }
        }
    }
}

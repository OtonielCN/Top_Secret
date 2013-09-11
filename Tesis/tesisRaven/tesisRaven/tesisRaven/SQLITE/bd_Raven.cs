using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;

namespace tesisRaven.SQLITE
{
    static class bd_Raven
    {
        private static SQLiteConnection conexion;
        private static string consulta_sql;
        private static SQLiteCommand command;
        private static SQLiteDataReader reader;

        private static List<paciente> pacientes;
        private static paciente pac;

        public static void _Conexion(string conex)
        {
            conexion = new SQLiteConnection(conex);
        }

        public static void _Insert(string consulta)
        {
            consulta_sql = consulta;
            conexion.Open();
            command = new SQLiteCommand(consulta_sql, conexion);
            command.ExecuteNonQuery();
            conexion.Close();
            //command.Dispose();
        }

        public static string _Select(string consulta)
        {
            consulta_sql = consulta;
            conexion.Open();
            command = new SQLiteCommand(consulta_sql, conexion);
            reader = command.ExecuteReader();
            string var1 = null;
            while (reader.Read())
            {
                var1 = reader.GetString(0);
            }
            conexion.Close();

            return var1;
        }

        public static List<paciente> _Resultados(string consulta)
        {
            pacientes = new List<paciente>();
            pac = new paciente();
        
            consulta_sql = consulta;
            conexion.Open();
            command = new SQLiteCommand(consulta_sql, conexion);
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                pac = new paciente();
                pac._Nombre = reader.GetString(0);
                pac._Edad = reader.GetString(1);
                pac._Genero = reader.GetString(2);
                pac._IQ = reader.GetString(3);
                pacientes.Add(pac);
            }
            conexion.Close();
            return pacientes;
        }

        public static int _NumRegistros(string consulta)
        {
            int registros=0;
            consulta_sql = consulta;
            conexion.Open();
            command = new SQLiteCommand(consulta_sql, conexion);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                registros = reader.GetInt32(0);
            }
            conexion.Close();

            return registros;
        }
    }
}

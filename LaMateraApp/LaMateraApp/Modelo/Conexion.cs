using System;
using System.Data.SqlClient;
using System.Configuration;


namespace LaMateraApp.Modelo
{
    public class Conexion
    {
        // Asegurate de tener esta variable protegida
        protected SqlConnection conexion;

        public Conexion()
        {
            // Esto lee tu cadena de conexión desde App.config
            string connectionString = ConfigurationManager.ConnectionStrings["ConexionDB"].ConnectionString;
            conexion = new SqlConnection(connectionString);
        }

        public void Abrir()
        {
            if (conexion.State == System.Data.ConnectionState.Closed)
                conexion.Open();
        }

        public void Cerrar()
        {
            if (conexion.State == System.Data.ConnectionState.Open)
                conexion.Close();
        }

        public SqlConnection GetConnection()
        {
            return conexion;
        }
    }
}


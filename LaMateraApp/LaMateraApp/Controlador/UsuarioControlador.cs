using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaMateraApp.Modelo;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LaMateraApp.Controlador
{
    public class UsuarioControlador : Conexion
    {
        public List<Usuario> ListarUsuarios()
        {
            List<Usuario> lista = new List<Usuario>();
            Abrir();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Usuarios", conexion);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                lista.Add(new Usuario
                {
                    IdUsuario = (int)reader["IdUsuario"],
                    Nombre = reader["Nombre"].ToString(),
                    Rol = reader["Rol"].ToString()
                });
            }

            reader.Close();
            Cerrar();
            return lista;
        }

        public void AgregarUsuario(Usuario u)
        {
            Abrir();
            SqlCommand cmd = new SqlCommand("INSERT INTO Usuarios (Nombre, Rol) VALUES (@Nombre, @Rol)", conexion);
            cmd.Parameters.AddWithValue("@Nombre", u.Nombre);
            cmd.Parameters.AddWithValue("@Rol", u.Rol);
            cmd.ExecuteNonQuery();
            Cerrar();
        }

        public void EliminarUsuario(int id)
        {
            try
            {
                Abrir(); // Abre la conexión
                string query = "DELETE FROM Usuarios WHERE IdUsuario = @Id";
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery(); // Ejecuta la consulta
                MessageBox.Show("Usuario eliminado con éxito.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el usuario: " + ex.Message);
            }
            finally
            {
                Cerrar(); // Cierra la conexión
            }
        }

    }
}



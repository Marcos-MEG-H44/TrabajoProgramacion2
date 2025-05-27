using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using LaMateraApp.Modelo;

namespace LaMateraApp.Controlador
{
    public class ProductoControlador : Conexion
    {
        // LISTAR productos
        public List<Producto> ListarProductos()
        {
            List<Producto> lista = new List<Producto>();

            try
            {
                Abrir();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Productos", GetConnection());
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Producto p = new Producto
                    {
                        IdProducto = Convert.ToInt32(dr["IdProducto"]),
                        Nombre = dr["Nombre"].ToString(),
                        Categoria = dr["Categoria"].ToString(),
                        PrecioCosto = Convert.ToDecimal(dr["PrecioCosto"]),
                        PrecioVenta = Convert.ToDecimal(dr["PrecioVenta"]),
                        Stock = Convert.ToInt32(dr["Stock"])
                    };
                    lista.Add(p);
                }
                dr.Close();
                Cerrar();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar productos: " + ex.Message);
            }

            return lista;
        }

        // AGREGAR producto
        public void AgregarProducto(Producto producto)
        {
            try
            {
                Abrir();
                SqlCommand cmd = new SqlCommand("INSERT INTO Productos (Nombre, Categoria, PrecioCosto, PrecioVenta, Stock) VALUES (@Nombre, @Categoria, @PrecioCosto, @PrecioVenta, @Stock)", GetConnection());
                cmd.Parameters.AddWithValue("@Nombre", producto.Nombre);
                cmd.Parameters.AddWithValue("@Categoria", producto.Categoria);
                cmd.Parameters.AddWithValue("@PrecioCosto", producto.PrecioCosto);
                cmd.Parameters.AddWithValue("@PrecioVenta", producto.PrecioVenta);
                cmd.Parameters.AddWithValue("@Stock", producto.Stock);
                cmd.ExecuteNonQuery();
                Cerrar();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar producto: " + ex.Message);
            }
        }

        // EDITAR producto
        public void EditarProducto(Producto producto)
        {
            try
            {
                Abrir();
                SqlCommand cmd = new SqlCommand("UPDATE Productos SET Nombre=@Nombre, Categoria=@Categoria, PrecioCosto=@PrecioCosto, PrecioVenta=@PrecioVenta, Stock=@Stock WHERE IdProducto=@Id", GetConnection());
                cmd.Parameters.AddWithValue("@Nombre", producto.Nombre);
                cmd.Parameters.AddWithValue("@Categoria", producto.Categoria);
                cmd.Parameters.AddWithValue("@PrecioCosto", producto.PrecioCosto);
                cmd.Parameters.AddWithValue("@PrecioVenta", producto.PrecioVenta);
                cmd.Parameters.AddWithValue("@Stock", producto.Stock);
                cmd.Parameters.AddWithValue("@Id", producto.IdProducto);
                cmd.ExecuteNonQuery();
                Cerrar();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al editar producto: " + ex.Message);
            }
        }

        // ELIMINAR producto
        public void EliminarProducto(int idProducto)
        {
            try
            {
                Abrir();
                SqlCommand cmd = new SqlCommand("DELETE FROM Productos WHERE IdProducto=@Id", GetConnection());
                cmd.Parameters.AddWithValue("@Id", idProducto);
                cmd.ExecuteNonQuery();
                Cerrar();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar producto: " + ex.Message);
            }
        }
    }
}

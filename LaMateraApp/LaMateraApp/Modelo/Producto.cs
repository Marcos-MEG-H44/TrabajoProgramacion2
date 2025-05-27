using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaMateraApp.Modelo
{
    public class Producto
    {
        // Propiedades (coinciden con columnas de la tabla Productos)
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public decimal PrecioCosto { get; set; }
        public decimal PrecioVenta { get; set; }
        public int Stock { get; set; }

        // Constructor vacío (necesario para leer desde DB o crear sin datos)
        public Producto() { }

        // Constructor con todos los datos
        public Producto(int idProducto, string nombre, string categoria, decimal precioCosto, decimal precioVenta, int stock)
        {
            IdProducto = idProducto;
            Nombre = nombre;
            Categoria = categoria;
            PrecioCosto = precioCosto;
            PrecioVenta = precioVenta;
            Stock = stock;
        }
    }
}

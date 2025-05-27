using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LaMateraApp.Modelo;
using LaMateraApp.Controlador;

namespace LaMateraApp.Vista
{
    public partial class UCProductos : UserControl
    {

        private ProductoControlador controlador = new ProductoControlador();
        private int idSeleccionado = 0;

        public UCProductos()
        {
            InitializeComponent();
            CargarProductos();
        }

        private void CargarProductos()
        {
            dgvProductos.DataSource = null;
            dgvProductos.DataSource = controlador.ListarProductos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Producto nuevo = new Producto
                {
                    Nombre = txtNombre.Text,
                    Categoria = txtCategoria.Text,
                    PrecioCosto = decimal.Parse(txtPrecioCosto.Text),
                    PrecioVenta = decimal.Parse(txtPrecioVenta.Text),
                    Stock = int.Parse(txtStock.Text)
                };

                controlador.AgregarProducto(nuevo);
                MessageBox.Show("Producto agregado.");
                CargarProductos();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar: " + ex.Message);
            }
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                idSeleccionado = Convert.ToInt32(dgvProductos.Rows[e.RowIndex].Cells["IdProducto"].Value);
                txtNombre.Text = dgvProductos.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                txtCategoria.Text = dgvProductos.Rows[e.RowIndex].Cells["Categoria"].Value.ToString();
                txtPrecioCosto.Text = dgvProductos.Rows[e.RowIndex].Cells["PrecioCosto"].Value.ToString();
                txtPrecioVenta.Text = dgvProductos.Rows[e.RowIndex].Cells["PrecioVenta"].Value.ToString();
                txtStock.Text = dgvProductos.Rows[e.RowIndex].Cells["Stock"].Value.ToString();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0)
            {
                MessageBox.Show("Seleccioná un producto para editar.");
                return;
            }

            try
            {
                Producto producto = new Producto
                {
                    IdProducto = idSeleccionado,
                    Nombre = txtNombre.Text,
                    Categoria = txtCategoria.Text,
                    PrecioCosto = decimal.Parse(txtPrecioCosto.Text),
                    PrecioVenta = decimal.Parse(txtPrecioVenta.Text),
                    Stock = int.Parse(txtStock.Text)
                };

                controlador.EditarProducto(producto);
                MessageBox.Show("Producto actualizado.");
                CargarProductos();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar: " + ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0)
            {
                MessageBox.Show("Seleccioná un producto para eliminar.");
                return;
            }

            var confirm = MessageBox.Show("¿Estás seguro de eliminar?", "Confirmar", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    controlador.EliminarProducto(idSeleccionado);
                    MessageBox.Show("Producto eliminado.");
                    CargarProductos();
                    LimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar: " + ex.Message);
                }
            }
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtCategoria.Clear();
            txtPrecioCosto.Clear();
            txtPrecioVenta.Clear();
            txtStock.Clear();
            idSeleccionado = 0;
        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }

        private void UCProductos_Load(object sender, EventArgs e)
        {

        }
    }
}

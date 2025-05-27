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
    public partial class UCUsuarios : UserControl
    {
        private UsuarioControlador controlador = new UsuarioControlador();
        private int idSeleccionado = 0;

        public UCUsuarios()
        {
            InitializeComponent();
            CargarUsuarios();
        }

        private void UCUsuarios_Load(object sender, EventArgs e)
        {
            CargarUsuarios(); // Por si querés volver a cargar al iniciar
        }

        private void CargarUsuarios()
        {
            dgvUsuarios.DataSource = null;
            dgvUsuarios.DataSource = controlador.ListarUsuarios();
        }

        private void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtRol.Text))
                {
                    MessageBox.Show("Por favor, completá todos los campos.");
                    return;
                }

                Usuario nuevo = new Usuario
                {
                    Nombre = txtNombre.Text,
                    Rol = txtRol.Text
                };

                controlador.AgregarUsuario(nuevo);
                MessageBox.Show("Usuario agregado con éxito.");
                CargarUsuarios();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar usuario: " + ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0)
            {
                MessageBox.Show("Por favor, seleccioná un usuario para eliminar.");
                return;
            }

            var confirmacion = MessageBox.Show(
                "¿Estás seguro de que querés eliminar este usuario?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    controlador.EliminarUsuario(idSeleccionado);
                    MessageBox.Show("Usuario eliminado con éxito.");
                    CargarUsuarios();
                    LimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar el usuario: " + ex.Message);
                }
            }
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                idSeleccionado = Convert.ToInt32(dgvUsuarios.Rows[e.RowIndex].Cells["IdUsuario"].Value);
                txtNombre.Text = dgvUsuarios.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                txtRol.Text = dgvUsuarios.Rows[e.RowIndex].Cells["Rol"].Value.ToString();
            }
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtRol.Clear();
            idSeleccionado = 0;
        }
    }
}

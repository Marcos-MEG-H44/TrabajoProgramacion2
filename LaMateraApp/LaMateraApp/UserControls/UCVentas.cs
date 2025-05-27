using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace LaMateraApp.Vista
{
    public partial class UCVentas : UserControl
    {
        public UCVentas()
        {
            InitializeComponent();
        }

        private void btnRegistrarVenta_Click(object sender, EventArgs e)
        {
            try
            {
                // Validación del campo de monto
                if (string.IsNullOrWhiteSpace(txtMonto.Text))
                {
                    MessageBox.Show("Por favor, ingrese el monto de la venta.");
                    return;
                }

                // Captura de datos
                DateTime fechaVenta = dateTimePicker.Value;
                decimal monto = decimal.Parse(txtMonto.Text); // puede lanzar excepción

                // Simulación de registro (más adelante podés conectarlo a base de datos)
                MessageBox.Show($"✅ Venta registrada con éxito.\n\n📅 Fecha: {fechaVenta.ToShortDateString()}\n💲 Monto: {monto:C}");

                // Limpiar los campos
                txtMonto.Clear();
                dateTimePicker.Value = DateTime.Now;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Error al registrar la venta:\n{ex.Message}");
            }
        }
    }
}

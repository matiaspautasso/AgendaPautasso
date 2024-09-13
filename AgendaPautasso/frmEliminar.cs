using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgendaPautasso
{
    public partial class frmEliminar : Form
    {
        public frmEliminar()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Indicar que el usuario canceló la operación
            this.DialogResult = DialogResult.Cancel;

            // Cerrar el formulario
            this.Close();
        }
        clsConexion clsConexion = new clsConexion();    

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener los datos del formulario
                string nombre = txtNombre.Text;
                string apellido = txtApellido.Text;

                // Eliminar el contacto de la base de datos
                clsConexion.Eliminar(nombre, apellido);

                // Indicar que la operación fue exitosa
                this.DialogResult = DialogResult.OK;

                // Cerrar el formulario actual (frmEliminar)
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el contacto: " + ex.Message);
            }

        }
    }
}

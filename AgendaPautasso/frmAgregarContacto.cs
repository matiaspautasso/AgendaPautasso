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
    public partial class frmAgregarContacto : Form
    {
        public frmAgregarContacto()
        {
            InitializeComponent();
        }

        private void frmAgregarContacto_Load(object sender, EventArgs e)
        {
            cboCategoria.Items.Clear();
            cboCategoria.Items.Clear();
            cboCategoria.Items.Add("Amigos");
            cboCategoria.Items.Add("Familia");
            cboCategoria.Items.Add("Trabajo");
        }
        clsConexion clsConexion = new clsConexion();

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try  // uso try catch para manejar futuros errores por ej si intento meter algun formato que no corresponda
            {
                // Obtener los datos del formulario
                string nombre = txtNombre.Text;
                string apellido = txtApellido.Text;
                string tel = txtTelefono.Text;
                string mail = txtCorreo.Text;
                string categoria = cboCategoria.Text;

                // Agregar el contacto a la base de datos
                clsConexion.Agregar(nombre, apellido, tel, mail, categoria);

                // Indicar que la operación fue exitosa    osea que el usuario cargo el contacto
                this.DialogResult = DialogResult.OK;

                // Cerrar el formulario
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el contacto: " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Indicar que el usuario canceló la operación
            this.DialogResult = DialogResult.Cancel;

            // Cerrar el formulario
            this.Close();
        }
    }
}

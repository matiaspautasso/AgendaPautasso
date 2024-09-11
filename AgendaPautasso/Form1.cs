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
    public partial class frmAgenda : Form
    {
        public frmAgenda()
        {
            InitializeComponent();
        }
        clsConexion conexion = new clsConexion();

        private void Form1_Load(object sender, EventArgs e)
        {
            conexion = new clsConexion();
            //conexion.VerificarConexion();
            conexion.MostrarGrilla(DgvAgenda);
            cmbCategoria.Items.Clear();
            cmbCategoria.Items.Add("Amigos");
            cmbCategoria.Items.Add("Familia");
            cmbCategoria.Items.Add("Trabajo");
            
            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAgregarContacto frmAgregarContacto = new frmAgregarContacto();

            // ===> dialogResult significa que si el usuario al estar en el otro formulario, le dio a ok es true, si cierra el frm abierto
            // seria DialogResult.Cancel 
            if (frmAgregarContacto.ShowDialog() == DialogResult.OK)  
            {
                // Actualizar la grilla si el contacto fue agregado correctamente
                conexion.MostrarGrilla(DgvAgenda); 
            }
        }
    }
}

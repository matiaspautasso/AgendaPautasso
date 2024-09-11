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
            cmbCategoria.Items.Clear();
            cmbCategoria.Items.Add("Amigos");
            cmbCategoria.Items.Add("Familia");
            cmbCategoria.Items.Add("Trabajo");
            
            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAgregarContacto frmAgregarContacto = new frmAgregarContacto();
            frmAgregarContacto.ShowDialog();    
        }
    }
}

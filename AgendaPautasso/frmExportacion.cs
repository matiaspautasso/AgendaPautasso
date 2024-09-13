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
    public partial class frmExportacion : Form
    {
        public frmExportacion()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            string categoria = cboExportar.SelectedItem.ToString();
            string tipoArchivo;

            if (rdbCsv.Checked)
            {
                tipoArchivo = "Csv";
            }
            else
            {
                tipoArchivo = "Excel";
            }

            clsConexion conexion = new clsConexion();
            conexion.Exportar(categoria, tipoArchivo);

            MessageBox.Show("Exportación realizada con éxito!");
        }

        private void frmExportacion_Load(object sender, EventArgs e)
        {
            cboExportar.Items.Clear();
            cboExportar.Items.Clear();
            cboExportar.Items.Add("Amigos");
            cboExportar.Items.Add("Familia");
            cboExportar.Items.Add("Trabajo");
            cboExportar.Items.Add("Todos");
            cboExportar.SelectedIndex = 3;
        }
    }
}

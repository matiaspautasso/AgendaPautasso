using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgendaPautasso
{
    public partial class frmEditarContacto : Form
    {
        public frmEditarContacto()
        {
            InitializeComponent();
        }

        private void frmEditarContacto_Load(object sender, EventArgs e)
        {
            cboCategoria.Items.Clear();
            cboCategoria.Items.Add("Amigos");
            cboCategoria.Items.Add("Familia");
            cboCategoria.Items.Add("Trabajo");
            CargarCategoriasEnTreeView();
            clsConexion conexion = new clsConexion();
            conexion.MostrarTreeView(TvMostrar);
            TvMostrar.AfterSelect += treeViewCategorias_AfterSelect;
        }
        private void CargarCategoriasEnTreeView()
        {
            // Limpiar el TreeView 
            TvMostrar.Nodes.Clear();

            // Iterar sobre los elementos del ComboBox (cboCategoria)
            foreach (var item in cboCategoria.Items)
            {
                // Crear un nodo para cada elemento del ComboBox
                TreeNode nodo = new TreeNode(item.ToString());

                // Agregar el nodo al TreeView (treeViewCategorias)
                TvMostrar.Nodes.Add(nodo);
            }
        }
        private void treeViewCategorias_AfterSelect(object sender, TreeViewEventArgs e)   //este evento traslada los datos que el usuario clickeo a las cajas de texto
        {
            // Verificar si el nodo seleccionado es un nodo hijo 
            if (e.Node.Parent != null)
            {
                // Obtener el texto del nodo (formato: "Nombre Apellido - Telefono - Correo")
                string[] datosContacto = e.Node.Text.Split('-');

                if (datosContacto.Length == 3)
                {
                    // Llenar los campos con los datos del contacto seleccionado

                    // Llenar txtNombre y txtApellido (separar por espacio)
                    string[] nombreApellido = datosContacto[0].Trim().Split(' ');
                    if (nombreApellido.Length >= 2)
                    {
                        txtNombre.Text = nombreApellido[0];   //==> aca traslada los campos seleccionados a los componentes 
                        txtApellido.Text = nombreApellido[1];
                    }

                    // Llenar txtTelefono
                    txtTelefono.Text = datosContacto[1].Trim();

                    // Llenar txtCorreo
                    txtCorreo.Text = datosContacto[2].Trim();

                    // Llenar cboCategoria con la categoría del nodo padre
                    cboCategoria.Text = e.Node.Parent.Text;
                }
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        clsConexion clsConexion = new clsConexion();
        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }
    }



}


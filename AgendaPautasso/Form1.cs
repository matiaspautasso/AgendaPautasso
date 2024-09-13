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
            cmbCategoria.Items.Add("Todos");
            cmbCategoria.SelectedIndex = 3;
            //recordar cambiar icon de cada formulario
            // recordar cambiar icono de ejecutable

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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string categoriaSeleccionada = cmbCategoria.Text;
            
            string textoBusqueda = txtBuscar.Text;


            // Verificar qué tipo de búsqueda se debe hacer
            if (!string.IsNullOrEmpty(categoriaSeleccionada) && !string.IsNullOrEmpty(textoBusqueda))
            {
                // Escenario 3: Buscar por categoría y por texto (nombre, teléfono o correo)
                conexion.BuscarPorCategoriaYTexto(categoriaSeleccionada, textoBusqueda,DgvAgenda);
            }
            else if (!string.IsNullOrEmpty(categoriaSeleccionada))
            {
                // Escenario 1: Solo buscar por categoría
                conexion.BuscarPorCategoria(categoriaSeleccionada, DgvAgenda);
            }
            else if (!string.IsNullOrEmpty(textoBusqueda))
            {
                // Escenario 2: Solo buscar por texto (nombre, teléfono o correo)
                conexion.BuscarPorTexto(textoBusqueda,DgvAgenda);
            }
            else
            {
                // Si no hay criterios de búsqueda, puedes mostrar un mensaje o volver a mostrar todos los contactos
                MessageBox.Show("Por favor, seleccione una categoría o ingrese un término de búsqueda.");
            }
            if(cmbCategoria.Text=="Todos")
            {
               
                conexion.MostrarGrilla(DgvAgenda);
            }

        }

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCategoria.Text == "Todos")
            {
                txtBuscar.Enabled = false;  ///
            }
            else 
            {
                txtBuscar.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e) //btnEliminar
        {
            frmEliminar frmEliminar = new frmEliminar();

            // ===> dialogResult significa que si el usuario al estar en el otro formulario, le dio a ok es true, si cierra el frm abierto
            // seria DialogResult.Cancel 
            if (frmEliminar.ShowDialog() == DialogResult.OK)
            {
                // Actualizar la grilla si el contacto fue agregado correctamente
                conexion.MostrarGrilla(DgvAgenda);
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            frmExportacion frmExportacion = new frmExportacion();   
            frmExportacion.ShowDialog();

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            frmEditarContacto frmEditar = new frmEditarContacto();  
            frmEditar.ShowDialog(); 
        }
    }
}

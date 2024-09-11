using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using System.Collections;
using System.Data.Common;

namespace AgendaPautasso
{
    internal class clsConexion
    {
        OleDbCommand comando;
        OleDbConnection conexion;
        OleDbDataAdapter adaptador;

        string cadena;
        public clsConexion()
        {
            cadena = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=./BdAgenda.accdb";
            //recordar esta conexion ==> cadena = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=./Usuarios.mdb;";
        }
        public bool VerificarConexion()
        {
            bool result = false;

            conexion = new OleDbConnection(cadena);
            try
            {
                conexion.Open();
                result = true;
                MessageBox.Show("conectado");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { conexion.Close(); }

            return result;
        }
        public void Agregar(string nombre, string apellido, int telefono, string correo, string categoria) 
        {
            try
            {
                conexion = new OleDbConnection(cadena);
                comando = new OleDbCommand();
                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = "INSERT INTO AGENDA (Nombre, Apellido, Telefono, Correo, Categoria) " +
                             "VALUES (@nombre, @apellido, @telefono, @correo, @categoria)";  //recordar estos son los valores que le paso
                                                                                             //a la base de datos por eso se escriben con @
               
                comando.Parameters.AddWithValue("@nombre", nombre);
                comando.Parameters.AddWithValue("@apellido", apellido);
                comando.Parameters.AddWithValue("@telefono", telefono);
                comando.Parameters.AddWithValue("@correo", correo);
                comando.Parameters.AddWithValue("@categoria", categoria);
                
                conexion.Open();
                comando.ExecuteNonQuery();

            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
            finally 
            {
                conexion.Close();
            }
        
        }
        public void MostrarGrilla(DataGridView grilla)
        {
            try
            {
                conexion = new OleDbConnection(cadena);
                comando = new OleDbCommand();
                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = "SELECT * FROM AGENDA";
                DataTable TABLA = new DataTable();
                adaptador = new OleDbDataAdapter(comando);
                adaptador.Fill(TABLA);
                grilla.DataSource = TABLA;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexion.Close();
            }
        }


    }
}

using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

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
            cadena = "";
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


    }
}

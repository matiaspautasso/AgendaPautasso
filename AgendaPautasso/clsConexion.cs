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
        public void Agregar(string nombre, string apellido, string telefono, string correo, string categoria)
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
        public void Eliminar(string nombre, string apellido)
        {
            try
            {
                conexion = new OleDbConnection(cadena);  // Inicializa la conexión
                comando = new OleDbCommand();  // Crea el comando
                comando.Connection = conexion;  // Asocia el comando con la conexión
                comando.CommandType = CommandType.Text;  // Tipo de comando: texto (consulta SQL)

                // Consulta SQL adaptada para eliminar según Nombre y Apellido
                comando.CommandText = "DELETE FROM AGENDA WHERE Nombre = @Nombre AND Apellido = @Apellido";

                // Asocia los parámetros para evitar inyecciones SQL y errores de tipo
                comando.Parameters.AddWithValue("@Nombre", nombre);
                comando.Parameters.AddWithValue("@Apellido", apellido);

                conexion.Open();  // Abre la conexión
                comando.ExecuteNonQuery();  // Ejecuta la consulta de eliminación
            }
            catch (Exception ex)
            {
                // Muestra un mensaje en caso de error
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // Asegura que la conexión se cierre siempre, haya error o no
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
        public void BuscarPorCategoria(string categoria, DataGridView dgv)
        {
            try
            {
                conexion = new OleDbConnection(cadena);
                comando = new OleDbCommand();
                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;

                // Consulta SQL para buscar por categoría
                comando.CommandText = "SELECT * FROM AGENDA WHERE Categoria = @categoria";
                comando.Parameters.AddWithValue("@categoria", categoria);
                //recordar el uso de parametros con @ sirven para insertar ese argumento literalmente en la base 
                DataTable tabla = new DataTable();
                adaptador = new OleDbDataAdapter(comando);
                adaptador.Fill(tabla);

                dgv.DataSource = tabla; // Actualizar el DataGridView con los resultados
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
        public void BuscarPorTexto(string texto, DataGridView dgv)
        {
            try
            {
                conexion = new OleDbConnection(cadena);
                comando = new OleDbCommand();
                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;

                // Consulta SQL para buscar por nombre, teléfono o correo
                comando.CommandText = "SELECT * FROM AGENDA WHERE Nombre LIKE @texto OR Telefono LIKE @texto OR Correo LIKE @texto";
                comando.Parameters.AddWithValue("@texto", "%" + texto + "%"); // Usar LIKE para buscar coincidencias de cadenas de texto 
                //recordar uso de % entre cadenas de texto para busqueda parcial ej : 
                //===> se busca %matias%, osea se busca matias dentro de la base 
                DataTable tabla = new DataTable();
                adaptador = new OleDbDataAdapter(comando);
                adaptador.Fill(tabla);

                dgv.DataSource = tabla; // Actualizar el DataGridView con los resultados
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
        public void BuscarPorCategoriaYTexto(string categoria, string texto, DataGridView dgv)
        {
            try
            {
                conexion = new OleDbConnection(cadena);
                comando = new OleDbCommand();
                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;

                // Consulta SQL para buscar por categoría y también nombre, teléfono o correo
                comando.CommandText = "SELECT * FROM AGENDA WHERE Categoria = @categoria AND (Nombre LIKE @texto OR Telefono LIKE @texto OR Correo LIKE @texto)";
                comando.Parameters.AddWithValue("@categoria", categoria);
                comando.Parameters.AddWithValue("@texto", "%" + texto + "%"); // Usar LIKE para búsquedas parciales
                //recordar uso % EJ : buscar matias ===> %matias% 
                DataTable tabla = new DataTable();
                adaptador = new OleDbDataAdapter(comando);
                adaptador.Fill(tabla);

                dgv.DataSource = tabla; // Actualizar el DataGridView con los resultados
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

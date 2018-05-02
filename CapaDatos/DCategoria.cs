using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DCategoria
    {
        

        public int IdCategoria { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        // para hacer el filtro
        public string TextoBuscar { get; set; }

        public DCategoria()
        {

        }
        public DCategoria(string nombre, string descripcion)
        {
            this.Nombre = nombre;
            this.Descripcion = descripcion;
        }
        public DCategoria(int idCategoria, string nombre, string descripcion)
        {
            this.IdCategoria = idCategoria;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
        }

        public string Insertar1(DCategoria categoria)
        {
            string rpta = "";
            string cadena = "sp_insertar_categoria";
            SqlConnection cn = new SqlConnection();

            try
            {
                // code here 
                cn.ConnectionString = Conexion.conectar;
                cn.Open();

                using (SqlCommand cmd = new SqlCommand(cadena, cn))
                {
                    cmd.Parameters.AddWithValue("@nombre", categoria.Nombre);
                    cmd.Parameters.AddWithValue("@descripcion", categoria.Descripcion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    rpta = cmd.ExecuteNonQuery() == 1 ? "Ok" : "Error al registrar categoria";
                       
                }

            }
            catch (Exception ex)
            {
                rpta = ex.Message;
                throw;
            }
            finally
            {
                if (cn.State == ConnectionState.Open) cn.Close();
            }
            return rpta;
        }

        // metodo insertar
        public bool Insertar(DCategoria categoria)
        {
            string cadena = "sp_insertar_categoria";
            SqlConnection cn = new SqlConnection();
            try
            {
                // code here
                cn.ConnectionString = Conexion.conectar;
                cn.Open();

                using (SqlCommand cmd = new SqlCommand(cadena, cn))
                {
                    cmd.Parameters.AddWithValue("@nombre", categoria.Nombre);
                    cmd.Parameters.AddWithValue("@descripcion", categoria.Descripcion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    int r = cmd.ExecuteNonQuery();
                    if (r == 1) return true;
                }

            }
            catch (Exception ex)
            {
                return false;
                throw;                
            }
            finally
            {
                if (cn.State == ConnectionState.Open) cn.Close();
            }
            return false;
        }
        // metodo editar
        public string Editar(DCategoria categoria)
        {
            string r = "";
            string cadena = "sp_insertar_categoria";
            SqlConnection cn = new SqlConnection();
            try
            {
                // code here
                cn.ConnectionString = Conexion.conectar;
                cn.Open();

                using (SqlCommand cmd = new SqlCommand(cadena, cn))
                {
                    cmd.Parameters.AddWithValue("@nombre", categoria.Nombre);
                    cmd.Parameters.AddWithValue("@descripcion", categoria.Descripcion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    r = cmd.ExecuteNonQuery().ToString();
                    if (int.Parse(r) == 1) r = "Ok";
                    else r = "Error al insertar categoria";
                }

            }
            catch (Exception ex)
            {
                r = ex.Message;
                throw;
            }
            finally
            {
                if (cn.State == ConnectionState.Open) cn.Close();
            }
            return r;
        }
        // metodo eliminar
        public string Eliminar(DCategoria categoria)
        {
            string r = "";
            string cadena = "sp_insertar_categoria";
            SqlConnection cn = new SqlConnection();
            try
            {
                // code here
                cn.ConnectionString = Conexion.conectar;
                cn.Open();

                using (SqlCommand cmd = new SqlCommand(cadena, cn))
                {
                    cmd.Parameters.AddWithValue("@nombre", categoria.Nombre);
                    cmd.Parameters.AddWithValue("@descripcion", categoria.Descripcion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    //r = cmd.ExecuteNonQuery() == 1 ? "Ok" : "Error al insertar categoria";
                    r = cmd.ExecuteNonQuery().ToString();
                    if (int.Parse(r) == 1) r = "Ok";
                    else r = "Error al insertar categoria";
                }

            }
            catch (Exception ex)
            {
                r = ex.Message;
                throw;
            }
            finally
            {
                if (cn.State == ConnectionState.Open) cn.Close();
            }
            return r;
        }
        // metodo listar
        public DataTable Listar()
        {
            DataTable tabla = new DataTable();
            return tabla;
        }
        // metodo buscar por nombre de categoria
        public DataTable BuscarNombre(DCategoria Categoria)
        {
            DataTable tabla = new DataTable();
            return tabla;
        }

    }
}

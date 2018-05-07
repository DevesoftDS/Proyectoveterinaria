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

        //public string BuscarCategoria { get; set; }

        // para hacer el filtro
        public string TextoBuscar { get; set; }

        public DCategoria()
        {

        }
        public DCategoria(int idcategoria)
        {
            this.IdCategoria = idcategoria;

        }
        public DCategoria(string nombre, string descripcion)
        {
            this.Nombre = nombre;
            this.Descripcion = descripcion;
        }
        public DCategoria(string nombre, string descripcion, int idCategoria)
        {
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.IdCategoria = idCategoria;
        }

        // metodo insertar
        public int Insertar(DCategoria categoria)
        {
            int rpta = 0;
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

                    rpta = cmd.ExecuteNonQuery();
                       
                }

            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return rpta;
                throw;
            }
            finally
            {
                if (cn.State == ConnectionState.Open) cn.Close();
            }
            return rpta;
        }


        // metodo editar
        public int Actualizar(DCategoria categoria)
        {
            int r = 0;
            string cadena = "sp_modificar_categoria";
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
                    cmd.Parameters.AddWithValue("@idcategoria", categoria.IdCategoria);
                    cmd.CommandType = CommandType.StoredProcedure;

                    r = cmd.ExecuteNonQuery();

                }

            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return r;
                throw;
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close();
            }
            return r;
        }
        // metodo eliminar
        public bool Eliminar(DCategoria categoria)
        {
            int r = 0;
            string cadena = "sp_eliminar_categoria";
            SqlConnection cn = new SqlConnection();
            try
            {
                // code here
                cn.ConnectionString = Conexion.conectar;
                cn.Open();

                using (SqlCommand cmd = new SqlCommand(cadena, cn))
                {
                    cmd.Parameters.AddWithValue("@id", categoria.IdCategoria);
                    cmd.CommandType = CommandType.StoredProcedure;

                    r = cmd.ExecuteNonQuery();
                    if (r == 1)
                        return true;
                }

            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return false;
                throw;
            }
            finally
            {
                if (cn.State == ConnectionState.Open) cn.Close();
            }
            return false;
        }
        // metodo listar
        public DataTable Listar()
        {
            string cadena = "sp_listar_categoria";
            DataTable tabla = new DataTable();
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conexion.conectar;
                cn.Open();
                using (SqlDataAdapter da = new SqlDataAdapter(cadena, cn))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.Fill(tabla);
                }
            }
            catch (Exception)
            {
                return tabla;
                throw;
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close();
            }
            return tabla;
        }
        // metodo buscar por nombre de categoria
        public DataTable BuscarNombre(DCategoria categoria)
        {
            string cadena = "sp_buscar_categoria_por_nombre";
            DataTable tabla = new DataTable();
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conexion.conectar;
                cn.Open();
                using (SqlDataAdapter da = new SqlDataAdapter(cadena, cn))
                {
                    da.SelectCommand.Parameters.AddWithValue("@nombre", categoria.Nombre);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.Fill(tabla);
                }
            }
            catch (Exception)
            {
                return tabla;
                throw;
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close();
            }
            return tabla;
        }

        //metodo buscar por codigo
        public DataTable BuscarPorCodigo(DCategoria categoria)
        {
            string cadena = "sp_buscar_categoria_por_codigo";
            DataTable tabla = new DataTable();
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conexion.conectar;
                cn.Open();
                using (SqlDataAdapter da = new SqlDataAdapter(cadena, cn))
                {
                    da.SelectCommand.Parameters.AddWithValue("@id", categoria.IdCategoria);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.Fill(tabla);
                }
            }
            catch (Exception)
            {
                return tabla;
                throw;
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close();
            }
            return tabla;
        }

    }
}

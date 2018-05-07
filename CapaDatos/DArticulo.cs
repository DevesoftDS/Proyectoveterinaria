using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaDatos
{
    public class DArticulo
    {
        public int IdArticulo { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public int IdCategoria { get; set; }
        public int IdPresentacion { get; set; }
        public string Neto { get; set; }
        public string Descripcion { get; set; }
        public byte[] Imagen { get; set; }

        public DArticulo()
        {

        }
        public DArticulo(string codigo, string nombre, int idCategoria, int idPresentacion, string neto, string descripcion, byte[] imagen, int idArticulo)
        {
            this.Codigo = codigo;
            this.Nombre = nombre;
            this.IdCategoria = idCategoria;
            this.IdPresentacion = idPresentacion;
            this.Neto = neto;
            this.Descripcion = descripcion;
            this.Imagen = imagen;
            this.IdArticulo = idArticulo;
        }
        public DArticulo(string codigo, string nombre, int idCategoria, int idPresentacion, string neto, string descripcion, byte[] imagen)
        {
            this.Codigo = codigo;
            this.Nombre = nombre;
            this.IdCategoria = idCategoria;
            this.IdPresentacion = idPresentacion;
            this.Neto = neto;
            this.Descripcion = descripcion;
            this.Imagen = imagen;
        }
        public DArticulo(int idArticulo)
        {
            this.IdArticulo = idArticulo;
        }

        public bool Insertar(DArticulo articulo)
        {
            int rpta = 0;
            string cadena = "sp_insertar_articulo";
            SqlConnection cn = new SqlConnection();

            try
            {
                // code here 
                cn.ConnectionString = Conexion.conectar;
                cn.Open();

                using (SqlCommand cmd = new SqlCommand(cadena, cn))
                {
                    cmd.Parameters.AddWithValue("@codigo", articulo.Codigo);
                    cmd.Parameters.AddWithValue("@nombre", articulo.Nombre);
                    cmd.Parameters.AddWithValue("@idcategoria", articulo.IdCategoria);
                    cmd.Parameters.AddWithValue("@idpresentacion", articulo.IdPresentacion);
                    cmd.Parameters.AddWithValue("@neto", articulo.Neto);
                    cmd.Parameters.AddWithValue("@descripcion", articulo.Descripcion);
                    cmd.Parameters.AddWithValue("@imagen", articulo.Imagen);
                    cmd.CommandType = CommandType.StoredProcedure;

                    rpta = cmd.ExecuteNonQuery();
                    if (rpta == 1)
                        return true;

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error ... ???", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
                throw;

            }
            finally
            {
                if (cn.State == ConnectionState.Open) cn.Close();
            }
            return false;
        }

        public bool Actualizar(DArticulo articulo)
        {
            int rpta = 0;
            string cadena = "sp_modificar_articulo";
            SqlConnection cn = new SqlConnection();

            try
            {
                // code here 
                cn.ConnectionString = Conexion.conectar;
                cn.Open();

                using (SqlCommand cmd = new SqlCommand(cadena, cn))
                {
                    cmd.Parameters.AddWithValue("@codigo", articulo.Codigo);
                    cmd.Parameters.AddWithValue("@nombre", articulo.Nombre);
                    cmd.Parameters.AddWithValue("@idcategoria", articulo.IdCategoria);
                    cmd.Parameters.AddWithValue("@idpresentacion", articulo.IdPresentacion);
                    cmd.Parameters.AddWithValue("@neto", articulo.Neto);
                    cmd.Parameters.AddWithValue("@descripcion", articulo.Descripcion);
                    cmd.Parameters.AddWithValue("@imagen", articulo.Imagen);
                    cmd.Parameters.AddWithValue("@id", articulo.IdArticulo);
                    cmd.CommandType = CommandType.StoredProcedure;

                    rpta = cmd.ExecuteNonQuery();
                    if (rpta == 1)
                        return true;

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error ... ???", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
                throw;

            }
            finally
            {
                if (cn.State == ConnectionState.Open) cn.Close();
            }
            return false;
        }


        public bool Eliminar(DArticulo articulo)
        {
            int r = 0;
            string cadena = "sp_eliminar_articulo";
            SqlConnection cn = new SqlConnection();
            try
            {
                // code here
                cn.ConnectionString = Conexion.conectar;
                cn.Open();

                using (SqlCommand cmd = new SqlCommand(cadena, cn))
                {
                    cmd.Parameters.AddWithValue("@id", articulo.IdArticulo);
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

        public DataTable Listar()
        {
            string cadena = "sp_listar_articulo";
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

        // metodo buscar por nombre
        public DataTable BuscarNombre(DArticulo articulo)
        {
            string cadena = "sp_buscar_articulo_por_nombre";
            DataTable tabla = new DataTable();
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conexion.conectar;
                cn.Open();
                using (SqlDataAdapter da = new SqlDataAdapter(cadena, cn))
                {
                    da.SelectCommand.Parameters.AddWithValue("@nombre", articulo.Nombre);
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
        public DataTable BuscarPorCodigo(DArticulo articulo)
        {
            string cadena = "sp_buscar_articulo_por_codigo";
            DataTable tabla = new DataTable();
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conexion.conectar;
                cn.Open();
                using (SqlDataAdapter da = new SqlDataAdapter(cadena, cn))
                {
                    da.SelectCommand.Parameters.AddWithValue("@id", articulo.IdArticulo);
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

        // listar categoria combo
        public DataTable ListarCategoria()
        {
            string cadena = " select *from categoria order by idcategoria desc ";
            DataTable tabla = new DataTable();
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conexion.conectar;
                cn.Open();
                using (SqlDataAdapter da = new SqlDataAdapter(cadena, cn))
                {
                    da.SelectCommand.CommandType = CommandType.Text;
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

        // listar presentacion combo
        public DataTable ListarPresentacion()
        {
            string cadena = "select *from presentacion order by idpresentacion desc";
            DataTable tabla = new DataTable();
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conexion.conectar;
                cn.Open();
                using (SqlDataAdapter da = new SqlDataAdapter(cadena, cn))
                {
                    da.SelectCommand.CommandType = CommandType.Text;
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

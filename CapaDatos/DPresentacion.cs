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
    public class DPresentacion
    {

        public int Idpresentacion { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public DPresentacion()
        {

        }
        public DPresentacion(int idpresentacion)
        {
            this.Idpresentacion = idpresentacion;
        }
        
        public DPresentacion(string nombre, string descripcion)
        {
            this.Nombre = nombre;
            this.Descripcion = descripcion;
        }

        public DPresentacion(string nombre, string descripcion, int idpresentacion)
        {
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.Idpresentacion = idpresentacion;
        }


        // metodo insertar
        public bool Insertar(DPresentacion presentacion)
        {
            int rpta = 0;
            string cadena = "sp_insertar_presentacion";
            SqlConnection cn = new SqlConnection();

            try
            {
                // code here 
                cn.ConnectionString = Conexion.conectar;
                cn.Open();

                using (SqlCommand cmd = new SqlCommand(cadena, cn))
                {
                    cmd.Parameters.AddWithValue("@nombre", presentacion.Nombre);
                    cmd.Parameters.AddWithValue("@descripcion", presentacion.Descripcion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    rpta = cmd.ExecuteNonQuery();
                    if (rpta == 1)
                        return true;

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error ... ???",MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        public bool Actualizar(DPresentacion presentacion)
        {
            int r = 0;
            string cadena = "sp_modificar_presentacion";
            SqlConnection cn = new SqlConnection();
            try
            {
                // code here
                cn.ConnectionString = Conexion.conectar;
                cn.Open();

                using (SqlCommand cmd = new SqlCommand(cadena, cn))
                {
                    cmd.Parameters.AddWithValue("@nombre", presentacion.Nombre);
                    cmd.Parameters.AddWithValue("@descripcion", presentacion.Descripcion);
                    cmd.Parameters.AddWithValue("@idpresentacion", presentacion.Idpresentacion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    r = cmd.ExecuteNonQuery();
                    if (r == 1)
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
                if (cn.State == ConnectionState.Open)
                    cn.Close();
            }
            return false;
        }


        // metodo eliminar
        public bool Eliminar(DPresentacion presentacion)
        {
            int r = 0;
            string cadena = "sp_eliminar_presentacion";
            SqlConnection cn = new SqlConnection();
            try
            {
                // code here
                cn.ConnectionString = Conexion.conectar;
                cn.Open();

                using (SqlCommand cmd = new SqlCommand(cadena, cn))
                {
                    cmd.Parameters.AddWithValue("@id", presentacion.Idpresentacion);
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
            string cadena = "sp_listar_presentacion";
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
        public DataTable BuscarNombre(DPresentacion presentacion)
        {
            string cadena = "sp_buscar_presentacion_por_nombre";
            DataTable tabla = new DataTable();
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conexion.conectar;
                cn.Open();
                using (SqlDataAdapter da = new SqlDataAdapter(cadena, cn))
                {
                    da.SelectCommand.Parameters.AddWithValue("@nombre", presentacion.Nombre);
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
        public DataTable BuscarPorCodigo(DPresentacion presentacion)
        {
            string cadena = "sp_buscar_presentacion_por_codigo";
            DataTable tabla = new DataTable();
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conexion.conectar;
                cn.Open();
                using (SqlDataAdapter da = new SqlDataAdapter(cadena, cn))
                {
                    da.SelectCommand.Parameters.AddWithValue("@id", presentacion.Idpresentacion);
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


        //public DataTable Mostrar()
        //{
        //    //code here
        //    cmd.Connection = cn.AbrirConexion();
        //    cmd.CommandText = "select *from categoria";
        //    leer = cmd.ExecuteReader();
        //    tabla.Load(leer);
        //    cn.CerrarConexion();
        //    return tabla;

        //}

        //public void Insertar(DPresentacion presentacion)
        //{
        //    cmd.Connection = cn.AbrirConexion();
        //    cmd.CommandText = "sp_insertar_categoria";
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@nombre", presentacion.Nombre);
        //    cmd.Parameters.AddWithValue("@descripcion", presentacion.Descripcion);
        //    cmd.ExecuteNonQuery();
        //    cn.CerrarConexion();
        //}
    }
}

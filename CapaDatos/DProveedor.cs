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
    public class DProveedor
    {


        public int IdProveedor { get; set; }
        public string RazonSocial { get; set; }
        public string TipoDocumento { get; set; }
        public string NumDocumento { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }

        public DProveedor()
        {

        }
        public DProveedor(string razonSocial, string tipoDocumento, string numDocumento, string telefono, string email, string direccion)
        {
            this.RazonSocial = razonSocial;
            this.TipoDocumento = tipoDocumento;
            this.NumDocumento = numDocumento;
            this.Telefono = telefono;
            this.Email = email;
            this.Direccion = direccion;
        }

        public DProveedor(string razonSocial, string tipoDocumento, string numDocumento, 
            string telefono, string email, string direccion, int idProveedor)
        {
            this.RazonSocial = razonSocial;
            this.TipoDocumento = tipoDocumento;
            this.NumDocumento = numDocumento;
            this.Telefono = telefono;
            this.Email = email;
            this.Direccion = direccion;
            this.IdProveedor = idProveedor;
        }

        public DProveedor(int idProveedor)
        {
            this.IdProveedor = idProveedor;
        }


        // metodo insertar
        public bool Insertar(DProveedor proveedor)
        {
            int rpta = 0;
            string cadena = "sp_insertar_proveedor";
            SqlConnection cn = new SqlConnection();

            try
            {
                // code here 
                cn.ConnectionString = Conexion.conectar;
                cn.Open();

                using (SqlCommand cmd = new SqlCommand(cadena, cn))
                {
                    cmd.Parameters.AddWithValue("@razonsocial", proveedor.RazonSocial);
                    cmd.Parameters.AddWithValue("@tipodocumento", proveedor.TipoDocumento);
                    cmd.Parameters.AddWithValue("@numdocumento", proveedor.NumDocumento);
                    cmd.Parameters.AddWithValue("@telefono", proveedor.Telefono);
                    cmd.Parameters.AddWithValue("@correo", proveedor.Email);
                    cmd.Parameters.AddWithValue("@direccion", proveedor.Direccion);
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

        // metodo insertar
        public bool Actualizar(DProveedor proveedor)
        {
            int rpta = 0;
            string cadena = "sp_modificar_proveedor";
            SqlConnection cn = new SqlConnection();

            try
            {
                // code here 
                cn.ConnectionString = Conexion.conectar;
                cn.Open();

                using (SqlCommand cmd = new SqlCommand(cadena, cn))
                {
                    cmd.Parameters.AddWithValue("@razonsocial", proveedor.RazonSocial);
                    cmd.Parameters.AddWithValue("@tipodocumento", proveedor.TipoDocumento);
                    cmd.Parameters.AddWithValue("@numdocumento", proveedor.NumDocumento);
                    cmd.Parameters.AddWithValue("@telefono", proveedor.Telefono);
                    cmd.Parameters.AddWithValue("@correo", proveedor.Email);
                    cmd.Parameters.AddWithValue("@direccion", proveedor.Direccion);
                    cmd.Parameters.AddWithValue("@id", proveedor.IdProveedor);
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

        // metodo eliminar
        public bool Eliminar(DProveedor proveedor)
        {
            int r = 0;
            string cadena = "sp_eliminar_proveedor";
            SqlConnection cn = new SqlConnection();
            try
            {
                // code here
                cn.ConnectionString = Conexion.conectar;
                cn.Open();

                using (SqlCommand cmd = new SqlCommand(cadena, cn))
                {
                    cmd.Parameters.AddWithValue("@id", proveedor.IdProveedor);
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
            string cadena = "sp_listar_proveedor";
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

        // metodo buscar por numero documento
        public DataTable BuscarNumeroDocumento(DProveedor proveedor)
        {
            string cadena = "sp_buscar_proveedor_por_numdocumento";
            DataTable tabla = new DataTable();
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conexion.conectar;
                cn.Open();
                using (SqlDataAdapter da = new SqlDataAdapter(cadena, cn))
                {
                    da.SelectCommand.Parameters.AddWithValue("@numdoc", proveedor.NumDocumento);
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
        public DataTable BuscarPorCodigo(DProveedor proveedor)
        {
            string cadena = "sp_buscar_proveedor_por_codigo";
            DataTable tabla = new DataTable();
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conexion.conectar;
                cn.Open();
                using (SqlDataAdapter da = new SqlDataAdapter(cadena, cn))
                {
                    da.SelectCommand.Parameters.AddWithValue("@id", proveedor.IdProveedor);
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

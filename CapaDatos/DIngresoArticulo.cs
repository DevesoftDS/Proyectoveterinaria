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
    public class DIngresoArticulo
    {


        public int IdIngresoArticulo { get; set; }
        public string Comprobante { get; set; }
        public string NumIngreso { get; set; }
        public string Impuesto { get; set; }
        public int IdProveedor { get; set; }
        public int IdUsuario { get; set; }

        public int Estado { get; set; }

        public DIngresoArticulo()
        {

        }
        public DIngresoArticulo(string comprobante, string numIngreso, string impuesto, int idProveedor, int idUsuario)
        {
            this.Comprobante = comprobante;
            this.NumIngreso = numIngreso;
            this.Impuesto = impuesto;
            this.IdProveedor = idProveedor;
            this.IdUsuario = idUsuario;
        }

        public DIngresoArticulo(int estado)
        {
            this.Estado = estado;
        }

        public int Insertar(DIngresoArticulo ingreso)
        {
            int ultimoid = 0;
            string cadena = "sp_insertar_ingreso_articulo";
            SqlConnection cn = new SqlConnection();

            try
            {
                // code here 
                cn.ConnectionString = Conexion.conectar;
                cn.Open();

                using (SqlCommand cmd = new SqlCommand(cadena, cn))
                {
                    cmd.Parameters.AddWithValue("@comprobante", ingreso.Comprobante);
                    cmd.Parameters.AddWithValue("@numingreso", ingreso.NumIngreso);
                    cmd.Parameters.AddWithValue("@impuesto", ingreso.Impuesto);
                    cmd.Parameters.AddWithValue("@idproveedor", ingreso.IdProveedor);
                    cmd.Parameters.AddWithValue("@idusuario", ingreso.IdUsuario);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ultimoid", SqlDbType.Int).Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();
                    cn.Close();
                    ultimoid = Convert.ToInt32(cmd.Parameters["@ultimoid"].Value.ToString());

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error ... ???", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return ultimoid;
                throw;

            }
            finally
            {
                if (cn.State == ConnectionState.Open) cn.Close();
            }
            return ultimoid;
        }

        public DataTable Listar()
        {
            string cadena = "sp_listar_ingreso_articulo";
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

        public DataTable BuscarIngresoNumeroIngreso(DIngresoArticulo ingreso)
        {
            string cadena = "sp_buscar_ingreso_por_numero_ingreso";
            DataTable tabla = new DataTable();
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conexion.conectar;
                cn.Open();
                using (SqlDataAdapter da = new SqlDataAdapter(cadena, cn))
                {
                    da.SelectCommand.Parameters.AddWithValue("@id", ingreso.NumIngreso);
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
        public DataTable BuscarPorCodigo(DIngresoArticulo ingreso)
        {
            string cadena = "sp_buscar_ingreso_por_codigo";
            DataTable tabla = new DataTable();
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conexion.conectar;
                cn.Open();
                using (SqlDataAdapter da = new SqlDataAdapter(cadena, cn))
                {
                    da.SelectCommand.Parameters.AddWithValue("@id", ingreso.IdIngresoArticulo);
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

        public bool ActualizarEstado(DIngresoArticulo ingreso)
        {
            int rpta = 0;
            string cadena = "sp_anular_ingreso_articulo";
            SqlConnection cn = new SqlConnection();

            try
            {
                // code here 
                cn.ConnectionString = Conexion.conectar;
                cn.Open();

                using (SqlCommand cmd = new SqlCommand(cadena, cn))
                {
                    cmd.Parameters.AddWithValue("@estado", ingreso.Estado);
                    cmd.Parameters.AddWithValue("@id", ingreso.IdIngresoArticulo);
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

    }
}

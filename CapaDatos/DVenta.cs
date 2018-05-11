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
    public class DVenta
    {


        public int IdVenta { get; set; }
        public int IdComprobante { get; set; }
        public string Comprobante { get; set; }
        public string Serie { get; set; }
        public string Correlativo { get; set; }
        public int IdCliente { get; set; }
        public string RazonSocial { get; set; }
        public string Ruc { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Igv { get; set; }
        public decimal Total { get; set; }
        public int IdUsuario { get; set; }

        public string Dato { get; set; }

        public DVenta()
        {

        }
        public DVenta(int idComprobante, string comprobante, string serie, string correlativo, int idCliente, string razonSocial, string ruc, decimal subTotal, decimal igv, decimal total, int idUsuario)
        {
            this.IdComprobante = idComprobante;
            this.Comprobante = comprobante;
            this.Serie = serie;
            this.Correlativo = correlativo;
            this.IdCliente = idCliente;
            this.RazonSocial = razonSocial;
            this.Ruc = ruc;
            this.SubTotal = subTotal;
            this.Igv = igv;
            this.Total = total;
            this.IdUsuario = idUsuario;
        }

        // metodo insertar venta
        public int Insertar(DVenta venta)
        {
            int ultimoid = 0;
            string cadena = "sp_insertar_venta";
            SqlConnection cn = new SqlConnection();

            try
            {
                // code here 
                cn.ConnectionString = Conexion.conectar;
                cn.Open();

                using (SqlCommand cmd = new SqlCommand(cadena, cn))
                {
                    cmd.Parameters.AddWithValue("@idcomprobante", venta.IdComprobante);
                    cmd.Parameters.AddWithValue("@comprobante", venta.Comprobante);
                    cmd.Parameters.AddWithValue("@serie", venta.Serie);
                    cmd.Parameters.AddWithValue("@correlativo", venta.Correlativo);
                    cmd.Parameters.AddWithValue("@idcliente", venta.IdCliente);
                    cmd.Parameters.AddWithValue("@razonsocial", venta.RazonSocial);
                    cmd.Parameters.AddWithValue("@ruc", venta.Ruc);
                    cmd.Parameters.AddWithValue("@subtotal", venta.SubTotal);
                    cmd.Parameters.AddWithValue("@igv", venta.Igv);
                    cmd.Parameters.AddWithValue("@total", venta.Total);
                    cmd.Parameters.AddWithValue("@idusuario", venta.IdUsuario);

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
            string cadena = "sp_listar_venta";
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

        public DataTable BuscarVentaCorrelativoDni(DVenta venta)
        {
            string cadena = "sp_buscar_venta_correlativo_dni";
            DataTable tabla = new DataTable();
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conexion.conectar;
                cn.Open();
                using (SqlDataAdapter da = new SqlDataAdapter(cadena, cn))
                {
                    da.SelectCommand.Parameters.AddWithValue("@dato", venta.Dato);
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

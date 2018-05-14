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
    public class DPagoServicio
    {


        public int IdPagoServicio { get; set; }
        public string TipoDoc { get; set; }
        public string Serie { get; set; }
        public string Correlativo { get; set; }
        public DateTime FechaEmision { get; set; }
        

        public DPagoServicio() { }

        public DPagoServicio(string tipoDoc, string serie)
        {
            this.TipoDoc = tipoDoc;
            this.Serie = serie;
        }



        /*  public string InsertarPagoServicio(DPagoServicio detalle)
          {
              string rpta = "";
              string sql = "";
              SqlConnection cn = new SqlConnection();
              try
              {
                  cn.ConnectionString = Conexion.conectar;
                  cn.Open();
                  using (SqlCommand cmd = new SqlCommand(sql, cn))
                  {
                      cmd.Parameters.AddWithValue("@serie", detalle.Serie);
                      cmd.Parameters.AddWithValue("@correlativo", detalle.Correlativo);                    
                      cmd.CommandType = CommandType.StoredProcedure;
                      rpta = cmd.ExecuteNonQuery() == 1 ? "Ok" : "Error al registrar el detalle comprobante";
                  }
              }
              catch (Exception ex)
              {
                  rpta = ex.Message.ToString();
                  throw;
              }
              finally
              {
                  if (cn.State == ConnectionState.Open) cn.Close();
              }
              return rpta;
          }*/
        public int InsertarPagoServicio(DPagoServicio pago)
        {
            int ultimoId = 0;
            string sql = "sp_insertar_pago_servicio";
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conexion.conectar;
                cn.Open();

                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@tipodoc", pago.TipoDoc);
                    cmd.Parameters.AddWithValue("@serie", pago.Serie);                    
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ultimoid", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    ultimoId = Convert.ToInt32(cmd.Parameters["@ultimoid"].Value.ToString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error ... ???", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return ultimoId;
                throw;

            }
            finally
            {
                if (cn.State == ConnectionState.Open) cn.Close();
            }
            return ultimoId;
        }
        public DataTable ListarPagoServcio()
        {
            string sql = "sp_listar_pago";
            DataTable tabla = new DataTable();
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conexion.conectar;
                cn.Open();
                using (var da = new SqlDataAdapter(sql, cn))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.Fill(tabla);
                }

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                tabla = null;
                throw;
            }
            finally
            {
                if (cn.State == ConnectionState.Open) cn.Close();
            }
            return tabla;
        }
        public DataTable GenerarCorelativo(DPagoServicio pago)
        {
            string sql = "sp_generar_correlativo";
            DataTable tabla = new DataTable();
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conexion.conectar;
                cn.Open();
                using (var da = new SqlDataAdapter(sql, cn))
                {
                    da.SelectCommand.Parameters.AddWithValue("@tipodoc", pago.TipoDoc);
                    da.SelectCommand.Parameters.AddWithValue("@serie", pago.Serie);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.Fill(tabla);
                }
            }
            catch (Exception ex)
            {
                tabla = null;
                ex.Message.ToString();
            }
            finally
            {
                if (cn.State == ConnectionState.Open) cn.Close();
            }
            return tabla;
        }

    }
}

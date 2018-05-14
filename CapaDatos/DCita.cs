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
    public class DCita
    {
        

        public int IdCita { get; set; }
        public DateTime FechaCita { get; set; }
        public int IdCliente { get; set; }
        public int IdPagoServicio { get; set; }
        public int IdUsuario { get; set; }
        public decimal Total { get; set; }
        public int UltimoId { get; set; }
        public string TextoBuscar { get; set; }
        public DCita() { }

        public DCita(int idCliente, int idPagoServicio, int idUsuario,decimal total)
        {
            this.IdCliente = idCliente;
            this.IdPagoServicio = idPagoServicio;
            this.IdUsuario = idUsuario;
            this.Total = total;
        }
      
        public DCita(string textoBuscar)
        {
            this.TextoBuscar = textoBuscar;
        }

        public DCita(DateTime fechaCita)
        {
            this.FechaCita = fechaCita;
        }

        public int InsertarCita(DCita cita)
        {
            int ultimoId = 0;
            string sql = "sp_insertar_cita";
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conexion.conectar;
                cn.Open();

                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@idcliente", cita.IdCliente);
                    cmd.Parameters.AddWithValue("@idpagoservicio", cita.IdPagoServicio);
                    cmd.Parameters.AddWithValue("@idusuario", cita.IdUsuario);
                     cmd.Parameters.AddWithValue("@total", cita.Total);
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

        public DataTable ListarCitas()
        {
            string sql = "sp_lista_cita";
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

        public DataTable BuscarCita(DCita cita)
        {
            string sql = "sp_buscar_cita_dnicli";
            DataTable tabla = new DataTable();
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conexion.conectar;
                cn.Open();
                using (var da = new SqlDataAdapter(sql, cn))
                {
                    da.SelectCommand.Parameters.AddWithValue("@buscar", cita.TextoBuscar);
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

        public DataTable BuscarFechaCita(DCita cita)
        {
            string sql = "sp_buscar_fechadetalle_cita";
            DataTable tabla = new DataTable();
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conexion.conectar;
                cn.Open();
                using (var da = new SqlDataAdapter(sql, cn))
                {
                    da.SelectCommand.Parameters.AddWithValue("@buscar", cita.FechaCita);
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

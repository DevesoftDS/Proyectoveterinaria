using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DDetalleCita
    {
        public int IdDetalleCita { get; set; }
        public int IdCita { get; set; }
        public int IdMascota { get; set; }
        public int IdServicio { get; set; }
        public string Fecha { get; set; }
        public string Hora { get; set; }
        public string Motivo { get; set; }
        public string Sintoma { get; set; }
        public decimal Descuento { get; set; }
        public decimal Importe { get; set; }

        public DateTime FechaBuscar { get; set; }

        public DDetalleCita() { }

        public DDetalleCita(int idCita,int idMascota,int idServicio, string fecha, string hora, string motivo, string sintoma, decimal descuento, decimal importe)
        {
            
            this.IdCita = idCita;
            this.IdMascota = idMascota;
            this.IdServicio = idServicio;
            this.Fecha = fecha;
            this.Hora = hora;
            this.Motivo = motivo;
            this.Sintoma = sintoma;
            this.Descuento = descuento;
            this.Importe = importe;
        }
        public string InsertarDetalleCita(DDetalleCita detalle)
        {
            string rpta = "";
            string sql = "sp_insertar_detalle_cita";
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conexion.conectar;
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@idcita", detalle.IdCita);
                    cmd.Parameters.AddWithValue("@idmascota", detalle.IdMascota);
                    cmd.Parameters.AddWithValue("@idservicio", detalle.IdServicio);
                    cmd.Parameters.AddWithValue("@fecha", detalle.Fecha);
                    cmd.Parameters.AddWithValue("@hora", detalle.Hora);
                    cmd.Parameters.AddWithValue("@motivo", detalle.Motivo);
                    cmd.Parameters.AddWithValue("@sintoma", detalle.Sintoma);
                    cmd.Parameters.AddWithValue("@descuento", detalle.Descuento);
                    cmd.Parameters.AddWithValue("@importe", detalle.Importe);
                    cmd.CommandType = CommandType.StoredProcedure;
                    rpta = cmd.ExecuteNonQuery() == 1 ? "Ok" : "Error al registrar el detalle de la cita";
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
        }      

        public DataTable BuscarFechaCita(DDetalleCita detalle)
        {
            string sql = "sp_listar_detalle_cita";
            DataTable tabla = new DataTable();
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conexion.conectar;
                cn.Open();
                using (var da = new SqlDataAdapter(sql, cn))
                {
                    da.SelectCommand.Parameters.AddWithValue("@fecha", detalle.FechaBuscar);
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

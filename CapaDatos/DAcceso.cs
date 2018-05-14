using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DAcceso
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public DataTable Acceso(DAcceso acceso)
        {
            string cadena = "sp_login";
            DataTable tabla = new DataTable();
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conexion.conectar;
                cn.Open();
                using (SqlDataAdapter da = new SqlDataAdapter(cadena, cn))
                {
                    da.SelectCommand.Parameters.AddWithValue("@username", acceso.UserName);
                    da.SelectCommand.Parameters.AddWithValue("@pasword", acceso.Password);
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

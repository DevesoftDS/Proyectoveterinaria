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
    public class DBoleta
    {

        public string Serie { get; set; }
        public string Correlativo { get; set; }
        public int IdVenta { get; set; }

        public bool InsertarBoleta(DBoleta boleta)
        {
            int rpta = 0;
            string cadena = "sp_insertar_boleta";
            SqlConnection cn = new SqlConnection();

            try
            {
                // code here 
                cn.ConnectionString = Conexion.conectar;
                cn.Open();

                using (SqlCommand cmd = new SqlCommand(cadena, cn))
                {
                    cmd.Parameters.AddWithValue("@serie", boleta.Serie);
                    cmd.Parameters.AddWithValue("@correlativo", boleta.Correlativo);
                    cmd.Parameters.AddWithValue("@idventa", boleta.IdVenta);
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


        public string GeneradorCodigoBoleta()
        {
            SqlConnection cn = new SqlConnection();
            SqlDataReader dr;
            SqlCommand cmd = new SqlCommand();
            string codigo = "";

            cn.ConnectionString = Conexion.conectar;
            cn.Open();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "sp_generar_codigo_boleta";

            dr = cmd.ExecuteReader();
            if (dr.HasRows == false)
            {
                codigo = "0000001";
            }
            else
            {
                int cant = 1;
                while (dr.Read())
                {
                    cant = cant + 1;

                }
                String ceros = "";
                int i;
                String Ct = cant.ToString();
                for (i = 1; i <= 6 - Ct.Length; i++)
                { ceros = "0" + ceros; }
                codigo = "0" + ceros + cant.ToString();
            }
            dr.Close();
            cn.Close();
            return codigo;
        }

    }
}

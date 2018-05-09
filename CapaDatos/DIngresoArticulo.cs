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
        public string NumIngreso { get; set; }
        public decimal Impuesto { get; set; }
        public int IdProveedor { get; set; }
        public int IdUsuario { get; set; }

        public DIngresoArticulo()
        {

        }
        public DIngresoArticulo(string numIngreso, decimal impuesto, int idProveedor, int idUsuario)
        {
            this.NumIngreso = numIngreso;
            this.Impuesto = impuesto;
            this.IdProveedor = idProveedor;
            this.IdUsuario = idUsuario;
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

    }
}

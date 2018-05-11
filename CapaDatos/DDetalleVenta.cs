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
    public class DDetalleVenta
    {
        

        public int IdDetalleVenta { get; set; }
        public int IdVenta { get; set; }
        public int IdDetalleIngresoArticulo { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Descuento { get; set; }

        public DDetalleVenta()
        {

        }
        public DDetalleVenta(int idVenta, int idDetalleIngresoArticulo, int cantidad, decimal precio, decimal descuento)
        {
            IdVenta = idVenta;
            IdDetalleIngresoArticulo = idDetalleIngresoArticulo;
            Cantidad = cantidad;
            Precio = precio;
            Descuento = descuento;
        }

        // metodo insertar
        public bool Insertar(DDetalleVenta detalleVenta)
        {
            int rpta = 0;
            string cadena = "sp_insertar_detalle_venta";
            SqlConnection cn = new SqlConnection();

            try
            {
                // code here 
                cn.ConnectionString = Conexion.conectar;
                cn.Open();

                using (SqlCommand cmd = new SqlCommand(cadena, cn))
                {
                    cmd.Parameters.AddWithValue("@idventa", detalleVenta.IdVenta);
                    cmd.Parameters.AddWithValue("@iddingresoart", detalleVenta.IdDetalleIngresoArticulo);
                    cmd.Parameters.AddWithValue("@cantidad", detalleVenta.Cantidad);
                    cmd.Parameters.AddWithValue("@precio", detalleVenta.Precio);
                    cmd.Parameters.AddWithValue("@descuento", detalleVenta.Descuento);

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

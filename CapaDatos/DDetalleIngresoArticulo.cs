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
    public class DDetalleIngresoArticulo
    {

        public int IdDIArticulo { get; set; }
        public int IdIngresoArticulo { get; set; }
        public int IdArticulo { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal PrecioVenta { get; set; }
        public int StockInicial { get; set; }
        public int StockActual { get; set; }
        public DateTime FechaProduccion { get; set; }
        public DateTime FechaVencimiento { get; set; }

        public DDetalleIngresoArticulo()
        {

        }
        public DDetalleIngresoArticulo(int idIngresoArticulo, int idArticulo, decimal precioCompra, decimal precioVenta, int stockInicial, int stockActual, DateTime fechaProduccion, DateTime fechaVencimiento)
        {
            this.IdIngresoArticulo = idIngresoArticulo;
            this.IdArticulo = idArticulo;
            this.PrecioCompra = precioCompra;
            this.PrecioVenta = precioVenta;
            this.StockInicial = stockInicial;
            this.StockActual = stockActual;
            this.FechaProduccion = fechaProduccion;
            this.FechaVencimiento = fechaVencimiento;
        }

        // metodo insertar
        public bool Insertar(DDetalleIngresoArticulo detalleIngreso)
        {
            int rpta = 0;
            string cadena = "sp_insertar_detalle_ingreso_articulo";
            SqlConnection cn = new SqlConnection();

            try
            {
                // code here 
                cn.ConnectionString = Conexion.conectar;
                cn.Open();

                using (SqlCommand cmd = new SqlCommand(cadena, cn))
                {
                    cmd.Parameters.AddWithValue("@idingresoart", detalleIngreso.IdIngresoArticulo);
                    cmd.Parameters.AddWithValue("@idarticulo", detalleIngreso.IdArticulo);
                    cmd.Parameters.AddWithValue("@preciocompra", detalleIngreso.PrecioCompra);
                    cmd.Parameters.AddWithValue("@precioventa", detalleIngreso.PrecioVenta);
                    cmd.Parameters.AddWithValue("@stockinicial", detalleIngreso.StockInicial);
                    cmd.Parameters.AddWithValue("@stockactual", detalleIngreso.StockActual);
                    cmd.Parameters.AddWithValue("@fechaproduccion", detalleIngreso.FechaProduccion);
                    cmd.Parameters.AddWithValue("@fechavencimiento", detalleIngreso.FechaVencimiento);

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

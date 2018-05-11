using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;
using System.Windows.Forms;

namespace CapaNegocio
{
    public class NDetalleIngresoArticulo
    {
        DDetalleIngresoArticulo objDDIA = new DDetalleIngresoArticulo();

        public static bool Insertar(int idingreso, int idarticulo, decimal preciocompra, decimal precioventa, int stockinicial, int stockactual, DateTime fechaproduccion, DateTime fechavencimiento)
        {
            DDetalleIngresoArticulo objDDI = new DDetalleIngresoArticulo();
            objDDI.IdIngresoArticulo = idingreso;
            objDDI.IdArticulo = idarticulo;
            objDDI.PrecioCompra = preciocompra;
            objDDI.PrecioVenta = precioventa;
            objDDI.StockInicial = stockinicial;
            objDDI.StockActual = stockactual;
            objDDI.FechaProduccion = fechaproduccion;
            objDDI.FechaVencimiento = fechavencimiento;
            return objDDI.Insertar(objDDI);
        }

        public static DataTable Listar()
        {
            return new DDetalleIngresoArticulo().Listar();
        }
        public static DataTable BuscarNombre(string nombre)
        {
            DDetalleIngresoArticulo objDDI = new DDetalleIngresoArticulo();
            objDDI.Nombre = nombre;
            return objDDI.BuscarNombre(objDDI);
        }

        public static DataTable BuscarNombreAndCategoria(string categoria)
        {
            DDetalleIngresoArticulo objDDI = new DDetalleIngresoArticulo();
            objDDI.Nombre = categoria;
            return objDDI.BuscarNombreAndCategoria(objDDI);
        }
        public void MostrarArticuloPorCategoria(DataGridView dgv, string categoria)
        {
            DataTable tabla = BuscarNombreAndCategoria(categoria);
            this.ListarGrid(dgv, tabla);
        }

        public void MostrarArticuloPorNombre(DataGridView dgv, string nombre)
        {
            DataTable tabla = BuscarNombre(nombre);
            this.ListarGrid(dgv, tabla);
        }
        public void MostrarDataGridViewIngresoArticulos(DataGridView dgv)
        {
            DataTable tabla = Listar();
            this.ListarGrid(dgv, tabla);
        }

        public void ListarGrid(DataGridView dgv, DataTable tabla)
        {
            var num_filas = tabla.Rows.Count;
            if (num_filas > 0)
            {
                dgv.Rows.Clear();
                for (int i = 0; i < num_filas; i++)
                {
                    string articulo = tabla.Rows[i]["nombre"].ToString();
                    string categoria = tabla.Rows[i]["categoria"].ToString();
                    string presentacion = tabla.Rows[i]["neto"].ToString() + " " + tabla.Rows[i]["presentacion"].ToString();
                    int stock = Convert.ToInt32(tabla.Rows[i]["stockactual"].ToString());
                    decimal precio = Convert.ToDecimal(tabla.Rows[i]["precioventa"].ToString());
                    int iddingreso = Convert.ToInt32(tabla.Rows[i]["iddiarticulo"].ToString());

                    dgv.Rows.Add(
                        i + 1, articulo, categoria, presentacion, stock, precio, iddingreso
                        );
                }
            }
        }

    }
}

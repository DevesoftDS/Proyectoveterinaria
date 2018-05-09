using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocio
{
    public class NDetalleIngresoArticulo
    {
        DDetalleIngresoArticulo objDDIA = new DDetalleIngresoArticulo();

        public static bool Insertar(int idingreso, int idarticulo, decimal preciocompra, 
            decimal precioventa, int stockinicial, int stockactual, DateTime fechaproduccion, DateTime fechavencimiento)
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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocio
{
    public class NDetalleVenta
    {
        public static bool Insertar(int idventa, int iddina, int cantidad, decimal precio, decimal descuento)
        {
            DDetalleVenta objDetalleVenta = new DDetalleVenta();
            objDetalleVenta.IdVenta = idventa;
            objDetalleVenta.IdDetalleIngresoArticulo = iddina;
            objDetalleVenta.Cantidad = cantidad;
            objDetalleVenta.Precio = precio;
            objDetalleVenta.Descuento = descuento;
            return objDetalleVenta.Insertar(objDetalleVenta);
        }
    }
}

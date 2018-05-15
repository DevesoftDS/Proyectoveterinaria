using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocio
{
    public class NFactura
    {
        public static bool insertarFactura(string serie, string correlativo, int idventa)
        {
            DFactura objFactura = new DFactura();
            objFactura.Serie = serie;
            objFactura.Correlativo = correlativo;
            objFactura.IdVenta = idventa;

            return objFactura.InsertarFactura(objFactura);
        }

        public static string GenerarCodigoFactura()
        {
            return new DFactura().GeneradorCodigoFactura();
        }
    }
}

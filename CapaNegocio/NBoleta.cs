using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocio
{
    public class NBoleta
    {
        public static bool insertarBoleta(string serie, string correlativo, int idventa)
        {
            DBoleta objBoleta = new DBoleta();
            objBoleta.Serie = serie;
            objBoleta.Correlativo = correlativo;
            objBoleta.IdVenta = idventa;

            return objBoleta.InsertarBoleta(objBoleta);
        }

        public static string GenerarCodigoBoleta()
        {
            return new DBoleta().GeneradorCodigoBoleta();
        }
    }
}

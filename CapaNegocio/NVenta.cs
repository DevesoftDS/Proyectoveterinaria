using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocio
{
    public class NVenta
    {
        public static int Insertar(int idcomprobante, string comprobante, string serie, string correlativo, 
            int idcliente, string razonsocial, string ruc, decimal subtotal, decimal igv, decimal total, int idusuario
            )
        {
            DVenta objVenta = new DVenta();
            objVenta.IdComprobante = idcomprobante;
            objVenta.Comprobante = comprobante;
            objVenta.Serie = serie;
            objVenta.Correlativo = correlativo;
            objVenta.IdCliente = idcliente;
            objVenta.RazonSocial = razonsocial;
            objVenta.Ruc = ruc;
            objVenta.SubTotal = subtotal;
            objVenta.Igv = igv;
            objVenta.Total = total;
            objVenta.IdUsuario = idusuario;

            return objVenta.Insertar(objVenta);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NPagoServicio
    {
        public static int InsertarPagoServicio(string tipodoc,string serie)
        {
            DPagoServicio objPago = new DPagoServicio();
            objPago.TipoDoc = tipodoc;
            objPago.Serie = serie;            
            return objPago.InsertarPagoServicio(objPago);
        }

        public static DataTable ListarPagoServicio()
        {
            DPagoServicio objPago = new DPagoServicio();
            return objPago.ListarPagoServcio();
        }
        public static DataTable GenerarCorrelativo(string tipodoc, string serie)
        {
            DPagoServicio objPago = new DPagoServicio();
            objPago.TipoDoc = tipodoc;
            objPago.Serie = serie;
            return objPago.GenerarCorelativo(objPago);
        } 
    }
}

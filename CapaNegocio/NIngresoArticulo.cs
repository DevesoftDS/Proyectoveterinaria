using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocio
{
    public class NIngresoArticulo
    {
        DIngresoArticulo objDIA = new DIngresoArticulo();

        public static int Insertar(string numingreso, decimal impuesto, int idproveedor, int idusuario)
        {
            DIngresoArticulo objingreso = new DIngresoArticulo();
            objingreso.NumIngreso = numingreso;
            objingreso.Impuesto = impuesto;
            objingreso.IdProveedor = idproveedor;
            objingreso.IdUsuario = idusuario;
            return objingreso.Insertar(objingreso);
        }
    }
}

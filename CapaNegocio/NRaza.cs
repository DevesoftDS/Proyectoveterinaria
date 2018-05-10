using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NRaza
    {
        public static DataTable ListarRaza()
        {
            return new DRaza().ListarRaza();
        }
        public static DataTable BuscarRaza(string textoBuscar)
        {
            DRaza objRaza = new DRaza();
            objRaza.TextoBuscar = textoBuscar;
            return objRaza.BuscarRaza(objRaza);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocio
{
    public class NServicio
    {
        
        public static DataTable ListarServicio()
        {
            return new DServicio().ListarServicio();
        }
        public static DataTable BuscarServicioArea(string textoBuscar)
        {
            DServicio objServicio = new DServicio();
            objServicio.TextoBuscar = textoBuscar;
            return objServicio.BuscarServicioArea(objServicio);
        }
    }
}

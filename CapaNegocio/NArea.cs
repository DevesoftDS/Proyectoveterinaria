using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocio
{
     public class NArea
    {
        public static DataTable ListarArea()
        {
            return new DArea().ListarArea();
        }
        public static DataTable BuscarAreaEmpleado(string textoBuscar)
        {
            DArea objArea = new DArea();
            objArea.TextoBuscar = textoBuscar;
            return objArea.BuscarAreaEmpleado(objArea);
        }
    }
}

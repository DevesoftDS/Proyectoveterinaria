using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NEspecie
    {
        public static DataTable ListarEspecie()
        {
            return new DEspecie().ListarEspecie();
        }
        public static DataTable BuscarEspecie(string textoBuscar)
        {
            DEspecie objEspecie = new DEspecie();
            objEspecie.TextoBuscar = textoBuscar;
            return objEspecie.BuscarEspecie(objEspecie);
        }
    }
}

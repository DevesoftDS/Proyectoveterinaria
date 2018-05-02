using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocio
{
    public class NPresentacion
    {
        private DPresentacion objtoDP = new DPresentacion();

        public DataTable MostrarCategoria()
        {
            //DPresentacion objtoDP = new DPresentacion();
            DataTable tabla = new DataTable();
            tabla = objtoDP.Mostrar();
            return tabla;
        }

        public void InsertarCategoria(string nombre, string descripcion)
        {
            objtoDP.Nombre = nombre;
            objtoDP.Descripcion = descripcion;
            objtoDP.Insertar(objtoDP);
        }

    }
}

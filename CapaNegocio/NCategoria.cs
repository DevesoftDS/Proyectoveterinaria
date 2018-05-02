using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
namespace CapaNegocio
{
    public class NCategoria
    {
        // metodo insertar que llama al metodo insertar de la clase dcategoria capadatos
        public static bool Insertar(string nombre, string descripcion)
        {
            DCategoria categoria = new DCategoria();
            categoria.Nombre = nombre;
            categoria.Descripcion = descripcion;
            return categoria.Insertar(categoria);
        }

        public static string Insertar1(string nombre, string descripcion)
        {
            DCategoria categoria = new DCategoria();
            categoria.Nombre = nombre;
            categoria.Descripcion = descripcion;
            return categoria.Insertar1(categoria);
        }
    }
}

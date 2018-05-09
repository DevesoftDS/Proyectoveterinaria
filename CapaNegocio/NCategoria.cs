using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;
using System.Windows.Forms;
using System.Globalization;

namespace CapaNegocio
{
    public class NCategoria
    {
        public DCategoria objDC = new DCategoria();

        // metodo insertar que llama al metodo insertar de la clase dcategoria capadatos
        public static int Insertar(string nombre, string descripcion)
        {
            DCategoria categoria = new DCategoria();
            categoria.Nombre = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(nombre);
            categoria.Descripcion = descripcion;
            return categoria.Insertar(categoria);
        }
        //metodo modificar que llama al metodo actualizar CD
        public static int Actualizar(string nombre, string descripcion, int idcategoria)
        {
            DCategoria categoria = new DCategoria();
            categoria.Nombre = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(nombre);
            categoria.Descripcion = descripcion;
            categoria.IdCategoria = idcategoria;
            return categoria.Actualizar(categoria);
        }
        // metodo para listar categoria
        public static DataTable Listar()
        {
            return new DCategoria().Listar();
        }

        //metodo para pasar datos de list a update
        public static DataTable BuscarCodigo(int idCategoria)
        {
            DCategoria objDC = new DCategoria();
            objDC.IdCategoria = idCategoria;
            return objDC.BuscarPorCodigo(objDC);
        }

        // metodo para buscar categoria por nombre
        public static DataTable BuscarNombre(string nombre)
        {
            DCategoria objDC = new DCategoria();
            objDC.Nombre = nombre;
            return objDC.BuscarNombre(objDC);
        }

        public static bool Eliminar(int idcategoria)
        {
            DCategoria objDC = new DCategoria();
            objDC.IdCategoria = idcategoria;
            return objDC.Eliminar(objDC);
        }

        //metodo para listar categoria por nombre
        public void BuscarCategoriaPorNombre(DataGridView dgv, string nombre)
        {
            var tabla = BuscarNombre(nombre);
            this.ListarGrid(dgv, tabla);

        }

        //metodo para listar el DataGridView
        public void ListarDataGridViewCategoria(DataGridView dgv)
        {
            var tabla = Listar();
            this.ListarGrid(dgv, tabla);
            
        }

        // metodo para llenar datos a DataGridView
        public void ListarGrid(DataGridView dgv, DataTable tabla)
        {
            int numFilas = tabla.Rows.Count;
            if (numFilas > 0)
            {
                dgv.Rows.Clear();
                for (int i = 0; i < numFilas; i++)
                {
                    string nombre = tabla.Rows[i]["nombre"].ToString();
                    string descripcion = tabla.Rows[i]["descripcion"].ToString();
                    int idcategoria = int.Parse(tabla.Rows[i]["idcategoria"].ToString());

                    dgv.Rows.Add(
                        i + 1, nombre, descripcion, "Editar", "Eliminar", idcategoria
                        );
                }
            }
        }

    }
}

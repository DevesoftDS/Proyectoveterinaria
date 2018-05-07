using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;
using System.Windows.Forms;

namespace CapaNegocio
{
    public class NArticulo
    {
        DArticulo objDA = new DArticulo();

        // metodo insertar que llama al metodo insertar de la clase dcategoria capadatos
        public static bool Insertar(string codigo,string nombre, int idcategoria, int idpresentacion, string neto, string descripcion, byte[] imagen)
        {
            DArticulo objArt = new DArticulo();
            objArt.Codigo = codigo;
            objArt.Nombre = nombre;
            objArt.IdCategoria = idcategoria;
            objArt.IdPresentacion = idpresentacion;
            objArt.Neto = neto;
            objArt.Descripcion = descripcion;
            objArt.Imagen = imagen;
            return objArt.Insertar(objArt);
        }
        //metodo modificar que llama al metodo actualizar CD
        public static bool Actualizar(string codigo, string nombre, int idcategoria, int idpresentacion, string neto, string descripcion, byte[] imagen, int id)
        {
            DArticulo objArt = new DArticulo();
            objArt.Codigo = codigo;
            objArt.Nombre = nombre;
            objArt.IdCategoria = idcategoria;
            objArt.IdPresentacion = idpresentacion;
            objArt.Neto = neto;
            objArt.Descripcion = descripcion;
            objArt.Imagen = imagen;
            objArt.IdArticulo = id;
            return objArt.Actualizar(objArt);
        }
        // metodo para listar articulo
        public static DataTable Listar()
        {
            return new DArticulo().Listar();
        }

        // metodo para listar categoria
        public static DataTable ListarCategoria()
        {
            return new DArticulo().ListarCategoria();
        }

        // metodo para listar presentacion
        public static DataTable ListarPresentacion()
        {
            return new DArticulo().ListarPresentacion();
        }

        //metodo para pasar datos de list a update
        public static DataTable BuscarCodigo(int id)
        {
            DArticulo objArt = new DArticulo();
            objArt.IdArticulo = id;
            return objArt.BuscarPorCodigo(objArt);
        }

        // metodo para buscar categoria por nombre
        public static DataTable BuscarNombre(string nombre)
        {
            DArticulo objArt = new DArticulo();
            objArt.Nombre = nombre;
            return objArt.BuscarNombre(objArt);
        }

        // metodo eliminar llamando desde datos
        public static bool Eliminar(int id)
        {
            DArticulo objArt = new DArticulo();
            objArt.IdArticulo = id;
            return objArt.Eliminar(objArt);
        }

        public void ListarArticuloPorNombre(DataGridView dgv, string nombre)
        {
            DataTable tabla = BuscarNombre(nombre);
            this.ListarGrid(dgv, tabla);

        }

        public void ListarDataGridViewArticulo(DataGridView dgv)
        {
            DataTable tabla = Listar();
            this.ListarGrid(dgv, tabla);
            
        }

        public void ListarGrid(DataGridView dgv, DataTable tabla)
        {
            int numFilas = tabla.Rows.Count;
            if (numFilas > 0)
            {
                dgv.Rows.Clear();
                for (int i = 0; i < numFilas; i++)
                {
                    string codigo = tabla.Rows[i]["codigo"].ToString();
                    string nombre = tabla.Rows[i]["nombre"].ToString();
                    string categoria = tabla.Rows[i]["categoria"].ToString();
                    string presentacion = tabla.Rows[i]["presentacion"].ToString() + " " + tabla.Rows[i]["neto"].ToString();
                    string idarticulo = tabla.Rows[i]["idarticulo"].ToString();

                    dgv.Rows.Add(
                        i + 1, codigo, nombre, categoria, presentacion, "Editar", "Eliminar", idarticulo
                        );
                }
            }
        }
    }
}

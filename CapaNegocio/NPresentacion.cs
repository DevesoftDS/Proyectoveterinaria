using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Windows.Forms;

namespace CapaNegocio
{
    public class NPresentacion
    {

        private DPresentacion objDP = new DPresentacion();

        // metodo insertar que llama al metodo insertar de la clase dcategoria capadatos
        public static bool Insertar(string nombre, string descripcion)
        {
            DPresentacion presentacion = new DPresentacion();
            presentacion.Nombre = nombre;
            presentacion.Descripcion = descripcion;
            return presentacion.Insertar(presentacion);
        }
        //metodo modificar que llama al metodo actualizar CD
        public static bool Actualizar(string nombre, string descripcion, int id)
        {
            DPresentacion presentacion = new DPresentacion();
            presentacion.Nombre = nombre;
            presentacion.Descripcion = descripcion;
            presentacion.Idpresentacion = id;
            return presentacion.Actualizar(presentacion);
        }
        // metodo para listar categoria
        public static DataTable Listar()
        {
            return new DPresentacion().Listar();
        }

        //metodo para pasar datos de list a update
        public static DataTable BuscarCodigo(int id)
        {
            DPresentacion presentacion = new DPresentacion();
            presentacion.Idpresentacion = id;
            return presentacion.BuscarPorCodigo(presentacion);
        }

        // metodo para buscar categoria por nombre
        public static DataTable BuscarNombre(string nombre)
        {
            DPresentacion presentacion = new DPresentacion();
            presentacion.Nombre = nombre;
            return presentacion.BuscarNombre(presentacion);
        }
        
        // metodo eliminar llamando desde datos
        public static bool Eliminar(int id)
        {
            DPresentacion presentacion = new DPresentacion();
            presentacion.Idpresentacion = id;
            return presentacion.Eliminar(presentacion);
        }
        // metodo metodo buscar por nombre
        public void BuscarPresentacionPorNombre(DataGridView dgv, string nombre)
        {
            var tabla = BuscarNombre(nombre);
            this.ListarGrid(dgv, tabla);
        }

        // metodo listar dgv
        public void ListarDataGridViewPresentacion(DataGridView dgv)
        {
            var tabla = Listar();
            this.ListarGrid(dgv, tabla);
        }
        // metodo llenar campos de row a dgv
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
                    int idpresentacion = int.Parse(tabla.Rows[i]["idpresentacion"].ToString());

                    dgv.Rows.Add(i + 1, nombre, descripcion, "Editar", "Eliminar", idpresentacion);
                }
            }
        }
    }
}

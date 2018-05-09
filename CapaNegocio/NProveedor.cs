using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace CapaNegocio
{
    public class NProveedor
    {
        DProveedor objDP = new DProveedor();

        public static bool Insertar(string razonsocial, string tipodoc, string numdoc, 
            string telefono, string correo, string direccion)
        {
            DProveedor objDP = new DProveedor();
            objDP.RazonSocial = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(razonsocial);
            objDP.TipoDocumento = tipodoc;
            objDP.NumDocumento = numdoc;
            objDP.Telefono = telefono;
            objDP.Email = correo;
            objDP.Direccion = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(direccion);

            return objDP.Insertar(objDP);
        }

        public static bool Actualizar(string razonsocial, string tipodoc, string numdoc,
            string telefono, string correo, string direccion, int id)
        {
            DProveedor objDP = new DProveedor();
            objDP.RazonSocial = razonsocial;
            objDP.TipoDocumento = tipodoc;
            objDP.NumDocumento = numdoc;
            objDP.Telefono = telefono;
            objDP.Email = correo;
            objDP.Direccion = direccion;
            objDP.IdProveedor = id;

            return objDP.Actualizar(objDP);
        }



        public static DataTable Listar()
        {
            return new DProveedor().Listar();
        }

        //metodo para pasar datos de list a update
        public static DataTable BuscarCodigo(int id)
        {
            DProveedor objDP = new DProveedor();
            objDP.IdProveedor = id;
            return objDP.BuscarPorCodigo(objDP);
        }

        // metodo para buscar categoria por nombre
        public static DataTable BuscarNumDocumento(string numdocu)
        {
            DProveedor objDP = new DProveedor();
            objDP.NumDocumento = numdocu;
            return objDP.BuscarNumeroDocumento(objDP);
        }

        // metodo eliminar llamando desde datos
        public static bool Eliminar(int id)
        {
            DProveedor objArt = new DProveedor();
            objArt.IdProveedor = id;
            return objArt.Eliminar(objArt);
        }

        public void LIstarPorNumeroDocumento(DataGridView dgv, string numdoc)
        {
            DataTable tabla = BuscarNumDocumento(numdoc);
            this.ListarGrid(dgv, tabla);

        }

        public void LIstarDataGridViewProveedor(DataGridView dgv)
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
                    string razonsocial = tabla.Rows[i]["razonsocial"].ToString();
                    string tipodoc = tabla.Rows[i]["tipodocumento"].ToString();
                    string numdoc = tabla.Rows[i]["numdocumento"].ToString();
                    string telefono = tabla.Rows[i]["telefono"].ToString();
                    string correo = tabla.Rows[i]["correo"].ToString();
                    int idproveedor = int.Parse(tabla.Rows[i]["idproveedor"].ToString());

                    dgv.Rows.Add(
                        i + 1, razonsocial, tipodoc, numdoc, telefono, correo, "Editar", "Eliminar", idproveedor
                        );
                }
            }
        }
    }
}

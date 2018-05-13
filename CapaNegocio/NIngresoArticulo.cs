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
    public class NIngresoArticulo
    {
        DIngresoArticulo objDIA = new DIngresoArticulo();

        public static int Insertar(string comprobante, string numingreso, string impuesto, int idproveedor, int idusuario)
        {
            DIngresoArticulo objingreso = new DIngresoArticulo();
            objingreso.Comprobante = comprobante;
            objingreso.NumIngreso = numingreso;
            objingreso.Impuesto = impuesto;
            objingreso.IdProveedor = idproveedor;
            objingreso.IdUsuario = idusuario;
            return objingreso.Insertar(objingreso);
        }

        public static  bool ActualizarEstado(int estado, int idingreso)
        {
            DIngresoArticulo objingreso = new DIngresoArticulo();
            objingreso.Estado = estado;
            objingreso.IdIngresoArticulo = idingreso;
            return objingreso.ActualizarEstado(objingreso);
        }



        public static DataTable Listar()
        {
            return new DIngresoArticulo().Listar();
        }

        public static string GenerarCodigoIngreso()
        {
            return new DIngresoArticulo().GeneradorCodigoIngreso();
        }


        public static DataTable BuscarCodigo(int id)
        {
            DIngresoArticulo objDIA = new DIngresoArticulo();
            objDIA.IdIngresoArticulo = id;
            return objDIA.BuscarPorCodigo(objDIA);
        }



        // metodo para buscar categoria por nombre
        public static DataTable BuscarNumeroIngreso(string numingreso)
        {
            DIngresoArticulo objDIA = new DIngresoArticulo();
            objDIA.NumIngreso = numingreso;
            return objDIA.BuscarIngresoNumeroIngreso(objDIA);
        }

        public void ListarIngresoPorNumeroIngreso(DataGridView dgv, string numingreso)
        {
            DataTable tabla = BuscarNumeroIngreso(numingreso);
            this.ListarGrid(dgv, tabla);
        }

        public void ListarDataGridViewIngresoArticulos(DataGridView dgv)
        {
            DataTable tabla = Listar();
            this.ListarGrid(dgv, tabla);
        }


        //double amount = 1234.95;

            //amount.ToString("C"); // whatever the executing computer thinks is the right fomat

            //amount.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("en-ie"));    //  €1,234.95
            //amount.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("es-es"));    //  1.234,95 € 
            //amount.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("en-GB"));    //  £1,234.95 

            //amount.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("en-au"));    //  $1,234.95
            //amount.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("en-us"));    //  $1,234.95
            //amount.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("en-ca"));    //  $1,234.95
        public void ListarGrid(DataGridView dgv, DataTable tabla)
        {
            int numFilas = tabla.Rows.Count;
            if (numFilas > 0)
            {
                dgv.Rows.Clear();
                for (int i = 0; i < numFilas; i++)
                {
                    string comprobante = tabla.Rows[i]["comprobante"].ToString();
                    string proveedor = tabla.Rows[i]["proveedor"].ToString();
                    DateTime fecha = Convert.ToDateTime(tabla.Rows[i]["fecha"].ToString());
                    string estado = Convert.ToInt32(tabla.Rows[i]["estado"].ToString()) == 1 ? "Emitido" : "Anulado";
                    decimal total = Convert.ToDecimal(tabla.Rows[i]["total"].ToString());
                    int id_ingreso_articulo = Convert.ToInt32(tabla.Rows[i]["idingresoart"].ToString());

                    dgv.Rows.Add(
                        i + 1, comprobante, proveedor, fecha.ToString("dd-MM-yyyyy"), estado, total.ToString("C",CultureInfo.GetCultureInfo("en-US")), "VER", "ANULAR", id_ingreso_articulo
                        );
                }
            }
        }
    }
}

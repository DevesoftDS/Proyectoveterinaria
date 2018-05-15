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
    public class NVenta
    {
        public static int Insertar(int idcomprobante, string comprobante, string serie, string correlativo, 
            int idcliente, string razonsocial, string ruc, decimal subtotal, decimal igv, decimal total, int idusuario
            )
        {
            DVenta objVenta = new DVenta();
            objVenta.IdComprobante = idcomprobante;
            objVenta.Comprobante = comprobante;
            objVenta.Serie = serie;
            objVenta.Correlativo = correlativo;
            objVenta.IdCliente = idcliente;
            objVenta.RazonSocial = razonsocial;
            objVenta.Ruc = ruc;
            objVenta.SubTotal = subtotal;
            objVenta.Igv = igv;
            objVenta.Total = total;
            objVenta.IdUsuario = idusuario;

            return objVenta.Insertar(objVenta);
        }

        public static DataTable Listar()
        {
            return new DVenta().Listar();
        }

        public static DataTable BuscarNombre(string dato)
        {
            DVenta objVenta = new DVenta();
            objVenta.Dato = dato;
            return objVenta.BuscarVentaCorrelativoDni(objVenta);
        }

        public void ListarventaPorBusqueda(DataGridView dgv, string dato)
        {
            DataTable tabla = BuscarNombre(dato);
            this.ListarGrid(dgv, tabla);

        }

        public void ListarDataGridViewVenta(DataGridView dgv)
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
                    string comprobante = tabla.Rows[i]["comprobante"].ToString();
                    string serie = tabla.Rows[i]["serie"].ToString();
                    string correlativo = tabla.Rows[i]["correlativo"].ToString();
                    string cliente = tabla.Rows[i]["nombres"].ToString() + " " + tabla.Rows[i]["apellidos"].ToString();
                    string razon_social = tabla.Rows[i]["razonsocial"].ToString();
                    string ruc = tabla.Rows[i]["ruc"].ToString();
                    DateTime fecha = Convert.ToDateTime(tabla.Rows[i]["fecha"].ToString());
                    string subtotal = tabla.Rows[i]["subtotal"].ToString();
                    string igv = tabla.Rows[i]["igv"].ToString();
                    string total = tabla.Rows[i]["total"].ToString();
                    int idventa = Convert.ToInt32(tabla.Rows[i]["idventas"].ToString());

                    dgv.Rows.Add(
                        i + 1, comprobante, serie, correlativo, cliente, razon_social, ruc, fecha.ToString("dd/MM/yyyy"), subtotal, igv, total, idventa
                        );
                }
            }
        }
    }
}

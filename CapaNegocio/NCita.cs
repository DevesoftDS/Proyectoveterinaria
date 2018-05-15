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
    public class NCita
    {
        public static int InsertarCita(int idPagoServicio, int idUsuario,decimal total)
        {
            DCita objCita = new DCita();
            objCita.IdPagoServicio = idPagoServicio;
            objCita.IdUsuario = idUsuario;
            objCita.Total = total;
            return objCita.InsertarCita(objCita);
        }
        public static DataTable BuscarCitaFecha(DateTime fecha)
        {
            DCita objCita = new DCita();
            objCita.FechaCita = fecha;
            return objCita.BuscarFechaCita(objCita);
        }

        public static DataTable ListarCitas()
        {
            return new DCita().ListarCitas();
        }
        public static DataTable BuscarCita(string textoBuscar)
        {
            DCita ojcita = new DCita();
            ojcita.TextoBuscar = textoBuscar;
            return ojcita.BuscarCita(ojcita);
        }

        
        public static void ListarGriv(DataGridView dgv, DataTable tabla)
        {
            string simbolo = "S/.";
            string total = "";
            string importe = "";
            char espacio = Convert.ToChar(" ");
            int libre = 25;
        int numRow = tabla.Rows.Count;
            
            if (numRow > 0)
            {

                dgv.Rows.Clear();
               
                for (int i = 0; i < numRow; i++)
                {
                    int codigo = Convert.ToInt32(tabla.Rows[i]["idcita"].ToString());
                    string fechaCita = tabla.Rows[i]["fechacita"].ToString();
                    string cliente = tabla.Rows[i]["nombres"].ToString()+" " + tabla.Rows[i]["apellidos"].ToString();
                    string dni = tabla.Rows[i]["dni"].ToString();
                    string direccion = tabla.Rows[i]["direccion"].ToString();
                    string codigoM = tabla.Rows[i]["codigo"].ToString();
                    string mascota = tabla.Rows[i]["mascota"].ToString();                                     
                    string fechaAtencion = tabla.Rows[i]["fecha"].ToString();
                    string hora = tabla.Rows[i]["hora"].ToString();
                    string servicio = tabla.Rows[i]["servicio"].ToString();
                    //total = simbolo.PadRight(libre,espacio)+ tabla.Rows[i]["total"].ToString();
                   // string importe = simbolo.PadRight(libre, espacio) + tabla.Rows[i]["importe"].ToString();

                    if (tabla.Rows[i]["total"].ToString().Length==4)
                    {
                         total = simbolo.PadRight(libre, espacio) + tabla.Rows[i]["total"].ToString();
                    }
                    else if (tabla.Rows[i]["total"].ToString().Length > 4)
                    {
                        total = simbolo.PadRight(libre- tabla.Rows[i]["total"].ToString().Length, espacio) + tabla.Rows[i]["total"].ToString();
                    }
                    if (tabla.Rows[i]["importe"].ToString().Length == 4)
                    {
                        importe = simbolo.PadRight(libre, espacio) + tabla.Rows[i]["importe"].ToString();
                    }
                    else if (tabla.Rows[i]["importe"].ToString().Length > 4)
                    {
                        importe = simbolo.PadRight(libre - tabla.Rows[i]["importe"].ToString().Length, espacio) + tabla.Rows[i]["importe"].ToString();
                    }                    
                    dgv.Rows.Add(i + 1, codigo, fechaCita,cliente, dni, direccion,codigoM, mascota,fechaAtencion,hora,servicio, importe, total);
                }
                
            }                    
        }

        public void ListarBusquedaCita(DataGridView dgv, string text)
        {
            var tabla = BuscarCita(text);
            ListarGriv(dgv, tabla);
        }
        public void ListarBusquedaFecha(DataGridView dgv, DateTime fecha)
        {
            var tabla = BuscarCitaFecha(fecha);
            ListarGriv(dgv, tabla);
        }
        public void ListadoDgv(DataGridView dgv)
        {
            var tabla = ListarCitas();
            ListarGriv(dgv, tabla);
        }

    }
}

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
    public class NDetalleCita
    {
        public static string insertarDetalleCita(int idCita, int idmascota,int idServicio, string fecha, string hora, string motivo, string sintoma, decimal descuento, decimal importe)
        {
            DDetalleCita objDetalle = new DDetalleCita();
            objDetalle.IdCita = idCita;
            objDetalle.IdMascota = idmascota;
            objDetalle.IdServicio = idServicio;
            objDetalle.Fecha = fecha;
            objDetalle.Hora = hora;
            objDetalle.Motivo = motivo;
            objDetalle.Sintoma = sintoma;
            objDetalle.Descuento = descuento;
            objDetalle.Importe = importe;
            return objDetalle.InsertarDetalleCita(objDetalle);
        }
        

        public static DataTable BuscarFechaCita(DateTime fecha)
        {
            DDetalleCita objCita = new DDetalleCita();
            objCita.FechaBuscar = fecha;
            return objCita.BuscarFechaCita(objCita);
        }

        public static void ListarGriv(DataGridView dgv, DataTable tabla)
        {
            
            int numRow = tabla.Rows.Count;

            if (numRow > 0)
            {

                dgv.Rows.Clear();

                for (int i = 0; i < numRow; i++)
                {
                    int idcita = Convert.ToInt32(tabla.Rows[i]["idcita"].ToString());                    
                    string cliente = tabla.Rows[i]["nombres"].ToString() + " " + tabla.Rows[i]["apellidos"].ToString();
                    string codigomascota = tabla.Rows[i]["codigo"].ToString();
                    string mascota = tabla.Rows[i]["mascota"].ToString();
                    string servicio = tabla.Rows[i]["servicio"].ToString();
                    string fecha = tabla.Rows[i]["fecha"].ToString();
                    string hora = tabla.Rows[i]["hora"].ToString();                    
                    dgv.Rows.Add(i + 1, idcita,cliente,codigomascota,mascota,servicio,fecha,hora);
                }

            }
        }
        public void ListarBuscarFecha(DataGridView dgv, DateTime fecha)
        {
            var tabla = BuscarFechaCita(fecha);
            ListarGriv(dgv, tabla);
        }


    }

    
}

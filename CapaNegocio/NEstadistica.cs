using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;
namespace CapaNegocio
{
    public class NEstadistica
    {
        public  DataTable MostrarVentasHoy()
        {
            DEstadistica objEst = new DEstadistica();
            return objEst.MostarVentaHoy();
        }
        public  DataTable MostrarTotalVentas()
        {
            DEstadistica objEst = new DEstadistica();
            return objEst.MostarTotalVentas();
        }
        public  DataTable CitasEmitidasHoy()
        {
            DEstadistica objEst = new DEstadistica();
            return objEst.CitasEmitidasHoy();
        }
        public  DataTable CitasAtenderhoy()
        {
            DEstadistica objEst = new DEstadistica();
            return objEst.CitasAtenderHoy();
        }
    }
}

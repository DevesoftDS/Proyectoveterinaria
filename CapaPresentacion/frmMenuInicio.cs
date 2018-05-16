using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
namespace CapaPresentacion
{
    public partial class frmMenuInicio : Form
    {
        public frmMenuInicio()
        {
            InitializeComponent();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        private void timerHoraFecha_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("HH:mm:ss");
            lblFecha.Text = DateTime.Now.ToLongDateString();
        }

        private void frmMenuInicio_Load(object sender, EventArgs e)
        {
            MostraDatos();
        }
        private void MostraDatos()
        {
            var objEst = new NEstadistica();

            var ventasHoy = objEst.MostrarVentasHoy();
            var citasHoy = objEst.CitasEmitidasHoy();
            var ventaTotal = objEst.MostrarTotalVentas();
            var citastotal = objEst.CitasAtenderhoy();
            if (ventasHoy.Rows.Count > 0)
            {
                txtVentaTotalHoy.Text = ventasHoy.Rows[0]["ventashoy"].ToString();
            }
            if (ventaTotal.Rows.Count > 0)
            {
                txtSumaVentas.Text = ventaTotal.Rows[0]["totalventa"].ToString();
            }
            if (citasHoy.Rows.Count > 0)
            {
                txtCitasHoy.Text = citasHoy.Rows[0]["emitidos"].ToString();
            }
            if (citastotal.Rows.Count > 0)
            {
                txtTotalCitas.Text = citastotal.Rows[0]["atender"].ToString();
            }
        }
    }
}

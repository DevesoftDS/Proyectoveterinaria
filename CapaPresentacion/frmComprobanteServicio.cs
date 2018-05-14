using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{

    public partial class frmComprobanteServicio : Form
    {
        public int IdComprobante { get; set; }
        public frmComprobanteServicio()
        {
            InitializeComponent();
        }

        private void frmComprobanteServicio_Load(object sender, EventArgs e)
        {
            string num;
            num = IdComprobante.ToString();
            var cita = new CRComprobanteServis();
            cita.SetParameterValue("@buscar", num);
            cita.SetDatabaseLogon("sa", "123");            
            crystalReportViewer2.ReportSource = cita;

        }
    }
}

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
    public partial class frmComprobante : Form
    {
        public int IdVenta { get; set; }
        public frmComprobante()
        {
            InitializeComponent();
        }

        private void frmComprobante_Load(object sender, EventArgs e)
        {
            string num;
            num = IdVenta.ToString();
            var rpFactura = new CRComprobante();
            rpFactura.SetParameterValue("@id", num);
            rpFactura.SetDatabaseLogon("marade", "soto");
            crvComprobante.ReportSource = rpFactura;
        }
    }
}

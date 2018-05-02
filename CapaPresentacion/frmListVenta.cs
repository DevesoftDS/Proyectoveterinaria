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
    public partial class frmListVenta : Form
    {
        public frmListVenta()
        {
            InitializeComponent();
        }

        private void btnNuevoVenta_Click(object sender, EventArgs e)
        {
            new frmVenta().ShowDialog();
        }
    }
}

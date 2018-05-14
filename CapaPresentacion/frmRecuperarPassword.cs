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
    public partial class frmRecuperarPassword : Form
    {
        public frmRecuperarPassword()
        {
            InitializeComponent();
        }

        private void btnRecuperar_Click(object sender, EventArgs e)
        {
            string rpta = NRecuperar.RecuperarPassword(txtrecuperar.Text.Trim());
            txtMensaje.Text = rpta;
        }
    }
}

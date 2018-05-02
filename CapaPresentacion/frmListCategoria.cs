using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class frmListCategoria : Form
    {
        NPresentacion objtCN = new NPresentacion();
        public frmListCategoria()
        {
            InitializeComponent();
        }

        private void btnNuevoCategoria_Click(object sender, EventArgs e)
        {
            new frmCategoria().ShowDialog();
        }

        private void frmListCategoria_Load(object sender, EventArgs e)
        {
            Mostrarcategoria();
        }
        private void Mostrarcategoria()
        {
            dgvPresentacion.DataSource = objtCN.MostrarCategoria();
        }
    }
}

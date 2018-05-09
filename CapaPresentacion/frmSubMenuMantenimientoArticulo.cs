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
    public partial class frmSubMenuMantenimientoArticulo : Form
    {
        public frmSubMenuMantenimientoArticulo()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnArticulos_Click(object sender, EventArgs e)
        {
            frmHome.MyForm.AbrirFormHija(new frmListArticulo());
            frmListArticulo.MyFormListArt.dgvArticulo.Refresh();
        }

        private void btnCategoria_Click(object sender, EventArgs e)
        {
            frmHome.MyForm.AbrirFormHija(new frmListCategoria());
            frmListCategoria.MyForm.dgvPresentacion.Refresh();
        }

        private void btnPresentacion_Click(object sender, EventArgs e)
        {
            frmHome.MyForm.AbrirFormHija(new frmListPresentacion());
            frmPresentacion.MyFormPresentation.Refresh();
        }
    }
}

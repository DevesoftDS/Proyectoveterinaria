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
    public partial class frmSubMenuIngresoArticulo : Form
    {
        public frmSubMenuIngresoArticulo()
        {
            InitializeComponent();
        }

        private void btnIngreso_Click(object sender, EventArgs e)
        {
            frmHome.MyForm.AbrirFormHija(new frmListIngresoArticulos());
        }

        private void btnListaProductos_Click(object sender, EventArgs e)
        {
            frmHome.MyForm.AbrirFormHija(new frmListaArticulosAlmacen());
        }
    }
}

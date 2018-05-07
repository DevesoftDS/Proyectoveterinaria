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
    public partial class frmMenuMantenimiento : Form
    {
        public frmMenuMantenimiento()
        {
            InitializeComponent();
        }

        private void AbrirSubMenu2(object formHija)
        {
            frmHome frmsubmen = new frmHome();
            if (frmsubmen.barraSubMenu.Controls.Count > 0)
                frmsubmen.barraSubMenu.Controls.RemoveAt(0);
            Form fh = formHija as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            frmsubmen.barraSubMenu.Controls.Add(fh);
            frmsubmen.barraSubMenu.Tag = fh;
            fh.Show();
        }
        private void pArticulos_Click(object sender, EventArgs e)
        {
            frmHome.MyForm.AbrirSubMenu(new frmSubMenuMantenimientoArticulo());
            frmHome.MyForm.barraSection.Controls.Clear();
        } 

        private void pCliente_Click(object sender, EventArgs e)
        {
            frmHome.MyForm.AbrirFormHija(new frmListCliente());
            frmHome.MyForm.barraSubMenu.Controls.Clear();
        }

        private void pPersonal_Click(object sender, EventArgs e)
        {
            frmHome.MyForm.AbrirFormHija(new frmListEmpleado());
            frmHome.MyForm.barraSubMenu.Controls.Clear();
        }

        private void pProveedor_Click(object sender, EventArgs e)
        {
            frmHome.MyForm.AbrirFormHija(new frmListProveedor());
            frmHome.MyForm.barraSubMenu.Controls.Clear();
        }

        private void pUsuario_Click(object sender, EventArgs e)
        {
            frmHome.MyForm.AbrirFormHija(new frmListUsuario());
            frmHome.MyForm.barraSubMenu.Controls.Clear();
        }
    }
}

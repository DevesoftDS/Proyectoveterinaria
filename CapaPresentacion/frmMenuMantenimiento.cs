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
        public string TipoUser { get; set; }
        public frmMenuMantenimiento()
        {
            InitializeComponent();
            if (_myFormMant == null)
            {
                _myFormMant = this;
            }
        }

        private static frmMenuMantenimiento _myFormMant;

        public static frmMenuMantenimiento MyFormMant
        {
            get
            {
                if (_myFormMant == null)
                {
                    _myFormMant = new frmMenuMantenimiento();
                }
                return _myFormMant;
            }

            set
            {
                _myFormMant = value;
            }
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

        private void pPaciente_Click(object sender, EventArgs e)
        {
            frmHome.MyForm.AbrirFormHija(new frmListMascota());
            frmHome.MyForm.barraSubMenu.Controls.Clear();
        }

        private void frmMenuMantenimiento_FormClosed(object sender, FormClosedEventArgs e)
        {
            _myFormMant = null;
        }

        private void frmMenuMantenimiento_Load(object sender, EventArgs e)
        {
            TipoUser = Program.tipo;

            if (TipoUser == "Invitado")
            {

            }
            else if (TipoUser == "Vendedor")
            {
                
            }
            else if (TipoUser == "Almacenero")
            {
                pUsuario.Enabled = false;
                pArticulos.Enabled = false;
                pPersonal.Enabled = false;
                pPaciente.Enabled = false;
                pCliente.Enabled = false;
                pProveedor.Enabled = true;
            }
            else
            {
                pUsuario.Enabled = true;
                pArticulos.Enabled = true;
                pPersonal.Enabled = true;
                pPaciente.Enabled = true;
                pCliente.Enabled = true;
                pProveedor.Enabled = true;
            }
        }
    }
}

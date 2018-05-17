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
    public partial class frmSubMenuReportes : Form
    {
        public string TipoUser { get; set; }
        public frmSubMenuReportes()
        {
            InitializeComponent();
            if (_myFormSubReports == null)
            {
                _myFormSubReports = this;
            }
        }

        private static frmSubMenuReportes _myFormSubReports;

        public static frmSubMenuReportes MyFormSubReports
        {
            get
            {
                if (_myFormSubReports == null)
                {
                    _myFormSubReports = new frmSubMenuReportes();
                }
                return _myFormSubReports;
            }

            set
            {
                _myFormSubReports = value;
            }
        }

        private void frmSubMenuReportes_FormClosed(object sender, FormClosedEventArgs e)
        {
            _myFormSubReports = null;
        }

        private void pPersonal_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Reporte personal");
        }

        private void frmSubMenuReportes_Load(object sender, EventArgs e)
        {
            TipoUser = Program.tipo;

            if (TipoUser == "Invitado")
            {

            }
            else if (TipoUser == "Vendedor")
            {
                pCitas.Enabled = true;
                pArticulos.Enabled = false;
                pPersonal.Enabled = false;
                pPaciente.Enabled = false;
                pCliente.Enabled = false;
            }
            else if (TipoUser == "Almacenero")
            {

            }
            else
            {
                pCitas.Enabled = true;
                pArticulos.Enabled = true;
                pPersonal.Enabled = true;
                pPaciente.Enabled = true;
                pCliente.Enabled = true;
            }
        }
    }
}

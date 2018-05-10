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
    public partial class frmListCita : Form
    {
        public frmListCita()
        {
            InitializeComponent();
            if (_miFormListCita==null)
            {
                _miFormListCita = this;
            }
        }

        #region interfaz
        private static frmListCita _miFormListCita;

        public static frmListCita MiFormListCita
        {
            get
            {
                if (_miFormListCita==null)
                {
                    _miFormListCita = new frmListCita();
                }
                return _miFormListCita;
            }

            set
            {
                _miFormListCita = value;
            }
        }
        private void frmListCita_FormClosed(object sender, FormClosedEventArgs e)
        {
            _miFormListCita = null;
        }
        #endregion

        private void btnNuevaCita_Click(object sender, EventArgs e)
        {
            frmCita fCita = new frmCita();
            fCita.ShowDialog();
            dgvCita.Refresh();
        }
        
    }
}

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
        private void estiloDgv()
        {
            this.dgvCita.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            this.dgvCita.DefaultCellStyle.ForeColor = Color.Black;
            this.dgvCita.DefaultCellStyle.BackColor = Color.White;
            this.dgvCita.DefaultCellStyle.SelectionForeColor = Color.Black;
            this.dgvCita.DefaultCellStyle.SelectionBackColor = Color.FromArgb(128, 203, 196);          
            
        }

        private void btnNuevaCita_Click(object sender, EventArgs e)
        {
            frmCita fCita = new frmCita();
            fCita.ShowDialog();
            dgvCita.Refresh();
        }

        private void frmListCita_Load(object sender, EventArgs e)
        {
           
            var tabla = new NCita();
            tabla.ListadoDgv(dgvCita);
            estiloDgv();

            dgvCita.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvCita.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvCita.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvCita.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvCita.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvCita.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvCita.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvCita.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvCita.Columns[12].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;

            dgvCita.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCita.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCita.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCita.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvCita.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCita.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCita.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCita.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCita.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvCita.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;  
                     
            dgvCita.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);           

        }

        private void dtpBuscar_ValueChanged(object sender, EventArgs e)
        {
            var tabla = new NCita();
            tabla.ListarBusquedaFecha(dgvCita, Convert.ToDateTime(dtpBuscar.Text));           
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            NCita objcita = new NCita();
            if (Char.IsLetter(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsSeparator(e.KeyChar) || char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
            }
            if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
            if ((int)e.KeyChar==(int)Keys.Enter)
            {                
                objcita.ListarBusquedaCita(dgvCita, txtBuscar.Text);
            }
           else
            {
                objcita.ListadoDgv(dgvCita);
            }
        }
    }
}

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
    public partial class frmListVenta : Form
    {
        NVenta objNV = new NVenta();

        public frmListVenta()
        {
            InitializeComponent();
            if (_myFormListVenta == null)
            {
                _myFormListVenta = this;
            }
        }

        private static frmListVenta _myFormListVenta;

        public static frmListVenta MyFormListVenta
        {
            get
            {
                if (_myFormListVenta == null)
                {
                    _myFormListVenta = new frmListVenta();
                }
                return _myFormListVenta;
            }

            set
            {
                _myFormListVenta = value;
            }
        }

        private void btnNuevoVenta_Click(object sender, EventArgs e)
        {
            new frmVenta().ShowDialog();
        }
        private void estiloDgv()
        {
            this.dgvVenta.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            this.dgvVenta.DefaultCellStyle.ForeColor = Color.Black;
            this.dgvVenta.DefaultCellStyle.BackColor = Color.White;
            this.dgvVenta.DefaultCellStyle.SelectionForeColor = Color.Black;
            this.dgvVenta.DefaultCellStyle.SelectionBackColor = Color.Orange;
        }

        private void frmListVenta_Load(object sender, EventArgs e)
        {
            MostrarVenta();
            estiloDgv();
            dgvVenta.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;

            dgvVenta.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvVenta.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvVenta.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;

            dgvVenta.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvVenta.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvVenta.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvVenta.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvVenta.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
        }

        private void MostrarVenta()
        {
            objNV.ListarDataGridViewVenta(dgvVenta);
        }

        private void frmListVenta_FormClosed(object sender, FormClosedEventArgs e)
        {
            _myFormListVenta = null;
        }

        private void txtBuscarVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                //aqui codigo
                objNV.ListarventaPorBusqueda(dgvVenta, txtBuscarVenta.Text.Trim());
            }
            else
                MostrarVenta();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            MostrarVenta();
        }
    }
}

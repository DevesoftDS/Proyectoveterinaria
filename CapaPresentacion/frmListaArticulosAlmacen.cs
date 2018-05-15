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
    public partial class frmListaArticulosAlmacen : Form
    {
        NDetalleIngresoArticulo objNDIA = new NDetalleIngresoArticulo();

        public frmListaArticulosAlmacen()
        {
            InitializeComponent();
        }

        private void frmListaArticulosAlmacen_Load(object sender, EventArgs e)
        {
            MostrarIngresos();
            estiloDgv();

            dgvArticulo.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvArticulo.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvArticulo.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
        }

        private void MostrarIngresos()
        {
            objNDIA.MostrarDataGridViewIngresoArticulos(dgvArticulo);
        }

        private void txtBuscarIngreso_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscarIngreso.Text.Trim().Length > 0)
            {
                objNDIA.MostrarArticuloPorNombre(dgvArticulo, txtBuscarIngreso.Text.Trim());
            }
            else
                MostrarIngresos();
        }

        private void estiloDgv()
        {
            this.dgvArticulo.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            this.dgvArticulo.DefaultCellStyle.ForeColor = Color.Black;
            this.dgvArticulo.DefaultCellStyle.BackColor = Color.White;
            this.dgvArticulo.DefaultCellStyle.SelectionForeColor = Color.Black;
            this.dgvArticulo.DefaultCellStyle.SelectionBackColor = Color.Orange;
        }
    }
}

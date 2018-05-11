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
    public partial class FrmListadoArticuloIngreso : Form
    {
        NDetalleIngresoArticulo objNDI = new NDetalleIngresoArticulo();
        NCategoria objNC = new NCategoria();

        public FrmListadoArticuloIngreso()
        {
            InitializeComponent();
            if (_myformListaAI == null)
            {
                _myformListaAI = this;
            }
        }
        private static FrmListadoArticuloIngreso _myformListaAI;

        public static FrmListadoArticuloIngreso MyformListaAI
        {
            get
            {
                if (_myformListaAI == null)
                {
                    _myformListaAI = new FrmListadoArticuloIngreso();
                }
                return _myformListaAI;
            }

            set
            {
                _myformListaAI = value;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmListadoArticuloIngreso_FormClosed(object sender, FormClosedEventArgs e)
        {
            _myformListaAI = null;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FrmListadoArticuloIngreso_Load(object sender, EventArgs e)
        {
            MostarIngresoArticulo();

            MostarCategoriaCBO();

            estiloDgv();

            dgvArticulo.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;        
            dgvArticulo.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvArticulo.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);

        }

        private void MostarCategoriaCBO()
        {
            DataTable tabla = NCategoria.Listar();
            int num_filas = tabla.Rows.Count;
            if (num_filas > 0)
            {
                cboBuscar.DataSource = tabla;
                cboBuscar.DisplayMember = "nombre";
                cboBuscar.ValueMember = "idcategoria";
            }
        }

        private void MostarIngresoArticulo()
        {
            objNDI.MostrarDataGridViewIngresoArticulos(dgvArticulo);
        }

        private void txtBuscarArt_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscarArt.Text.Trim().Length > 0)
            {
                objNDI.MostrarArticuloPorNombre(dgvArticulo, txtBuscarArt.Text.Trim());
            }
            else
                MostarIngresoArticulo();
        }

        private void cboBuscar_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboBuscar.SelectedIndex != -1)
            {
                objNDI.MostrarArticuloPorCategoria(dgvArticulo, cboBuscar.SelectedItem.ToString());
            }
            else
                MostarIngresoArticulo();
        }

        private void cboBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            objNDI.MostrarArticuloPorCategoria(dgvArticulo, cboBuscar.Text);
        }
        private void estiloDgv()
        {
            this.dgvArticulo.DefaultCellStyle.Font = new Font("Arial", 9);
            this.dgvArticulo.DefaultCellStyle.ForeColor = Color.Black;
            this.dgvArticulo.DefaultCellStyle.BackColor = Color.White;
            this.dgvArticulo.DefaultCellStyle.SelectionForeColor = Color.Black;
            this.dgvArticulo.DefaultCellStyle.SelectionBackColor = Color.Orange;
        }

        private void cboBuscar_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cboBuscar.SelectedIndex != -1)
            {
                objNDI.MostrarArticuloPorCategoria(dgvArticulo, cboBuscar.SelectedItem.ToString());
            }
            else
                MostarIngresoArticulo();
        }

        private void dgvArticulo_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataTable tabla = new DataTable();

                int idingreso = Convert.ToInt32(dgvArticulo.Rows[e.RowIndex].Cells[6].Value);

                int num_filas = dgvArticulo.Rows.Count;
                if (num_filas > 0)
                {
                    frmVenta.MyFormVenta.idDAIngreso = idingreso;
                    frmVenta.MyFormVenta.txtArticulo.Text = dgvArticulo.Rows[e.RowIndex].Cells[1].Value.ToString()+" "+ dgvArticulo.Rows[e.RowIndex].Cells[2].Value.ToString() + " " + dgvArticulo.Rows[e.RowIndex].Cells[3].Value.ToString();
                    frmVenta.MyFormVenta.txtPrecio.Text = dgvArticulo.Rows[e.RowIndex].Cells[5].Value.ToString();
                    frmVenta.MyFormVenta.txtStock.Text = dgvArticulo.Rows[e.RowIndex].Cells[4].Value.ToString();

                    this.Close();
                }
                //tabla = NArticulo.BuscarCodigo(idarticulo);
                //new frmArticulo().Show();
                //int numFilas = tabla.Rows.Count;
                //if (numFilas == 1)
                //{
                //    frmArticulo.MyFormArt.txtCodigo.Text = tabla.Rows[0]["codigo"].ToString();
                //}

            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class frmListCategoria : Form
    {
        //NPresentacion objtCN = new NPresentacion();
        NCategoria objNC = new NCategoria();
        
        public frmListCategoria()
        {
            InitializeComponent();
            if (_myForm == null)
            {
                _myForm = this;
            }
        }

        private static frmListCategoria _myForm;

        public static frmListCategoria MyForm
        {
            get
            {
                if (_myForm == null)
                {
                    _myForm = new frmListCategoria();
                }
                return _myForm;
            }

            set
            {
                _myForm = value;
            }
        }

        private void btnNuevoCategoria_Click(object sender, EventArgs e)
        {
            new frmCategoria().ShowDialog();
            //frmCategoria.MyFormCategoria.isNew = false;
        }

        private void frmListCategoria_Load(object sender, EventArgs e)
        {
            Mostrarcategoria();
            estiloDgv();

            dgvPresentacion.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvPresentacion.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvPresentacion.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;

            dgvPresentacion.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPresentacion.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPresentacion.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvPresentacion.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);

        }
        private void Mostrarcategoria()
        {
            objNC.ListarDataGridViewCategoria(dgvPresentacion);

        }

        private void estiloDgv()
        {
            this.dgvPresentacion.DefaultCellStyle.Font = new Font("Arial", 9);
            this.dgvPresentacion.DefaultCellStyle.ForeColor = Color.Black;
            this.dgvPresentacion.DefaultCellStyle.BackColor = Color.White;
            this.dgvPresentacion.DefaultCellStyle.SelectionForeColor = Color.Yellow;
            this.dgvPresentacion.DefaultCellStyle.SelectionBackColor = Color.Black;
        }

        private void txtBuscarCategoria_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscarCategoria.Text.Trim().Length > 0)
            {
                objNC.BuscarCategoriaPorNombre(dgvPresentacion, txtBuscarCategoria.Text);
            }
            else
            {
                Mostrarcategoria();
            }
        }

        private void frmListCategoria_FormClosed(object sender, FormClosedEventArgs e)
        {
            _myForm = null;
        }

        private void dgvPresentacion_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataTable tabla = new DataTable();
                
                
                if (dgvPresentacion.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Equals("Editar"))
                {
                    int idcategoria = Convert.ToInt32(dgvPresentacion.Rows[e.RowIndex].Cells[5].Value);
                    tabla = NCategoria.BuscarCodigo(idcategoria);
                    new frmCategoria().Show();
                    int numFilas = tabla.Rows.Count;
                    if (numFilas == 1)
                    {
                        frmCategoria.MyFormCategoria.txtNombre.Text = tabla.Rows[0]["nombre"].ToString();
                        frmCategoria.MyFormCategoria.txtDescripcion.Text = tabla.Rows[0]["Descripcion"].ToString();
                        frmCategoria.MyFormCategoria.idcategoria = int.Parse(tabla.Rows[0]["idcategoria"].ToString());
                        frmCategoria.MyFormCategoria.isNew = false;
                    }
                }
                if (dgvPresentacion.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Equals("Eliminar"))
                {
                    int idcategoria = Convert.ToInt32(dgvPresentacion.Rows[e.RowIndex].Cells[5].Value);
                    DialogResult rspta = MessageBox.Show("Desea Eliminar", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (DialogResult.Yes == rspta)
                    {
                        //var empleado = new Clases.Empleado(id_personal);
                        bool objCat = NCategoria.Eliminar(idcategoria);
                        if (objCat)
                        {
                            dgvPresentacion.Rows.RemoveAt(e.RowIndex);
                            Mostrarcategoria();
                        }
                        else MessageBox.Show("Error al eliminar ");

                    }
                }
            }
        }
    }
}

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
using System.IO;

namespace CapaPresentacion
{
    public partial class frmListArticulo : Form
    {
        NArticulo objNA = new NArticulo();

        public frmListArticulo()
        {
            InitializeComponent();
            if (_myFormListArt == null)
            {
                _myFormListArt = this;
            }
        }
        private static frmListArticulo _myFormListArt;

        public static frmListArticulo MyFormListArt
        {
            get
            {
                if (_myFormListArt == null)
                {
                    _myFormListArt = new frmListArticulo();
                }
                return _myFormListArt;
            }

            set
            {
                _myFormListArt = value;
            }
        }

        private void btnNuevoArticulo_Click(object sender, EventArgs e)
        {
            new frmArticulo().ShowDialog();
        }

        private void frmListArticulo_Load(object sender, EventArgs e)
        {
            MostrarArticulo();
            estiloDgv();

            dgvArticulo.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvArticulo.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvArticulo.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;

            dgvArticulo.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvArticulo.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvArticulo.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvArticulo.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
        }

        private void estiloDgv()
        {
            this.dgvArticulo.DefaultCellStyle.Font = new Font("Arial", 9);
            this.dgvArticulo.DefaultCellStyle.ForeColor = Color.Black;
            this.dgvArticulo.DefaultCellStyle.BackColor = Color.White;
            this.dgvArticulo.DefaultCellStyle.SelectionForeColor = Color.Black;
            this.dgvArticulo.DefaultCellStyle.SelectionBackColor = Color.Orange;
        }

        private void MostrarArticulo()
        {
            objNA.ListarDataGridViewArticulo(dgvArticulo);
        }


        private void frmListArticulo_FormClosed(object sender, FormClosedEventArgs e)
        {
            _myFormListArt = null;
        }

        private void txtBuscarArt_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscarArt.Text.Trim().Length > 0)
            {
                objNA.ListarArticuloPorNombre(dgvArticulo, txtBuscarArt.Text.Trim());
            }
            else
                MostrarArticulo();
        }

        private void dgvArticulo_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataTable tabla = new DataTable();


                if (dgvArticulo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Equals("Editar"))
                {
                    int idarticulo = Convert.ToInt32(dgvArticulo.Rows[e.RowIndex].Cells[7].Value);
                    tabla = NArticulo.BuscarCodigo(idarticulo);
                    new frmArticulo().Show();
                    int numFilas = tabla.Rows.Count;
                    if (numFilas == 1)
                    {
                        frmArticulo.MyFormArt.txtCodigo.Text = tabla.Rows[0]["codigo"].ToString();
                        frmArticulo.MyFormArt.txtNombre.Text = tabla.Rows[0]["nombre"].ToString();
                        frmArticulo.MyFormArt.cboCategoria.SelectedValue = tabla.Rows[0]["idcategoria"].ToString();
                        frmArticulo.MyFormArt.cboPresentacion.SelectedValue = tabla.Rows[0]["idpresentacion"].ToString();
                        frmArticulo.MyFormArt.txtNeto.Text = tabla.Rows[0]["neto"].ToString();
                        frmArticulo.MyFormArt.txtDescripcion.Text = tabla.Rows[0]["Descripcion"].ToString();
                        byte[] img = (byte[])tabla.Rows[0]["imagen"];
                        var ms = new MemoryStream(img);
                        frmArticulo.MyFormArt.pbImagen.Image = Image.FromStream(ms);
                        frmArticulo.MyFormArt.idArticulo = int.Parse(tabla.Rows[0]["idarticulo"].ToString());
                        frmArticulo.MyFormArt._IsNew = false;
                    }
                }
                if (dgvArticulo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Equals("Eliminar"))
                {
                    int idarticulo = Convert.ToInt32(dgvArticulo.Rows[e.RowIndex].Cells[7].Value);
                    DialogResult rspta = MessageBox.Show("Desea Eliminar", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (DialogResult.Yes == rspta)
                    {
                        //var empleado = new Clases.Empleado(id_personal);
                        bool objCat = NArticulo.Eliminar(idarticulo);
                        if (objCat)
                        {
                            dgvArticulo.Rows.RemoveAt(e.RowIndex);
                            MostrarArticulo();
                        }
                        else MessageBox.Show("Error al eliminar ");

                    }
                }
            }
        }
    }
}

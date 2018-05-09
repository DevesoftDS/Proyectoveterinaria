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
    public partial class frmListProveedor : Form
    {
        NProveedor objNP = new NProveedor();

        public frmListProveedor()
        {
            InitializeComponent();
            if (_myFormListProv == null)
            {
                _myFormListProv = this;
            }
        }

        private static frmListProveedor _myFormListProv;

        public static frmListProveedor MyFormListProv
        {
            get
            {
                if (_myFormListProv == null)
                {
                    _myFormListProv = new frmListProveedor();
                }
                return _myFormListProv;
            }

            set
            {
                _myFormListProv = value;
            }
        }

        private void btnNuevoProveedor_Click(object sender, EventArgs e)
        {
            frmProveedor frmProveedor = new frmProveedor();
            frmProveedor.ShowDialog();
            this.dgvProveedor.Refresh();
        }

        private void estiloDgv()
        {
            this.dgvProveedor.DefaultCellStyle.Font = new Font("Arial", 9);
            this.dgvProveedor.DefaultCellStyle.ForeColor = Color.Black;
            this.dgvProveedor.DefaultCellStyle.BackColor = Color.White;
            this.dgvProveedor.DefaultCellStyle.SelectionForeColor = Color.Black;
            this.dgvProveedor.DefaultCellStyle.SelectionBackColor = Color.Orange;
        }

        private void frmListProveedor_Load(object sender, EventArgs e)
        {
            MostarProveedor();
            estiloDgv();


            dgvProveedor.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvProveedor.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvProveedor.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;

            dgvProveedor.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProveedor.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProveedor.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvProveedor.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
        }

        private void MostarProveedor()
        {
            objNP.LIstarDataGridViewProveedor(dgvProveedor);
        }

        private void txtBuscarProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                objNP.LIstarPorNumeroDocumento(dgvProveedor, txtBuscarProveedor.Text);
            }
            else
            {
                MostarProveedor();
            }
        }

        private void dgvProveedor_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataTable tabla = new DataTable();
                if (dgvProveedor.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Equals("Editar"))
                {
                    int idproveedor = Convert.ToInt32(dgvProveedor.Rows[e.RowIndex].Cells[8].Value);
                    tabla = NProveedor.BuscarCodigo(idproveedor);
                    new frmProveedor().Show();
                    int numFilas = tabla.Rows.Count;
                    if (numFilas == 1)
                    {
                        frmProveedor.MyFormProv.txtRazonSocial.Text = tabla.Rows[0]["razonsocial"].ToString();
                        frmProveedor.MyFormProv.cboTipoDoc.Text = tabla.Rows[0]["tipodocumento"].ToString();
                        frmProveedor.MyFormProv.txtNumDoc.Text = tabla.Rows[0]["numdocumento"].ToString();
                        frmProveedor.MyFormProv.txtTelefono.Text = tabla.Rows[0]["telefono"].ToString();
                        frmProveedor.MyFormProv.txtCorreo.Text = tabla.Rows[0]["correo"].ToString();
                        frmProveedor.MyFormProv.txtDireccion.Text = tabla.Rows[0]["direccion"].ToString();
                        frmProveedor.MyFormProv.idProveedor = int.Parse(tabla.Rows[0]["idproveedor"].ToString());

                        frmProveedor.MyFormProv._isNew = false;
                    }
                }
                if (dgvProveedor.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Equals("Eliminar"))
                {
                    int idproveedor = Convert.ToInt32(dgvProveedor.Rows[e.RowIndex].Cells[8].Value);
                    DialogResult rspta = MessageBox.Show("Desea Eliminar", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (DialogResult.Yes == rspta)
                    {
                        //var empleado = new Clases.Empleado(id_personal);
                        bool objCat = NProveedor.Eliminar(idproveedor);
                        if (objCat)
                        {
                            dgvProveedor.Rows.RemoveAt(e.RowIndex);
                            MostarProveedor();
                        }
                        else MessageBox.Show("Error al eliminar ");

                    }
                }
            }
        }

        private void frmListProveedor_FormClosed(object sender, FormClosedEventArgs e)
        {
            _myFormListProv = null;
        }
    }
}

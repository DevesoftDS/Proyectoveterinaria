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
    public partial class frmListPresentacion : Form
    {
        NPresentacion objNP = new NPresentacion();
        public frmListPresentacion()
        {
            InitializeComponent();
            if (_myFormlistP == null)
            {
                _myFormlistP = this;
            }
        }

        private static frmListPresentacion _myFormlistP;

        public static frmListPresentacion MyFormlistP
        {
            get
            {
                if (_myFormlistP == null)
                {
                    _myFormlistP = new frmListPresentacion();
                }
                return _myFormlistP;
            }

            set
            {
                _myFormlistP = value;
            }
        }

        private void btnNuevoPresentacion_Click(object sender, EventArgs e)
        {
            new frmPresentacion().ShowDialog();
            this.dgvPresentacion.Refresh();
        }

        private void frmListPresentacion_Load(object sender, EventArgs e)
        {
            MostrarPresentacion();
            estiloDgv();

            dgvPresentacion.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvPresentacion.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvPresentacion.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;

            dgvPresentacion.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPresentacion.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPresentacion.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvPresentacion.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
        }

        private void estiloDgv()
        {
            this.dgvPresentacion.DefaultCellStyle.Font = new Font("Arial", 9);
            this.dgvPresentacion.DefaultCellStyle.ForeColor = Color.Black;
            this.dgvPresentacion.DefaultCellStyle.BackColor = Color.White;
            this.dgvPresentacion.DefaultCellStyle.SelectionForeColor = Color.Black;
            this.dgvPresentacion.DefaultCellStyle.SelectionBackColor = Color.Orange;
        }

        private void MostrarPresentacion()
        {
            objNP.ListarDataGridViewPresentacion(dgvPresentacion);
        }

        private void frmListPresentacion_FormClosed(object sender, FormClosedEventArgs e)
        {
            _myFormlistP = null;
        }

        private void txtBuscarPresentacion_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscarPresentacion.Text.Trim().Length > 0)
            {
                objNP.BuscarPresentacionPorNombre(dgvPresentacion, txtBuscarPresentacion.Text.Trim());
            }
            else
                MostrarPresentacion();
        }

        private void dgvPresentacion_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataTable tabla = new DataTable();


                if (dgvPresentacion.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Equals("Editar"))
                {
                    int idpresentacion = Convert.ToInt32(dgvPresentacion.Rows[e.RowIndex].Cells[5].Value);
                    tabla = NPresentacion.BuscarCodigo(idpresentacion);
                    new frmPresentacion().Show();
                    int numFilas = tabla.Rows.Count;
                    if (numFilas == 1)
                    {
                        frmPresentacion.MyFormPresentation.txtNombre.Text = tabla.Rows[0]["nombre"].ToString();
                        frmPresentacion.MyFormPresentation.txtDescripcion.Text = tabla.Rows[0]["Descripcion"].ToString();
                        frmPresentacion.MyFormPresentation.idPresentacion = int.Parse(tabla.Rows[0]["idpresentacion"].ToString());
                        frmPresentacion.MyFormPresentation.isNew = false;
                    }
                }
                if (dgvPresentacion.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Equals("Eliminar"))
                {
                    int idpresentacion = Convert.ToInt32(dgvPresentacion.Rows[e.RowIndex].Cells[5].Value);
                    DialogResult rspta = MessageBox.Show("Desea Eliminar", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (DialogResult.Yes == rspta)
                    {
                        //var empleado = new Clases.Empleado(id_personal);
                        bool objPres = NPresentacion.Eliminar(idpresentacion);
                        if (objPres)
                        {
                            dgvPresentacion.Rows.RemoveAt(e.RowIndex);
                            MostrarPresentacion();
                        }
                        else MessageBox.Show("Error al eliminar ");

                    }
                }
            }
        }
    }
}

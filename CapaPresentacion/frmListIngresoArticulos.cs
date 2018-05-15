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
    public partial class frmListIngresoArticulos : Form
    {

        NIngresoArticulo objNIA = new NIngresoArticulo();

        public frmListIngresoArticulos()
        {
            InitializeComponent();
            if (_myFormListIngreso == null)
                _myFormListIngreso = this;
        }
        private static frmListIngresoArticulos _myFormListIngreso;

        public static frmListIngresoArticulos MyFormListIngreso
        {
            get
            {
                if (_myFormListIngreso == null)
                {
                    _myFormListIngreso = new frmListIngresoArticulos();
                }
                return _myFormListIngreso;
            }

            set
            {
                _myFormListIngreso = value;
            }
        }

        private void btnNuevoIngresoArticulo_Click(object sender, EventArgs e)
        {
            frmIngresoArticulos frmIngArticulo = new frmIngresoArticulos();
            frmIngArticulo.ShowDialog();
        }

        private void estiloDgv()
        {
            this.dgvIngresoArt.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            this.dgvIngresoArt.DefaultCellStyle.ForeColor = Color.Black;
            this.dgvIngresoArt.DefaultCellStyle.BackColor = Color.White;
            this.dgvIngresoArt.DefaultCellStyle.SelectionForeColor = Color.Black;
            this.dgvIngresoArt.DefaultCellStyle.SelectionBackColor = Color.Orange;
            this.dgvIngresoArt.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);

        }

        private void frmListIngresoArticulos_Load(object sender, EventArgs e)
        {
            MostrarIngreso();
            estiloDgv();

            dgvIngresoArt.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvIngresoArt.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvIngresoArt.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvIngresoArt.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;


            dgvIngresoArt.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvIngresoArt.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvIngresoArt.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvIngresoArt.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            

        }

        private void MostrarIngreso()
        {
            objNIA.ListarDataGridViewIngresoArticulos(dgvIngresoArt);
        }

        private void txtBuscarIngreso_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                //here code
                objNIA.ListarIngresoPorNumeroIngreso(dgvIngresoArt, txtBuscarIngreso.Text.Trim());
            }
            else
                MostrarIngreso();
            
        }

        private void dgvIngresoArt_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataTable tabla = new DataTable();


                if (dgvIngresoArt.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Equals("VER"))
                {
                    int idingreso = Convert.ToInt32(dgvIngresoArt.Rows[e.RowIndex].Cells[8].Value);
                    tabla = NIngresoArticulo.BuscarCodigo(idingreso);

                    //MessageBox.Show(idingreso.ToString());
                    new frmIngresoArticulos().Show();
                    int numFilas = tabla.Rows.Count;
                    if (numFilas > 0)
                    {
                        frmIngresoArticulos.MyformIngresoArt.cboProveedor.SelectedValue = tabla.Rows[0]["idproveedor"].ToString();
                        frmIngresoArticulos.MyformIngresoArt.cboComprobante.Text = tabla.Rows[0]["comprobante"].ToString();
                        frmIngresoArticulos.MyformIngresoArt.txtNumIngreso.Text = tabla.Rows[0]["numingreso"].ToString();
                        frmIngresoArticulos.MyformIngresoArt.txtImpuesto.Text = tabla.Rows[0]["impuesto"].ToString();
                        frmIngresoArticulos.MyformIngresoArt.txtTotal.Text = dgvIngresoArt.Rows[e.RowIndex].Cells[5].Value.ToString();
                        frmIngresoArticulos.MyformIngresoArt._isNew = false;
                        for (int i = 0; i < numFilas; i++)
                        {
                            string articulo = tabla.Rows[i]["articulo"].ToString();
                            string p_venta = tabla.Rows[i]["precioventa"].ToString();
                            string p_compra = tabla.Rows[i]["preciocompra"].ToString();
                            string cantidad = tabla.Rows[i]["stockactual"].ToString();
                            DateTime f_produccion = Convert.ToDateTime(tabla.Rows[i]["fechaproduccion"].ToString());
                            DateTime f_venc = Convert.ToDateTime(tabla.Rows[i]["fechavencimiento"].ToString());

                            frmIngresoArticulos.MyformIngresoArt.dgvIngresoArticulo.Rows.Add(
                                i + 1, articulo, p_venta, p_compra, cantidad, f_produccion.ToString("dd/MM/yyyy"), f_venc.ToString("dd/MM/yyyy")
                                );
                        }
                        frmIngresoArticulos.MyformIngresoArt.habilitar(true);
                        //frmIngresoArticulos.MyformIngresoArt.txtNumIngreso.ReadOnly = true;
                        //frmIngresoArticulos.MyformIngresoArt.txtImpuesto.ReadOnly = true;
                        //frmIngresoArticulos.MyformIngresoArt.dgvIngresoArticulo.Enabled = false;
                        //frmIngresoArticulos.MyformIngresoArt.btnGuardar.Enabled = false;

                    }
                }
                if (dgvIngresoArt.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Equals("ANULAR"))
                {
                    
                    try
                    {
                        int estado =0;
                        int idingreso = Convert.ToInt32(dgvIngresoArt.Rows[e.RowIndex].Cells[8].Value);
                        DialogResult rspta = MessageBox.Show("Desea anular este ingreso", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                        if (DialogResult.Yes == rspta)
                        {
                            //var empleado = new Clases.Empleado(id_personal);
                            bool rpta2 = NIngresoArticulo.ActualizarEstado(
                                estado, 
                                idingreso
                                );

                            
                            MessageBox.Show("Ingreso anulado correctamente", "Sistema veterinaria", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dgvIngresoArt.Rows.Clear();
                            MostrarIngreso();

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error ...!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        throw;
                    }
                    
                }
            }
        }
    }
}

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
    public partial class frmIngresoArticulos : Form
    {
        NIngresoArticulo objNIA = new NIngresoArticulo();
        NProveedor objNP = new NProveedor();

        //public int idProveedor = 1;
        public int IdUsuario = 1;
        public int IdArticulo = 2;

        public int IdIngresoArticulo = 0;

        public bool _isNew = true;

        
        public frmIngresoArticulos()
        {
            InitializeComponent();
            ProveedorCBO();
            LLenarComprobanteCBO();
            cboComprobante.SelectedIndex = 0;
            estiloDgv();
        }

        private void estiloDgv()
        {
            this.dgvIngresoArticulo.DefaultCellStyle.Font = new Font("Arial", 9);
            this.dgvIngresoArticulo.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
            this.dgvIngresoArticulo.DefaultCellStyle.ForeColor = Color.Black;
            this.dgvIngresoArticulo.DefaultCellStyle.BackColor = Color.White;
            this.dgvIngresoArticulo.DefaultCellStyle.SelectionForeColor = Color.Black;
            this.dgvIngresoArticulo.DefaultCellStyle.SelectionBackColor = Color.Orange;
        }

        public void ProveedorCBO()
        {
            DataTable tabla = NProveedor.Listar();
            int numFilas = tabla.Rows.Count;
            if (numFilas > 0)
            {
                cboProveedor.DataSource = tabla;
                cboProveedor.DisplayMember = "razonsocial";
                cboProveedor.ValueMember = "idproveedor";
            }
        }

        public void LLenarComprobanteCBO()
        {
            cboComprobante.Items.Add("Factura");
            cboComprobante.Items.Add("Boleta");
            cboComprobante.Items.Add("Otro");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int ultimoid = 0;
            if (_isNew)
            {
                ultimoid = NIngresoArticulo.Insertar(
                    txtNumIngreso.Text,
                    Convert.ToDecimal(txtImpuesto.Text),
                    Convert.ToInt32(cboProveedor.SelectedValue),
                    IdUsuario
                    );

                //MessageBox.Show(IdIngresoArticulo.ToString());
                if (IdIngresoArticulo == 1)
                {
                    int numFilas = dgvIngresoArticulo.Rows.Count;
                    for (int i = 0; i < numFilas; i++)
                    {
                        int id_ingreso = ultimoid;
                        int id_articulo = Convert.ToInt32(dgvIngresoArticulo.Rows[i].Cells[8].Value.ToString());
                        decimal precio_compra = Convert.ToDecimal(dgvIngresoArticulo.Rows[i].Cells[2].Value.ToString());
                        decimal precio_venta = Convert.ToDecimal(dgvIngresoArticulo.Rows[i].Cells[3].Value.ToString());
                        int stock_inicial = Convert.ToInt32(dgvIngresoArticulo.Rows[i].Cells[4].Value.ToString());
                        int stock_actual = Convert.ToInt32(dgvIngresoArticulo.Rows[i].Cells[4].Value.ToString());
                        DateTime fecha_produccion = Convert.ToDateTime(dgvIngresoArticulo.Rows[i].Cells[5].Value.ToString());
                        DateTime fecha_vencimiento = Convert.ToDateTime(dgvIngresoArticulo.Rows[i].Cells[6].Value.ToString());

                        bool rpta = NDetalleIngresoArticulo.Insertar(
                            id_ingreso, id_articulo, precio_compra, precio_venta, stock_inicial, stock_actual, fecha_produccion, fecha_vencimiento
                            );
                        if (!rpta)
                        {
                            MessageBox.Show("Error al registrar detalle");
                        }

                    }
                }
                MessageBox.Show("Ingreso registrado correctamente");
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtArticulo.Text))
            {
                epIngreso.SetError(btnBuscarArticulo, "Busque el articulo que desea ingresar al almcen");
            }
            else if (string.IsNullOrEmpty(txtCantidad.Text))
            {
                txtCantidad.Focus();
                epIngreso.SetError(txtCantidad, "Ingrese la cantidad ingreso de articulo");
            }
            else if (string.IsNullOrEmpty(txtPrecioCompra.Text))
            {
                txtPrecioCompra.Focus();
                epIngreso.SetError(txtPrecioCompra, "Ingrese el precio de compra del articulo");
            }
            else if (string.IsNullOrEmpty(txtPrecioVenta.Text))
            {
                txtPrecioVenta.Focus();
                epIngreso.SetError(txtPrecioVenta, "Ingrese el precio de venta del articulo");
            }
            else
            {
                int num_filas = dgvIngresoArticulo.Rows.Count;
                if (num_filas == 0)
                {
                    epIngreso.Clear();
                    agregarArticuloIngreso();

                }
                else
                {
                    bool existe = false;
                    int id_articulo = IdArticulo;
                    for (int i = 0; i < num_filas; i++)
                    {
                        if (id_articulo.Equals(dgvIngresoArticulo.Rows[i].Cells[8].Value))
                        {
                            existe = true;
                            break;
                        }
                    }
                    if (existe)
                    {
                        MessageBox.Show("Articulo ya agregado a la grilla");
                    }
                    else
                    {
                        agregarArticuloIngreso();
                    }
                }
            }

            decimal total = 0;
            for (int i = 0; i < dgvIngresoArticulo.Rows.Count; i++)
            {
                total += Convert.ToDecimal(dgvIngresoArticulo.Rows[i].Cells[7].Value.ToString());
            }
            txtTotal.Text = total.ToString();
            
        }

        private void agregarArticuloIngreso()
        {
            int num_filas = dgvIngresoArticulo.Rows.Count;
            string articulo = txtArticulo.Text.Trim();
            decimal p_compra = Convert.ToInt32(txtPrecioCompra.Text.Trim());
            decimal p_venta = Convert.ToInt32(txtPrecioVenta.Text.Trim());
            int cantidad = Convert.ToInt32(txtCantidad.Text.Trim());
            DateTime f_produccion = Convert.ToDateTime(dtpFechaProduccion.Value);
            DateTime f_vencimiento = Convert.ToDateTime(dtpFechaProduccion.Value);
            int id_articulo = IdArticulo;

            dgvIngresoArticulo.Rows.Add(
                num_filas + 1, articulo, p_compra, p_venta, cantidad, f_produccion.ToString("dd/MM/yyyy"), f_vencimiento.ToString("dd/MM/yyyy"), "", id_articulo
                );

            decimal importe;

            importe = Convert.ToDecimal(dgvIngresoArticulo.Rows[num_filas].Cells[2].Value) * Convert.ToDecimal(dgvIngresoArticulo.Rows[num_filas].Cells[4].Value);
            dgvIngresoArticulo.Rows[num_filas].Cells[7].Value = importe;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            MessageBox.Show(IdIngresoArticulo.ToString());
        }

        private void frmIngresoArticulos_Load(object sender, EventArgs e)
        {
            dgvIngresoArticulo.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvIngresoArticulo.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvIngresoArticulo.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvIngresoArticulo.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;

            dgvIngresoArticulo.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvIngresoArticulo.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvIngresoArticulo.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvIngresoArticulo.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
    }
}

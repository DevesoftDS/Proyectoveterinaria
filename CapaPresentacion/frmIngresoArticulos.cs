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
using System.Security.Permissions;
using System.Runtime.InteropServices;

namespace CapaPresentacion
{
    public partial class frmIngresoArticulos : Form
    {
        NIngresoArticulo objNIA = new NIngresoArticulo();
        NProveedor objNP = new NProveedor();

        //public int idProveedor = 1;
        public int IdUsuario = 1;
        public int IdArticulo = 0;

        public int IdIngresoArticulo = 0;

        public bool _isNew = true;

        
        public frmIngresoArticulos()
        {
            InitializeComponent();
            if (_myformIngresoArt == null)
                _myformIngresoArt = this;
            ProveedorCBO();
            LLenarComprobanteCBO();
            cboComprobante.SelectedIndex = 0;
            estiloDgv();
        }

        private static frmIngresoArticulos _myformIngresoArt;

        public static frmIngresoArticulos MyformIngresoArt
        {
            get
            {
                if (_myformIngresoArt == null)
                {
                    _myformIngresoArt = new frmIngresoArticulos();
                }
                return _myformIngresoArt;
            }

            set
            {
                _myformIngresoArt = value;
            }
        }

        #region shadown
        private const int CS_DROPSHADOW = 0x00020000;
        protected override CreateParams CreateParams
        {
            [SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode = true)]
            get
            {
                CreateParams parameters = base.CreateParams;

                if (DropShadowSupported)
                {
                    parameters.ClassStyle = (parameters.ClassStyle | CS_DROPSHADOW);
                }

                return parameters;
            }
        }

        /// <summary>
        /// Gets indicator if drop shadow is supported
        /// </summary>
        public static bool DropShadowSupported
        {
            get
            {
                OperatingSystem system = Environment.OSVersion;
                bool runningNT = system.Platform == PlatformID.Win32NT;

                return runningNT && system.Version.CompareTo(new Version(5, 1, 0, 0)) >= 0;
            }
        }

       
        #endregion

        #region movefrm
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int Wparam, int lParam);
        #endregion

        private void estiloDgv()
        {
            this.dgvIngresoArticulo.DefaultCellStyle.Font = new Font("Arial", 9);
            this.dgvIngresoArticulo.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
            this.dgvIngresoArticulo.DefaultCellStyle.ForeColor = Color.Black;
            this.dgvIngresoArticulo.DefaultCellStyle.BackColor = Color.White;
            this.dgvIngresoArticulo.DefaultCellStyle.SelectionForeColor = Color.Black;
            this.dgvIngresoArticulo.DefaultCellStyle.SelectionBackColor = Color.Orange;
        }

        public void habilitar(bool estado)
        {
            txtNumIngreso.ReadOnly = estado;
            txtImpuesto.ReadOnly = estado;
            dgvIngresoArticulo.Enabled = !estado;
            MyformIngresoArt.btnGuardar.Enabled = !estado;
        }

        // mostrar mensaje de confirmacion
        private void mensajeYes(string msn)
        {
            MessageBox.Show(msn, "Sistema veterinario", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        public void LimpiarIngreso()
        {
            txtNumIngreso.Text = string.Empty;
            cboProveedor.SelectedIndex = 0;
            cboComprobante.SelectedIndex = 0;
            txtImpuesto.Text = string.Empty;
            dgvIngresoArticulo.Rows.Clear();
            epIngreso.Clear();
            txtTotal.Text = string.Empty;

        }
        public void LimpiarDetalleIngreso()
        {
            txtArticulo.Text = string.Empty;
            txtCategoria.Text = string.Empty;
            txtNeto.Text = string.Empty;
            txtPresentacion.Text = string.Empty;
            txtCantidad.Text = string.Empty;
            txtPrecioCompra.Text = string.Empty;
            txtPrecioVenta.Text = string.Empty;
            IdArticulo = 0;
            epIngreso.Clear();
            txtCantidad.Focus();
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
            if (string.IsNullOrEmpty(txtNumIngreso.Text))
            {
                txtNumIngreso.Focus();
                epIngreso.SetError(txtNumIngreso, "Campo obligatorio - ingrese el numero de comprobante");
            }
            else if (dgvIngresoArticulo.Rows.Count == 0)
            {
                epIngreso.SetError(btnBuscarArticulo, "Agregue al menos un articulo para registrar");
            }
            else
            {
                if (_isNew)
                {
                    ultimoid = NIngresoArticulo.Insertar(
                        cboComprobante.Text,
                        txtNumIngreso.Text.Trim(),
                        txtImpuesto.Text.Trim(),
                        Convert.ToInt32(cboProveedor.SelectedValue),
                        IdUsuario
                        );
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
                    mensajeYes("Ingreso insertado correctamente a la base de datos");
                    LimpiarIngreso();
                    objNIA.ListarDataGridViewIngresoArticulos(frmListIngresoArticulos.MyFormListIngreso.dgvIngresoArt);
                    string codigo = NIngresoArticulo.GenerarCodigoIngreso();
                    txtNumIngreso.Text = codigo;
                }
            }
            
        }
        public static decimal total = 0;

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
                    LimpiarDetalleIngreso();

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
                        LimpiarDetalleIngreso();
                    }
                }
            }

            total = 0;
            for (int i = 0; i < dgvIngresoArticulo.Rows.Count; i++)
            {
                total += Convert.ToDecimal(dgvIngresoArticulo.Rows[i].Cells[7].Value.ToString());
            }
            txtTotal.Text = total.ToString();
            
        }

        private void agregarArticuloIngreso()
        {
            int num_filas = dgvIngresoArticulo.Rows.Count;
            string articulo = txtArticulo.Text.Trim()+" - " + txtCategoria.Text.Trim() + " - " + txtNeto.Text.Trim() + " " + txtPresentacion.Text.Trim();
            decimal p_compra = Convert.ToDecimal(txtPrecioCompra.Text.Trim());
            decimal p_venta = Convert.ToDecimal(txtPrecioVenta.Text.Trim());
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
            LimpiarIngreso();
            LimpiarDetalleIngreso();
            _isNew = true;
            txtNumIngreso.Focus();
            habilitar(false);

        }

        private void frmIngresoArticulos_Load(object sender, EventArgs e)
        {
            string codigo = NIngresoArticulo.GenerarCodigoIngreso();
            txtNumIngreso.Text = codigo;

            dgvIngresoArticulo.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvIngresoArticulo.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvIngresoArticulo.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvIngresoArticulo.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;

            dgvIngresoArticulo.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvIngresoArticulo.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvIngresoArticulo.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvIngresoArticulo.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void btnBuscarArticulo_Click(object sender, EventArgs e)
        {
            new FrmListadoArticulo().ShowDialog();
            epIngreso.Clear();
        }

        private void btnNewProveedor_Click(object sender, EventArgs e)
        {
            new frmProveedor().ShowDialog();
        }

        private void pBarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void frmIngresoArticulos_FormClosed(object sender, FormClosedEventArgs e)
        {
            _myformIngresoArt = null;
        }

        private void txtNumIngreso_TextChanged(object sender, EventArgs e)
        {
            epIngreso.Clear();
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            epIngreso.Clear();
        }

        private void txtPrecioCompra_TextChanged(object sender, EventArgs e)
        {
            epIngreso.Clear();
        }

        private void txtPrecioVenta_TextChanged(object sender, EventArgs e)
        {
            epIngreso.Clear();
        }

        
        private void btnQuitar_Click(object sender, EventArgs e)
        {
            int num_filas = dgvIngresoArticulo.Rows.Count;
            if (num_filas > 0)
            {
                total = total -(Convert.ToDecimal(dgvIngresoArticulo.Rows[dgvIngresoArticulo.CurrentRow.Index].Cells[7].Value));
                dgvIngresoArticulo.Rows.RemoveAt(dgvIngresoArticulo.CurrentRow.Index);
                txtTotal.Text = total.ToString();

            }
            else
            {
                MessageBox.Show("No hay producto ingresado para poder quitar", "Error ???", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        private static void OnlyNumber(KeyPressEventArgs e, bool isdecimal)
        {
            string aceptados;
            if (!isdecimal)
            {
                aceptados = "0123456789," + Convert.ToChar(8);
            }
            else
                aceptados = "0123456789." + Convert.ToChar(8);

            if (aceptados.Contains("" + e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtPrecioCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyNumber(e, false);
        }

        private void txtPrecioVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyNumber(e, false);
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void dgvIngresoArticulo_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int num_filas = dgvIngresoArticulo.Rows.Count;
            if (num_filas > 0)
            {
                for (int i = 0; i < num_filas; i++)
                {
                    decimal subTotal;
                    subTotal = Convert.ToDecimal(dgvIngresoArticulo.Rows[i].Cells[2].Value) * Convert.ToDecimal(dgvIngresoArticulo.Rows[i].Cells[4].Value);
                    dgvIngresoArticulo.Rows[i].Cells[7].Value = subTotal;

                }
            }

            total = 0;
            for (int i = 0; i < dgvIngresoArticulo.Rows.Count; i++)
            {
                total += Convert.ToDecimal(dgvIngresoArticulo.Rows[i].Cells[7].Value.ToString());
            }
            txtTotal.Text = total.ToString();
        }
    }
}

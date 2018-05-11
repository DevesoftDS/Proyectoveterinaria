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
    public partial class frmVenta : Form
    {
        NCliente objNC = new NCliente();
        NVenta objNV = new NVenta();

        public int IdVenta { get; set; }

        public bool _isNew = true;
        //public int idArticulo = 0;
        public int idCliente = 0;
        public int idDAIngreso = 0;
        public int idUsuario = 0;

        public frmVenta()
        {
            InitializeComponent();
            LlenarComboComprobante();
            cboComprobante.SelectedIndex = 1;
            if (_myFormVenta == null)
            {
                _myFormVenta = this;
            }
        }

        public void LlenarComboComprobante()
        {
            cboComprobante.Items.Add("Factura");
            cboComprobante.Items.Add("Boleta");
            cboComprobante.Items.Add("Ticket");
            cboComprobante.Items.Add("Otro");
        }

        private static frmVenta _myFormVenta;

        public static frmVenta MyFormVenta
        {
            get
            {
                if (_myFormVenta == null)
                {
                    _myFormVenta = new frmVenta();
                }
                return _myFormVenta;
            }

            set
            {
                _myFormVenta = value;
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
        // mostrar mensaje de confirmacion
        private void mensajeYes(string msn)
        {
            MessageBox.Show(msn, "Sistema veterinario", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void LimpiarVenta()
        {
            txtDocumento.Text = string.Empty;
            txtCliente.Text = string.Empty;
            txtRazonSocial.Text = string.Empty;
            txtRuc.Text = string.Empty;
            txtSerie.Text = "0023";
            txtCorrelativo.Text = "0000234";
            cboComprobante.SelectedIndex = 1;
            txtSubTotal.Text = string.Empty;
            txtIGV.Text = string.Empty;
            txtTotal.Text = string.Empty;

            dgvDetalleventa.Rows.Clear();
            idCliente = 0;
            txtDocumento.Focus();
        }

        public void LimpiarDetalleVenta()
        {
            txtArticulo.Text = string.Empty;
            txtPrecio.Text = string.Empty;
            txtStock.Text = string.Empty;
            txtCantidad.Text = string.Empty;
            txtDescuento.Text = "0,00";

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            new frmCliente().ShowDialog();
        }
        private void estiloDgv()
        {
            this.dgvDetalleventa.DefaultCellStyle.Font = new Font("Arial", 9);
            this.dgvDetalleventa.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
            this.dgvDetalleventa.DefaultCellStyle.ForeColor = Color.Black;
            this.dgvDetalleventa.DefaultCellStyle.BackColor = Color.White;
            this.dgvDetalleventa.DefaultCellStyle.SelectionForeColor = Color.Black;
            this.dgvDetalleventa.DefaultCellStyle.SelectionBackColor = Color.Orange;
        }
        private void frmVenta_Load(object sender, EventArgs e)
        {
            estiloDgv();
            dgvDetalleventa.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvDetalleventa.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvDetalleventa.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvDetalleventa.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvDetalleventa.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;

            dgvDetalleventa.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetalleventa.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetalleventa.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetalleventa.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetalleventa.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void btnBuscarArticulo_Click(object sender, EventArgs e)
        {
            new FrmListadoArticuloIngreso().ShowDialog();
            epVenta.Clear();
        }

        public static decimal total = 0;
        public static decimal subtotal = 0;
        public static decimal igv = 0;

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtArticulo.Text) && string.IsNullOrEmpty(txtPrecio.Text) && string.IsNullOrEmpty(txtStock.Text))
            {
                epVenta.SetError(btnBuscarArticulo, "Busque articulos que se va vender");
            }
            else if (string.IsNullOrEmpty(txtCantidad.Text))
            {
                txtCantidad.Focus();
                epVenta.SetError(txtCantidad, "Campo obligatorio  - ingrese la cantidad que se va vender");
            }
            else if (string.IsNullOrEmpty(txtDescuento.Text))
            {
                txtDescuento.Focus();
                epVenta.SetError(txtDescuento, "Campo obligatorio  - si no hay descuento ponga solo (0,00)");
            }
            else
            {
                int numFilas = dgvDetalleventa.Rows.Count;
                if (numFilas == 0)
                {
                    AgregarArticuloDetalleVenta();
                    LimpiarDetalleVenta();
                }
                else
                {
                    bool existe = false;
                    int iddingresoarticulo = idDAIngreso;

                    for (int i = 0; i < numFilas; i++)
                    {
                        if (iddingresoarticulo.Equals(dgvDetalleventa.Rows[i].Cells[7].Value))
                        {
                            existe = true;
                            break;
                        }
                    }
                    if (existe)
                    {
                        MessageBox.Show("Este articulo ya fue agregado", "Sistema veterinario", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                    else
                    {
                        AgregarArticuloDetalleVenta();
                        LimpiarDetalleVenta();
                    }
                }
            }
            subtotal = 0;
            igv = 0;
            total = 0;
            
            for (int i = 0; i < dgvDetalleventa.Rows.Count; i++)
            {
                total += Convert.ToDecimal(dgvDetalleventa.Rows[i].Cells[6].Value.ToString());
            }

            txtTotal.Text = total.ToString();
            
            igv = Convert.ToDecimal(txtTotal.Text) * 18/100;
            txtIGV.Text = igv.ToString();
            
            subtotal = total - Convert.ToDecimal(txtIGV.Text);
            txtSubTotal.Text = subtotal.ToString();

        }

        private void AgregarArticuloDetalleVenta()
        {
            int num_filas = dgvDetalleventa.Rows.Count;

            string articulo = txtArticulo.Text.Trim();
            int cantidad = Convert.ToInt32(txtCantidad.Text.Trim());
            decimal precio = Convert.ToDecimal(txtPrecio.Text.Trim());
            decimal descuento = Convert.ToDecimal(txtDescuento.Text.Trim());
            string f_vencimiento = txtFvencimiento.Text.Trim();
            int iddingresoarticulo = idDAIngreso;

            dgvDetalleventa.Rows.Add(
                num_filas + 1, articulo, cantidad, precio, descuento, f_vencimiento, "", iddingresoarticulo
                );
            decimal importe;

            importe = Convert.ToDecimal(dgvDetalleventa.Rows[num_filas].Cells[2].Value) * Convert.ToDecimal(dgvDetalleventa.Rows[num_filas].Cells[3].Value) - Convert.ToDecimal(dgvDetalleventa.Rows[num_filas].Cells[4].Value);
            dgvDetalleventa.Rows[num_filas].Cells[6].Value = importe;
        }

        private void txtDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                DataTable tabla = NCliente.BuscarClienteDNI(txtDocumento.Text.Trim());
                if (tabla.Rows.Count != 0)
                {
                    txtCliente.Text = tabla.Rows[0]["nombres"].ToString() + " " + tabla.Rows[0]["Apellidos"].ToString();
                    idCliente = Convert.ToInt32(tabla.Rows[0]["idcliente"].ToString());
                }
                else
                    MessageBox.Show("Error cliente no existe en la BD", "Error...!!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            //MessageBox.Show("Error cliente no existe en la BD", "Error...!!", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }

        private void cboComprobante_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboComprobante.Text.Equals("Factura"))
            {
                lblRazonSocial.Visible = true;
                lblRuc.Visible = true;
                txtRazonSocial.Visible = true;
                txtRuc.Visible = true;
            }
            else
            {
                lblRazonSocial.Visible = false;
                lblRuc.Visible = false;
                txtRazonSocial.Visible = false;
                txtRuc.Visible = false;
            }
        }

        private void frmVenta_FormClosed(object sender, FormClosedEventArgs e)
        {
            _myFormVenta = null;
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            epVenta.Clear();
        }

        private void txtDescuento_TextChanged(object sender, EventArgs e)
        {
            epVenta.Clear();
        }

        private void txtDocumento_TextChanged(object sender, EventArgs e)
        {
            epVenta.Clear();
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            int num_filas = dgvDetalleventa.Rows.Count;
            if (num_filas > 0)
            {
                total = total - (Convert.ToDecimal(dgvDetalleventa.Rows[dgvDetalleventa.CurrentRow.Index].Cells[6].Value));
                dgvDetalleventa.Rows.RemoveAt(dgvDetalleventa.CurrentRow.Index);
                txtTotal.Text = total.ToString();

                igv = Convert.ToDecimal(txtTotal.Text) * 18 / 100;
                txtIGV.Text = igv.ToString();

                subtotal = total - Convert.ToDecimal(txtIGV.Text);
                txtSubTotal.Text = subtotal.ToString();

            }
            else
            {
                MessageBox.Show("No hay producto ingresado para poder quitar", "Error ???", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        private void dgvDetalleventa_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int num_filas = dgvDetalleventa.Rows.Count;
            if (num_filas > 0)
            {
                for (int i = 0; i < num_filas; i++)
                {
                    decimal subTotal;
                    subTotal = Convert.ToDecimal(dgvDetalleventa.Rows[i].Cells[2].Value) * Convert.ToDecimal(dgvDetalleventa.Rows[i].Cells[3].Value) - Convert.ToDecimal(dgvDetalleventa.Rows[i].Cells[4].Value);
                    dgvDetalleventa.Rows[i].Cells[6].Value = subTotal;

                }
            }

            total = 0;
            for (int i = 0; i < dgvDetalleventa.Rows.Count; i++)
            {
                total += Convert.ToDecimal(dgvDetalleventa.Rows[i].Cells[6].Value.ToString());
            }
            txtTotal.Text = total.ToString();

            igv = Convert.ToDecimal(txtTotal.Text) * 18 / 100;
            txtIGV.Text = igv.ToString();

            subtotal = total - Convert.ToDecimal(txtIGV.Text);
            txtSubTotal.Text = subtotal.ToString();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtSerie.Text) && string.IsNullOrEmpty(txtCorrelativo.Text))
                {
                    epVenta.SetError(txtSerie, "verifica el numero de serie - para poder hacer la venta");
                    epVenta.SetError(txtCorrelativo, "verifica el numero de correlativo - para poder hacer la venta");
                }
                else if (string.IsNullOrEmpty(txtDocumento.Text) && string.IsNullOrEmpty(txtCliente.Text))
                {
                    epVenta.SetError(btnNuevoCliente, "Buscar cliente por DNI, O agregar nuevo cliente");
                }
                else if (dgvDetalleventa.Rows.Count == 0)
                {
                    epVenta.SetError(btnBuscarArticulo, "Ingrese al menos un producto para poder hacer la venta");
                }
                else
                {
                    if (_isNew)
                    {
                        int ultimo_id = NVenta.Insertar(
                            cboComprobante.SelectedIndex, cboComprobante.Text, txtSerie.Text.Trim(), txtCorrelativo.Text.Trim(),
                            idCliente, txtRazonSocial.Text.Trim(), txtRuc.Text.Trim(),
                            Convert.ToDecimal(txtSubTotal.Text.Trim()), Convert.ToDecimal(txtIGV.Text.Trim()), Convert.ToDecimal(txtTotal.Text.Trim()), idUsuario
                            );
                        int numFilas = dgvDetalleventa.Rows.Count;
                        for (int i = 0; i < numFilas; i++)
                        {
                            int idventa = ultimo_id;
                            int iddia = Convert.ToInt32(dgvDetalleventa.Rows[i].Cells[7].Value.ToString());
                            int cantidad = Convert.ToInt32(dgvDetalleventa.Rows[i].Cells[2].Value.ToString());
                            decimal precio = Convert.ToDecimal(dgvDetalleventa.Rows[i].Cells[3].Value.ToString());
                            decimal descuento = Convert.ToDecimal(dgvDetalleventa.Rows[i].Cells[4].Value.ToString());

                            bool rpta = NDetalleVenta.Insertar(
                                idventa, iddia, cantidad, precio, descuento
                                );
                        }
                        mensajeYes("Venta registrado correctamente");
                        LimpiarVenta();
                        objNV.ListarDataGridViewVenta(frmListVenta.MyFormListVenta.dgvVenta);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error ....!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
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

        private void txtSerie_Click(object sender, EventArgs e)
        {
            epVenta.Clear();
        }

        private void txtCorrelativo_Click(object sender, EventArgs e)
        {
            epVenta.Clear();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}

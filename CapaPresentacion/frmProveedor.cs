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
using System.Globalization;
using System.Runtime.InteropServices;
using System.Security.Permissions;

namespace CapaPresentacion
{
    public partial class frmProveedor : Form
    {
        NProveedor objNP = new NProveedor();

        public int idProveedor = 0;

        public bool _isNew = true;


        public frmProveedor()
        {
            InitializeComponent();
            if (_myFormProv == null)
                _myFormProv = this;
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

        private static frmProveedor _myFormProv;

        public static frmProveedor MyFormProv
        {
            get
            {
                if (_myFormProv ==null)
                    _myFormProv = new frmProveedor();
                return _myFormProv;
            }

            set
            {
                _myFormProv = value;
            }
        }

        private void mensajeYes(string msn)
        {
            MessageBox.Show(msn, "Sistema veterinario", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void Limpiar()
        {
            txtRazonSocial.Text = string.Empty;
            cboTipoDoc.SelectedIndex = 1;
            txtNumDoc.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtCorreo.Text = string.Empty;
            txtDireccion.Text = string.Empty;
        }

        private void frmProveedor_Load(object sender, EventArgs e)
        {
            LLenarCombo();
            cboTipoDoc.SelectedIndex = 1;
        }
        public void LLenarCombo()
        {
            cboTipoDoc.Items.Add("DNI");
            cboTipoDoc.Items.Add("RUC");
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
            txtRazonSocial.Focus();
            _isNew = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtRazonSocial.Text))
                {
                    txtRazonSocial.Focus();
                    epProveedor.SetError(txtRazonSocial, "Campo obligatorio - ingrese razon social de su proveedor");
                }
                else if (string.IsNullOrEmpty(txtNumDoc.Text))
                {
                    txtNumDoc.Focus();
                    epProveedor.SetError(txtNumDoc, "Campo obligatorio - ingrese numero de RUC / DNI");
                }
                else if (string.IsNullOrEmpty(txtTelefono.Text))
                {
                    txtTelefono.Focus();
                    epProveedor.SetError(txtTelefono, "Campo obligatorio - ingrese numero de telèfono");
                }
                else
                {
                    if (_isNew)
                    {
                        bool rpta_add = NProveedor.Insertar(
                            txtRazonSocial.Text.Trim(),
                            cboTipoDoc.Text,
                            txtNumDoc.Text.Trim(),
                            txtTelefono.Text.Trim(),
                            txtCorreo.Text.Trim(),
                            txtDireccion.Text.Trim()
                            );
                        mensajeYes("Proveedor insertado correctamente");
                        Limpiar();
                        txtRazonSocial.Focus();
                        objNP.LIstarDataGridViewProveedor(frmListProveedor.MyFormListProv.dgvProveedor);
                        frmListProveedor.MyFormListProv.dgvProveedor.Refresh();
                    }
                    else
                    {
                        bool rpta_update = NProveedor.Actualizar(
                            txtRazonSocial.Text.Trim(),
                            cboTipoDoc.Text,
                            txtNumDoc.Text.Trim(),
                            txtTelefono.Text.Trim(),
                            txtCorreo.Text.Trim(),
                            txtDireccion.Text.Trim(),
                            idProveedor                            
                            );
                        mensajeYes("Proveedor actualizado correctamente");
                        Limpiar();
                        txtRazonSocial.Focus();
                        _isNew = true;
                        objNP.LIstarDataGridViewProveedor(frmListProveedor.MyFormListProv.dgvProveedor);
                        frmListProveedor.MyFormListProv.dgvProveedor.Refresh();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error ...... ???", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void frmProveedor_FormClosed(object sender, FormClosedEventArgs e)
        {
            _myFormProv = null;
        }

        private void txtNumDoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloNumeros(e);
        }

        private static void soloNumeros(KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
                e.Handled = false;
            //evalua si es un caracter 
            else if (Char.IsControl(e.KeyChar))
                e.Handled = false;
            //evalua si es un caracter separador 
            else if (Char.IsSeparator(e.KeyChar))
                e.Handled = false;

            else
                e.Handled = true;
        }

        private void txtRazonSocial_TextChanged(object sender, EventArgs e)
        {
            epProveedor.Clear();
        }

        private void txtNumDoc_TextChanged(object sender, EventArgs e)
        {
            epProveedor.Clear();
        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            epProveedor.Clear();
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloNumeros(e);
        }

        private void pBarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}

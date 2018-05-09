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
    public partial class frmUsuario : Form
    {
        public frmUsuario()
        {
            InitializeComponent();
            if (_miFormUsuario==null)
            {
                _miFormUsuario = this;
            }
        }
        #region interfaz
        private static frmUsuario _miFormUsuario;

        public static frmUsuario MiFormUsuario
        {
            get
            {
                if (_miFormUsuario==null)
                {
                    _miFormUsuario = new frmUsuario();
                }
                return _miFormUsuario;
            }

            set
            {
                _miFormUsuario = value;
            }
        }
        private void frmUsuario_FormClosed(object sender, FormClosedEventArgs e)
        {
            _miFormUsuario = null;
        }
        #endregion
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
        #region remove
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        #endregion
        public int _idUsuario = 0;
        public int _idEmpleado = 0;
        public bool _isNew = true;

        public void Limpiar()
        {
            _idEmpleado = 0;
            txtUsuario.Text = string.Empty;
            txtPassword.Text = string.Empty;
            cboTipo.SelectedIndex = 0;
            txtUsuario.Focus();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        
        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            epUsuario.Clear();
        }

        private void frmUsuario_Load(object sender, EventArgs e)
        {
            cboTipo.SelectedIndex = 0;
            txtPassword.UseSystemPasswordChar =true;
        }


        private void CrearCuentaUsuario()
        {
            string rpta = "";
            if (string.IsNullOrEmpty(txtUsuario.Text))
            {
                txtUsuario.Focus();
                epUsuario.SetError(txtUsuario, "Ingrese su usuario");

            }
            else if (string.IsNullOrEmpty(txtPassword.Text))
            {
                txtPassword.Focus();
                epUsuario.SetError(txtPassword, "Ingrese su password");

            }
            else
            {
                if (_idEmpleado != 0)
                {
                    rpta = NUsusario.CrearCuentaUsuario(
                    txtUsuario.Text.Trim(),
                    txtPassword.Text.Trim(),
                    cboTipo.SelectedItem.ToString().Trim(),
                    _idEmpleado
                    );
                    if (rpta == "Ok") MessageBox.Show(rpta + "--Se creó su cuenta");
                    else MessageBox.Show("Error");
                }
                else MessageBox.Show("Error");

            }
        }
        private void ActualizarCuenta()
        {
            string rpta = "";
            if (string.IsNullOrEmpty(txtUsuario.Text))
            {
                txtUsuario.Focus();
                epUsuario.SetError(txtUsuario, "Ingrese su usuario");

            }
            else if (string.IsNullOrEmpty(txtPassword.Text))
            {
                txtPassword.Focus();
                epUsuario.SetError(txtPassword, "Ingrese su password");

            }
            else
            {
                if (_idEmpleado != 0 && _idUsuario != 0)
                {
                    rpta = NUsusario.ActualizarCuenta(
                    _idUsuario,
                    txtUsuario.Text.Trim(),
                    txtPassword.Text.Trim(),
                    cboTipo.SelectedItem.ToString().Trim(),
                    _idEmpleado
                    );
                    if (rpta == "Ok") MessageBox.Show(rpta + "--Se actualizó su cuenta");
                    else MessageBox.Show("Error");
                }
                else MessageBox.Show("Error");

            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (_isNew)
            {
                CrearCuentaUsuario();
                NUsusario objUser = new NUsusario();
                objUser.ListadoDgv(frmListUsuario.MiFormLisUsuario.dgvUsuario);
                frmListUsuario.MiFormLisUsuario.dgvUsuario.Refresh();
                Limpiar();
            }
            else
            {
                ActualizarCuenta();
                NUsusario objUser = new NUsusario();
                objUser.ListadoDgv(frmListUsuario.MiFormLisUsuario.dgvUsuario);
                Limpiar();
                frmListUsuario.MiFormLisUsuario.dgvUsuario.Refresh();
            }

            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) txtPassword.UseSystemPasswordChar = false;
            else txtPassword.UseSystemPasswordChar = true;
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}

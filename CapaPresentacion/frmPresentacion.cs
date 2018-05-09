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
using System.Runtime.InteropServices;
using System.Security.Permissions;

namespace CapaPresentacion
{
    public partial class frmPresentacion : Form
    {
        NPresentacion objNP = new NPresentacion();

        public int idPresentacion = 0;

        public bool isNew = true;
        public frmPresentacion()
        {
            InitializeComponent();
            if (_myFormPresentation == null)
            {
                _myFormPresentation = this;
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

        private static frmPresentacion _myFormPresentation;

        public static frmPresentacion MyFormPresentation
        {
            get
            {
                if (_myFormPresentation == null)
                {
                    _myFormPresentation = new frmPresentacion();
                }
                return _myFormPresentation;
            }

            set
            {
                _myFormPresentation = value;
            }
        }


        private void mensajeYes(string msn)
        {
            MessageBox.Show(msn, "Sistema veterinario", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // metodo mostrar mensaje de error
        private void mensajeError(string msn)
        {
            MessageBox.Show(msn, "Sistema veterinario", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // metodo limpiar controles del formulario
        private void Limpiar()
        {
            this.txtNombre.Text = string.Empty;
            this.txtDescripcion.Text = string.Empty;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPresentacion_Load(object sender, EventArgs e)
        {

        }

        private void frmPresentacion_FormClosed(object sender, FormClosedEventArgs e)
        {
            _myFormPresentation = null;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtNombre.Text.Trim()))
                {
                    txtNombre.Focus();
                    epPresentation.SetError(txtNombre, "Campo obligatorio - ingrese nombre de la presentacion");
                }
                else
                {
                    if (isNew)
                    {
                        bool rpta = NPresentacion.Insertar(txtNombre.Text.Trim(), txtDescripcion.Text.Trim());
                        mensajeYes("Presentacion insertado correctamente (O_O)");
                        Limpiar();
                        txtNombre.Focus();
                        objNP.ListarDataGridViewPresentacion(frmListPresentacion.MyFormlistP.dgvPresentacion);
                        frmListPresentacion.MyFormlistP.dgvPresentacion.Refresh();
                    }
                    else
                    {
                        bool rpta2 = NPresentacion.Actualizar(txtNombre.Text.Trim(), txtDescripcion.Text.Trim(), idPresentacion);
                        mensajeYes("Presentacion actualizado correctamente (0_0)");
                        Limpiar();
                        txtNombre.Focus();
                        objNP.ListarDataGridViewPresentacion(frmListPresentacion.MyFormlistP.dgvPresentacion);
                        frmListPresentacion.MyFormlistP.dgvPresentacion.Refresh();
                        isNew = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error ...... ???", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            epPresentation.Clear();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
            txtNombre.Focus();
            isNew = true;
        }

        private void pBarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}

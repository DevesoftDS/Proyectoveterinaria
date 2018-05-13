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
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Security.Permissions;

namespace CapaPresentacion
{
    public partial class frmArticulo : Form
    {
        NArticulo objNA = new NArticulo();
        public int idArticulo = 0;

        public bool _IsNew = true;
        public frmArticulo()
        {
            InitializeComponent();
            if (_myFormArt == null)
            {
                _myFormArt = this;
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

        private static frmArticulo _myFormArt;

        public static frmArticulo MyFormArt
        {
            get
            {
                if (_myFormArt == null)
                {
                    _myFormArt = new frmArticulo();
                }
                return _myFormArt;
            }

            set
            {
                _myFormArt = value;
            }
        }

        // mostrar mensaje de confirmacion
        private void mensajeYes(string msn)
        {
            MessageBox.Show(msn, "Sistema veterinario", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // mostrar mensaje de error
        private void mensajeError(string msn)
        {
            MessageBox.Show(msn, "Sistema veterinario", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // limpiar controles del formulario
        private void Limpiar()
        {
            this.txtCodigo.Text = string.Empty;
            this.txtNombre.Text = string.Empty;
            this.cboCategoria.SelectedIndex = 0;
            this.cboPresentacion.SelectedIndex = 0;
            this.txtNeto.Text = string.Empty;
            this.txtDescripcion.Text = string.Empty;
            this.pbImagen.Image = null;
            //pbImagen.Image = Image.FromFile(@"C:..\\imgAplicacion\photo.png");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
            txtCodigo.Focus();
            _IsNew = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmArticulo_Load(object sender, EventArgs e)
        {
            MostrarCategoria();

            DataTable tabla = NArticulo.ListarPresentacion();
            if (tabla.Rows.Count > 0)
            {
                cboPresentacion.DataSource = tabla;
                cboPresentacion.DisplayMember = "nombre";
                cboPresentacion.ValueMember = "idpresentacion";
            }
        }

        private void MostrarCategoria()
        {
            DataTable tabla = NArticulo.ListarCategoria();
            if (tabla.Rows.Count > 0)
            {
                cboCategoria.DataSource = tabla;
                cboCategoria.DisplayMember = "nombre";
                cboCategoria.ValueMember = "idcategoria";
            }
        }

        public byte[] ImageToByteArray(Image imageIn)
        {

            using (MemoryStream ms = new MemoryStream())
            {
                if (imageIn != null)
                {
                    imageIn.Save(ms, ImageFormat.Jpeg);
                }
                return ms.ToArray();
            }
        }

        //public static Image ByteArrayToImage(byte[] byteArrayIn)
        //{
        //    MemoryStream ms = new MemoryStream(byteArrayIn);
        //    return Image.FromStream(ms);
        //}


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (_IsNew)
            {
                InsertarArticulo();
                objNA.ListarDataGridViewArticulo(frmListArticulo.MyFormListArt.dgvArticulo);
                frmListArticulo.MyFormListArt.dgvArticulo.Refresh();
            }
            else
            {
                ActualizarArticulo();
                objNA.ListarDataGridViewArticulo(frmListArticulo.MyFormListArt.dgvArticulo);
                frmListArticulo.MyFormListArt.dgvArticulo.Refresh();
                _IsNew = true;

            }
        }

        private void ActualizarArticulo()
        {
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                txtNombre.Focus();
                epArticulo.SetError(txtNombre, "Campo obligatorio - ingrese nombre del articulo");
            }
            else if (string.IsNullOrEmpty(txtNeto.Text))
            {
                txtNeto.Focus();
                epArticulo.SetError(txtNeto, "Campo obligatorio - ingrese neto de la presentacion: ejm. Kg 200");
            }
            else
            {
                bool rpta2 = NArticulo.Actualizar(
                txtCodigo.Text.Trim(), txtNombre.Text.Trim(),
                Convert.ToInt32(cboCategoria.SelectedValue), Convert.ToInt32(cboPresentacion.SelectedValue), txtNeto.Text.Trim(),
                txtDescripcion.Text.Trim(), ImageToByteArray(pbImagen.Image), idArticulo
                );
                if (rpta2)
                {
                    mensajeYes("Articulo actualizado correctamente");
                    Limpiar();
                    txtCodigo.Focus();
                }
                else
                {
                    mensajeError("Error al actualizar articulo");
                }
            }
        }

        private void InsertarArticulo()
        {
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                txtNombre.Focus();
                epArticulo.SetError(txtNombre, "Campo obligatorio - ingrese nombre del articulo");
            }
            else if (string.IsNullOrEmpty(txtNeto.Text))
            {
                txtNeto.Focus();
                epArticulo.SetError(txtNeto, "Campo obligatorio - ingrese neto de la presentacion: ejm. Kg 200");
            }
            else
            {
                bool rpta = NArticulo.Insertar(
                txtCodigo.Text.Trim(), txtNombre.Text.Trim(),
                Convert.ToInt32(cboCategoria.SelectedValue), Convert.ToInt32(cboPresentacion.SelectedValue), txtNeto.Text.Trim(),
                txtDescripcion.Text.Trim(), ImageToByteArray(pbImagen.Image)
                );
                if (rpta)
                {
                    mensajeYes("Articulo insertado correctamente");
                    Limpiar();
                    txtCodigo.Focus();
                }
                else
                {
                    mensajeError("Error al insertar el articulo");
                }
            }
            
        }

        private void frmArticulo_FormClosed(object sender, FormClosedEventArgs e)
        {
            _myFormArt = null;
        }

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                pbImagen.Image = Image.FromFile(dialog.FileName);

            }
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            epArticulo.Clear();
        }

        private void txtNeto_TextChanged(object sender, EventArgs e)
        {
            epArticulo.Clear();
        }

        private void pBarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}

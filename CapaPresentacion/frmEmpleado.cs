using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using System.Globalization;

namespace CapaPresentacion
{
    public partial class frmEmpleado : Form
    {
        public frmEmpleado()
        {
            InitializeComponent();
            if (_miFormEmpleado==null)
            {
                _miFormEmpleado = this;
            }
        }
        #region interface

        private static frmEmpleado _miFormEmpleado;

        public static frmEmpleado MiFormEmpleado
        {
            get
            {
                if (_miFormEmpleado==null)
                {
                    _miFormEmpleado = new frmEmpleado();
                }
                return _miFormEmpleado;
            }

            set
            {
                _miFormEmpleado = value;
            }
        }

        private void frmEmpleado_FormClosed(object sender, FormClosedEventArgs e)
        {
            _miFormEmpleado = null;
        }
        #endregion

        public int idEmpleado = 0;
        public bool _IsNew = true;
        private void frmEmpleado_Load(object sender, EventArgs e)
        {
            cboSexo.SelectedIndex = 0;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                pbFoto.Image = Image.FromFile(dialog.FileName);

            }
        }

        public byte[] ImageToByteArray(Image imageIn)
        {

            using (var ms = new MemoryStream())
            {
                if (imageIn != null)
                {
                    imageIn.Save(ms, ImageFormat.Jpeg);
                }

                return ms.ToArray();
            }

        }

        private void InsertarEmpleado()
        {
            string rpta = "";
            if (string.IsNullOrEmpty(txtNombres.Text))
            {
                txtNombres.Focus();
                epEmpleado.SetError(txtNombres, "Ingrese nombre del cliente");

            }
            else if (string.IsNullOrEmpty(txtApellidos.Text))
            {
                txtApellidos.Focus();
                epEmpleado.Clear();
                epEmpleado.SetError(txtApellidos, "Ingrese apellidos del cliente");
            }
            else if (string.IsNullOrEmpty(txtDni.Text))
            {
                txtDni.Focus();
                epEmpleado.Clear();
                epEmpleado.SetError(txtDni, "Ingrese dni del cliente");
            }
            else if (string.IsNullOrEmpty(cboSexo.Text))
            {
                cboSexo.Focus();
                epEmpleado.Clear();
                epEmpleado.SetError(cboSexo, "Indique sexo del cliente");
            }
            else if (string.IsNullOrEmpty(txtTelefono.Text))
            {
                txtTelefono.Focus();
                epEmpleado.Clear();
                epEmpleado.SetError(txtTelefono, "Ingrese telefono del cliente");
            }
            else if (string.IsNullOrEmpty(txtDireccion.Text))
            {
                txtDireccion.Focus();
                epEmpleado.Clear();
                epEmpleado.SetError(txtDireccion, "Ingrese dirección del cliente");
            }            

            else
            {
                rpta = NEmpleado.InsertarEmpleado(
                CultureInfo.InvariantCulture.TextInfo.ToTitleCase(txtNombres.Text).Trim(),
                CultureInfo.InvariantCulture.TextInfo.ToTitleCase(txtApellidos.Text).Trim(),
                txtDni.Text.Trim(),
                cboSexo.Text.Trim().Substring(0, 1),
                txtTelefono.Text.Trim(),
                txtCorreo.Text.Trim().ToLower(),
                CultureInfo.InvariantCulture.TextInfo.ToTitleCase(txtDireccion.Text).Trim(),
                ImageToByteArray(pbFoto.Image)
                );
                if (rpta == "Ok")
                {
                    MessageBox.Show(rpta + "--- Registrado");
                }
                else MessageBox.Show(rpta);

            }

        }
        private void ActualizarEmpleado()
        {
            string rpta = "";
            if (string.IsNullOrEmpty(txtNombres.Text))
            {
                txtNombres.Focus();
                epEmpleado.SetError(txtNombres, "Ingrese nombre del cliente");

            }
            else if (string.IsNullOrEmpty(txtApellidos.Text))
            {
                txtApellidos.Focus();
                epEmpleado.Clear();
                epEmpleado.SetError(txtApellidos, "Ingrese apellidos del cliente");
            }
            else if (string.IsNullOrEmpty(txtDni.Text))
            {
                txtDni.Focus();
                epEmpleado.Clear();
                epEmpleado.SetError(txtDni, "Ingrese dni del cliente");
            }
            else if (string.IsNullOrEmpty(cboSexo.Text))
            {
                cboSexo.Focus();
                epEmpleado.Clear();
                epEmpleado.SetError(cboSexo, "Indique sexo del cliente");
            }
            else if (string.IsNullOrEmpty(txtTelefono.Text))
            {
                txtTelefono.Focus();
                epEmpleado.Clear();
                epEmpleado.SetError(txtTelefono, "Ingrese telefono del cliente");
            }
            else if (string.IsNullOrEmpty(txtDireccion.Text))
            {
                txtDireccion.Focus();
                epEmpleado.Clear();
                epEmpleado.SetError(txtDireccion, "Ingrese dirección del cliente");
            }

            else
            {
                rpta = NEmpleado.ModificarEmpleado(
                idEmpleado,
                CultureInfo.InvariantCulture.TextInfo.ToTitleCase(txtNombres.Text).Trim(),
                CultureInfo.InvariantCulture.TextInfo.ToTitleCase(txtApellidos.Text).Trim(),
                txtDni.Text.Trim(),
                cboSexo.Text.Trim().Substring(0, 1),
                txtTelefono.Text.Trim(),
                txtCorreo.Text.Trim().ToLower(),
                CultureInfo.InvariantCulture.TextInfo.ToTitleCase(txtDireccion.Text).Trim(),
                ImageToByteArray(pbFoto.Image)
                );
                if (rpta == "Ok")
                {
                    MessageBox.Show(rpta + "---Actualizado");
                }
                else MessageBox.Show("error");

            }
        }
        public void Limpiar()
        {
            txtNombres.Text = string.Empty;
            txtApellidos.Text = string.Empty;
            txtDni.Text = string.Empty;
            cboSexo.SelectedIndex = 0;
            txtTelefono.Text = string.Empty;
            txtCorreo.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            pbFoto.Image = null;

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (_IsNew)
            {
                InsertarEmpleado();
                NEmpleado objEmpleado = new NEmpleado();
                objEmpleado.ListadoDgv(frmListEmpleado.MiFormListEmpleado.dgvEmpleado);
                Limpiar();
            }
            else
            {
                ActualizarEmpleado();
                NEmpleado objEmpleado = new NEmpleado();
                objEmpleado.ListadoDgv(frmListEmpleado.MiFormListEmpleado.dgvEmpleado);
                Limpiar();

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}

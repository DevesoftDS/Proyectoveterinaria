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
using System.Globalization;

namespace CapaPresentacion
{
    public partial class frmCliente : Form
    {
        public frmCliente()
        {
            InitializeComponent();
            if (_miFormCliente==null)
            {
                _miFormCliente = this;
            }
            
        }
        #region interfaz
        private static frmCliente _miFormCliente;
        public static frmCliente MiFormCliente
        {
            get
            {
                if (_miFormCliente==null)
                {
                    _miFormCliente = new frmCliente();
                }
                return _miFormCliente;
            }

            set
            {
                _miFormCliente = value;
            }
        }

        private void frmCliente_FormClosed(object sender, FormClosedEventArgs e)
        {
            _miFormCliente = null;
        }
        #endregion


        public bool _IsNew = true;
        public int idCliente = 0;

        private void frmCliente_Load(object sender, EventArgs e)
        {
            cboSexo.SelectedIndex = 0;
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

        private void InsertarCliente()
        {
            string rpta = "";
            if (string.IsNullOrEmpty(txtNombres.Text))
            {
                txtNombres.Focus();
                epCliente.SetError(txtNombres, "Ingrese nombre del cliente");

            }
            else if (string.IsNullOrEmpty(txtApellidos.Text))
            {
                txtApellidos.Focus();
                epCliente.Clear();
                epCliente.SetError(txtApellidos, "Ingrese apellidos del cliente");
            }
            else if (string.IsNullOrEmpty(txtDni.Text))
            {
                txtDni.Focus();
                epCliente.Clear();
                epCliente.SetError(txtDni, "Ingrese dni del cliente");
            }
            else if (string.IsNullOrEmpty(cboSexo.Text))
            {
                cboSexo.Focus();
                epCliente.Clear();
                epCliente.SetError(cboSexo, "Indique sexo del cliente");
            }
            else if (string.IsNullOrEmpty(txtTelefono.Text))
            {
                txtTelefono.Focus();
                epCliente.Clear();
                epCliente.SetError(txtTelefono, "Ingrese telefono del cliente");
            }
            else if (string.IsNullOrEmpty(txtDireccion.Text))
            {
                txtDireccion.Focus();
                epCliente.Clear();
                epCliente.SetError(txtDireccion, "Ingrese dirección del cliente");
            }
           
            else
            {
                rpta = NCliente.InsertarCliente(
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
                    MessageBox.Show(rpta+"--- Registrado");
                }
                else MessageBox.Show(rpta);

            }
            
        }
        private void ActualizarCliente()
        {
            string rpta = "";
            if (string.IsNullOrEmpty(txtNombres.Text))
            {
                txtNombres.Focus();
                epCliente.SetError(txtNombres, "Ingrese nombre del cliente");

            }
            else if (string.IsNullOrEmpty(txtApellidos.Text))
            {
                txtApellidos.Focus();
                epCliente.Clear();
                epCliente.SetError(txtApellidos, "Ingrese apellidos del cliente");
            }
            else if (string.IsNullOrEmpty(txtDni.Text))
            {
                txtDni.Focus();
                epCliente.Clear();
                epCliente.SetError(txtDni, "Ingrese dni del cliente");
            }
            else if (string.IsNullOrEmpty(cboSexo.Text))
            {
                cboSexo.Focus();
                epCliente.Clear();
                epCliente.SetError(cboSexo, "Indique sexo del cliente");
            }
            else if (string.IsNullOrEmpty(txtTelefono.Text))
            {
                txtTelefono.Focus();
                epCliente.Clear();
                epCliente.SetError(txtTelefono, "Ingrese telefono del cliente");
            }
            else if (string.IsNullOrEmpty(txtDireccion.Text))
            {
                txtDireccion.Focus();
                epCliente.Clear();
                epCliente.SetError(txtDireccion, "Ingrese dirección del cliente");
            }            

            else
            {
                rpta = NCliente.ModificarCliente(
                idCliente,
                CultureInfo.InvariantCulture.TextInfo.ToTitleCase(txtNombres.Text).Trim(),
                CultureInfo.InvariantCulture.TextInfo.ToTitleCase(txtApellidos.Text).Trim(),
                txtDni.Text.Trim(),
                cboSexo.Text.Trim().Substring(0,1),
                txtTelefono.Text.Trim(),
                txtCorreo.Text.Trim().ToLower(),
                CultureInfo.InvariantCulture.TextInfo.ToTitleCase(txtDireccion.Text).Trim(),
                ImageToByteArray(pbFoto.Image)
                );
                if (rpta == "Ok")
                {
                    MessageBox.Show(rpta+"---Actualizado");
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
                InsertarCliente();
                NCliente objCliente = new NCliente();
                objCliente.ListadoDgv(frmListCliente.MiFormListCliente.dgvCliente);
                Limpiar();
            }
            else
            {
                ActualizarCliente();
                NCliente objCliente = new NCliente();
                objCliente.ListadoDgv(frmListCliente.MiFormListCliente.dgvCliente);
                Limpiar();

            }
            
        }        

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        
    }
}

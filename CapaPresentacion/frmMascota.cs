using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaNegocio;
using System.Globalization;
using System.IO;
using System.Drawing.Imaging;

namespace CapaPresentacion
{
    public partial class frmMascota : Form
    {
        public bool _IsNew = true;
        public int _idMascota = 0;
        public int _idCliente = 0;
        public int _idRaza = 0;
        public frmMascota()
        {
            InitializeComponent();
            if (_miFormMascota==null)
            {
                _miFormMascota = this;
            }
        }

        #region interfaz
        private static frmMascota _miFormMascota;

        public static frmMascota MiFormMascota
        {
            get
            {
                if (_miFormMascota==null)
                {
                    _miFormMascota = new frmMascota();
                }
                return _miFormMascota;
            }

            set
            {
                _miFormMascota = value;
            }
        }
        private void frmMascota_FormClosed(object sender, FormClosedEventArgs e)
        {            
                _miFormMascota = null;

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

        private void Limpiar()
        {
            txtBuscar.Focus();
            txtCodigo.Text = string.Empty;       
            txtBuscar.Text = string.Empty;
            txtCliente.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtEdad.Text = string.Empty;
            cboSexo.SelectedItem = 1;
            txtPeso.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            cboEspecie.SelectedItem = 0;
            cboRaza.SelectedItem = 0;
            pbFoto.Image = Image.FromFile(@"C:\\fotoSV\art_image.png");

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
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBuscar.Text))
            {
                txtBuscar.Focus();
                epMascota.SetError(txtCliente, "Ingrese dato a buscar: dni y/o nombre del cliente");
                txtCliente.Text = "";
            }
            else
            {
                var tablaCli = NCliente.BuscarCliente(txtBuscar.Text);
                if (tablaCli.Rows.Count > 0)
                {

                    _idCliente = int.Parse(tablaCli.Rows[0]["codigo"].ToString());
                    txtCliente.Text = tablaCli.Rows[0]["nombres"].ToString() + " " + tablaCli.Rows[0]["apellidos"].ToString();
                    epMascota.Clear();

                }
                else
                {
                    epMascota.Clear();
                    txtBuscar.Focus();
                    epMascota.SetError(txtCliente, "No encontrado pulse en + para registrarlo");
                    txtCliente.Text = string.Empty;
                }
            }
        }
        private void InsertarMascota()
        {
            string rpta = "";
            if (string.IsNullOrEmpty(txtCliente.Text))
            {
                txtCliente.Focus();
                epMascota.SetError(txtCliente, "Ingrese datos del cliente");

            }
            else if (string.IsNullOrEmpty(txtNombre.Text))
            {
                txtNombre.Focus();
                epMascota.Clear();
                epMascota.SetError(txtNombre, "Ingrese nombre de la mascota");
            }
            else if (string.IsNullOrEmpty(txtEdad.Text))
            {
                txtEdad.Focus();
                epMascota.Clear();
                epMascota.SetError(txtEdad, "Ingrese la edad de la mascota");
            }            
            else if (string.IsNullOrEmpty(txtPeso.Text))
            {
                txtPeso.Focus();
                epMascota.Clear();
                epMascota.SetError(txtPeso, "Ingrese el peso de la mascota");
            }
            
            else if (string.IsNullOrEmpty(cboEspecie.Text))
            {
                cboEspecie.Focus();
                epMascota.Clear();
                epMascota.SetError(cboEspecie, "Indique la especie");
            }
            else if (string.IsNullOrEmpty(cboRaza.Text))
            {
                cboRaza.Focus();
                epMascota.Clear();
                epMascota.SetError(cboRaza, "Indique la raza");
            }
            else if (string.IsNullOrEmpty(cboSexo.Text))
            {
                cboSexo.Focus();
                epMascota.Clear();
                epMascota.SetError(cboSexo, "Indique el sexo de la mascota");
            }            

            else
            {              
                

                rpta = NMascota.InsertarMascota(
                CultureInfo.InvariantCulture.TextInfo.ToTitleCase(txtNombre.Text).Trim(),
                CultureInfo.InvariantCulture.TextInfo.ToTitleCase(txtEdad.Text).Trim(),
                CultureInfo.InvariantCulture.TextInfo.ToTitleCase(cboSexo.SelectedItem.ToString()).Trim(),
                CultureInfo.InvariantCulture.TextInfo.ToTitleCase(txtPeso.Text).Trim(),
                txtDescripcion.Text.Trim(),
                 Convert.ToInt32(cboRaza.SelectedValue),
                _idCliente,
                ImageToByteArray(pbFoto.Image)
                );
                if (rpta == "Ok")
                {
                    MessageBox.Show(rpta + "--- Registrado");                   
                    Limpiar();
                }
                else MessageBox.Show(rpta +" -----Error");

            }

        }
        private void ActualizarMascota()
        {
            string rpta = "";
            if (string.IsNullOrEmpty(txtCliente.Text))
            {
                txtCliente.Focus();
                epMascota.SetError(txtCliente, "Ingrese datos del cliente");

            }
            else if (string.IsNullOrEmpty(txtNombre.Text))
            {
                txtNombre.Focus();
                epMascota.Clear();
                epMascota.SetError(txtNombre, "Ingrese nombre de la mascota");
            }
            else if (string.IsNullOrEmpty(txtEdad.Text))
            {
                txtEdad.Focus();
                epMascota.Clear();
                epMascota.SetError(txtEdad, "Ingrese la edad de la mascota");
            }
            else if (string.IsNullOrEmpty(txtPeso.Text))
            {
                txtPeso.Focus();
                epMascota.Clear();
                epMascota.SetError(txtPeso, "Ingrese el peso de la mascota");
            }

            else if (string.IsNullOrEmpty(cboEspecie.Text))
            {
                cboEspecie.Focus();
                epMascota.Clear();
                epMascota.SetError(cboEspecie, "Indique la especie");
            }
            else if (string.IsNullOrEmpty(cboRaza.Text))
            {
                cboRaza.Focus();
                epMascota.Clear();
                epMascota.SetError(cboRaza, "Indique la raza");
            }
            else if (string.IsNullOrEmpty(cboSexo.Text))
            {
                cboSexo.Focus();
                epMascota.Clear();
                epMascota.SetError(cboSexo, "Indique el sexo de la mascota");
            }

            else
            {
                rpta = NMascota.ActualizarMascota(
                _idMascota,
                 CultureInfo.InvariantCulture.TextInfo.ToTitleCase(txtNombre.Text).Trim(),
                CultureInfo.InvariantCulture.TextInfo.ToTitleCase(txtEdad.Text).Trim(),
                CultureInfo.InvariantCulture.TextInfo.ToTitleCase(cboSexo.SelectedItem.ToString()).Trim(),
                CultureInfo.InvariantCulture.TextInfo.ToTitleCase(txtPeso.Text).Trim(),
                txtDescripcion.Text.Trim(),
                 Convert.ToInt32(cboRaza.SelectedValue),
                _idCliente,
                ImageToByteArray(pbFoto.Image)
                );
                if (rpta == "Ok")
                {
                    MessageBox.Show(rpta + "---Actualizado");
                    Limpiar();
                }
                else MessageBox.Show("error");

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (_IsNew==true)
            {
                InsertarMascota();
                NMascota objMascota = new NMascota();
                objMascota.ListadoDgv(frmListMascota.MiFormListMascota.dgvMascota);
            }
            else
            {
                ActualizarMascota();
                NMascota objMascota = new NMascota();
                objMascota.ListadoDgv(frmListMascota.MiFormListMascota.dgvMascota);
                frmListMascota.MiFormListMascota.dgvMascota.Refresh();
                label1.Visible = false;
                txtCodigo.Visible = false;
            }
        }

        private void cboEspecie_SelectedValueChanged(object sender, EventArgs e)
        {
            var tabla = NRaza.BuscarRaza(cboEspecie.Text);
            if (tabla.Rows.Count > 0)
            {
                cboRaza.DataSource = tabla;
                cboRaza.DisplayMember = "nombre";
                cboRaza.ValueMember = "idraza";
            }
        }

        private void frmMascota_Load(object sender, EventArgs e)
        {
            cboSexo.SelectedItem = 1;
            var tabla = NEspecie.ListarEspecie();
            if (tabla.Rows.Count > 0)
            {
                cboEspecie.DataSource = tabla;
                cboEspecie.DisplayMember = "nombre";
                cboEspecie.ValueMember = "idEspecie";
            }
        }

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                pbFoto.Image = Image.FromFile(dialog.FileName);

            }
        }

        private void pBarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
            _IsNew = true;
            txtBuscar.Enabled = true;
            cboEspecie.Enabled = true;
            cboRaza.Enabled = true;
            cboSexo.Enabled = true;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            new frmCliente().ShowDialog();
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (string.IsNullOrEmpty(txtBuscar.Text))
            {
                txtBuscar.Focus();
                epMascota.SetError(txtCliente, "Ingrese dato a buscar: dni y/o nombre del cliente");
                txtCliente.Text = "";
            }
            else
            {
                var tablaCli = NCliente.BuscarCliente(txtBuscar.Text);
                if (tablaCli.Rows.Count > 0)
                {

                    _idCliente = int.Parse(tablaCli.Rows[0]["codigo"].ToString());
                    txtCliente.Text = tablaCli.Rows[0]["nombres"].ToString() + " " + tablaCli.Rows[0]["apellidos"].ToString();
                    epMascota.Clear();

                }
                else
                {
                    epMascota.Clear();
                    txtBuscar.Focus();
                    epMascota.SetError(txtCliente, "No encontrado pulse en + para registrarlo");
                    txtCliente.Text = string.Empty;
                }
            }
        }
    }
}

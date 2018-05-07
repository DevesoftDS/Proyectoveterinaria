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
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmArticulo_Load(object sender, EventArgs e)
        {
            MostrarCategoria();

            var tabla = NArticulo.ListarPresentacion();
            if (tabla.Rows.Count > 0)
            {
                cboPresentacion.DataSource = tabla;
                cboPresentacion.DisplayMember = "nombre";
                cboPresentacion.ValueMember = "idpresentacion";
            }
        }

        private void MostrarCategoria()
        {
            var tabla = NArticulo.ListarCategoria();
            if (tabla.Rows.Count > 0)
            {
                cboCategoria.DataSource = tabla;
                cboCategoria.DisplayMember = "nombre";
                cboCategoria.ValueMember = "idcategoria";
            }
        }

        public byte[] ImageToByteArray(Image imageIn)
        {

            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, ImageFormat.Gif);
                return ms.ToArray();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
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
                else if (pbImagen.Image == null)
                {
                    epArticulo.SetError(btnExaminar, "Campo obligatorio - Seleccione una imagen para el articulo");

                }
                else
                {
                    if (_IsNew)
                    {
                        bool rpta = NArticulo.Insertar(
                            txtCodigo.Text.Trim(), txtNombre.Text.Trim(), 
                            Convert.ToInt32(cboCategoria.SelectedValue), Convert.ToInt32(cboPresentacion.SelectedValue), txtNeto.Text.Trim(), 
                            txtDescripcion.Text.Trim(), ImageToByteArray(pbImagen.Image)
                            );

                        mensajeYes("Articulo insertado correctamente");
                        Limpiar();
                        txtCodigo.Focus();
                        objNA.ListarDataGridViewArticulo(frmListArticulo.MyFormListArt.dgvArticulo);
                        
                    }
                    else
                    {
                        bool rpta2 = NArticulo.Actualizar(
                            txtCodigo.Text.Trim(), txtNombre.Text.Trim(),
                            Convert.ToInt32(cboCategoria.SelectedValue), Convert.ToInt32(cboPresentacion.SelectedValue), txtNeto.Text.Trim(),
                            txtDescripcion.Text.Trim(), ImageToByteArray(pbImagen.Image), idArticulo
                            );

                        mensajeYes("Articulo actualizado correctamente");
                        Limpiar();
                        txtCodigo.Focus();
                        objNA.ListarDataGridViewArticulo(frmListArticulo.MyFormListArt.dgvArticulo);

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error........!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
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
    }
}

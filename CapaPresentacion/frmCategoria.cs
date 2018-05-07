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
using System.Data.SqlClient;

namespace CapaPresentacion
{
    public partial class frmCategoria : Form
    {

        public int idcategoria = 0;

        public bool isNew = true;

        public bool isUpdate = false;
        NCategoria objtNC = new NCategoria();
        public frmCategoria()
        {
            InitializeComponent();
            if (_myFormCategoria == null)
            {
                _myFormCategoria = this;
            }
        }

        private static frmCategoria _myFormCategoria;
        public static frmCategoria MyFormCategoria
        {
            get
            {
                if (_myFormCategoria == null)
                {
                    _myFormCategoria = new frmCategoria();
                }
                return _myFormCategoria;
            }

            set
            {
                _myFormCategoria = value;
            }
        }

        #region
        // mostrar mensaje de confirmacion
        private void mensajeYes(string msn)
        {
            MessageBox.Show(msn,"Sistema veterinario", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // mostrar mensaje de error
        private void mensajeError(string msn)
        {
            MessageBox.Show(msn, "Sistema veterinario", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion

        // limpiar controles del formulario
        private void Limpiar()
        {
            this.txtNombre.Text = string.Empty;
            this.txtDescripcion.Text = string.Empty;
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
            txtNombre.Focus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            isNew = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //int rpta = 0;
            try
            {
                if (txtNombre.Text.Equals(""))
                {
                    txtNombre.Focus();
                    epCategoria.SetError(txtNombre, "Campo obligatorio - ingrese nombre de la categoria");
                }
                else
                {
                    
                    // error here change a negation
                    if (isNew)
                    {
                        int rpta_insert = NCategoria.Insertar(txtNombre.Text.Trim(), txtDescripcion.Text.Trim());
                        mensajeYes("Categoria insertado correctamente al registro");
                        Limpiar();
                        txtNombre.Focus();
                        objtNC.ListarDataGridViewCategoria(frmListCategoria.MyForm.dgvPresentacion);
                        _myFormCategoria = this;
                    }
                    else
                    {
                        int rpta_update = NCategoria.Actualizar(txtNombre.Text.Trim(), txtDescripcion.Text.Trim(), idcategoria);
                        mensajeYes("Categoria actualizado correctamente al registro");
                        Limpiar();
                        txtNombre.Focus();
                        objtNC.ListarDataGridViewCategoria(frmListCategoria.MyForm.dgvPresentacion);
                        isNew = true;
                        _myFormCategoria = this;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error.......... ???", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(ex.Message + ex.StackTrace);
                throw;
            }
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            epCategoria.Clear();
        }

        private void frmCategoria_Load(object sender, EventArgs e)
        {

        }

        private void frmCategoria_FormClosed(object sender, FormClosedEventArgs e)
        {
            _myFormCategoria = null;
        }
    }
}

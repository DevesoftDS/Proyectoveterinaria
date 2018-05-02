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
        private bool isNew = false;
        private bool isApdate = false;

        NPresentacion objtNP = new NPresentacion();
        public frmCategoria()
        {
            InitializeComponent();
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
            //this.Close();
            try
            {
                objtNP.InsertarCategoria(
                txtNombre.Text,
                txtDescripcion.Text
                );
                mensajeYes("Categoria registrado correctamente");
            }
            catch (Exception ex)
            {
                mensajeError("Error al registrar categoria"+ex.Message);
                throw;
            }
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string rpta ="";
            try
            {
                if (txtNombre.Text.Equals(""))
                {
                    mensajeError("Ingrese nombre de la categoria campo obligatorio");
                }
                else
                {
                    // error here change a negation
                    if (isNew)
                    {
                        rpta = NCategoria.Insertar1(
                            txtNombre.Text.Trim(),
                            txtDescripcion.Text.Trim()
                            );
                        
                    }
                    if (rpta.Equals("Ok"))
                    {
                        if (isNew)
                        {
                            mensajeYes("Categoria insertado correctamente al registro");
                        }
                        
                    }
                    else
                    {
                        mensajeError("Error al insertar registro categoria");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
                throw;
            }
        }
    }
}

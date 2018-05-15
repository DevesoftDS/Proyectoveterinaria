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

namespace CapaPresentacion
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
        }

        private void lkblRecuperar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new frmRecuperarPassword().ShowDialog();
        }


        private void btnIngresar_Click(object sender, EventArgs e)
        {
            Logear();

        }

        private void Logear()
        {
            string usuario = txtUsuario.Text.Trim();
            string password = txtPassword.Text.Trim();
            if (string.IsNullOrEmpty(txtUsuario.Text.Trim()))
            {
                txtUsuario.Focus();
                txtError.Text = "Campo requerido - Ingrese nombre usuario/Email";
            }
            else if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                txtPassword.Focus();
                txtError.Text = "Campo requerido - Ingrese password. si se ha olvidado pulse He olvidado mi contraseña";
            }
            else
            {
                DataTable tabla = NAcceso.Acceso(usuario, password);
                int numFilas = tabla.Rows.Count;
                if (numFilas > 0)
                {
                    frmHome frm = new frmHome();
                    Program.idUsuario = Convert.ToInt32(tabla.Rows[0]["idusuario"].ToString());
                    Program.tipo = tabla.Rows[0]["tipo"].ToString();
                    Program.idEmpleado = Convert.ToInt32(tabla.Rows[0]["idempleado"].ToString());
                    Program.nombres = tabla.Rows[0]["nombres"].ToString();
                    Program.apellidos = tabla.Rows[0]["apellidos"].ToString();
                    Program.correo = tabla.Rows[0]["correo"].ToString();
                    frm.Show();
                    this.Hide();

                }
                else
                    MessageBox.Show("Error cuenta usuario incorrecto ..... !!??", "Error al iniciar sesiòn", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            txtError.Text = string.Empty;
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            txtError.Text = string.Empty;
        }

        private void btnFacebook_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/franz.programador");
        }

        private void btnGooglePlus_Click(object sender, EventArgs e)
        {
            //
            System.Diagnostics.Process.Start("https://plus.google.com/u/0/107973794450007524146");
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                Logear();
            }
        }
    }
}

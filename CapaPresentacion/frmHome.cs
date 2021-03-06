﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace CapaPresentacion
{
    public partial class frmHome : Form
    {
        public int Idusuario { get; set; }
        public string TipoUsuario { get; set; }

        #region MyRegion
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int Wparam, int lParam);
        #endregion


        public frmHome()
        {
            InitializeComponent();
            subLogo.Visible = false;

            if (_myForm == null)
            {
                MyForm = this;
            }
            this.WindowState = FormWindowState.Maximized;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        private static frmHome _myForm;

        public static frmHome MyForm
        {
            get
            {
                if (_myForm == null)
                {
                    _myForm = new frmHome();
                }
                return _myForm;
            }

            set
            {
                _myForm = value;
            }
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            //267; 454
            if (menuVertical.Width == 267)
            {
                menuVertical.Width = 60;
                pictureLogo.Visible = false;
                subLogo.Visible = true;
            }
            else
            {
                menuVertical.Width = 267;
                pictureLogo.Visible = true;
                subLogo.Visible = false;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnNormal_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnNormal.Visible = false;
            btnMaximize.Visible = true;
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            
            btnMaximize.Visible = false;
            btnNormal.Visible = true;

        }

        private void barraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        
        private void frmHome_Load(object sender, EventArgs e)
        {
            //this.StartPosition = FormStartPosition.CenterScreen;
            btnMaximize.Visible = true;
            btnNormal.Visible = false;
            btnHome_Click(null, e);
            lblNombreUsuario.Text = Program.nombres + " " + Program.apellidos;
            lblTipoUser.Text = Program.tipo;
        }

        public void AbrirFormHija(object formHija)
        {
            if (barraSection.Controls.Count > 0)
                this.barraSection.Controls.RemoveAt(0);

            Privilegio();
            Form fh = formHija as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.barraSection.Controls.Add(fh);
            this.barraSection.Tag = fh;
            fh.Show();
        }

        public void AbrirSubMenu(object formHija)
        {
            if (barraSubMenu.Controls.Count > 0)
                this.barraSubMenu.Controls.RemoveAt(0);
            Form fh = formHija as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.barraSubMenu.Controls.Add(fh);
            this.barraSubMenu.Tag = fh;
            fh.Show();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new frmMenuInicio());
            this.barraSubMenu.Controls.Clear();
        }

        private void btnMantenimiento_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new frmMenuMantenimiento());
            this.barraSubMenu.Controls.Clear();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new frmListVenta());
            this.barraSubMenu.Controls.Clear();
        }

        private void btnAlmacen_Click(object sender, EventArgs e)
        {
            this.barraSubMenu.Controls.Clear();
            AbrirSubMenu(new frmSubMenuIngresoArticulo());
            AbrirFormHija(new frmListIngresoArticulos());
        }

        private void frmHome_FormClosed(object sender, FormClosedEventArgs e)
        {
            MyForm = null;
        }

        private void btnServicios_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new frmListCita());
            this.barraSubMenu.Controls.Clear();
        }

        private void btnAcerca_Click(object sender, EventArgs e)
        {
            new frmAcerca().ShowDialog();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new frmSubMenuReportes());
            this.barraSubMenu.Controls.Clear();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            new FrmLogin().Show();
            this.Close();

        }

        private void Privilegio()
        {
            //vendedor

            TipoUsuario = Program.tipo;
            if (TipoUsuario == "Invitado")
            {
                btnVentas.Enabled = false;
                btnServicios.Enabled = false;
                btnAlmacen.Enabled = false;
                btnReportes.Enabled = false;
            }
            else if (TipoUsuario == "Vendedor")
            {
                btnMantenimiento.Enabled = false;
                btnVentas.Enabled = true;
                btnServicios.Enabled = true;
                btnAlmacen.Enabled = false;
                btnReportes.Enabled = true;
            }
            else if (TipoUsuario == "Almacenero")
            {
                btnMantenimiento.Enabled = false;
                btnVentas.Enabled = false;
                btnServicios.Enabled = false;
                btnAlmacen.Enabled = true;
                btnReportes.Enabled = false;
            }
            else
            {
                btnMantenimiento.Enabled = true;
                btnVentas.Enabled = true;
                btnServicios.Enabled = true;
                btnAlmacen.Enabled = true;
                btnReportes.Enabled = true;
            }
            
        }
    }
}

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
namespace CapaPresentacion
{
    public partial class frmCita : Form
    {
        public frmCita()
        {
            InitializeComponent();
            if (_miFormCita==null)
            {
                _miFormCita = this;
            }
        }

        #region interfaz
        private static frmCita _miFormCita;

        public static frmCita MiFormCita
        {
            get
            {
                if (_miFormCita==null)
                {
                    _miFormCita = new frmCita();
                }
                return _miFormCita;
            }

            set
            {
                _miFormCita = value;
            }
        }
        private void frmCita_FormClosed(object sender, FormClosedEventArgs e)
        {
            _miFormCita = null;
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
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void frmCita_Load(object sender, EventArgs e)
        {
            cboAmPm.SelectedIndex = 1;
            var tabla = NArea.ListarArea();
            if (tabla.Rows.Count > 0)
            {
                cboArea.DataSource = tabla;
                cboArea.DisplayMember = "nombre";
                cboArea.ValueMember = "idarea";
            }
        }
        

        private void cboArea_SelectedValueChanged(object sender, EventArgs e)
        {
            var tablaEmp = NArea.BuscarAreaEmpleado(cboArea.Text);
            if (tablaEmp.Rows.Count > 0)
            {
                cboEmpleado.DataSource = tablaEmp;
                cboEmpleado.DisplayMember = "personal";
                cboEmpleado.ValueMember = "idempleado";              

            }
            var tablaServ = NServicio.BuscarServicioArea(cboArea.Text);
            if (tablaServ.Rows.Count > 0)
            {
                cboServicio.DataSource = tablaServ;
                cboServicio.DisplayMember = "servicio";
                cboServicio.ValueMember = "idservicio";
                txtCosto.Text = tablaServ.Rows[0]["precio"].ToString();

            }


        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var tabla = NMascota.BuscarMascota(txtBuscar.Text);
            if (tabla.Rows.Count>0)
            {
                txtCliente.Text = tabla.Rows[0]["nombres"].ToString() + " " + tabla.Rows[0]["apellidos"].ToString();
                string codmascota = tabla.Rows[0]["codigo"].ToString();
                string mascota = tabla.Rows[0]["nombre"].ToString();
                string edad = tabla.Rows[0]["edad"].ToString();
                string peso = tabla.Rows[0]["peso"].ToString();
                string especie = tabla.Rows[0]["especie"].ToString();
                string raza = tabla.Rows[0]["raza"].ToString();
                int idMascota = Convert.ToInt32(tabla.Rows[0]["idmascota"].ToString());
                int idCliente = Convert.ToInt32(tabla.Rows[0]["idcliente"].ToString());
                dgvMacota.Rows.Add(codmascota, mascota, edad, peso, especie, raza, idMascota, idCliente);
            }
           
        }
    }
}

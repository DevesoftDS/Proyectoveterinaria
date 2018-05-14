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
using System.Runtime.InteropServices;
using System.Security.Permissions;

namespace CapaPresentacion
{
    public partial class frmListHorarioDisponible : Form
    {
        public frmListHorarioDisponible()
        {
            InitializeComponent();
            if (_miFormHorario==null)
            {
                _miFormHorario = this;
            }
        }

        #region interfaz
        private static frmListHorarioDisponible _miFormHorario;

        public static frmListHorarioDisponible MiFormHorario
        {
            get
            {
                if (_miFormHorario==null)
                {
                    _miFormHorario = new frmListHorarioDisponible();
                }
                return _miFormHorario;
            }

            set
            {
                _miFormHorario = value;
            }
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
        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void estiloDgv()
        {
            this.dgvListaHorario.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            this.dgvListaHorario.DefaultCellStyle.ForeColor = Color.Black;
            this.dgvListaHorario.DefaultCellStyle.BackColor = Color.White;
            this.dgvListaHorario.DefaultCellStyle.SelectionForeColor = Color.Black;
            this.dgvListaHorario.DefaultCellStyle.SelectionBackColor = Color.FromArgb(128, 203, 196);

        }

        private void dtpBuscar_ValueChanged(object sender, EventArgs e)
        {
            var tabla = new NDetalleCita();
            tabla.ListarBuscarFecha(dgvListaHorario, Convert.ToDateTime(dtpBuscar.Text));
        }

        private void frmListHorarioDisponible_Load(object sender, EventArgs e)
        {
            estiloDgv();
            //var tabla = new NDetalleCita();
            //tabla.ListarBuscarFecha(dgvListaHorario, Convert.ToDateTime(dtpBuscar.Text));
            dgvListaHorario.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvListaHorario.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvListaHorario.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvListaHorario.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvListaHorario.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            
            dgvListaHorario.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvListaHorario.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvListaHorario.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvListaHorario.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvListaHorario.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
           

            dgvListaHorario.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
        }

        private void frmListHorarioDisponible_FormClosed(object sender, FormClosedEventArgs e)
        {
            _miFormHorario = null;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}

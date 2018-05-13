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
using System.Security.Permissions;
using System.Runtime.InteropServices;

namespace CapaPresentacion
{
    public partial class FrmListadoArticulo : Form
    {
        NArticulo objNA = new NArticulo();

        public FrmListadoArticulo()
        {
            InitializeComponent();
            if (_myFormListArticulo == null)
            {
                _myFormListArticulo = this;
            }
        }

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

        #region movefrm
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int Wparam, int lParam);
        #endregion

        private static FrmListadoArticulo _myFormListArticulo;

        public static FrmListadoArticulo MyFormListArticulo
        {
            get
            {
                if (_myFormListArticulo == null)
                {
                    _myFormListArticulo = new FrmListadoArticulo();
                }
                return _myFormListArticulo;
            }

            set
            {
                _myFormListArticulo = value;
            }
        }

        private void estiloDgv()
        {
            this.dgvArticulo.DefaultCellStyle.Font = new Font("Arial", 9);
            this.dgvArticulo.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
            this.dgvArticulo.DefaultCellStyle.ForeColor = Color.Black;
            this.dgvArticulo.DefaultCellStyle.BackColor = Color.White;
            this.dgvArticulo.DefaultCellStyle.SelectionForeColor = Color.Black;
            this.dgvArticulo.DefaultCellStyle.SelectionBackColor = Color.Orange;
        }

        private void FrmListadoArticulo_Load(object sender, EventArgs e)
        {
            MostrarArticulo();
            estiloDgv();

            dgvArticulo.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;

            dgvArticulo.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
         
        }

        private void MostrarArticulo()
        {
            objNA.ListarDataGridViewArticulo(dgvArticulo);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pBarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void txtBuscarArt_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscarArt.Text.Trim().Length > 0)
            {
                objNA.ListarArticuloPorNombre(dgvArticulo, txtBuscarArt.Text.Trim());

            }
            else
            {
                MostrarArticulo();
            }
        }

        private void FrmListadoArticulo_FormClosed(object sender, FormClosedEventArgs e)
        {
            _myFormListArticulo = null;
        }

        private void dgvArticulo_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataTable tabla = new DataTable();

                int idarticulo = Convert.ToInt32(dgvArticulo.Rows[e.RowIndex].Cells[8].Value);
                tabla = NArticulo.BuscarCodigo(idarticulo);
                int numFilas = tabla.Rows.Count;
                if (numFilas == 1)
                {
                    frmIngresoArticulos.MyformIngresoArt.IdArticulo = idarticulo;
                    frmIngresoArticulos.MyformIngresoArt.txtArticulo.Text = tabla.Rows[0]["nombre"].ToString();
                    frmIngresoArticulos.MyformIngresoArt.txtCategoria.Text = tabla.Rows[0]["categoria"].ToString();
                    frmIngresoArticulos.MyformIngresoArt.txtNeto.Text = tabla.Rows[0]["neto"].ToString();
                    frmIngresoArticulos.MyformIngresoArt.txtPresentacion.Text = tabla.Rows[0]["presentacion"].ToString();
                    this.Close();
                }
            }
        }
    }
}

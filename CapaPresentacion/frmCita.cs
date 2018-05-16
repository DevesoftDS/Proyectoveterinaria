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
using System.IO;

namespace CapaPresentacion
{
    public partial class frmCita : Form
    {
        public frmCita()
        {
            InitializeComponent();
            if (_miFormCita == null)
            {
                _miFormCita = this;
            }
        }
        int _idCliente = 0;
        int _idMascota = 0;              
        public int IdComprobante { get; set; }

        #region interfaz
        private static frmCita _miFormCita;

        public static frmCita MiFormCita
        {
            get
            {
                if (_miFormCita == null)
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

        private void dtpHora_ValueChanged(object sender, EventArgs e)
        {
            var diff = dtpHora.Value.TimeOfDay.Minutes % 30;
            if (diff != 0)
            {
                dtpHora.Value = dtpHora.Value.AddMinutes(30 - diff);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void estiloDgv()
        {
            this.dgvMacota.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            this.dgvMacota.DefaultCellStyle.ForeColor = Color.Black;
            this.dgvMacota.DefaultCellStyle.BackColor = Color.White;
            this.dgvMacota.DefaultCellStyle.SelectionForeColor = Color.Black;
            this.dgvMacota.DefaultCellStyle.SelectionBackColor = Color.FromArgb(128, 203, 196);

            this.dgvDetalleCita.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            this.dgvDetalleCita.DefaultCellStyle.ForeColor = Color.Black;
            this.dgvDetalleCita.DefaultCellStyle.BackColor = Color.White;
            this.dgvDetalleCita.DefaultCellStyle.SelectionForeColor = Color.Black;
            this.dgvDetalleCita.DefaultCellStyle.SelectionBackColor = Color.FromArgb(133, 193, 233);

        }
        private void frmCita_Load(object sender, EventArgs e)
        {
            dtpFecha.Value = DateTime.Now;
            var tabla = NArea.ListarArea();

            if (tabla.Rows.Count > 0)
            {
                cboArea.DataSource = tabla;
                cboArea.DisplayMember = "nombre";
                cboArea.ValueMember = "idarea";
            }
            cboTipoDoc.SelectedIndex = 0;
            txtCorrelativo.Text = "";
            estiloDgv();
            NumeroComprobante();
            dgvMacota.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvDetalleCita.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
           

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
            if (string.IsNullOrEmpty(txtBuscar.Text))
            {
                txtBuscar.Focus();
                epCita.SetError(txtBuscar, "ingrese dni para buscar");
            }

            else
            {
                var tabla = NMascota.BuscarMascota(txtBuscar.Text);
                int numFil = tabla.Rows.Count;
                if (numFil > 0)
                {
                    epCita.Clear();
                    txtCliente.Text = tabla.Rows[0]["nombres"].ToString() + " " + tabla.Rows[0]["apellidos"].ToString();
                    _idCliente = Convert.ToInt16(tabla.Rows[0]["idcliente"].ToString());

                    for (int i = 0; i < numFil; i++)
                    {
                        string codmascota = tabla.Rows[i]["codigo"].ToString();
                        string mascota = tabla.Rows[i]["nombre"].ToString();
                        string edad = tabla.Rows[i]["edad"].ToString();
                        string peso = tabla.Rows[i]["peso"].ToString();
                        string especie = tabla.Rows[i]["especie"].ToString();
                        string raza = tabla.Rows[i]["raza"].ToString();
                        int idMascota = Convert.ToInt32(tabla.Rows[i]["idmascota"].ToString());
                        int idCliente = Convert.ToInt32(tabla.Rows[i]["idcliente"].ToString());
                        dgvMacota.Rows.Add(codmascota, mascota, edad, peso, especie, raza, idMascota, idCliente);
                    }

                }
                else
                {
                    epCita.Clear();
                    txtBuscar.Focus();
                    epCita.SetError(txtCliente, "No encontrado pulse en + para registrarlo");
                    txtCliente.Text = string.Empty;
                    dgvMacota.Rows.Clear();
                }
            }
        }
        int posicion = 0;
        private void dgvMacota_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            posicion = dgvMacota.CurrentRow.Index;
            _idMascota = Convert.ToInt32(dgvMacota[6, posicion].Value.ToString());          
            txtId.Text = dgvMacota[6, posicion].Value.ToString();
            txtMascota.Text = dgvMacota[1, posicion].Value.ToString();
            txtCodigo.Text = dgvMacota[0, posicion].Value.ToString();
            var tabla = NMascota.BuscarMascotaId(_idMascota);
            if (tabla.Rows.Count!=0)
            {
                byte[] img = (byte[])tabla.Rows[0]["imagen"];
                var ms = new MemoryStream(img);
                pbFoto.Image = Image.FromStream(ms);              

            }          
        }
        private void LimpiarAgregar() {
            txtMotivo.Text = string.Empty;
            txtSintoma.Text = string.Empty;
            pbFoto.Image = null;
           // txtCosto.Text = "0.0";
            txtDescuento.Text = "0.0";
            dtpFecha.Text = string.Empty;
            epCita.Clear();
            _idMascota = 0;
            txtCodigo.Text = "";
            txtMascota.Text = "";
            txtId.Text = "";        
        }
        private void LimpiarGuardar()
        {
            txtBuscar.Text = string.Empty;
            txtCliente.Text = string.Empty;            
            dgvMacota.Rows.Clear();
            dgvDetalleCita.Rows.Clear();
            txtBuscar.Focus();
            epCita.Clear();
            cboTipoDoc.SelectedIndex = 0;
        }
        private void AgregarGrillaDetalle()
        {
            decimal _costo = 0, _descuento = 0, _importe = 0, _suma = 0;
            if (string.IsNullOrEmpty(txtDescuento.Text))
            {
                txtDescuento.Focus();
                epCita.SetError(label13, "ingrese un descuento por el servicio");
            }
            if (string.IsNullOrEmpty(txtDescuento.Text) || Convert.ToDecimal(txtDescuento.Text) > Convert.ToDecimal(txtCosto.Text))
            {
                epCita.Clear();
                txtDescuento.Focus();
                epCita.SetError(label13, "ingrese un descuento no mayor del costo del servicio");
            }         

            else
            {               
                _costo = Convert.ToDecimal(txtCosto.Text);
                _descuento = Convert.ToDecimal(txtDescuento.Text);
                _importe = _costo - _descuento;
                int item = 0;
                int idServicio = Convert.ToInt16(cboServicio.SelectedValue);
                int idEmpleado = Convert.ToInt16(cboEmpleado.SelectedValue);
                dgvDetalleCita.Rows.Add(item, txtCodigo.Text, cboArea.Text, cboServicio.Text, dtpFecha.Text, dtpHora.Text, _costo, _descuento, _importe, txtMotivo.Text, txtSintoma.Text, txtId.Text, _idCliente, idServicio, idEmpleado);
                for (int i = 0; i < dgvDetalleCita.RowCount; i++)
                {
                    _suma += Convert.ToDecimal(dgvDetalleCita.Rows[i].Cells[8].Value);

                    txtTotal.Text = "" + _suma;
                    dgvDetalleCita.Rows[i].Cells[0].Value = i + 1;
                }                
            }
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {

            if (dgvMacota.Rows.Count == 0)
            {
                epCita.Clear();
                txtBuscar.Focus();
                epCita.SetError(txtCliente, "Busque un cliente por el dni");
            }

            else if (string.IsNullOrEmpty(txtCosto.Text))
            {
                epCita.Clear();
                cboServicio.Focus();
                epCita.SetError(label2, "indique el servicio");
            }
            else if (string.IsNullOrEmpty(txtId.Text))
            {
                epCita.Clear();
                txtCodigo.Focus();
                epCita.SetError(txtCodigo, "Debe indicar almenos una mascota");
            }

            else
            {
                int num_filas = dgvDetalleCita.Rows.Count;
               
                if (num_filas == 0 )
                {
                    AgregarGrillaDetalle();
                    LimpiarAgregar();
                }
                else
                {
                    string fecha = dtpFecha.Text;
                    string hora = dtpHora.Text;
                    string codMascot = txtCodigo.Text;
                    string servicio = cboServicio.SelectedValue.ToString();
                    bool existe = false;
                    for (int i = 0; i < num_filas; i++)
                    {
                        if (codMascot.Equals(dgvDetalleCita.Rows[i].Cells[2].Value.ToString())&&fecha.Equals(dgvDetalleCita.Rows[i].Cells[4].Value.ToString()) && hora.Equals(dgvDetalleCita.Rows[i].Cells[5].Value.ToString()))
                        {
                            existe = true;
                            break;
                        }
                        else if(fecha.Equals(dgvDetalleCita.Rows[i].Cells[4].Value.ToString())&& hora.Equals(dgvDetalleCita.Rows[i].Cells[5].Value.ToString()))
                        {
                            existe = true;
                            break;
                        }
                    }
                    if (existe)
                    {
                        MessageBox.Show("ya fue agregado");
                    }
                    else
                    {
                        AgregarGrillaDetalle();
                        LimpiarAgregar();
                    }
                }


            }
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            new frmMascota().ShowDialog();
            
        }
        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsSeparator(e.KeyChar) || char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
            }
            if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                if (string.IsNullOrEmpty(txtBuscar.Text))
                {
                    txtBuscar.Focus();
                    epCita.SetError(txtBuscar, "ingrese dni para buscar");
                }

                else
                {
                    var tabla = NMascota.BuscarMascota(txtBuscar.Text);
                    int numFil = tabla.Rows.Count;
                    if (numFil > 0)
                    {
                        epCita.Clear();
                        txtCliente.Text = tabla.Rows[0]["nombres"].ToString() + " " + tabla.Rows[0]["apellidos"].ToString();
                        _idCliente = Convert.ToInt16(tabla.Rows[0]["idcliente"].ToString());

                        for (int i = 0; i < numFil; i++)
                        {
                            string codmascota = tabla.Rows[i]["codigo"].ToString();
                            string mascota = tabla.Rows[i]["nombre"].ToString();
                            string edad = tabla.Rows[i]["edad"].ToString();
                            string peso = tabla.Rows[i]["peso"].ToString();
                            string especie = tabla.Rows[i]["especie"].ToString();
                            string raza = tabla.Rows[i]["raza"].ToString();
                            int idMascota = Convert.ToInt32(tabla.Rows[i]["idmascota"].ToString());
                            int idCliente = Convert.ToInt32(tabla.Rows[i]["idcliente"].ToString());
                            dgvMacota.Rows.Add(codmascota, mascota, edad, peso, especie, raza, idMascota, idCliente);
                        }

                    }
                    else
                    {
                        epCita.Clear();
                        txtBuscar.Focus();
                        epCita.SetError(txtCliente, "No encontrado pulse en + para registrarlo");
                        txtCliente.Text = string.Empty;
                        dgvMacota.Rows.Clear();
                    }
                }
            }
            else
            {
                epCita.Clear();
                txtBuscar.Focus();
                epCita.SetError(txtCliente, "No encontrado pulse en + para registrarlo");
                txtCliente.Text = string.Empty;
                dgvMacota.Rows.Clear();
            }
        }
        private void txtDescuento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsSeparator(e.KeyChar) || char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
            }
            if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
        }        
        int quit = 0;
        private void cboTipoDoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            NumeroComprobante();
        }
        private void NumeroComprobante()
        {
            DateTime AnioActual = DateTime.Today;
            string cadena = string.Format("{0}", AnioActual.Year).ToString();
            string extraer = cadena.Substring(cadena.Length - 2);

            string simbolo = "0";
            char espacio = Convert.ToChar("0");
            int libre = 8;
            NPagoServicio objPago = new NPagoServicio();
            var pago = NPagoServicio.ListarPagoServicio();
            if (pago.Rows.Count == 0)
            {
                if (cboTipoDoc.SelectedItem.Equals("BOLETA"))
                {
                    epCita.Clear();
                    txtSerie.Text = "00000" + extraer;
                    txtCorrelativo.Text = "000000001";
                }
                /* else if (cboTipoDoc.SelectedItem.Equals("FACTURA"))
                 {
                     epCita.Clear();
                     txtSerie.Text = "0000002";
                     txtCorrelativo.Text = "000000001";
                 }*/
                else
                {
                    txtSerie.Text = "";
                    txtCorrelativo.Text = "";

                }
            }
            else
            {
                if (cboTipoDoc.SelectedItem.Equals("BOLETA"))
                {
                    epCita.Clear();
                    txtSerie.Text = "00000" + extraer;
                    var capcorrelativo = NPagoServicio.GenerarCorrelativo(cboTipoDoc.Text, txtSerie.Text);

                    if (capcorrelativo.Rows.Count > 0)
                    {
                        if (capcorrelativo.Rows[0]["correlativo"].ToString().Length == 0)
                        {
                            txtCorrelativo.Text = "000000001";
                        }
                        if (capcorrelativo.Rows[0]["correlativo"].ToString().Length == 1)
                        {
                            txtCorrelativo.Text = simbolo.PadRight(libre, espacio) + capcorrelativo.Rows[0]["correlativo"].ToString(); ;
                        }
                        else if (capcorrelativo.Rows[0]["correlativo"].ToString().Length == 2 || capcorrelativo.Rows[0]["correlativo"].ToString().Length == 3 || capcorrelativo.Rows[0]["correlativo"].ToString().Length == 4 || capcorrelativo.Rows[0]["correlativo"].ToString().Length == 5 || capcorrelativo.Rows[0]["correlativo"].ToString().Length == 6 || capcorrelativo.Rows[0]["correlativo"].ToString().Length == 7 || capcorrelativo.Rows[0]["correlativo"].ToString().Length == 8)
                        {
                            txtCorrelativo.Text = simbolo.PadRight(libre - capcorrelativo.Rows[0]["correlativo"].ToString().Length, espacio) + capcorrelativo.Rows[0]["correlativo"].ToString();
                        }
                    }
                    else
                    {
                        txtCorrelativo.Text = "000000001";
                    }

                }
                /*else if (cboTipoDoc.SelectedItem.Equals("FACTURA"))
                {
                    epCita.Clear();
                    txtSerie.Text = "0000002";
                    var capcorrelativo = NPagoServicio.GenerarCorrelativo(cboTipoDoc.Text, txtSerie.Text);
                   
                    if (capcorrelativo.Rows.Count > 0)
                    {
                        if (capcorrelativo.Rows[0]["correlativo"].ToString().Length == 1)
                        {
                            txtCorrelativo.Text = simbolo.PadRight(libre, espacio) + capcorrelativo.Rows[0]["correlativo"].ToString(); ;
                        }
                        else if (capcorrelativo.Rows[0]["correlativo"].ToString().Length == 2 || capcorrelativo.Rows[0]["correlativo"].ToString().Length == 3 || capcorrelativo.Rows[0]["correlativo"].ToString().Length == 4 || capcorrelativo.Rows[0]["correlativo"].ToString().Length == 5 || capcorrelativo.Rows[0]["correlativo"].ToString().Length == 6 || capcorrelativo.Rows[0]["correlativo"].ToString().Length == 7 || capcorrelativo.Rows[0]["correlativo"].ToString().Length == 8)
                        {
                            txtCorrelativo.Text = simbolo.PadRight(libre - capcorrelativo.Rows[0]["correlativo"].ToString().Length, espacio) + capcorrelativo.Rows[0]["correlativo"].ToString();
                        }
                    }

                }*/
                else
                {
                    txtSerie.Text = "";
                    txtCorrelativo.Text = "";

                }

            }
        }
        private void lblVerDetalle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmListHorarioDisponible frm = new frmListHorarioDisponible();
            frm.ShowDialog();
        }
        private void dgvDetalleCita_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetalleCita.Rows.Count>0)
            {
                quit = dgvDetalleCita.CurrentRow.Index;
            }
                       
        }
        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dgvDetalleCita.Rows.Count > 0)
            {
                decimal impo = decimal.Parse(dgvDetalleCita.Rows[quit].Cells[8].Value.ToString());
                decimal captotal = decimal.Parse(txtTotal.Text);
                decimal totalquit = captotal - impo;
                txtTotal.Text = "" + totalquit;
                dgvDetalleCita.Rows.Remove(dgvDetalleCita.Rows[quit]);
            }
            
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {        
            
            string rptadetalle = "";
            if (string.IsNullOrEmpty(txtCliente.Text))
            {                
                txtBuscar.Focus();
                epCita.SetError(txtBuscar, "Busque un cliente por el dni");
            }                                   
            else if (string.IsNullOrEmpty(txtSerie.Text))
            {
                epCita.Clear();
                txtSerie.Focus();
                epCita.SetError(cboTipoDoc, "Indique el comprobante a generar");
            }
            else if (string.IsNullOrEmpty(txtSerie.Text))
            {
                epCita.Clear();
                txtCorrelativo.Focus();
                epCita.SetError(cboTipoDoc, "Indique el comprobante a generar");
            }
            else
            {
                int ultimoPagoServicio = NPagoServicio.InsertarPagoServicio(cboTipoDoc.Text, txtSerie.Text);              

                int ultimoidCita = NCita.InsertarCita(ultimoPagoServicio, Program.idUsuario,Convert.ToDecimal(txtTotal.Text));

                int numfilas = dgvDetalleCita.Rows.Count;
               
                for (int i = 0; i < numfilas; i++)
                {
                    int id = ultimoidCita;
                    string fecha = dgvDetalleCita.Rows[i].Cells[4].Value.ToString();
                    string hora = dgvDetalleCita.Rows[i].Cells[5].Value.ToString();
                    decimal dscto = Convert.ToDecimal(dgvDetalleCita.Rows[i].Cells[7].Value.ToString());
                    decimal importe = Convert.ToDecimal(dgvDetalleCita.Rows[i].Cells[8].Value.ToString());
                    string motivo = dgvDetalleCita.Rows[i].Cells[9].Value.ToString();
                    string sintoma = dgvDetalleCita.Rows[i].Cells[10].Value.ToString();
                    int idservis = Convert.ToInt32(dgvDetalleCita.Rows[i].Cells[13].Value.ToString());
                    int idmascota = Convert.ToInt32(dgvDetalleCita.Rows[i].Cells[11].Value.ToString());

                    rptadetalle = NDetalleCita.insertarDetalleCita(id, idmascota,idservis, fecha, hora, motivo, sintoma, dscto, importe);
                    if (rptadetalle!="Ok")
                    {
                        MessageBox.Show("Error");
                    }
                }
                IdComprobante = ultimoidCita;
                MessageBox.Show("okk--"+rptadetalle);
                btnGeneraComprobante.Enabled=true;               
                LimpiarGuardar();
                var tabla = new NCita();
                tabla.ListadoDgv(frmListCita.MiFormListCita.dgvCita);
            }

        }
        private void btnGeneraComprobante_Click(object sender, EventArgs e)
        {
            //int idComprobante = IdComprobante;
            //var frm = new frmComprobanteServicio();
            //frm.IdComprobante = IdComprobante;
            //frm.Show();

        }

    }
}

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

namespace CapaPresentacion
{
    public partial class frmListCliente : Form
    {
        public frmListCliente()
        {
            InitializeComponent();
            if (_miFormListCliente==null)
            {
                _miFormListCliente = this;
            }
        }

        #region interfaz
        private static frmListCliente _miFormListCliente;

        public static frmListCliente MiFormListCliente
        {
            get
            {
                if (_miFormListCliente==null)
                {
                    _miFormListCliente = new frmListCliente();
                }
                return _miFormListCliente;
            }

            set
            {
                _miFormListCliente = value;
            }
        }

        private void frmListCliente_FormClosed(object sender, FormClosedEventArgs e)
        {
            _miFormListCliente = null;
        }

        #endregion
        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            frmCliente frmCliente = new frmCliente();
            frmCliente.ShowDialog();
            dgvCliente.Refresh();

        }

        private void estiloDgv()
        {
            this.dgvCliente.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            this.dgvCliente.DefaultCellStyle.ForeColor = Color.Black;
            this.dgvCliente.DefaultCellStyle.BackColor = Color.White;
            this.dgvCliente.DefaultCellStyle.SelectionForeColor = Color.Black;
            this.dgvCliente.DefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 231, 117);
        }
        private void frmListCliente_Load(object sender, EventArgs e)
        {
            NCliente objCliente = new NCliente();
            objCliente.ListadoDgv(dgvCliente);
            estiloDgv();

            dgvCliente.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvCliente.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvCliente.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvCliente.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvCliente.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;

            dgvCliente.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCliente.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCliente.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCliente.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCliente.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvCliente.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            NCliente objCliente = new NCliente();
            objCliente.ListarBusquedaCliente(dgvCliente, txtBuscar.Text);
        }

        private void dgvCliente_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string sexo = "";
            if (e.RowIndex != -1)
            {

                if (dgvCliente.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Equals("Editar"))
                {
                    int idCliente = Convert.ToInt32(dgvCliente.Rows[e.RowIndex].Cells[1].Value.ToString());

                    
                    frmCliente frmCliente = new frmCliente();
                    frmCliente.Show();

                    var tabla = NCliente.BuscarClienteId(idCliente);

                    frmCliente.MiFormCliente.txtNombres.Text = tabla.Rows[0]["nombres"].ToString();
                    frmCliente.MiFormCliente.txtApellidos.Text = tabla.Rows[0]["apellidos"].ToString();
                    frmCliente.MiFormCliente.txtDni.Text = tabla.Rows[0]["dni"].ToString();
                    sexo = tabla.Rows[0]["sexo"].ToString();
                    if (sexo == "M") frmCliente.MiFormCliente.cboSexo.SelectedItem = "Masculino";
                    else frmCliente.MiFormCliente.cboSexo.SelectedItem = "Femenino";
                    frmCliente.MiFormCliente.txtTelefono.Text = tabla.Rows[0]["telefono"].ToString();
                    frmCliente.MiFormCliente.txtCorreo.Text = tabla.Rows[0]["correo"].ToString();
                    frmCliente.MiFormCliente.txtDireccion.Text = tabla.Rows[0]["direccion"].ToString();
                    byte[] img = (byte[])tabla.Rows[0]["foto"];
                    var ms = new MemoryStream(img);                    
                    frmCliente.MiFormCliente.pbFoto.Image = Image.FromStream(ms);                   

                    frmCliente.MiFormCliente.idCliente = idCliente;
                    frmCliente.MiFormCliente._IsNew = false;
                }
               if (dgvCliente.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Equals("Eliminar"))
                {
                    int idclient = Convert.ToInt32(dgvCliente.Rows[e.RowIndex].Cells[1].Value.ToString());
                    DialogResult rspta = MessageBox.Show("Desea Eliminar", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (DialogResult.Yes == rspta)
                    {
                        var rpta = NCliente.EliminarCliente(idclient);

                        if (rpta == "Ok")
                        {
                            MessageBox.Show(rpta + "---Elimado");
                            dgvCliente.Rows.RemoveAt(e.RowIndex);
                            NCliente objCliente = new NCliente();
                            objCliente.ListadoDgv(dgvCliente);
                            dgvCliente.Refresh();
                        }
                        else MessageBox.Show("error");

                        

                    }
                }
                if (dgvCliente.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Equals("Ver"))
                {

                    int idCliente = Convert.ToInt32(dgvCliente.Rows[e.RowIndex].Cells[1].Value.ToString());

                    frmPerfil perfil = new frmPerfil();
                    perfil.Show();

                    var tabla = NCliente.BuscarClienteId(idCliente);

                    if (tabla.Rows.Count > 0)
                    {
                        sexo = tabla.Rows[0]["sexo"].ToString();
                        if (sexo == "M") sexo = "Masculino";
                        else sexo = "Femenino";

                        frmPerfil.MiFormPerfil.listDatos.Items.Add("Nombre:     " + tabla.Rows[0]["nombres"].ToString());
                        frmPerfil.MiFormPerfil.listDatos.Items.Add("");
                        frmPerfil.MiFormPerfil.listDatos.Items.Add("Apellidos:  " + tabla.Rows[0]["apellidos"].ToString());
                        frmPerfil.MiFormPerfil.listDatos.Items.Add("");
                        frmPerfil.MiFormPerfil.listDatos.Items.Add("Dni:        " + tabla.Rows[0]["dni"].ToString());
                        frmPerfil.MiFormPerfil.listDatos.Items.Add("");
                        frmPerfil.MiFormPerfil.listDatos.Items.Add("Sexo:       " + sexo);
                        frmPerfil.MiFormPerfil.listDatos.Items.Add("");
                        frmPerfil.MiFormPerfil.listDatos.Items.Add("Teléfono:   " + tabla.Rows[0]["telefono"].ToString());
                        frmPerfil.MiFormPerfil.listDatos.Items.Add("");
                        frmPerfil.MiFormPerfil.listDatos.Items.Add("Correo:     " + tabla.Rows[0]["correo"].ToString());
                        frmPerfil.MiFormPerfil.listDatos.Items.Add("");
                        frmPerfil.MiFormPerfil.listDatos.Items.Add("Dirección:  " + tabla.Rows[0]["direccion"].ToString());

                        byte[] img = (byte[])tabla.Rows[0]["foto"];
                        var ms = new MemoryStream(img);
                        frmPerfil.MiFormPerfil.pbFoto.Image = Image.FromStream(ms);
                        frmPerfil.MiFormPerfil.lblTitulo.Text = "Datos Cliente";
                    }
                }
            }
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            NCliente objCliente = new NCliente();
            objCliente.ListarBusquedaCliente(dgvCliente, txtBuscar.Text);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            NCliente objCliente = new NCliente();
            objCliente.ListadoDgv(dgvCliente);
        }
    }
}

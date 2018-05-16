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
    public partial class frmListEmpleado : Form
    {
        public frmListEmpleado()
        {
            InitializeComponent();
            if (_miFormListEmpleado==null)
            {
                _miFormListEmpleado = this;
            }
        }

        #region interfaz
        private static frmListEmpleado _miFormListEmpleado;

        public static frmListEmpleado MiFormListEmpleado
        {
            get
            {
                if (_miFormListEmpleado==null)
                {
                    _miFormListEmpleado = new frmListEmpleado();
                }
                return _miFormListEmpleado;
            }

            set
            {
                _miFormListEmpleado = value;
            }
        }

        private void frmListEmpleado_FormClosed(object sender, FormClosedEventArgs e)
        {
            _miFormListEmpleado = null;
        }
        #endregion

        private void frmListEmpleado_Load(object sender, EventArgs e)
        {
            NEmpleado objEmpleado = new NEmpleado();
            objEmpleado.ListadoDgv(dgvEmpleado);
            estiloDgv();

            dgvEmpleado.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvEmpleado.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvEmpleado.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvEmpleado.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvEmpleado.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvEmpleado.Columns[12].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvEmpleado.Columns[13].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;

            dgvEmpleado.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvEmpleado.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvEmpleado.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvEmpleado.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvEmpleado.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvEmpleado.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvEmpleado.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvEmpleado.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);



        }

        private void estiloDgv()
        {
            this.dgvEmpleado.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            this.dgvEmpleado.DefaultCellStyle.ForeColor = Color.Black;
            this.dgvEmpleado.DefaultCellStyle.BackColor = Color.White;
            this.dgvEmpleado.DefaultCellStyle.SelectionForeColor = Color.Black;
            this.dgvEmpleado.DefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 231, 117);
        }

        private void btnNuevoEmpleado_Click(object sender, EventArgs e)
        {
            frmEmpleado frmEmpleado = new frmEmpleado();
            frmEmpleado.ShowDialog();
            dgvEmpleado.Refresh();
        }

        private void dgvEmpleado_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string sexo = "";
            if (e.RowIndex != -1)
            {
                if (dgvEmpleado.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Equals("Crear cuenta"))
                {
                    frmUsuario frmUser = new frmUsuario();
                    int idempplead = Convert.ToInt32(dgvEmpleado.Rows[e.RowIndex].Cells[1].Value.ToString());
                    var user = NUsusario.BuscarUsuarioIdEmpleado(idempplead);
                    if (user.Rows.Count>0)
                    {
                        if (idempplead==Convert.ToInt32(user.Rows[0]["idempleado"].ToString()))
                        {
                            MessageBox.Show("ya tiene una cuenta");
                        }
                        else
                        {
                            frmUser.Show();
                            var tabla = NEmpleado.BuscarEmpleadoId(idempplead);

                            frmUsuario.MiFormUsuario._idEmpleado = int.Parse(tabla.Rows[0]["idempleado"].ToString());
                            frmUsuario.MiFormUsuario.txtUsuario.Text = tabla.Rows[0]["correo"].ToString();
                        }
                    }
                    else
                    {
                        frmUser.Show();
                        var tabla = NEmpleado.BuscarEmpleadoId(idempplead);

                        frmUsuario.MiFormUsuario._idEmpleado = int.Parse(tabla.Rows[0]["idempleado"].ToString());
                        frmUsuario.MiFormUsuario.txtUsuario.Text = tabla.Rows[0]["correo"].ToString();
                    }                   
                   

                }

                if (dgvEmpleado.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Equals("Editar"))
                {
                    int idEmpleado = Convert.ToInt32(dgvEmpleado.Rows[e.RowIndex].Cells[1].Value.ToString());


                    frmEmpleado frmEmpleado = new frmEmpleado();
                    frmEmpleado.Show();

                    var tabla = NEmpleado.BuscarEmpleadoId(idEmpleado);

                    frmEmpleado.MiFormEmpleado.txtNombres.Text = tabla.Rows[0]["nombres"].ToString();
                    frmEmpleado.MiFormEmpleado.txtApellidos.Text = tabla.Rows[0]["apellidos"].ToString();
                    frmEmpleado.MiFormEmpleado.txtDni.Text = tabla.Rows[0]["dni"].ToString();
                    sexo = tabla.Rows[0]["sexo"].ToString();
                    if (sexo == "M") frmEmpleado.MiFormEmpleado.cboSexo.SelectedItem = "Masculino";
                    else frmEmpleado.MiFormEmpleado.cboSexo.SelectedItem = "Femenino";
                    frmEmpleado.MiFormEmpleado.txtTelefono.Text = tabla.Rows[0]["telefono"].ToString();
                    frmEmpleado.MiFormEmpleado.txtCorreo.Text = tabla.Rows[0]["correo"].ToString();
                    frmEmpleado.MiFormEmpleado.txtDireccion.Text = tabla.Rows[0]["direccion"].ToString();
                    frmEmpleado.MiFormEmpleado.cboArea.SelectedValue = tabla.Rows[0]["idarea"].ToString();
                    byte[] img = (byte[])tabla.Rows[0]["foto"];
                    var ms = new MemoryStream(img);
                    frmEmpleado.MiFormEmpleado.pbFoto.Image = Image.FromStream(ms);

                    frmEmpleado.MiFormEmpleado.idEmpleado = idEmpleado;
                    frmEmpleado.MiFormEmpleado._IsNew = false;
                    frmEmpleado.MiFormEmpleado.cboArea.Enabled = true;
                }                

                if (dgvEmpleado.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Equals("Eliminar"))
                {
                    int idempplead = Convert.ToInt32(dgvEmpleado.Rows[e.RowIndex].Cells[1].Value.ToString());
                    DialogResult rspta = MessageBox.Show("Desea Eliminar", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (DialogResult.Yes == rspta)
                    {
                        var rpta = NEmpleado.EliminarEmpleado(idempplead);

                        if (rpta == "Ok")
                        {
                            MessageBox.Show(rpta + "---Elimado");
                            dgvEmpleado.Rows.RemoveAt(e.RowIndex);
                            NEmpleado objEmpleado = new NEmpleado();
                            objEmpleado.ListadoDgv(dgvEmpleado);
                        }
                        else MessageBox.Show("error");



                    }
                }
                if (dgvEmpleado.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Equals("Ver"))
                {
                   
                    int idEmpleado = Convert.ToInt32(dgvEmpleado.Rows[e.RowIndex].Cells[1].Value.ToString());


                    frmPerfil perfil = new frmPerfil();
                    perfil.Show();

                    var tabla = NEmpleado.BuscarEmpleadoId(idEmpleado);
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
                    frmPerfil.MiFormPerfil.listDatos.Items.Add("");
                    frmPerfil.MiFormPerfil.listDatos.Items.Add("Area:       " + tabla.Rows[0]["area"].ToString());

                    byte[] img = (byte[])tabla.Rows[0]["foto"];
                     var ms = new MemoryStream(img);
                     frmPerfil.MiFormPerfil.pbFoto.Image = Image.FromStream(ms);
                     frmPerfil.MiFormPerfil.lblTitulo.Text = "Datos Empleado";
                   
                }
            }
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            NEmpleado objCliente = new NEmpleado();
            objCliente.ListarBusquedaEmpleado(dgvEmpleado, txtBuscar.Text);

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            NEmpleado objEmpleado = new NEmpleado();
            objEmpleado.ListadoDgv(dgvEmpleado);
        }
    }
}

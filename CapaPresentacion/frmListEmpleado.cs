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
            
        }

        private void btnNuevoEmpleado_Click(object sender, EventArgs e)
        {
            frmEmpleado frmEmpleado = new frmEmpleado();
            frmEmpleado.ShowDialog();
        }

        private void dgvEmpleado_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string sexo = "";
            if (e.RowIndex != -1)
            {
                if (dgvEmpleado.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Equals("Crear Cuenta"))
                {
                    int idempplead = Convert.ToInt32(dgvEmpleado.Rows[e.RowIndex].Cells[2].Value.ToString());
                    DialogResult rspta = MessageBox.Show("Desea crear cuenta de usuario?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (DialogResult.Yes == rspta)
                    {
                        frmUsuario frmUser = new frmUsuario();
                        frmUser.Show();
                        var tabla = NEmpleado.BuscarEmpleadoId(idempplead);

                        frmUsuario.MiFormUsuario._idEmpleado = int.Parse(tabla.Rows[0]["idempleado"].ToString());
                        frmUsuario.MiFormUsuario.txtUsuario.Text = tabla.Rows[0]["correo"].ToString();
                    }
                }

                if (dgvEmpleado.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Equals("Editar"))
                {
                    int idEmpleado = Convert.ToInt32(dgvEmpleado.Rows[e.RowIndex].Cells[2].Value.ToString());


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
                    byte[] img = (byte[])tabla.Rows[0]["foto"];
                    var ms = new MemoryStream(img);
                    frmEmpleado.MiFormEmpleado.pbFoto.Image = Image.FromStream(ms);

                    frmEmpleado.MiFormEmpleado.idEmpleado = idEmpleado;
                    frmEmpleado.MiFormEmpleado._IsNew = false;
                }                

                if (dgvEmpleado.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Equals("Eliminar"))
                {
                    int idempplead = Convert.ToInt32(dgvEmpleado.Rows[e.RowIndex].Cells[2].Value.ToString());
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

                    int idEmpleado = Convert.ToInt32(dgvEmpleado.Rows[e.RowIndex].Cells[2].Value.ToString());


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
                    byte[] img = (byte[])tabla.Rows[0]["foto"];
                    var ms = new MemoryStream(img);
                    frmEmpleado.MiFormEmpleado.pbFoto.Image = Image.FromStream(ms);

                    frmEmpleado.MiFormEmpleado.idEmpleado = idEmpleado;
                    frmEmpleado.MiFormEmpleado._IsNew = true;
                    frmEmpleado.MiFormEmpleado.txtNombres.Enabled = false;
                    frmEmpleado.MiFormEmpleado.txtApellidos.Enabled = false;
                    frmEmpleado.MiFormEmpleado.txtDni.Enabled = false;
                    frmEmpleado.MiFormEmpleado.cboSexo.Enabled = false;
                    frmEmpleado.MiFormEmpleado.txtTelefono.Enabled = false;
                    frmEmpleado.MiFormEmpleado.txtCorreo.Enabled = false;
                    frmEmpleado.MiFormEmpleado.txtDireccion.Enabled = false;
                    frmEmpleado.MiFormEmpleado.btnExaminar.Visible = false;
                    frmEmpleado.MiFormEmpleado.btnGuardar.Visible = false;
                    frmEmpleado.MiFormEmpleado.btnCancelar.Visible = false;                  
                }
            }
        }
    }
}

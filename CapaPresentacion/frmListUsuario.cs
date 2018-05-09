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
    public partial class frmListUsuario : Form
    {
        public frmListUsuario()
        {
            InitializeComponent();
            if (_miFormLisUsuario==null)
            {
                _miFormLisUsuario = this;
            }
        }

        #region interfaz

        private static frmListUsuario _miFormLisUsuario;

        public static frmListUsuario MiFormLisUsuario
        {
            get
            {
                if (_miFormLisUsuario==null)
                {
                    _miFormLisUsuario = new frmListUsuario();
                }
                return _miFormLisUsuario;
            }

            set
            {
                _miFormLisUsuario = value;
            }
        }

        private void frmListUsuario_FormClosed(object sender, FormClosedEventArgs e)
        {
            _miFormLisUsuario = null;
        }




        #endregion

        private void estiloDgv()
        {
            this.dgvUsuario.DefaultCellStyle.Font = new Font("Arial", 9);
            this.dgvUsuario.DefaultCellStyle.ForeColor = Color.Black;
            this.dgvUsuario.DefaultCellStyle.BackColor = Color.White;
            this.dgvUsuario.DefaultCellStyle.SelectionForeColor = Color.Black;
            this.dgvUsuario.DefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 231, 117);
        }
        private void frmListUsuario_Load(object sender, EventArgs e)
        {
            NUsusario objUser = new NUsusario();
            objUser.ListadoDgv(dgvUsuario);
            estiloDgv();

            dgvUsuario.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;            
            dgvUsuario.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvUsuario.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvUsuario.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvUsuario.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;

            dgvUsuario.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;            
            dgvUsuario.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvUsuario.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvUsuario.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvUsuario.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvUsuario.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
        }

        

        private void dgvUsuario_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string sexo = "";

            if (e.RowIndex != -1)
            {
                if (dgvUsuario.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Equals("Activar") || dgvUsuario.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Equals("Desactivar"))
                {
                    try
                    {
                        string estado = dgvUsuario.Rows[e.RowIndex].Cells[7].Value.ToString();
                        int iduser = Convert.ToInt32(dgvUsuario.Rows[e.RowIndex].Cells[1].Value.ToString());

                        NUsusario objUser = new NUsusario();
                        if (NUsusario.ActualizarEstadoUsuario(estado.Equals("Desactivar") ? 0 : 1, iduser)) objUser.ListadoDgv(dgvUsuario);

                        else MessageBox.Show("Error al controlar el estado");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        throw;
                    }

                }

                if (dgvUsuario.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Equals("Editar"))
                {
                    int idUser = Convert.ToInt32(dgvUsuario.Rows[e.RowIndex].Cells[1].Value.ToString());
                    
                        frmUsuario frmUser = new frmUsuario();
                        frmUser.Show();
                        var tabla = NUsusario.BuscarUsuarioId(idUser);

                        frmUsuario.MiFormUsuario._isNew = false;   
                        frmUsuario.MiFormUsuario._idUsuario = idUser;                       
                        frmUsuario.MiFormUsuario.txtUsuario.Text = tabla.Rows[0]["usuario"].ToString();
                        frmUsuario.MiFormUsuario.txtPassword.Text = tabla.Rows[0]["pasword"].ToString();
                        frmUsuario.MiFormUsuario.cboTipo.SelectedItem = tabla.Rows[0]["tipo"].ToString();
                        frmUsuario.MiFormUsuario._idEmpleado = int.Parse(tabla.Rows[0]["idempleado"].ToString());

                        dgvUsuario.Refresh();

                }

                if (dgvUsuario.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Equals("Eliminar"))
                {
                    int iduser = Convert.ToInt32(dgvUsuario.Rows[e.RowIndex].Cells[1].Value.ToString());
                    DialogResult rspta = MessageBox.Show("Desea Eliminar", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (DialogResult.Yes == rspta)
                    {
                        var rpta = NUsusario.EliminarUsuario(iduser);

                        if (rpta == "Ok")
                        {
                            MessageBox.Show(rpta + "---Elimado");
                            dgvUsuario.Rows.RemoveAt(e.RowIndex);
                            NUsusario objUser = new NUsusario();
                            objUser.ListadoDgv(dgvUsuario);
                        }
                        else MessageBox.Show("error");
                    }
                }

                if (dgvUsuario.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Equals("Ver"))
                {
                    
                    DialogResult rspta = MessageBox.Show("Desea Desencripar la contraseña", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (DialogResult.Yes == rspta)
                    {
                        int idUser = Convert.ToInt32(dgvUsuario.Rows[e.RowIndex].Cells[1].Value.ToString());


                        frmPerfil perfil = new frmPerfil();
                        perfil.Show();

                        var tabla = NUsusario.BuscarUsuarioId(idUser);
                        frmPerfil.MiFormPerfil.lblUsuario.Text = tabla.Rows[0]["username"].ToString();                         
                        frmPerfil.MiFormPerfil.lblPassword.Text = tabla.Rows[0]["pasword"].ToString();
                        frmPerfil.MiFormPerfil.lblTipo.Text = tabla.Rows[0]["tipo"].ToString();
                        string captura = tabla.Rows[0]["estado"].ToString();
                        frmPerfil.MiFormPerfil.lblEstadoUser.Visible = true;
                        if (captura=="1")
                        {
                            frmPerfil.MiFormPerfil.lblEstadoUser.Text = "Activo";
                            frmPerfil.MiFormPerfil.lblEstadoUser.ForeColor = Color.Green;
                        }
                        else
                        {
                            frmPerfil.MiFormPerfil.lblEstadoUser.Text = "Inactivo";
                            frmPerfil.MiFormPerfil.lblEstadoUser.ForeColor = Color.Red;
                        }
                        frmPerfil.MiFormPerfil.lblNombre.Text = tabla.Rows[0]["nombres"].ToString();
                        frmPerfil.MiFormPerfil.lblApellidos.Text = tabla.Rows[0]["apellidos"].ToString();
                        frmPerfil.MiFormPerfil.lblDni.Text = tabla.Rows[0]["dni"].ToString();
                        sexo = tabla.Rows[0]["sexo"].ToString();
                        if (sexo == "M") frmPerfil.MiFormPerfil.lblSexo.Text = "Masculino";
                        else frmPerfil.MiFormPerfil.lblSexo.Text = "Femenino";
                        frmPerfil.MiFormPerfil.lblTelefono.Text = tabla.Rows[0]["telefono"].ToString();
                        frmPerfil.MiFormPerfil.lblCorreo.Text = tabla.Rows[0]["correo"].ToString();
                        frmPerfil.MiFormPerfil.lblDireccion.Text = tabla.Rows[0]["direccion"].ToString();
                        byte[] img = (byte[])tabla.Rows[0]["foto"];
                        var ms = new MemoryStream(img);
                        frmPerfil.MiFormPerfil.pbFoto.Image = Image.FromStream(ms);
                        frmPerfil.MiFormPerfil.lblTitulo.Text = "Datos Usuario";
                        frmPerfil.MiFormPerfil.label9.Visible = true;
                        frmPerfil.MiFormPerfil.lblTipo.Visible = true;
                        frmPerfil.MiFormPerfil.label11.Visible = true;
                        frmPerfil.MiFormPerfil.label12.Visible = true;
                        frmPerfil.MiFormPerfil.lblUsuario.Visible = true;
                        frmPerfil.MiFormPerfil.lblPassword.Visible = true;
                        
                    }
                }
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            NUsusario objUser = new NUsusario();
            objUser.ListarBusquedaUsuario(dgvUsuario, txtBuscar.Text.Trim());
        }
    }
}

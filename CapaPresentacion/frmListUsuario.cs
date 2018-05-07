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

        private void frmListUsuario_Load(object sender, EventArgs e)
        {
            NUsusario objUser = new NUsusario();
            objUser.ListadoDgv(dgvUsuario);
        }

        private void dgvUsuario_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

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
                    string estado = "";
                    string personal = dgvUsuario.Rows[e.RowIndex].Cells[2].Value.ToString();
                    string usuario = dgvUsuario.Rows[e.RowIndex].Cells[3].Value.ToString();
                    string pass = dgvUsuario.Rows[e.RowIndex].Cells[4].Value.ToString();
                    string tipo = dgvUsuario.Rows[e.RowIndex].Cells[5].Value.ToString();
                    string captura = dgvUsuario.Rows[e.RowIndex].Cells[7].Value.ToString();
                    if (captura.Equals("Desactivar")) estado = "Activo";
                    else estado = "Inactivo";
                    DialogResult rspta = MessageBox.Show("Desea Desencripar la contraseña", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (DialogResult.Yes == rspta)
                    {
                        string desencripatado = NUsusario.DesencriptarPass(pass);

                        MessageBox.Show("Personal: " + personal + "\n" +
                                        "Usuario: " + usuario + "\n" +
                                        "Contraseña: " + desencripatado + "\n" +
                                        "Tipo de Usuario: " + tipo + "\n" +
                                        "Estado: " + estado + "\n"
                                        , "Informacion del Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

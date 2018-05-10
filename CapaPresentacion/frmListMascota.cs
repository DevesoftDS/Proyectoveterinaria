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
    public partial class frmListMascota : Form
    {
        public frmListMascota()
        {
            InitializeComponent();
            if (_miFormListMascota==null)
            {
                _miFormListMascota = this;
            }
        }

        #region interfaz
        private static frmListMascota _miFormListMascota;

        public static frmListMascota MiFormListMascota
        {
            get
            {
                if (_miFormListMascota==null)
                {
                    _miFormListMascota = new frmListMascota();
                }
                return _miFormListMascota;
            }

            set
            {
                _miFormListMascota = value;
            }
        }

        private void frmListMascota_FormClosed(object sender, FormClosedEventArgs e)
        {
            _miFormListMascota = null;
        }
        #endregion

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmMascota fMascota = new frmMascota();
            fMascota.ShowDialog();
            dgvMascota.Refresh();
        }
        private void estiloDgv()
        {
            this.dgvMascota.DefaultCellStyle.Font = new Font("Arial", 9);
            this.dgvMascota.DefaultCellStyle.ForeColor = Color.Black;
            this.dgvMascota.DefaultCellStyle.BackColor = Color.White;
            this.dgvMascota.DefaultCellStyle.SelectionForeColor = Color.Black;
            this.dgvMascota.DefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 231, 117);
        }
        private void frmListMascota_Load(object sender, EventArgs e)
        {
            NMascota objMascota = new NMascota();
            objMascota.ListadoDgv(dgvMascota);

            dgvMascota.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvMascota.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvMascota.Columns[13].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvMascota.Columns[14].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvMascota.Columns[15].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;

            dgvMascota.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvMascota.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvMascota.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvMascota.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvMascota.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;            

            dgvMascota.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
        }
        

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            NMascota objMascota = new NMascota();
            objMascota.ListarBusquedaMascota(dgvMascota, txtBuscar.Text);
        }

        private void dgvMascota_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)        {
            
            if (e.RowIndex != -1)
            {

                if (dgvMascota.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Equals("Editar"))
                {
                    int idmascota = Convert.ToInt32(dgvMascota.Rows[e.RowIndex].Cells[1].Value.ToString());


                    frmMascota fMascota = new frmMascota();
                    fMascota.Show();

                    var tabla = NMascota.BuscarMascotaId(idmascota);

                    frmMascota.MiFormMascota.txtCodigo.Text = tabla.Rows[0]["codigo"].ToString();
                    frmMascota.MiFormMascota.txtCliente.Text = tabla.Rows[0]["nombres"].ToString() +" "+ tabla.Rows[0]["apellidos"].ToString();                    
                    frmMascota.MiFormMascota.txtNombre.Text = tabla.Rows[0]["nombre"].ToString();
                    frmMascota.MiFormMascota.txtEdad.Text = tabla.Rows[0]["edad"].ToString();
                    frmMascota.MiFormMascota.txtPeso.Text = tabla.Rows[0]["peso"].ToString();
                    frmMascota.MiFormMascota.cboSexo.SelectedItem = tabla.Rows[0]["sexo"].ToString();
                    frmMascota.MiFormMascota.cboEspecie.SelectedValue = tabla.Rows[0]["idespecie"].ToString();
                    frmMascota.MiFormMascota.cboRaza.SelectedValue= tabla.Rows[0]["idraza"].ToString();
                    frmMascota.MiFormMascota.txtDescripcion.Text = tabla.Rows[0]["descripcion"].ToString();
                    byte[] img = (byte[])tabla.Rows[0]["imagen"];
                    var ms = new MemoryStream(img);
                    frmMascota.MiFormMascota.pbFoto.Image = Image.FromStream(ms);
                    frmMascota.MiFormMascota._idMascota = idmascota;
                    frmMascota.MiFormMascota._idCliente = Convert.ToInt32(tabla.Rows[0]["idcliente"].ToString());
                   /* frmMascota.MiFormMascota._idRaza = Convert.ToInt32(tabla.Rows[0]["idraza"].ToString());*/
                    frmMascota.MiFormMascota._IsNew = false;
                    frmMascota.MiFormMascota.txtBuscar.Enabled = false;
                    frmMascota.MiFormMascota.cboEspecie.Enabled = false;
                    frmMascota.MiFormMascota.cboRaza.Enabled = false;
                    frmMascota.MiFormMascota.cboSexo.Enabled = false;

                }
                if (dgvMascota.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Equals("Eliminar"))
                {
                    int idmascota = Convert.ToInt32(dgvMascota.Rows[e.RowIndex].Cells[1].Value.ToString());
                    DialogResult rspta = MessageBox.Show("Desea Eliminar", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (DialogResult.Yes == rspta)
                    {
                        var rpta = NMascota.EliminarMascota(idmascota);

                        if (rpta == "Ok")
                        {
                            MessageBox.Show(rpta + "---Elimado");
                            dgvMascota.Rows.RemoveAt(e.RowIndex);
                            NMascota objMascota = new NMascota();
                            objMascota.ListadoDgv(dgvMascota);
                            dgvMascota.Refresh();
                        }
                        else MessageBox.Show("error");



                    }
                }
                if (dgvMascota.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Equals("Ver"))
                {

                    int idmascota = Convert.ToInt32(dgvMascota.Rows[e.RowIndex].Cells[1].Value.ToString());


                    frmPerfil perfil = new frmPerfil();
                    perfil.Show();

                    var tabla = NMascota.BuscarMascotaId(idmascota);
                    
                    frmPerfil.MiFormPerfil.listDatos.Items.Add("Nombre:     " + tabla.Rows[0]["nombres"].ToString());
                    frmPerfil.MiFormPerfil.listDatos.Items.Add("");
                    frmPerfil.MiFormPerfil.listDatos.Items.Add("Apellidos:  " + tabla.Rows[0]["apellidos"].ToString());
                    frmPerfil.MiFormPerfil.listDatos.Items.Add("");
                    frmPerfil.MiFormPerfil.listDatos.Items.Add("Telefono:   " + tabla.Rows[0]["telefono"].ToString());
                    frmPerfil.MiFormPerfil.listDatos.Items.Add("");
                    frmPerfil.MiFormPerfil.listDatos.Items.Add("Codigo:     " + tabla.Rows[0]["codigo"].ToString());
                    frmPerfil.MiFormPerfil.listDatos.Items.Add("");
                    frmPerfil.MiFormPerfil.listDatos.Items.Add("Nombre:     " + tabla.Rows[0]["nombre"].ToString());
                    frmPerfil.MiFormPerfil.listDatos.Items.Add("");
                    frmPerfil.MiFormPerfil.listDatos.Items.Add("Edad:       " + tabla.Rows[0]["edad"].ToString());
                    frmPerfil.MiFormPerfil.listDatos.Items.Add("");
                    frmPerfil.MiFormPerfil.listDatos.Items.Add("Peso:       " + tabla.Rows[0]["peso"].ToString());
                    frmPerfil.MiFormPerfil.listDatos.Items.Add("");
                    frmPerfil.MiFormPerfil.listDatos.Items.Add("Especie:    " + tabla.Rows[0]["especie"].ToString());
                    frmPerfil.MiFormPerfil.listDatos.Items.Add("");
                    frmPerfil.MiFormPerfil.listDatos.Items.Add("Raza:       " + tabla.Rows[0]["raza"].ToString());

                    byte[] img = (byte[])tabla.Rows[0]["imagen"];
                    var ms = new MemoryStream(img);
                    frmPerfil.MiFormPerfil.pbFoto.Image = Image.FromStream(ms);
                    frmPerfil.MiFormPerfil.lblTitulo.Text = "Datos Dueño - Mascota";

                }
            }
        }
    }
}

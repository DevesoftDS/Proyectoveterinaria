namespace CapaPresentacion
{
    partial class frmListEmpleado
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListEmpleado));
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvEmpleado = new System.Windows.Forms.DataGridView();
            this.item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombres = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apellidos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dni = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sexo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.correo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Direccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.area = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.crearCuenta = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Editar = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Eliminar = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Ver = new System.Windows.Forms.DataGridViewLinkColumn();
            this.idarea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNuevoEmpleado = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpleado)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.dgvEmpleado);
            this.panel1.Location = new System.Drawing.Point(0, 71);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(834, 441);
            this.panel1.TabIndex = 23;
            // 
            // dgvEmpleado
            // 
            this.dgvEmpleado.AllowUserToAddRows = false;
            this.dgvEmpleado.AllowUserToDeleteRows = false;
            this.dgvEmpleado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEmpleado.BackgroundColor = System.Drawing.Color.White;
            this.dgvEmpleado.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvEmpleado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmpleado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.item,
            this.codigo,
            this.nombres,
            this.apellidos,
            this.dni,
            this.sexo,
            this.telefono,
            this.correo,
            this.Direccion,
            this.area,
            this.crearCuenta,
            this.Editar,
            this.Eliminar,
            this.Ver,
            this.idarea});
            this.dgvEmpleado.Location = new System.Drawing.Point(3, 4);
            this.dgvEmpleado.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvEmpleado.Name = "dgvEmpleado";
            this.dgvEmpleado.ReadOnly = true;
            this.dgvEmpleado.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgvEmpleado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEmpleado.Size = new System.Drawing.Size(824, 430);
            this.dgvEmpleado.TabIndex = 0;
            this.dgvEmpleado.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvEmpleado_CellMouseDoubleClick);
            // 
            // item
            // 
            this.item.HeaderText = "#";
            this.item.Name = "item";
            this.item.ReadOnly = true;
            this.item.Width = 50;
            // 
            // codigo
            // 
            this.codigo.HeaderText = "Código";
            this.codigo.Name = "codigo";
            this.codigo.ReadOnly = true;
            this.codigo.Visible = false;
            this.codigo.Width = 60;
            // 
            // nombres
            // 
            dataGridViewCellStyle13.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.nombres.DefaultCellStyle = dataGridViewCellStyle13;
            this.nombres.HeaderText = "Nombres";
            this.nombres.Name = "nombres";
            this.nombres.ReadOnly = true;
            this.nombres.Width = 150;
            // 
            // apellidos
            // 
            dataGridViewCellStyle14.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.apellidos.DefaultCellStyle = dataGridViewCellStyle14;
            this.apellidos.HeaderText = "Apellidos";
            this.apellidos.Name = "apellidos";
            this.apellidos.ReadOnly = true;
            this.apellidos.Width = 200;
            // 
            // dni
            // 
            dataGridViewCellStyle15.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.dni.DefaultCellStyle = dataGridViewCellStyle15;
            this.dni.HeaderText = "Dni";
            this.dni.Name = "dni";
            this.dni.ReadOnly = true;
            this.dni.Width = 150;
            // 
            // sexo
            // 
            this.sexo.HeaderText = "Sexo";
            this.sexo.Name = "sexo";
            this.sexo.ReadOnly = true;
            this.sexo.Width = 60;
            // 
            // telefono
            // 
            dataGridViewCellStyle16.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.telefono.DefaultCellStyle = dataGridViewCellStyle16;
            this.telefono.HeaderText = "Teléfono";
            this.telefono.Name = "telefono";
            this.telefono.ReadOnly = true;
            this.telefono.Width = 120;
            // 
            // correo
            // 
            dataGridViewCellStyle17.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.correo.DefaultCellStyle = dataGridViewCellStyle17;
            this.correo.HeaderText = "Correo";
            this.correo.Name = "correo";
            this.correo.ReadOnly = true;
            this.correo.Visible = false;
            this.correo.Width = 250;
            // 
            // Direccion
            // 
            dataGridViewCellStyle18.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.Direccion.DefaultCellStyle = dataGridViewCellStyle18;
            this.Direccion.HeaderText = "Dirección";
            this.Direccion.Name = "Direccion";
            this.Direccion.ReadOnly = true;
            this.Direccion.Visible = false;
            this.Direccion.Width = 200;
            // 
            // area
            // 
            this.area.HeaderText = "Area";
            this.area.Name = "area";
            this.area.ReadOnly = true;
            // 
            // crearCuenta
            // 
            this.crearCuenta.HeaderText = "Crear Cuenta";
            this.crearCuenta.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(137)))), ((int)(((byte)(16)))));
            this.crearCuenta.Name = "crearCuenta";
            this.crearCuenta.ReadOnly = true;
            this.crearCuenta.Width = 150;
            // 
            // Editar
            // 
            this.Editar.HeaderText = "Editar";
            this.Editar.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(173)))), ((int)(((byte)(226)))));
            this.Editar.Name = "Editar";
            this.Editar.ReadOnly = true;
            this.Editar.Width = 150;
            // 
            // Eliminar
            // 
            this.Eliminar.HeaderText = "Eliminar";
            this.Eliminar.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(57)))), ((int)(((byte)(37)))));
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.ReadOnly = true;
            this.Eliminar.Width = 150;
            // 
            // Ver
            // 
            this.Ver.HeaderText = "Ver";
            this.Ver.LinkColor = System.Drawing.Color.Green;
            this.Ver.Name = "Ver";
            this.Ver.ReadOnly = true;
            this.Ver.Width = 150;
            // 
            // idarea
            // 
            this.idarea.HeaderText = "IdArea";
            this.idarea.Name = "idarea";
            this.idarea.ReadOnly = true;
            this.idarea.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(834, 7);
            this.panel2.TabIndex = 27;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtBuscar.Location = new System.Drawing.Point(149, 28);
            this.txtBuscar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBuscar.MaxLength = 8;
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(431, 25);
            this.txtBuscar.TabIndex = 25;
            this.txtBuscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscar_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(6, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 18);
            this.label1.TabIndex = 24;
            this.label1.Text = "Buscar empleado";
            // 
            // btnNuevoEmpleado
            // 
            this.btnNuevoEmpleado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnNuevoEmpleado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevoEmpleado.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNuevoEmpleado.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevoEmpleado.ForeColor = System.Drawing.Color.White;
            this.btnNuevoEmpleado.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevoEmpleado.Image")));
            this.btnNuevoEmpleado.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNuevoEmpleado.Location = new System.Drawing.Point(636, 23);
            this.btnNuevoEmpleado.Name = "btnNuevoEmpleado";
            this.btnNuevoEmpleado.Size = new System.Drawing.Size(147, 34);
            this.btnNuevoEmpleado.TabIndex = 26;
            this.btnNuevoEmpleado.Text = "Nuevo";
            this.btnNuevoEmpleado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnNuevoEmpleado.Click += new System.EventHandler(this.btnNuevoEmpleado_Click);
            // 
            // frmListEmpleado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 525);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnNuevoEmpleado);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmListEmpleado";
            this.Text = "frmListEmpleado";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmListEmpleado_FormClosed);
            this.Load += new System.EventHandler(this.frmListEmpleado_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpleado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label btnNuevoEmpleado;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.DataGridView dgvEmpleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn item;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombres;
        private System.Windows.Forms.DataGridViewTextBoxColumn apellidos;
        private System.Windows.Forms.DataGridViewTextBoxColumn dni;
        private System.Windows.Forms.DataGridViewTextBoxColumn sexo;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn correo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Direccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn area;
        private System.Windows.Forms.DataGridViewLinkColumn crearCuenta;
        private System.Windows.Forms.DataGridViewLinkColumn Editar;
        private System.Windows.Forms.DataGridViewLinkColumn Eliminar;
        private System.Windows.Forms.DataGridViewLinkColumn Ver;
        private System.Windows.Forms.DataGridViewTextBoxColumn idarea;
    }
}
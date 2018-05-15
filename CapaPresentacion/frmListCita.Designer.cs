namespace CapaPresentacion
{
    partial class frmListCita
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListCita));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnNuevaCita = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvCita = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtpBuscar = new System.Windows.Forms.DateTimePicker();
            this.item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaCita = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombres = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dni = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Direccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.correo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.servicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.importe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCita)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(166)))), ((int)(((byte)(154)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(834, 8);
            this.panel2.TabIndex = 32;
            // 
            // btnNuevaCita
            // 
            this.btnNuevaCita.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(166)))), ((int)(((byte)(154)))));
            this.btnNuevaCita.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevaCita.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNuevaCita.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevaCita.ForeColor = System.Drawing.Color.White;
            this.btnNuevaCita.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevaCita.Image")));
            this.btnNuevaCita.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNuevaCita.Location = new System.Drawing.Point(636, 23);
            this.btnNuevaCita.Name = "btnNuevaCita";
            this.btnNuevaCita.Size = new System.Drawing.Size(147, 34);
            this.btnNuevaCita.TabIndex = 31;
            this.btnNuevaCita.Text = "Nueva Cita";
            this.btnNuevaCita.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnNuevaCita.Click += new System.EventHandler(this.btnNuevaCita_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.ForeColor = System.Drawing.Color.Black;
            this.txtBuscar.Location = new System.Drawing.Point(149, 32);
            this.txtBuscar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBuscar.MaxLength = 8;
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(204, 25);
            this.txtBuscar.TabIndex = 30;
            this.txtBuscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscar_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(5, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 18);
            this.label1.TabIndex = 29;
            this.label1.Text = "Buscar cita";
            // 
            // dgvCita
            // 
            this.dgvCita.AllowUserToAddRows = false;
            this.dgvCita.AllowUserToDeleteRows = false;
            this.dgvCita.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCita.BackgroundColor = System.Drawing.Color.White;
            this.dgvCita.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCita.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCita.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.item,
            this.codigo,
            this.fechaCita,
            this.nombres,
            this.dni,
            this.Direccion,
            this.telefono,
            this.correo,
            this.fecha,
            this.hora,
            this.servicio,
            this.importe,
            this.total});
            this.dgvCita.Location = new System.Drawing.Point(3, 4);
            this.dgvCita.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvCita.Name = "dgvCita";
            this.dgvCita.ReadOnly = true;
            this.dgvCita.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgvCita.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCita.Size = new System.Drawing.Size(825, 431);
            this.dgvCita.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.dgvCita);
            this.panel1.Location = new System.Drawing.Point(0, 72);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(834, 441);
            this.panel1.TabIndex = 28;
            // 
            // dtpBuscar
            // 
            this.dtpBuscar.CustomFormat = "dd-MM-yyyy";
            this.dtpBuscar.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBuscar.Location = new System.Drawing.Point(373, 32);
            this.dtpBuscar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpBuscar.Name = "dtpBuscar";
            this.dtpBuscar.Size = new System.Drawing.Size(201, 27);
            this.dtpBuscar.TabIndex = 33;
            this.dtpBuscar.ValueChanged += new System.EventHandler(this.dtpBuscar_ValueChanged);
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
            this.codigo.HeaderText = "Codigo";
            this.codigo.Name = "codigo";
            this.codigo.ReadOnly = true;
            this.codigo.Width = 60;
            // 
            // fechaCita
            // 
            this.fechaCita.HeaderText = "F_Cita";
            this.fechaCita.Name = "fechaCita";
            this.fechaCita.ReadOnly = true;
            // 
            // nombres
            // 
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.nombres.DefaultCellStyle = dataGridViewCellStyle1;
            this.nombres.HeaderText = "Cliente";
            this.nombres.Name = "nombres";
            this.nombres.ReadOnly = true;
            this.nombres.Width = 250;
            // 
            // dni
            // 
            this.dni.HeaderText = "Dni";
            this.dni.Name = "dni";
            this.dni.ReadOnly = true;
            // 
            // Direccion
            // 
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.Direccion.DefaultCellStyle = dataGridViewCellStyle2;
            this.Direccion.HeaderText = "Dirección";
            this.Direccion.Name = "Direccion";
            this.Direccion.ReadOnly = true;
            this.Direccion.Width = 200;
            // 
            // telefono
            // 
            this.telefono.HeaderText = "CodMascota";
            this.telefono.Name = "telefono";
            this.telefono.ReadOnly = true;
            this.telefono.Width = 120;
            // 
            // correo
            // 
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.correo.DefaultCellStyle = dataGridViewCellStyle3;
            this.correo.HeaderText = "Mascota";
            this.correo.Name = "correo";
            this.correo.ReadOnly = true;
            this.correo.Visible = false;
            this.correo.Width = 150;
            // 
            // fecha
            // 
            this.fecha.HeaderText = "F_Atencion";
            this.fecha.Name = "fecha";
            this.fecha.ReadOnly = true;
            // 
            // hora
            // 
            this.hora.HeaderText = "Hora";
            this.hora.Name = "hora";
            this.hora.ReadOnly = true;
            // 
            // servicio
            // 
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.servicio.DefaultCellStyle = dataGridViewCellStyle4;
            this.servicio.HeaderText = "Servicio";
            this.servicio.Name = "servicio";
            this.servicio.ReadOnly = true;
            this.servicio.Width = 150;
            // 
            // importe
            // 
            dataGridViewCellStyle5.NullValue = null;
            this.importe.DefaultCellStyle = dataGridViewCellStyle5;
            this.importe.HeaderText = "importe";
            this.importe.Name = "importe";
            this.importe.ReadOnly = true;
            this.importe.Width = 150;
            // 
            // total
            // 
            this.total.HeaderText = "Total";
            this.total.Name = "total";
            this.total.ReadOnly = true;
            this.total.Width = 150;
            // 
            // frmListCita
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 525);
            this.Controls.Add(this.dtpBuscar);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnNuevaCita);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmListCita";
            this.Text = "frmListCita";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmListCita_FormClosed);
            this.Load += new System.EventHandler(this.frmListCita_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCita)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label btnNuevaCita;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.DataGridView dgvCita;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dtpBuscar;
        private System.Windows.Forms.DataGridViewTextBoxColumn item;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaCita;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombres;
        private System.Windows.Forms.DataGridViewTextBoxColumn dni;
        private System.Windows.Forms.DataGridViewTextBoxColumn Direccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn correo;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn hora;
        private System.Windows.Forms.DataGridViewTextBoxColumn servicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn importe;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
    }
}
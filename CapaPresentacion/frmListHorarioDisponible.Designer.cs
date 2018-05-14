namespace CapaPresentacion
{
    partial class frmListHorarioDisponible
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListHorarioDisponible));
            this.dtpBuscar = new System.Windows.Forms.DateTimePicker();
            this.dgvListaHorario = new System.Windows.Forms.DataGridView();
            this.item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.servicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombres = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idMascota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mascota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaHorario)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpBuscar
            // 
            this.dtpBuscar.CustomFormat = "dd-MM-yyyy";
            this.dtpBuscar.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBuscar.Location = new System.Drawing.Point(264, 54);
            this.dtpBuscar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpBuscar.Name = "dtpBuscar";
            this.dtpBuscar.Size = new System.Drawing.Size(200, 27);
            this.dtpBuscar.TabIndex = 39;
            this.dtpBuscar.ValueChanged += new System.EventHandler(this.dtpBuscar_ValueChanged);
            // 
            // dgvListaHorario
            // 
            this.dgvListaHorario.AllowUserToAddRows = false;
            this.dgvListaHorario.AllowUserToDeleteRows = false;
            this.dgvListaHorario.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListaHorario.BackgroundColor = System.Drawing.Color.White;
            this.dgvListaHorario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvListaHorario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaHorario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.item,
            this.codigo,
            this.servicio,
            this.fecha,
            this.hora,
            this.nombres,
            this.idMascota,
            this.mascota});
            this.dgvListaHorario.Location = new System.Drawing.Point(3, 4);
            this.dgvListaHorario.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvListaHorario.Name = "dgvListaHorario";
            this.dgvListaHorario.ReadOnly = true;
            this.dgvListaHorario.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgvListaHorario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaHorario.Size = new System.Drawing.Size(608, 414);
            this.dgvListaHorario.TabIndex = 0;
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
            this.codigo.HeaderText = "IdCita";
            this.codigo.Name = "codigo";
            this.codigo.ReadOnly = true;
            this.codigo.Width = 60;
            // 
            // servicio
            // 
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.servicio.DefaultCellStyle = dataGridViewCellStyle5;
            this.servicio.HeaderText = "Servicio";
            this.servicio.Name = "servicio";
            this.servicio.ReadOnly = true;
            this.servicio.Width = 150;
            // 
            // fecha
            // 
            this.fecha.HeaderText = "Fecha";
            this.fecha.Name = "fecha";
            this.fecha.ReadOnly = true;
            this.fecha.Width = 150;
            // 
            // hora
            // 
            this.hora.HeaderText = "Hora";
            this.hora.Name = "hora";
            this.hora.ReadOnly = true;
            this.hora.Width = 150;
            // 
            // nombres
            // 
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.nombres.DefaultCellStyle = dataGridViewCellStyle6;
            this.nombres.HeaderText = "Cliente";
            this.nombres.Name = "nombres";
            this.nombres.ReadOnly = true;
            this.nombres.Visible = false;
            this.nombres.Width = 200;
            // 
            // idMascota
            // 
            dataGridViewCellStyle7.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.idMascota.DefaultCellStyle = dataGridViewCellStyle7;
            this.idMascota.HeaderText = "Codigo";
            this.idMascota.Name = "idMascota";
            this.idMascota.ReadOnly = true;
            this.idMascota.Visible = false;
            this.idMascota.Width = 80;
            // 
            // mascota
            // 
            dataGridViewCellStyle8.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.mascota.DefaultCellStyle = dataGridViewCellStyle8;
            this.mascota.HeaderText = "Mascota";
            this.mascota.Name = "mascota";
            this.mascota.ReadOnly = true;
            this.mascota.Visible = false;
            this.mascota.Width = 120;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(154, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 18);
            this.label1.TabIndex = 35;
            this.label1.Text = "Buscar Fecha";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.dgvListaHorario);
            this.panel1.Location = new System.Drawing.Point(0, 92);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(618, 425);
            this.panel1.TabIndex = 34;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(166)))), ((int)(((byte)(154)))));
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(618, 47);
            this.panel2.TabIndex = 92;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(35, 41);
            this.btnClose.TabIndex = 9;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label8.Location = new System.Drawing.Point(240, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(139, 18);
            this.label8.TabIndex = 10;
            this.label8.Text = "Formulario Fechas";
            // 
            // frmListHorarioDisponible
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 525);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dtpBuscar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmListHorarioDisponible";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmListHorarioDisponible";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmListHorarioDisponible_FormClosed);
            this.Load += new System.EventHandler(this.frmListHorarioDisponible_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaHorario)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpBuscar;
        public System.Windows.Forms.DataGridView dgvListaHorario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label btnClose;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn item;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn servicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn hora;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombres;
        private System.Windows.Forms.DataGridViewTextBoxColumn idMascota;
        private System.Windows.Forms.DataGridViewTextBoxColumn mascota;
    }
}
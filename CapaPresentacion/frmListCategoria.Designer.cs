namespace CapaPresentacion
{
    partial class frmListCategoria
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListCategoria));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvPresentacion = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtBuscarCategoria = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnNuevoCategoria = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPresentacion)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(214)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(834, 6);
            this.panel1.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.dgvPresentacion);
            this.panel2.Location = new System.Drawing.Point(0, 85);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(834, 439);
            this.panel2.TabIndex = 6;
            // 
            // dgvPresentacion
            // 
            this.dgvPresentacion.AllowUserToAddRows = false;
            this.dgvPresentacion.AllowUserToDeleteRows = false;
            this.dgvPresentacion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPresentacion.BackgroundColor = System.Drawing.Color.White;
            this.dgvPresentacion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPresentacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPresentacion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column5,
            this.Column6,
            this.Column4});
            this.dgvPresentacion.Location = new System.Drawing.Point(3, 4);
            this.dgvPresentacion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvPresentacion.Name = "dgvPresentacion";
            this.dgvPresentacion.ReadOnly = true;
            this.dgvPresentacion.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgvPresentacion.Size = new System.Drawing.Size(824, 420);
            this.dgvPresentacion.TabIndex = 0;
            this.dgvPresentacion.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvPresentacion_CellMouseDoubleClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "#";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Nombre";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 150;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Descripciòn";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 250;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Editar";
            this.Column5.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(127)))), ((int)(((byte)(169)))));
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column5.Width = 150;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Eliminar";
            this.Column6.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(57)))), ((int)(((byte)(37)))));
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 150;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "IdCategoria";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // txtBuscarCategoria
            // 
            this.txtBuscarCategoria.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscarCategoria.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtBuscarCategoria.Location = new System.Drawing.Point(149, 33);
            this.txtBuscarCategoria.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBuscarCategoria.Name = "txtBuscarCategoria";
            this.txtBuscarCategoria.Size = new System.Drawing.Size(349, 27);
            this.txtBuscarCategoria.TabIndex = 12;
            this.txtBuscarCategoria.TextChanged += new System.EventHandler(this.txtBuscarCategoria_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(6, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "Buscar categoria";
            // 
            // btnNuevoCategoria
            // 
            this.btnNuevoCategoria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(214)))));
            this.btnNuevoCategoria.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevoCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNuevoCategoria.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevoCategoria.ForeColor = System.Drawing.Color.White;
            this.btnNuevoCategoria.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevoCategoria.Image")));
            this.btnNuevoCategoria.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNuevoCategoria.Location = new System.Drawing.Point(533, 26);
            this.btnNuevoCategoria.Name = "btnNuevoCategoria";
            this.btnNuevoCategoria.Size = new System.Drawing.Size(147, 40);
            this.btnNuevoCategoria.TabIndex = 13;
            this.btnNuevoCategoria.Text = "Nuevo";
            this.btnNuevoCategoria.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnNuevoCategoria.Click += new System.EventHandler(this.btnNuevoCategoria_Click);
            // 
            // frmListCategoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 525);
            this.Controls.Add(this.btnNuevoCategoria);
            this.Controls.Add(this.txtBuscarCategoria);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmListCategoria";
            this.Text = "frmListCategoria";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmListCategoria_FormClosed);
            this.Load += new System.EventHandler(this.frmListCategoria_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPresentacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtBuscarCategoria;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label btnNuevoCategoria;
        internal System.Windows.Forms.DataGridView dgvPresentacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewLinkColumn Column5;
        private System.Windows.Forms.DataGridViewLinkColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}
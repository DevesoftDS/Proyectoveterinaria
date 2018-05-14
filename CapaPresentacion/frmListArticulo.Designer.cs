namespace CapaPresentacion
{
    partial class frmListArticulo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListArticulo));
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvArticulo = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtBuscarArt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNuevoArticulo = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.dgvArticulo);
            this.panel1.Location = new System.Drawing.Point(0, 85);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(834, 425);
            this.panel1.TabIndex = 0;
            // 
            // dgvArticulo
            // 
            this.dgvArticulo.AllowUserToAddRows = false;
            this.dgvArticulo.AllowUserToDeleteRows = false;
            this.dgvArticulo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvArticulo.BackgroundColor = System.Drawing.Color.White;
            this.dgvArticulo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvArticulo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArticulo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column5,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column9,
            this.Column6,
            this.Column7,
            this.Column8});
            this.dgvArticulo.Location = new System.Drawing.Point(3, 4);
            this.dgvArticulo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvArticulo.Name = "dgvArticulo";
            this.dgvArticulo.ReadOnly = true;
            this.dgvArticulo.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgvArticulo.Size = new System.Drawing.Size(828, 414);
            this.dgvArticulo.TabIndex = 0;
            this.dgvArticulo.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvArticulo_CellMouseDoubleClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Item";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Codigo";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 150;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Articulo";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 220;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Categoria";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Neto";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 80;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Descripciòn";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 150;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Editar";
            this.Column6.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(127)))), ((int)(((byte)(169)))));
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 150;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Eliminar";
            this.Column7.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(57)))), ((int)(((byte)(37)))));
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 150;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Idarticulo";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // txtBuscarArt
            // 
            this.txtBuscarArt.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscarArt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtBuscarArt.Location = new System.Drawing.Point(149, 33);
            this.txtBuscarArt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBuscarArt.Name = "txtBuscarArt";
            this.txtBuscarArt.Size = new System.Drawing.Size(413, 27);
            this.txtBuscarArt.TabIndex = 14;
            this.txtBuscarArt.TextChanged += new System.EventHandler(this.txtBuscarArt_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(6, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 20);
            this.label1.TabIndex = 13;
            this.label1.Text = "Buscar articulo";
            // 
            // btnNuevoArticulo
            // 
            this.btnNuevoArticulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(141)))), ((int)(((byte)(76)))));
            this.btnNuevoArticulo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevoArticulo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevoArticulo.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevoArticulo.ForeColor = System.Drawing.Color.White;
            this.btnNuevoArticulo.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevoArticulo.Image")));
            this.btnNuevoArticulo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNuevoArticulo.Location = new System.Drawing.Point(636, 27);
            this.btnNuevoArticulo.Name = "btnNuevoArticulo";
            this.btnNuevoArticulo.Size = new System.Drawing.Size(147, 40);
            this.btnNuevoArticulo.TabIndex = 15;
            this.btnNuevoArticulo.Text = "Nuevo";
            this.btnNuevoArticulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnNuevoArticulo.Click += new System.EventHandler(this.btnNuevoArticulo_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(141)))), ((int)(((byte)(76)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(834, 6);
            this.panel2.TabIndex = 16;
            // 
            // frmListArticulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 525);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnNuevoArticulo);
            this.Controls.Add(this.txtBuscarArt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmListArticulo";
            this.Text = "frmListArticulo";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmListArticulo_FormClosed);
            this.Load += new System.EventHandler(this.frmListArticulo_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtBuscarArt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label btnNuevoArticulo;
        private System.Windows.Forms.Panel panel2;
        internal System.Windows.Forms.DataGridView dgvArticulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewLinkColumn Column6;
        private System.Windows.Forms.DataGridViewLinkColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
    }
}
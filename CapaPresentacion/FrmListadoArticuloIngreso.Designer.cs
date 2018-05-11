namespace CapaPresentacion
{
    partial class FrmListadoArticuloIngreso
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmListadoArticuloIngreso));
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvArticulo = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pBarraTitulo = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtBuscarArt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboBuscar = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulo)).BeginInit();
            this.pBarraTitulo.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.dgvArticulo);
            this.panel1.Location = new System.Drawing.Point(0, 78);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(875, 403);
            this.panel1.TabIndex = 44;
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
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column8});
            this.dgvArticulo.Location = new System.Drawing.Point(3, 3);
            this.dgvArticulo.Name = "dgvArticulo";
            this.dgvArticulo.ReadOnly = true;
            this.dgvArticulo.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgvArticulo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvArticulo.Size = new System.Drawing.Size(865, 393);
            this.dgvArticulo.TabIndex = 0;
            this.dgvArticulo.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvArticulo_CellMouseDoubleClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "#";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 60;
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
            this.Column3.Width = 150;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Presentacion";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 150;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Stock";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Precio";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Idarticulo";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Visible = false;
            // 
            // pBarraTitulo
            // 
            this.pBarraTitulo.BackColor = System.Drawing.Color.LimeGreen;
            this.pBarraTitulo.Controls.Add(this.btnClose);
            this.pBarraTitulo.Controls.Add(this.label8);
            this.pBarraTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pBarraTitulo.Location = new System.Drawing.Point(0, 0);
            this.pBarraTitulo.Name = "pBarraTitulo";
            this.pBarraTitulo.Size = new System.Drawing.Size(875, 40);
            this.pBarraTitulo.TabIndex = 47;
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(3, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(35, 35);
            this.btnClose.TabIndex = 9;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label8.Location = new System.Drawing.Point(339, 11);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(129, 18);
            this.label8.TabIndex = 10;
            this.label8.Text = "Lista de articulos";
            // 
            // txtBuscarArt
            // 
            this.txtBuscarArt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtBuscarArt.Location = new System.Drawing.Point(128, 47);
            this.txtBuscarArt.Name = "txtBuscarArt";
            this.txtBuscarArt.Size = new System.Drawing.Size(413, 25);
            this.txtBuscarArt.TabIndex = 46;
            this.txtBuscarArt.TextChanged += new System.EventHandler(this.txtBuscarArt_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(7, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 18);
            this.label1.TabIndex = 45;
            this.label1.Text = "Buscar articulo";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // cboBuscar
            // 
            this.cboBuscar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBuscar.FormattingEnabled = true;
            this.cboBuscar.Location = new System.Drawing.Point(547, 47);
            this.cboBuscar.Name = "cboBuscar";
            this.cboBuscar.Size = new System.Drawing.Size(316, 25);
            this.cboBuscar.TabIndex = 48;
            this.cboBuscar.Visible = false;
            this.cboBuscar.SelectedIndexChanged += new System.EventHandler(this.cboBuscar_SelectedIndexChanged);
            this.cboBuscar.SelectionChangeCommitted += new System.EventHandler(this.cboBuscar_SelectionChangeCommitted);
            this.cboBuscar.SelectedValueChanged += new System.EventHandler(this.cboBuscar_SelectedValueChanged);
            // 
            // FrmListadoArticuloIngreso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 480);
            this.Controls.Add(this.cboBuscar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pBarraTitulo);
            this.Controls.Add(this.txtBuscarArt);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmListadoArticuloIngreso";
            this.Text = "FrmListadoArticuloIngreso";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmListadoArticuloIngreso_FormClosed);
            this.Load += new System.EventHandler(this.FrmListadoArticuloIngreso_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulo)).EndInit();
            this.pBarraTitulo.ResumeLayout(false);
            this.pBarraTitulo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.DataGridView dgvArticulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.Panel pBarraTitulo;
        private System.Windows.Forms.Label btnClose;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtBuscarArt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboBuscar;
    }
}
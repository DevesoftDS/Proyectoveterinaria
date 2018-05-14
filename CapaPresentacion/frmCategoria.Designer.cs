namespace CapaPresentacion
{
    partial class frmCategoria
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCategoria));
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pBarraTitulo = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.epCategoria = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel2.SuspendLayout();
            this.pBarraTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epCategoria)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtDescripcion);
            this.panel2.Controls.Add(this.txtNombre);
            this.panel2.Controls.Add(this.btnCancelar);
            this.panel2.Controls.Add(this.btnGuardar);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 47);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(724, 364);
            this.panel2.TabIndex = 8;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtDescripcion.Location = new System.Drawing.Point(188, 94);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(349, 86);
            this.txtDescripcion.TabIndex = 2;
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtNombre.Location = new System.Drawing.Point(188, 49);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(349, 27);
            this.txtNombre.TabIndex = 1;
            this.txtNombre.TextChanged += new System.EventHandler(this.txtNombre_TextChanged);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(214)))));
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(377, 253);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(187, 53);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(214)))));
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(161, 253);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(187, 53);
            this.btnGuardar.TabIndex = 6;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(92, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Descripciòn";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(92, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Nombre";
            // 
            // pBarraTitulo
            // 
            this.pBarraTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(214)))));
            this.pBarraTitulo.Controls.Add(this.btnClose);
            this.pBarraTitulo.Controls.Add(this.label7);
            this.pBarraTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pBarraTitulo.Location = new System.Drawing.Point(0, 0);
            this.pBarraTitulo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pBarraTitulo.Name = "pBarraTitulo";
            this.pBarraTitulo.Size = new System.Drawing.Size(724, 47);
            this.pBarraTitulo.TabIndex = 7;
            this.pBarraTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pBarraTitulo_MouseDown);
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label7.Location = new System.Drawing.Point(285, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(155, 20);
            this.label7.TabIndex = 10;
            this.label7.Text = "Formulario categoria";
            // 
            // epCategoria
            // 
            this.epCategoria.ContainerControl = this;
            this.epCategoria.Icon = ((System.Drawing.Icon)(resources.GetObject("epCategoria.Icon")));
            // 
            // frmCategoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 437);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pBarraTitulo);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmCategoria";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmCategoria";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmCategoria_FormClosed);
            this.Load += new System.EventHandler(this.frmCategoria_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pBarraTitulo.ResumeLayout(false);
            this.pBarraTitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epCategoria)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label btnCancelar;
        private System.Windows.Forms.Label btnGuardar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pBarraTitulo;
        private System.Windows.Forms.Label btnClose;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ErrorProvider epCategoria;
        internal System.Windows.Forms.TextBox txtDescripcion;
        internal System.Windows.Forms.TextBox txtNombre;
    }
}
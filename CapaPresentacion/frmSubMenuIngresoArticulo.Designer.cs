namespace CapaPresentacion
{
    partial class frmSubMenuIngresoArticulo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSubMenuIngresoArticulo));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnListaProductos = new System.Windows.Forms.Label();
            this.btnIngreso = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(59)))), ((int)(((byte)(65)))));
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btnListaProductos);
            this.panel1.Controls.Add(this.btnIngreso);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(834, 65);
            this.panel1.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(214)))));
            this.panel3.Location = new System.Drawing.Point(314, 49);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(210, 2);
            this.panel3.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(141)))), ((int)(((byte)(76)))));
            this.panel2.Location = new System.Drawing.Point(41, 49);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(210, 2);
            this.panel2.TabIndex = 1;
            // 
            // btnListaProductos
            // 
            this.btnListaProductos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(59)))), ((int)(((byte)(65)))));
            this.btnListaProductos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnListaProductos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnListaProductos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListaProductos.ForeColor = System.Drawing.Color.White;
            this.btnListaProductos.Image = ((System.Drawing.Image)(resources.GetObject("btnListaProductos.Image")));
            this.btnListaProductos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnListaProductos.Location = new System.Drawing.Point(311, 16);
            this.btnListaProductos.Name = "btnListaProductos";
            this.btnListaProductos.Size = new System.Drawing.Size(213, 33);
            this.btnListaProductos.TabIndex = 0;
            this.btnListaProductos.Text = "Lista productos";
            this.btnListaProductos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnListaProductos.Click += new System.EventHandler(this.btnListaProductos_Click);
            // 
            // btnIngreso
            // 
            this.btnIngreso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(59)))), ((int)(((byte)(65)))));
            this.btnIngreso.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIngreso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIngreso.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIngreso.ForeColor = System.Drawing.Color.White;
            this.btnIngreso.Image = ((System.Drawing.Image)(resources.GetObject("btnIngreso.Image")));
            this.btnIngreso.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIngreso.Location = new System.Drawing.Point(38, 16);
            this.btnIngreso.Name = "btnIngreso";
            this.btnIngreso.Size = new System.Drawing.Size(213, 33);
            this.btnIngreso.TabIndex = 0;
            this.btnIngreso.Text = "Lista Ingreso";
            this.btnIngreso.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnIngreso.Click += new System.EventHandler(this.btnIngreso_Click);
            // 
            // frmSubMenuIngresoArticulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 72);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmSubMenuIngresoArticulo";
            this.Text = "frmSubMenuIngresoArticulo";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label btnListaProductos;
        private System.Windows.Forms.Label btnIngreso;
    }
}
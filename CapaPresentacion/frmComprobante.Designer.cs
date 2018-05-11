namespace CapaPresentacion
{
    partial class frmComprobante
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
            this.crvComprobante = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvComprobante
            // 
            this.crvComprobante.ActiveViewIndex = -1;
            this.crvComprobante.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvComprobante.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvComprobante.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvComprobante.Location = new System.Drawing.Point(0, 0);
            this.crvComprobante.Name = "crvComprobante";
            this.crvComprobante.Size = new System.Drawing.Size(833, 526);
            this.crvComprobante.TabIndex = 0;
            this.crvComprobante.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // frmComprobante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 526);
            this.Controls.Add(this.crvComprobante);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmComprobante";
            this.Text = "frmComprobante";
            this.Load += new System.EventHandler(this.frmComprobante_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvComprobante;
    }
}
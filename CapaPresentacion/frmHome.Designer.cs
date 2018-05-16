namespace CapaPresentacion
{
    partial class frmHome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHome));
            this.barraTitulo = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Label();
            this.btnMaximize = new System.Windows.Forms.Label();
            this.btnNormal = new System.Windows.Forms.Label();
            this.btnMinimize = new System.Windows.Forms.Label();
            this.barraHeader = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTipoUser = new System.Windows.Forms.Label();
            this.lblNombreUsuario = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.menuVertical = new System.Windows.Forms.Panel();
            this.subLogo = new System.Windows.Forms.Label();
            this.pictureLogo = new System.Windows.Forms.Label();
            this.btnAcerca = new System.Windows.Forms.Button();
            this.btnReportes = new System.Windows.Forms.Button();
            this.btnAlmacen = new System.Windows.Forms.Button();
            this.btnServicios = new System.Windows.Forms.Button();
            this.btnMenu = new System.Windows.Forms.Button();
            this.btnVentas = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnMantenimiento = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.barraSection = new System.Windows.Forms.Panel();
            this.barraSubMenu = new System.Windows.Forms.Panel();
            this.barraTitulo.SuspendLayout();
            this.panel4.SuspendLayout();
            this.barraHeader.SuspendLayout();
            this.panel1.SuspendLayout();
            this.menuVertical.SuspendLayout();
            this.SuspendLayout();
            // 
            // barraTitulo
            // 
            this.barraTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(124)))), ((int)(((byte)(165)))));
            this.barraTitulo.Controls.Add(this.panel4);
            this.barraTitulo.Controls.Add(this.barraHeader);
            this.barraTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.barraTitulo.Location = new System.Drawing.Point(0, 0);
            this.barraTitulo.Name = "barraTitulo";
            this.barraTitulo.Size = new System.Drawing.Size(1101, 93);
            this.barraTitulo.TabIndex = 0;
            this.barraTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.barraTitulo_MouseDown);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnExit);
            this.panel4.Controls.Add(this.btnMaximize);
            this.panel4.Controls.Add(this.btnNormal);
            this.panel4.Controls.Add(this.btnMinimize);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(1011, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(90, 31);
            this.panel4.TabIndex = 1;
            // 
            // btnExit
            // 
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.Location = new System.Drawing.Point(55, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(26, 26);
            this.btnExit.TabIndex = 0;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnMaximize
            // 
            this.btnMaximize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMaximize.Image = ((System.Drawing.Image)(resources.GetObject("btnMaximize.Image")));
            this.btnMaximize.Location = new System.Drawing.Point(29, 2);
            this.btnMaximize.Name = "btnMaximize";
            this.btnMaximize.Size = new System.Drawing.Size(26, 26);
            this.btnMaximize.TabIndex = 0;
            this.btnMaximize.Visible = false;
            this.btnMaximize.Click += new System.EventHandler(this.btnMaximize_Click);
            // 
            // btnNormal
            // 
            this.btnNormal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNormal.Image = ((System.Drawing.Image)(resources.GetObject("btnNormal.Image")));
            this.btnNormal.Location = new System.Drawing.Point(29, 2);
            this.btnNormal.Name = "btnNormal";
            this.btnNormal.Size = new System.Drawing.Size(26, 26);
            this.btnNormal.TabIndex = 0;
            this.btnNormal.Click += new System.EventHandler(this.btnNormal_Click);
            // 
            // btnMinimize
            // 
            this.btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimize.Image = ((System.Drawing.Image)(resources.GetObject("btnMinimize.Image")));
            this.btnMinimize.Location = new System.Drawing.Point(3, 2);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(26, 26);
            this.btnMinimize.TabIndex = 0;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // barraHeader
            // 
            this.barraHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.barraHeader.Controls.Add(this.panel1);
            this.barraHeader.Controls.Add(this.label2);
            this.barraHeader.Controls.Add(this.label5);
            this.barraHeader.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barraHeader.Location = new System.Drawing.Point(0, 31);
            this.barraHeader.Name = "barraHeader";
            this.barraHeader.Size = new System.Drawing.Size(1101, 62);
            this.barraHeader.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblTipoUser);
            this.panel1.Controls.Add(this.lblNombreUsuario);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(658, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(443, 62);
            this.panel1.TabIndex = 0;
            // 
            // lblTipoUser
            // 
            this.lblTipoUser.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoUser.ForeColor = System.Drawing.Color.Black;
            this.lblTipoUser.Location = new System.Drawing.Point(188, 33);
            this.lblTipoUser.Name = "lblTipoUser";
            this.lblTipoUser.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblTipoUser.Size = new System.Drawing.Size(185, 20);
            this.lblTipoUser.TabIndex = 3;
            this.lblTipoUser.Text = "Administrador";
            this.lblTipoUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNombreUsuario
            // 
            this.lblNombreUsuario.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreUsuario.ForeColor = System.Drawing.Color.Black;
            this.lblNombreUsuario.Location = new System.Drawing.Point(188, 12);
            this.lblNombreUsuario.Name = "lblNombreUsuario";
            this.lblNombreUsuario.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblNombreUsuario.Size = new System.Drawing.Size(185, 20);
            this.lblNombreUsuario.TabIndex = 3;
            this.lblNombreUsuario.Text = "Soto Gomez T";
            this.lblNombreUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Lucida Sans Typewriter", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.Location = new System.Drawing.Point(383, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 51);
            this.label1.TabIndex = 2;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI Black", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(118)))), ((int)(((byte)(79)))));
            this.label2.Location = new System.Drawing.Point(12, -5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 58);
            this.label2.TabIndex = 2;
            this.label2.Text = "SV";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label5.Location = new System.Drawing.Point(104, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(255, 57);
            this.label5.TabIndex = 2;
            this.label5.Text = "Sistema veterinaria ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menuVertical
            // 
            this.menuVertical.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
            this.menuVertical.Controls.Add(this.subLogo);
            this.menuVertical.Controls.Add(this.pictureLogo);
            this.menuVertical.Controls.Add(this.btnAcerca);
            this.menuVertical.Controls.Add(this.btnReportes);
            this.menuVertical.Controls.Add(this.btnAlmacen);
            this.menuVertical.Controls.Add(this.btnServicios);
            this.menuVertical.Controls.Add(this.btnMenu);
            this.menuVertical.Controls.Add(this.btnVentas);
            this.menuVertical.Controls.Add(this.btnHome);
            this.menuVertical.Controls.Add(this.btnMantenimiento);
            this.menuVertical.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuVertical.Location = new System.Drawing.Point(0, 93);
            this.menuVertical.Name = "menuVertical";
            this.menuVertical.Size = new System.Drawing.Size(267, 590);
            this.menuVertical.TabIndex = 1;
            // 
            // subLogo
            // 
            this.subLogo.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subLogo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.subLogo.Location = new System.Drawing.Point(0, 15);
            this.subLogo.Name = "subLogo";
            this.subLogo.Size = new System.Drawing.Size(60, 50);
            this.subLogo.TabIndex = 3;
            this.subLogo.Text = "DS";
            this.subLogo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureLogo
            // 
            this.pictureLogo.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pictureLogo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.pictureLogo.Location = new System.Drawing.Point(62, 19);
            this.pictureLogo.Name = "pictureLogo";
            this.pictureLogo.Size = new System.Drawing.Size(149, 57);
            this.pictureLogo.TabIndex = 2;
            this.pictureLogo.Text = "Sistema DS";
            this.pictureLogo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAcerca
            // 
            this.btnAcerca.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
            this.btnAcerca.FlatAppearance.BorderSize = 0;
            this.btnAcerca.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(141)))), ((int)(((byte)(188)))));
            this.btnAcerca.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAcerca.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAcerca.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnAcerca.Image = ((System.Drawing.Image)(resources.GetObject("btnAcerca.Image")));
            this.btnAcerca.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAcerca.Location = new System.Drawing.Point(0, 448);
            this.btnAcerca.Name = "btnAcerca";
            this.btnAcerca.Size = new System.Drawing.Size(267, 48);
            this.btnAcerca.TabIndex = 1;
            this.btnAcerca.TabStop = false;
            this.btnAcerca.Text = "Acerca de ...";
            this.toolTip1.SetToolTip(this.btnAcerca, "Informaciòn del sistema");
            this.btnAcerca.UseVisualStyleBackColor = false;
            this.btnAcerca.Click += new System.EventHandler(this.btnAcerca_Click);
            // 
            // btnReportes
            // 
            this.btnReportes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
            this.btnReportes.FlatAppearance.BorderSize = 0;
            this.btnReportes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(141)))), ((int)(((byte)(188)))));
            this.btnReportes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReportes.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReportes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnReportes.Image = ((System.Drawing.Image)(resources.GetObject("btnReportes.Image")));
            this.btnReportes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReportes.Location = new System.Drawing.Point(0, 394);
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.Size = new System.Drawing.Size(267, 48);
            this.btnReportes.TabIndex = 1;
            this.btnReportes.TabStop = false;
            this.btnReportes.Text = "Reportes";
            this.toolTip1.SetToolTip(this.btnReportes, "Reportes");
            this.btnReportes.UseVisualStyleBackColor = false;
            this.btnReportes.Click += new System.EventHandler(this.btnReportes_Click);
            // 
            // btnAlmacen
            // 
            this.btnAlmacen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
            this.btnAlmacen.FlatAppearance.BorderSize = 0;
            this.btnAlmacen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(141)))), ((int)(((byte)(188)))));
            this.btnAlmacen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlmacen.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlmacen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnAlmacen.Image = ((System.Drawing.Image)(resources.GetObject("btnAlmacen.Image")));
            this.btnAlmacen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAlmacen.Location = new System.Drawing.Point(0, 340);
            this.btnAlmacen.Name = "btnAlmacen";
            this.btnAlmacen.Size = new System.Drawing.Size(267, 48);
            this.btnAlmacen.TabIndex = 1;
            this.btnAlmacen.TabStop = false;
            this.btnAlmacen.Text = "Almacen";
            this.toolTip1.SetToolTip(this.btnAlmacen, "Almacen - ingreso de articulos");
            this.btnAlmacen.UseVisualStyleBackColor = false;
            this.btnAlmacen.Click += new System.EventHandler(this.btnAlmacen_Click);
            // 
            // btnServicios
            // 
            this.btnServicios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
            this.btnServicios.FlatAppearance.BorderSize = 0;
            this.btnServicios.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(141)))), ((int)(((byte)(188)))));
            this.btnServicios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnServicios.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnServicios.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnServicios.Image = ((System.Drawing.Image)(resources.GetObject("btnServicios.Image")));
            this.btnServicios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnServicios.Location = new System.Drawing.Point(0, 286);
            this.btnServicios.Name = "btnServicios";
            this.btnServicios.Size = new System.Drawing.Size(267, 48);
            this.btnServicios.TabIndex = 1;
            this.btnServicios.TabStop = false;
            this.btnServicios.Text = "Servicios";
            this.toolTip1.SetToolTip(this.btnServicios, "Servicios de la clinica");
            this.btnServicios.UseVisualStyleBackColor = false;
            this.btnServicios.Click += new System.EventHandler(this.btnServicios_Click);
            // 
            // btnMenu
            // 
            this.btnMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
            this.btnMenu.FlatAppearance.BorderSize = 0;
            this.btnMenu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(141)))), ((int)(((byte)(188)))));
            this.btnMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenu.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnMenu.Image = ((System.Drawing.Image)(resources.GetObject("btnMenu.Image")));
            this.btnMenu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenu.Location = new System.Drawing.Point(0, 68);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(60, 50);
            this.btnMenu.TabIndex = 1;
            this.btnMenu.TabStop = false;
            this.btnMenu.UseVisualStyleBackColor = false;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // btnVentas
            // 
            this.btnVentas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
            this.btnVentas.FlatAppearance.BorderSize = 0;
            this.btnVentas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(141)))), ((int)(((byte)(188)))));
            this.btnVentas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVentas.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVentas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnVentas.Image = ((System.Drawing.Image)(resources.GetObject("btnVentas.Image")));
            this.btnVentas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVentas.Location = new System.Drawing.Point(0, 232);
            this.btnVentas.Name = "btnVentas";
            this.btnVentas.Size = new System.Drawing.Size(267, 48);
            this.btnVentas.TabIndex = 1;
            this.btnVentas.TabStop = false;
            this.btnVentas.Text = "Ventas";
            this.toolTip1.SetToolTip(this.btnVentas, "Venta de productos");
            this.btnVentas.UseVisualStyleBackColor = false;
            this.btnVentas.Click += new System.EventHandler(this.btnVentas_Click);
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
            this.btnHome.FlatAppearance.BorderSize = 0;
            this.btnHome.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(141)))), ((int)(((byte)(188)))));
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnHome.Image = ((System.Drawing.Image)(resources.GetObject("btnHome.Image")));
            this.btnHome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHome.Location = new System.Drawing.Point(0, 124);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(267, 48);
            this.btnHome.TabIndex = 1;
            this.btnHome.TabStop = false;
            this.btnHome.Text = "Home";
            this.toolTip1.SetToolTip(this.btnHome, "Menu inicio");
            this.btnHome.UseVisualStyleBackColor = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // btnMantenimiento
            // 
            this.btnMantenimiento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
            this.btnMantenimiento.FlatAppearance.BorderSize = 0;
            this.btnMantenimiento.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(141)))), ((int)(((byte)(188)))));
            this.btnMantenimiento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMantenimiento.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMantenimiento.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnMantenimiento.Image = ((System.Drawing.Image)(resources.GetObject("btnMantenimiento.Image")));
            this.btnMantenimiento.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMantenimiento.Location = new System.Drawing.Point(0, 178);
            this.btnMantenimiento.Name = "btnMantenimiento";
            this.btnMantenimiento.Size = new System.Drawing.Size(267, 48);
            this.btnMantenimiento.TabIndex = 1;
            this.btnMantenimiento.TabStop = false;
            this.btnMantenimiento.Text = "Mantenimiento";
            this.toolTip1.SetToolTip(this.btnMantenimiento, "Modulo mantenimiento");
            this.btnMantenimiento.UseVisualStyleBackColor = false;
            this.btnMantenimiento.Click += new System.EventHandler(this.btnMantenimiento_Click);
            // 
            // barraSection
            // 
            this.barraSection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.barraSection.Location = new System.Drawing.Point(267, 158);
            this.barraSection.Name = "barraSection";
            this.barraSection.Size = new System.Drawing.Size(834, 525);
            this.barraSection.TabIndex = 2;
            // 
            // barraSubMenu
            // 
            this.barraSubMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(59)))), ((int)(((byte)(65)))));
            this.barraSubMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.barraSubMenu.Location = new System.Drawing.Point(267, 93);
            this.barraSubMenu.Name = "barraSubMenu";
            this.barraSubMenu.Size = new System.Drawing.Size(834, 65);
            this.barraSubMenu.TabIndex = 3;
            // 
            // frmHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1101, 683);
            this.Controls.Add(this.barraSection);
            this.Controls.Add(this.barraSubMenu);
            this.Controls.Add(this.menuVertical);
            this.Controls.Add(this.barraTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmHome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmHome";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmHome_FormClosed);
            this.Load += new System.EventHandler(this.frmHome_Load);
            this.barraTitulo.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.barraHeader.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.menuVertical.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel barraTitulo;
        private System.Windows.Forms.Panel menuVertical;
        private System.Windows.Forms.Button btnReportes;
        private System.Windows.Forms.Button btnAlmacen;
        private System.Windows.Forms.Button btnServicios;
        private System.Windows.Forms.Button btnVentas;
        private System.Windows.Forms.Button btnMantenimiento;
        private System.Windows.Forms.Panel barraHeader;
        private System.Windows.Forms.Label btnExit;
        private System.Windows.Forms.Label btnMinimize;
        private System.Windows.Forms.Label btnNormal;
        private System.Windows.Forms.Label btnMaximize;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label pictureLogo;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.Label subLogo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTipoUser;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolTip toolTip1;
        public System.Windows.Forms.Panel barraSubMenu;
        public System.Windows.Forms.Panel barraSection;
        private System.Windows.Forms.Button btnAcerca;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNombreUsuario;
    }
}
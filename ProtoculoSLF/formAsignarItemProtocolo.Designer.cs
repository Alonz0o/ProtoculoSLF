namespace ProtoculoSLF
{
    partial class formAsignarItemProtocolo
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
            this.gcAgregar = new DevExpress.XtraEditors.GroupControl();
            this.btnCerrarMin = new FontAwesome.Sharp.IconButton();
            this.tlpRealizados = new System.Windows.Forms.TableLayoutPanel();
            this.pnlPendientes = new System.Windows.Forms.Panel();
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupControl7 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl6 = new DevExpress.XtraEditors.GroupControl();
            this.gcSimboloSignificado = new DevExpress.XtraEditors.GroupControl();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.groupControl5 = new DevExpress.XtraEditors.GroupControl();
            this.lueNombreItem = new DevExpress.XtraEditors.LookUpEdit();
            this.tlpNoti = new System.Windows.Forms.TableLayoutPanel();
            this.tlpCuerpo = new System.Windows.Forms.TableLayoutPanel();
            this.iconoNotificacion = new FontAwesome.Sharp.IconButton();
            this.pnlCuerpo = new System.Windows.Forms.Panel();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.tbEspMax = new ScrapKP.AAFControles.AAFTextBox();
            this.tbEspMed = new ScrapKP.AAFControles.AAFTextBox();
            this.tbEspMin = new ScrapKP.AAFControles.AAFTextBox();
            this.btnAgregarItem = new ProtoculoSLF.AAFControles.AAFBoton();
            this.btnCancelar = new ProtoculoSLF.AAFControles.AAFBoton();
            this.tbSimboloSignificado = new ScrapKP.AAFControles.AAFTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gcAgregar)).BeginInit();
            this.gcAgregar.SuspendLayout();
            this.tlpRealizados.SuspendLayout();
            this.pnlPendientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            this.groupControl4.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl7)).BeginInit();
            this.groupControl7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl6)).BeginInit();
            this.groupControl6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcSimboloSignificado)).BeginInit();
            this.gcSimboloSignificado.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).BeginInit();
            this.groupControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueNombreItem.Properties)).BeginInit();
            this.tlpNoti.SuspendLayout();
            this.tlpCuerpo.SuspendLayout();
            this.pnlCuerpo.SuspendLayout();
            this.SuspendLayout();
            // 
            // gcAgregar
            // 
            this.gcAgregar.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.gcAgregar.Appearance.Options.UseBorderColor = true;
            this.gcAgregar.AppearanceCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold);
            this.gcAgregar.AppearanceCaption.Options.UseFont = true;
            this.gcAgregar.Controls.Add(this.btnCerrarMin);
            this.gcAgregar.Controls.Add(this.tlpRealizados);
            this.gcAgregar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcAgregar.Location = new System.Drawing.Point(0, 0);
            this.gcAgregar.Name = "gcAgregar";
            this.gcAgregar.Size = new System.Drawing.Size(435, 520);
            this.gcAgregar.TabIndex = 3;
            this.gcAgregar.Text = "  Agregar protocolo ítem";
            // 
            // btnCerrarMin
            // 
            this.btnCerrarMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrarMin.BackColor = System.Drawing.Color.Transparent;
            this.btnCerrarMin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrarMin.FlatAppearance.BorderSize = 0;
            this.btnCerrarMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarMin.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.btnCerrarMin.IconColor = System.Drawing.Color.Azure;
            this.btnCerrarMin.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnCerrarMin.IconSize = 15;
            this.btnCerrarMin.Location = new System.Drawing.Point(412, 1);
            this.btnCerrarMin.Margin = new System.Windows.Forms.Padding(0);
            this.btnCerrarMin.Name = "btnCerrarMin";
            this.btnCerrarMin.Size = new System.Drawing.Size(20, 20);
            this.btnCerrarMin.TabIndex = 36;
            this.btnCerrarMin.UseVisualStyleBackColor = false;
            this.btnCerrarMin.Click += new System.EventHandler(this.btnCerrarMin_Click);
            // 
            // tlpRealizados
            // 
            this.tlpRealizados.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.tlpRealizados.ColumnCount = 2;
            this.tlpRealizados.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.tlpRealizados.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRealizados.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpRealizados.Controls.Add(this.pnlPendientes, 1, 0);
            this.tlpRealizados.Controls.Add(this.panel11, 0, 0);
            this.tlpRealizados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpRealizados.Location = new System.Drawing.Point(2, 23);
            this.tlpRealizados.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tlpRealizados.Name = "tlpRealizados";
            this.tlpRealizados.RowCount = 1;
            this.tlpRealizados.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRealizados.Size = new System.Drawing.Size(431, 495);
            this.tlpRealizados.TabIndex = 3;
            // 
            // pnlPendientes
            // 
            this.pnlPendientes.AutoScroll = true;
            this.pnlPendientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.pnlPendientes.Controls.Add(this.groupControl4);
            this.pnlPendientes.Controls.Add(this.tableLayoutPanel5);
            this.pnlPendientes.Controls.Add(this.groupControl5);
            this.pnlPendientes.Controls.Add(this.gcSimboloSignificado);
            this.pnlPendientes.Controls.Add(this.tlpNoti);
            this.pnlPendientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPendientes.Location = new System.Drawing.Point(13, 0);
            this.pnlPendientes.Margin = new System.Windows.Forms.Padding(0);
            this.pnlPendientes.Name = "pnlPendientes";
            this.pnlPendientes.Size = new System.Drawing.Size(418, 495);
            this.pnlPendientes.TabIndex = 0;
            // 
            // groupControl4
            // 
            this.groupControl4.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.groupControl4.Appearance.Options.UseBorderColor = true;
            this.groupControl4.AppearanceCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl4.AppearanceCaption.Options.UseFont = true;
            this.groupControl4.AppearanceCaption.Options.UseTextOptions = true;
            this.groupControl4.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.groupControl4.Controls.Add(this.tableLayoutPanel1);
            this.groupControl4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl4.Location = new System.Drawing.Point(0, 197);
            this.groupControl4.Margin = new System.Windows.Forms.Padding(0);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.Size = new System.Drawing.Size(418, 81);
            this.groupControl4.TabIndex = 79;
            this.groupControl4.Text = "Especificación";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.groupControl7, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupControl3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupControl6, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 23);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(414, 58);
            this.tableLayoutPanel1.TabIndex = 75;
            // 
            // groupControl7
            // 
            this.groupControl7.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.groupControl7.Appearance.Options.UseBorderColor = true;
            this.groupControl7.AppearanceCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl7.AppearanceCaption.Options.UseFont = true;
            this.groupControl7.Controls.Add(this.tbEspMax);
            this.groupControl7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl7.Location = new System.Drawing.Point(276, 0);
            this.groupControl7.Margin = new System.Windows.Forms.Padding(0);
            this.groupControl7.Name = "groupControl7";
            this.groupControl7.Size = new System.Drawing.Size(138, 58);
            this.groupControl7.TabIndex = 68;
            this.groupControl7.Text = "  Maximo *";
            // 
            // groupControl3
            // 
            this.groupControl3.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.groupControl3.Appearance.Options.UseBorderColor = true;
            this.groupControl3.AppearanceCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl3.AppearanceCaption.Options.UseFont = true;
            this.groupControl3.Controls.Add(this.tbEspMed);
            this.groupControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl3.Location = new System.Drawing.Point(138, 0);
            this.groupControl3.Margin = new System.Windows.Forms.Padding(0);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(138, 58);
            this.groupControl3.TabIndex = 66;
            this.groupControl3.Text = "  Medio *";
            // 
            // groupControl6
            // 
            this.groupControl6.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.groupControl6.Appearance.Options.UseBorderColor = true;
            this.groupControl6.AppearanceCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl6.AppearanceCaption.Options.UseFont = true;
            this.groupControl6.Controls.Add(this.tbEspMin);
            this.groupControl6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl6.Location = new System.Drawing.Point(0, 0);
            this.groupControl6.Margin = new System.Windows.Forms.Padding(0);
            this.groupControl6.Name = "groupControl6";
            this.groupControl6.Size = new System.Drawing.Size(138, 58);
            this.groupControl6.TabIndex = 67;
            this.groupControl6.Text = "  Minimo *";
            // 
            // gcSimboloSignificado
            // 
            this.gcSimboloSignificado.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.gcSimboloSignificado.Appearance.Options.UseBorderColor = true;
            this.gcSimboloSignificado.AppearanceCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gcSimboloSignificado.AppearanceCaption.Options.UseFont = true;
            this.gcSimboloSignificado.Controls.Add(this.tbSimboloSignificado);
            this.gcSimboloSignificado.Dock = System.Windows.Forms.DockStyle.Top;
            this.gcSimboloSignificado.Enabled = false;
            this.gcSimboloSignificado.Location = new System.Drawing.Point(0, 69);
            this.gcSimboloSignificado.Margin = new System.Windows.Forms.Padding(0);
            this.gcSimboloSignificado.Name = "gcSimboloSignificado";
            this.gcSimboloSignificado.Size = new System.Drawing.Size(418, 70);
            this.gcSimboloSignificado.TabIndex = 67;
            this.gcSimboloSignificado.Text = "  Significado de símbolo (+)";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel5.Controls.Add(this.btnAgregarItem, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.btnCancelar, 1, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 452);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(418, 43);
            this.tableLayoutPanel5.TabIndex = 66;
            // 
            // groupControl5
            // 
            this.groupControl5.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.groupControl5.Appearance.Options.UseBorderColor = true;
            this.groupControl5.AppearanceCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl5.AppearanceCaption.Options.UseFont = true;
            this.groupControl5.Controls.Add(this.lueNombreItem);
            this.groupControl5.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl5.Location = new System.Drawing.Point(0, 139);
            this.groupControl5.Margin = new System.Windows.Forms.Padding(0);
            this.groupControl5.Name = "groupControl5";
            this.groupControl5.Size = new System.Drawing.Size(418, 58);
            this.groupControl5.TabIndex = 75;
            this.groupControl5.Text = "  Nombre *";
            // 
            // lueNombreItem
            // 
            this.lueNombreItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lueNombreItem.EditValue = "";
            this.lueNombreItem.Location = new System.Drawing.Point(2, 23);
            this.lueNombreItem.Name = "lueNombreItem";
            this.lueNombreItem.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lueNombreItem.Properties.Appearance.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lueNombreItem.Properties.Appearance.Options.UseFont = true;
            this.lueNombreItem.Properties.Appearance.Options.UseForeColor = true;
            this.lueNombreItem.Properties.AutoHeight = false;
            this.lueNombreItem.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueNombreItem.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Nombre", "Nombre"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Medida", "Medida"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EsCertificadoSiNo", "Certifica")});
            this.lueNombreItem.Properties.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lueNombreItem.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.lueNombreItem.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lueNombreItem.Size = new System.Drawing.Size(414, 33);
            this.lueNombreItem.TabIndex = 64;
            this.lueNombreItem.EditValueChanged += new System.EventHandler(this.lueNombreItem_EditValueChanged);
            // 
            // tlpNoti
            // 
            this.tlpNoti.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.tlpNoti.ColumnCount = 1;
            this.tlpNoti.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpNoti.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpNoti.Controls.Add(this.tlpCuerpo, 0, 0);
            this.tlpNoti.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpNoti.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.tlpNoti.Location = new System.Drawing.Point(0, 0);
            this.tlpNoti.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tlpNoti.Name = "tlpNoti";
            this.tlpNoti.RowCount = 1;
            this.tlpNoti.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpNoti.Size = new System.Drawing.Size(418, 69);
            this.tlpNoti.TabIndex = 78;
            // 
            // tlpCuerpo
            // 
            this.tlpCuerpo.BackColor = System.Drawing.Color.Transparent;
            this.tlpCuerpo.ColumnCount = 2;
            this.tlpCuerpo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tlpCuerpo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCuerpo.Controls.Add(this.iconoNotificacion, 0, 0);
            this.tlpCuerpo.Controls.Add(this.pnlCuerpo, 1, 0);
            this.tlpCuerpo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCuerpo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.tlpCuerpo.Location = new System.Drawing.Point(2, 3);
            this.tlpCuerpo.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tlpCuerpo.Name = "tlpCuerpo";
            this.tlpCuerpo.RowCount = 1;
            this.tlpCuerpo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCuerpo.Size = new System.Drawing.Size(414, 63);
            this.tlpCuerpo.TabIndex = 4;
            // 
            // iconoNotificacion
            // 
            this.iconoNotificacion.BackColor = System.Drawing.Color.Transparent;
            this.iconoNotificacion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconoNotificacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.iconoNotificacion.FlatAppearance.BorderSize = 0;
            this.iconoNotificacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconoNotificacion.IconChar = FontAwesome.Sharp.IconChar.ExclamationCircle;
            this.iconoNotificacion.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.iconoNotificacion.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.iconoNotificacion.Location = new System.Drawing.Point(0, 0);
            this.iconoNotificacion.Margin = new System.Windows.Forms.Padding(0);
            this.iconoNotificacion.Name = "iconoNotificacion";
            this.iconoNotificacion.Size = new System.Drawing.Size(43, 63);
            this.iconoNotificacion.TabIndex = 30;
            this.iconoNotificacion.UseVisualStyleBackColor = false;
            // 
            // pnlCuerpo
            // 
            this.pnlCuerpo.BackColor = System.Drawing.Color.Transparent;
            this.pnlCuerpo.Controls.Add(this.lblMensaje);
            this.pnlCuerpo.Controls.Add(this.lblTitulo);
            this.pnlCuerpo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCuerpo.Location = new System.Drawing.Point(46, 3);
            this.pnlCuerpo.Name = "pnlCuerpo";
            this.pnlCuerpo.Size = new System.Drawing.Size(365, 57);
            this.pnlCuerpo.TabIndex = 31;
            // 
            // lblMensaje
            // 
            this.lblMensaje.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMensaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lblMensaje.Location = new System.Drawing.Point(0, 22);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lblMensaje.Size = new System.Drawing.Size(365, 35);
            this.lblMensaje.TabIndex = 40;
            this.lblMensaje.Text = "Se agregara un item, para este protocolo y este pallet";
            this.lblMensaje.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTitulo
            // 
            this.lblTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.Black;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(365, 22);
            this.lblTitulo.TabIndex = 39;
            this.lblTitulo.Text = "Agregando un ítem especificado para:";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.panel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel11.Location = new System.Drawing.Point(3, 3);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(7, 489);
            this.panel11.TabIndex = 1;
            // 
            // tbEspMax
            // 
            this.tbEspMax.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.tbEspMax.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.tbEspMax.BackColor = System.Drawing.Color.White;
            this.tbEspMax.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.tbEspMax.BorderFocusColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.tbEspMax.BorderSize = 2;
            this.tbEspMax.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbEspMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.tbEspMax.ForeColor = System.Drawing.SystemColors.GrayText;
            this.tbEspMax.Location = new System.Drawing.Point(2, 23);
            this.tbEspMax.Margin = new System.Windows.Forms.Padding(4);
            this.tbEspMax.Multiline = false;
            this.tbEspMax.Name = "tbEspMax";
            this.tbEspMax.Padding = new System.Windows.Forms.Padding(19, 8, 8, 8);
            this.tbEspMax.PasswordChar = false;
            this.tbEspMax.SelectionStart = 0;
            this.tbEspMax.Size = new System.Drawing.Size(134, 33);
            this.tbEspMax.TabIndex = 2;
            this.tbEspMax.Texts = "";
            this.tbEspMax.UnderlinedStyle = true;
            // 
            // tbEspMed
            // 
            this.tbEspMed.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.tbEspMed.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.tbEspMed.BackColor = System.Drawing.Color.White;
            this.tbEspMed.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.tbEspMed.BorderFocusColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.tbEspMed.BorderSize = 2;
            this.tbEspMed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbEspMed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.tbEspMed.ForeColor = System.Drawing.SystemColors.GrayText;
            this.tbEspMed.Location = new System.Drawing.Point(2, 23);
            this.tbEspMed.Margin = new System.Windows.Forms.Padding(4);
            this.tbEspMed.Multiline = false;
            this.tbEspMed.Name = "tbEspMed";
            this.tbEspMed.Padding = new System.Windows.Forms.Padding(19, 8, 8, 8);
            this.tbEspMed.PasswordChar = false;
            this.tbEspMed.SelectionStart = 0;
            this.tbEspMed.Size = new System.Drawing.Size(134, 33);
            this.tbEspMed.TabIndex = 2;
            this.tbEspMed.Texts = "";
            this.tbEspMed.UnderlinedStyle = true;
            // 
            // tbEspMin
            // 
            this.tbEspMin.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.tbEspMin.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.tbEspMin.BackColor = System.Drawing.Color.White;
            this.tbEspMin.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.tbEspMin.BorderFocusColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.tbEspMin.BorderSize = 2;
            this.tbEspMin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbEspMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.tbEspMin.ForeColor = System.Drawing.SystemColors.GrayText;
            this.tbEspMin.Location = new System.Drawing.Point(2, 23);
            this.tbEspMin.Margin = new System.Windows.Forms.Padding(4);
            this.tbEspMin.Multiline = false;
            this.tbEspMin.Name = "tbEspMin";
            this.tbEspMin.Padding = new System.Windows.Forms.Padding(19, 8, 8, 8);
            this.tbEspMin.PasswordChar = false;
            this.tbEspMin.SelectionStart = 0;
            this.tbEspMin.Size = new System.Drawing.Size(134, 33);
            this.tbEspMin.TabIndex = 2;
            this.tbEspMin.Texts = "";
            this.tbEspMin.UnderlinedStyle = true;
            // 
            // btnAgregarItem
            // 
            this.btnAgregarItem.BackColor = System.Drawing.Color.Transparent;
            this.btnAgregarItem.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnAgregarItem.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnAgregarItem.BorderRadius = 4;
            this.btnAgregarItem.BorderSize = 3;
            this.btnAgregarItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAgregarItem.FlatAppearance.BorderSize = 0;
            this.btnAgregarItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnAgregarItem.Location = new System.Drawing.Point(3, 3);
            this.btnAgregarItem.Name = "btnAgregarItem";
            this.btnAgregarItem.Size = new System.Drawing.Size(203, 37);
            this.btnAgregarItem.TabIndex = 1;
            this.btnAgregarItem.Text = "Agregar";
            this.btnAgregarItem.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnAgregarItem.UseVisualStyleBackColor = false;
            this.btnAgregarItem.Click += new System.EventHandler(this.btnAgregarItem_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Transparent;
            this.btnCancelar.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnCancelar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.btnCancelar.BorderRadius = 4;
            this.btnCancelar.BorderSize = 3;
            this.btnCancelar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.btnCancelar.Location = new System.Drawing.Point(212, 3);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(203, 37);
            this.btnCancelar.TabIndex = 0;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCerrarMin_Click);
            // 
            // tbSimboloSignificado
            // 
            this.tbSimboloSignificado.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.tbSimboloSignificado.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.tbSimboloSignificado.BackColor = System.Drawing.Color.White;
            this.tbSimboloSignificado.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.tbSimboloSignificado.BorderFocusColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.tbSimboloSignificado.BorderSize = 2;
            this.tbSimboloSignificado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbSimboloSignificado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.tbSimboloSignificado.ForeColor = System.Drawing.SystemColors.GrayText;
            this.tbSimboloSignificado.Location = new System.Drawing.Point(2, 23);
            this.tbSimboloSignificado.Margin = new System.Windows.Forms.Padding(4);
            this.tbSimboloSignificado.Multiline = true;
            this.tbSimboloSignificado.Name = "tbSimboloSignificado";
            this.tbSimboloSignificado.Padding = new System.Windows.Forms.Padding(19, 8, 8, 8);
            this.tbSimboloSignificado.PasswordChar = false;
            this.tbSimboloSignificado.SelectionStart = 0;
            this.tbSimboloSignificado.Size = new System.Drawing.Size(414, 45);
            this.tbSimboloSignificado.TabIndex = 2;
            this.tbSimboloSignificado.Texts = "";
            this.tbSimboloSignificado.UnderlinedStyle = true;
            // 
            // formAsignarItemProtocolo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 520);
            this.Controls.Add(this.gcAgregar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formAsignarItemProtocolo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "formAsignarItemProtocolo";
            this.Load += new System.EventHandler(this.formAsignarItemProtocolo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcAgregar)).EndInit();
            this.gcAgregar.ResumeLayout(false);
            this.tlpRealizados.ResumeLayout(false);
            this.pnlPendientes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            this.groupControl4.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl7)).EndInit();
            this.groupControl7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl6)).EndInit();
            this.groupControl6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcSimboloSignificado)).EndInit();
            this.gcSimboloSignificado.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).EndInit();
            this.groupControl5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lueNombreItem.Properties)).EndInit();
            this.tlpNoti.ResumeLayout(false);
            this.tlpCuerpo.ResumeLayout(false);
            this.pnlCuerpo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.GroupControl gcAgregar;
        private FontAwesome.Sharp.IconButton btnCerrarMin;
        private System.Windows.Forms.TableLayoutPanel tlpRealizados;
        private System.Windows.Forms.Panel pnlPendientes;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private AAFControles.AAFBoton btnAgregarItem;
        private AAFControles.AAFBoton btnCancelar;
        private DevExpress.XtraEditors.GroupControl gcSimboloSignificado;
        private ScrapKP.AAFControles.AAFTextBox tbSimboloSignificado;
        private DevExpress.XtraEditors.GroupControl groupControl5;
        private DevExpress.XtraEditors.LookUpEdit lueNombreItem;
        private System.Windows.Forms.TableLayoutPanel tlpNoti;
        private System.Windows.Forms.TableLayoutPanel tlpCuerpo;
        private FontAwesome.Sharp.IconButton iconoNotificacion;
        private System.Windows.Forms.Panel pnlCuerpo;
        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.Label lblTitulo;
        private DevExpress.XtraEditors.GroupControl groupControl4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.GroupControl groupControl7;
        private ScrapKP.AAFControles.AAFTextBox tbEspMax;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private ScrapKP.AAFControles.AAFTextBox tbEspMed;
        private DevExpress.XtraEditors.GroupControl groupControl6;
        private ScrapKP.AAFControles.AAFTextBox tbEspMin;
    }
}
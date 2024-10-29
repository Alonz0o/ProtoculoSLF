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
            this.lueItemSimbolos = new DevExpress.XtraEditors.LookUpEdit();
            this.gcAgregar = new DevExpress.XtraEditors.GroupControl();
            this.btnCerrarMin = new FontAwesome.Sharp.IconButton();
            this.tlpRealizados = new System.Windows.Forms.TableLayoutPanel();
            this.pnlPendientes = new System.Windows.Forms.Panel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAgregarItem = new ProtoculoSLF.AAFControles.AAFBoton();
            this.btnCancelar = new ProtoculoSLF.AAFControles.AAFBoton();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.gcEsp02 = new DevExpress.XtraEditors.GroupControl();
            this.tbEsp02 = new ScrapKP.AAFControles.AAFTextBox();
            this.gcSimboloSignificado = new DevExpress.XtraEditors.GroupControl();
            this.tbEsp01 = new ScrapKP.AAFControles.AAFTextBox();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.tbEspecificacion = new ScrapKP.AAFControles.AAFTextBox();
            this.groupControl8 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl5 = new DevExpress.XtraEditors.GroupControl();
            this.lueNombreItem = new DevExpress.XtraEditors.LookUpEdit();
            this.tlpNoti = new System.Windows.Forms.TableLayoutPanel();
            this.tlpCuerpo = new System.Windows.Forms.TableLayoutPanel();
            this.iconoNotificacion = new FontAwesome.Sharp.IconButton();
            this.pnlCuerpo = new System.Windows.Forms.Panel();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.lueItemSimbolos.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcAgregar)).BeginInit();
            this.gcAgregar.SuspendLayout();
            this.tlpRealizados.SuspendLayout();
            this.pnlPendientes.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcEsp02)).BeginInit();
            this.gcEsp02.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcSimboloSignificado)).BeginInit();
            this.gcSimboloSignificado.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl8)).BeginInit();
            this.groupControl8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).BeginInit();
            this.groupControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueNombreItem.Properties)).BeginInit();
            this.tlpNoti.SuspendLayout();
            this.tlpCuerpo.SuspendLayout();
            this.pnlCuerpo.SuspendLayout();
            this.SuspendLayout();
            // 
            // lueItemSimbolos
            // 
            this.lueItemSimbolos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lueItemSimbolos.EditValue = "";
            this.lueItemSimbolos.Location = new System.Drawing.Point(2, 23);
            this.lueItemSimbolos.Name = "lueItemSimbolos";
            this.lueItemSimbolos.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lueItemSimbolos.Properties.Appearance.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lueItemSimbolos.Properties.Appearance.Options.UseFont = true;
            this.lueItemSimbolos.Properties.Appearance.Options.UseForeColor = true;
            this.lueItemSimbolos.Properties.AutoHeight = false;
            this.lueItemSimbolos.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueItemSimbolos.Properties.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lueItemSimbolos.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.lueItemSimbolos.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lueItemSimbolos.Size = new System.Drawing.Size(226, 33);
            this.lueItemSimbolos.TabIndex = 63;
            this.lueItemSimbolos.EditValueChanged += new System.EventHandler(this.lueItemSimbolos_EditValueChanged);
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
            this.gcAgregar.Size = new System.Drawing.Size(477, 318);
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
            this.btnCerrarMin.Location = new System.Drawing.Point(454, 1);
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
            this.tlpRealizados.Size = new System.Drawing.Size(473, 293);
            this.tlpRealizados.TabIndex = 3;
            // 
            // pnlPendientes
            // 
            this.pnlPendientes.AutoScroll = true;
            this.pnlPendientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.pnlPendientes.Controls.Add(this.tableLayoutPanel5);
            this.pnlPendientes.Controls.Add(this.tableLayoutPanel8);
            this.pnlPendientes.Controls.Add(this.tableLayoutPanel7);
            this.pnlPendientes.Controls.Add(this.groupControl5);
            this.pnlPendientes.Controls.Add(this.tlpNoti);
            this.pnlPendientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPendientes.Location = new System.Drawing.Point(13, 0);
            this.pnlPendientes.Margin = new System.Windows.Forms.Padding(0);
            this.pnlPendientes.Name = "pnlPendientes";
            this.pnlPendientes.Size = new System.Drawing.Size(460, 293);
            this.pnlPendientes.TabIndex = 0;
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
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 250);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(460, 43);
            this.tableLayoutPanel5.TabIndex = 66;
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
            this.btnAgregarItem.Size = new System.Drawing.Size(224, 37);
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
            this.btnCancelar.Location = new System.Drawing.Point(233, 3);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(224, 37);
            this.btnCancelar.TabIndex = 0;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCerrarMin_Click);
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 2;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel8.Controls.Add(this.gcEsp02, 1, 0);
            this.tableLayoutPanel8.Controls.Add(this.gcSimboloSignificado, 0, 0);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(0, 185);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 1;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(460, 58);
            this.tableLayoutPanel8.TabIndex = 76;
            // 
            // gcEsp02
            // 
            this.gcEsp02.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.gcEsp02.Appearance.Options.UseBorderColor = true;
            this.gcEsp02.AppearanceCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gcEsp02.AppearanceCaption.Options.UseFont = true;
            this.gcEsp02.Controls.Add(this.tbEsp02);
            this.gcEsp02.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcEsp02.Location = new System.Drawing.Point(460, 0);
            this.gcEsp02.Margin = new System.Windows.Forms.Padding(0);
            this.gcEsp02.Name = "gcEsp02";
            this.gcEsp02.Size = new System.Drawing.Size(1, 58);
            this.gcEsp02.TabIndex = 68;
            this.gcEsp02.Text = "  Y (B) *";
            // 
            // tbEsp02
            // 
            this.tbEsp02.BackColor = System.Drawing.Color.White;
            this.tbEsp02.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.tbEsp02.BorderFocusColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.tbEsp02.BorderSize = 2;
            this.tbEsp02.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbEsp02.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.tbEsp02.ForeColor = System.Drawing.SystemColors.GrayText;
            this.tbEsp02.Location = new System.Drawing.Point(1, 23);
            this.tbEsp02.Margin = new System.Windows.Forms.Padding(4);
            this.tbEsp02.Multiline = false;
            this.tbEsp02.Name = "tbEsp02";
            this.tbEsp02.Padding = new System.Windows.Forms.Padding(19, 8, 8, 8);
            this.tbEsp02.PasswordChar = false;
            this.tbEsp02.SelectionStart = 0;
            this.tbEsp02.Size = new System.Drawing.Size(0, 33);
            this.tbEsp02.TabIndex = 2;
            this.tbEsp02.Texts = "";
            this.tbEsp02.UnderlinedStyle = true;
            // 
            // gcSimboloSignificado
            // 
            this.gcSimboloSignificado.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.gcSimboloSignificado.Appearance.Options.UseBorderColor = true;
            this.gcSimboloSignificado.AppearanceCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gcSimboloSignificado.AppearanceCaption.Options.UseFont = true;
            this.gcSimboloSignificado.Controls.Add(this.tbEsp01);
            this.gcSimboloSignificado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcSimboloSignificado.Location = new System.Drawing.Point(0, 0);
            this.gcSimboloSignificado.Margin = new System.Windows.Forms.Padding(0);
            this.gcSimboloSignificado.Name = "gcSimboloSignificado";
            this.gcSimboloSignificado.Size = new System.Drawing.Size(460, 58);
            this.gcSimboloSignificado.TabIndex = 67;
            this.gcSimboloSignificado.Text = "  Significado *";
            // 
            // tbEsp01
            // 
            this.tbEsp01.BackColor = System.Drawing.Color.White;
            this.tbEsp01.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.tbEsp01.BorderFocusColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.tbEsp01.BorderSize = 2;
            this.tbEsp01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbEsp01.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.tbEsp01.ForeColor = System.Drawing.SystemColors.GrayText;
            this.tbEsp01.Location = new System.Drawing.Point(2, 23);
            this.tbEsp01.Margin = new System.Windows.Forms.Padding(4);
            this.tbEsp01.Multiline = false;
            this.tbEsp01.Name = "tbEsp01";
            this.tbEsp01.Padding = new System.Windows.Forms.Padding(19, 8, 8, 8);
            this.tbEsp01.PasswordChar = false;
            this.tbEsp01.SelectionStart = 0;
            this.tbEsp01.Size = new System.Drawing.Size(456, 33);
            this.tbEsp01.TabIndex = 2;
            this.tbEsp01.Texts = "";
            this.tbEsp01.UnderlinedStyle = true;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 2;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel7.Controls.Add(this.groupControl1, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.groupControl8, 1, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(0, 127);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(460, 58);
            this.tableLayoutPanel7.TabIndex = 74;
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.groupControl1.Appearance.Options.UseBorderColor = true;
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.tbEspecificacion);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(230, 58);
            this.groupControl1.TabIndex = 66;
            this.groupControl1.Text = "  Especificación *";
            // 
            // tbEspecificacion
            // 
            this.tbEspecificacion.BackColor = System.Drawing.Color.White;
            this.tbEspecificacion.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.tbEspecificacion.BorderFocusColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.tbEspecificacion.BorderSize = 2;
            this.tbEspecificacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbEspecificacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.tbEspecificacion.ForeColor = System.Drawing.SystemColors.GrayText;
            this.tbEspecificacion.Location = new System.Drawing.Point(2, 23);
            this.tbEspecificacion.Margin = new System.Windows.Forms.Padding(4);
            this.tbEspecificacion.Multiline = false;
            this.tbEspecificacion.Name = "tbEspecificacion";
            this.tbEspecificacion.Padding = new System.Windows.Forms.Padding(19, 8, 8, 8);
            this.tbEspecificacion.PasswordChar = false;
            this.tbEspecificacion.SelectionStart = 0;
            this.tbEspecificacion.Size = new System.Drawing.Size(226, 33);
            this.tbEspecificacion.TabIndex = 2;
            this.tbEspecificacion.Texts = "";
            this.tbEspecificacion.UnderlinedStyle = true;
            // 
            // groupControl8
            // 
            this.groupControl8.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.groupControl8.Appearance.Options.UseBorderColor = true;
            this.groupControl8.AppearanceCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl8.AppearanceCaption.Options.UseFont = true;
            this.groupControl8.Controls.Add(this.lueItemSimbolos);
            this.groupControl8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl8.Location = new System.Drawing.Point(230, 0);
            this.groupControl8.Margin = new System.Windows.Forms.Padding(0);
            this.groupControl8.Name = "groupControl8";
            this.groupControl8.Size = new System.Drawing.Size(230, 58);
            this.groupControl8.TabIndex = 64;
            this.groupControl8.Text = "  Símbolo *";
            // 
            // groupControl5
            // 
            this.groupControl5.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.groupControl5.Appearance.Options.UseBorderColor = true;
            this.groupControl5.AppearanceCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl5.AppearanceCaption.Options.UseFont = true;
            this.groupControl5.Controls.Add(this.lueNombreItem);
            this.groupControl5.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl5.Location = new System.Drawing.Point(0, 69);
            this.groupControl5.Margin = new System.Windows.Forms.Padding(0);
            this.groupControl5.Name = "groupControl5";
            this.groupControl5.Size = new System.Drawing.Size(460, 58);
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
            this.lueNombreItem.Size = new System.Drawing.Size(456, 33);
            this.lueNombreItem.TabIndex = 64;
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
            this.tlpNoti.Size = new System.Drawing.Size(460, 69);
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
            this.tlpCuerpo.Size = new System.Drawing.Size(456, 63);
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
            this.pnlCuerpo.Size = new System.Drawing.Size(407, 57);
            this.pnlCuerpo.TabIndex = 31;
            // 
            // lblMensaje
            // 
            this.lblMensaje.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMensaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lblMensaje.Location = new System.Drawing.Point(0, 22);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lblMensaje.Size = new System.Drawing.Size(407, 35);
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
            this.lblTitulo.Size = new System.Drawing.Size(407, 22);
            this.lblTitulo.TabIndex = 39;
            this.lblTitulo.Text = "Agregando un item al protocolo 167";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.panel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel11.Location = new System.Drawing.Point(3, 3);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(7, 287);
            this.panel11.TabIndex = 1;
            // 
            // formAsignarItemProtocolo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 318);
            this.Controls.Add(this.gcAgregar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formAsignarItemProtocolo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "formAsignarItemProtocolo";
            this.Load += new System.EventHandler(this.formAsignarItemProtocolo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lueItemSimbolos.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcAgregar)).EndInit();
            this.gcAgregar.ResumeLayout(false);
            this.tlpRealizados.ResumeLayout(false);
            this.pnlPendientes.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcEsp02)).EndInit();
            this.gcEsp02.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcSimboloSignificado)).EndInit();
            this.gcSimboloSignificado.ResumeLayout(false);
            this.tableLayoutPanel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl8)).EndInit();
            this.groupControl8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).EndInit();
            this.groupControl5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lueNombreItem.Properties)).EndInit();
            this.tlpNoti.ResumeLayout(false);
            this.tlpCuerpo.ResumeLayout(false);
            this.pnlCuerpo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.LookUpEdit lueItemSimbolos;
        private DevExpress.XtraEditors.GroupControl gcAgregar;
        private FontAwesome.Sharp.IconButton btnCerrarMin;
        private System.Windows.Forms.TableLayoutPanel tlpRealizados;
        private System.Windows.Forms.Panel pnlPendientes;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private AAFControles.AAFBoton btnAgregarItem;
        private AAFControles.AAFBoton btnCancelar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private DevExpress.XtraEditors.GroupControl groupControl8;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private ScrapKP.AAFControles.AAFTextBox tbEspecificacion;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private DevExpress.XtraEditors.GroupControl gcSimboloSignificado;
        private ScrapKP.AAFControles.AAFTextBox tbEsp01;
        private DevExpress.XtraEditors.GroupControl groupControl5;
        private DevExpress.XtraEditors.LookUpEdit lueNombreItem;
        private System.Windows.Forms.TableLayoutPanel tlpNoti;
        private System.Windows.Forms.TableLayoutPanel tlpCuerpo;
        private FontAwesome.Sharp.IconButton iconoNotificacion;
        private System.Windows.Forms.Panel pnlCuerpo;
        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.Label lblTitulo;
        private DevExpress.XtraEditors.GroupControl gcEsp02;
        private ScrapKP.AAFControles.AAFTextBox tbEsp02;
    }
}
namespace ProtoculoSLF
{
    partial class formAsignarItemsAProtocolo
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
            this.groupControl9 = new DevExpress.XtraEditors.GroupControl();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.gcTodosItems = new DevExpress.XtraGrid.GridControl();
            this.gvTodosItems = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupControl7 = new DevExpress.XtraEditors.GroupControl();
            this.gcItemsAsignados = new DevExpress.XtraGrid.GridControl();
            this.gvItemsAsignados = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAgregarItemAProtocolo = new ProtoculoSLF.AAFControles.AAFBoton();
            this.btnCancelar = new ProtoculoSLF.AAFControles.AAFBoton();
            this.tlpNoti = new System.Windows.Forms.TableLayoutPanel();
            this.tlpCuerpo = new System.Windows.Forms.TableLayoutPanel();
            this.iconoNotificacion = new FontAwesome.Sharp.IconButton();
            this.pnlCuerpo = new System.Windows.Forms.Panel();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.gcAgregar)).BeginInit();
            this.gcAgregar.SuspendLayout();
            this.tlpRealizados.SuspendLayout();
            this.pnlPendientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl9)).BeginInit();
            this.groupControl9.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcTodosItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTodosItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl7)).BeginInit();
            this.groupControl7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcItemsAsignados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvItemsAsignados)).BeginInit();
            this.tableLayoutPanel5.SuspendLayout();
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
            this.gcAgregar.Size = new System.Drawing.Size(589, 519);
            this.gcAgregar.TabIndex = 5;
            this.gcAgregar.Text = "   Asistente de configuración";
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
            this.btnCerrarMin.Location = new System.Drawing.Point(566, 1);
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
            this.tlpRealizados.Size = new System.Drawing.Size(585, 494);
            this.tlpRealizados.TabIndex = 3;
            // 
            // pnlPendientes
            // 
            this.pnlPendientes.AutoScroll = true;
            this.pnlPendientes.AutoScrollMargin = new System.Drawing.Size(10, 10);
            this.pnlPendientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.pnlPendientes.Controls.Add(this.groupControl9);
            this.pnlPendientes.Controls.Add(this.tableLayoutPanel5);
            this.pnlPendientes.Controls.Add(this.tlpNoti);
            this.pnlPendientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPendientes.Location = new System.Drawing.Point(13, 0);
            this.pnlPendientes.Margin = new System.Windows.Forms.Padding(0);
            this.pnlPendientes.Name = "pnlPendientes";
            this.pnlPendientes.Size = new System.Drawing.Size(572, 494);
            this.pnlPendientes.TabIndex = 0;
            // 
            // groupControl9
            // 
            this.groupControl9.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.groupControl9.Appearance.Options.UseBorderColor = true;
            this.groupControl9.AppearanceCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold);
            this.groupControl9.AppearanceCaption.Options.UseFont = true;
            this.groupControl9.AppearanceCaption.Options.UseTextOptions = true;
            this.groupControl9.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.groupControl9.Controls.Add(this.tableLayoutPanel3);
            this.groupControl9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl9.Location = new System.Drawing.Point(0, 69);
            this.groupControl9.Name = "groupControl9";
            this.groupControl9.Size = new System.Drawing.Size(572, 382);
            this.groupControl9.TabIndex = 83;
            this.groupControl9.Text = "  Datos del codigo";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(2, 23);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(568, 357);
            this.tableLayoutPanel3.TabIndex = 3;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Controls.Add(this.groupControl1, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.groupControl7, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(568, 357);
            this.tableLayoutPanel4.TabIndex = 81;
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.groupControl1.Appearance.Options.UseBorderColor = true;
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.gcTodosItems);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(283, 0);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(285, 357);
            this.groupControl1.TabIndex = 84;
            this.groupControl1.Text = "  Todos los items";
            // 
            // gcTodosItems
            // 
            this.gcTodosItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcTodosItems.Location = new System.Drawing.Point(2, 23);
            this.gcTodosItems.MainView = this.gvTodosItems;
            this.gcTodosItems.Name = "gcTodosItems";
            this.gcTodosItems.Size = new System.Drawing.Size(281, 332);
            this.gcTodosItems.TabIndex = 13;
            this.gcTodosItems.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvTodosItems});
            // 
            // gvTodosItems
            // 
            this.gvTodosItems.GridControl = this.gcTodosItems;
            this.gvTodosItems.Name = "gvTodosItems";
            this.gvTodosItems.OptionsFind.AlwaysVisible = true;
            this.gvTodosItems.OptionsView.ShowGroupPanel = false;
            this.gvTodosItems.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gvTodosItems_MouseMove);
            // 
            // groupControl7
            // 
            this.groupControl7.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.groupControl7.Appearance.Options.UseBorderColor = true;
            this.groupControl7.AppearanceCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl7.AppearanceCaption.Options.UseFont = true;
            this.groupControl7.Controls.Add(this.gcItemsAsignados);
            this.groupControl7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl7.Location = new System.Drawing.Point(0, 0);
            this.groupControl7.Margin = new System.Windows.Forms.Padding(0);
            this.groupControl7.Name = "groupControl7";
            this.groupControl7.Size = new System.Drawing.Size(283, 357);
            this.groupControl7.TabIndex = 83;
            this.groupControl7.Text = "  Items asignados a 167";
            // 
            // gcItemsAsignados
            // 
            this.gcItemsAsignados.AllowDrop = true;
            this.gcItemsAsignados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcItemsAsignados.Location = new System.Drawing.Point(2, 23);
            this.gcItemsAsignados.MainView = this.gvItemsAsignados;
            this.gcItemsAsignados.Name = "gcItemsAsignados";
            this.gcItemsAsignados.Size = new System.Drawing.Size(279, 332);
            this.gcItemsAsignados.TabIndex = 13;
            this.gcItemsAsignados.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvItemsAsignados});
            this.gcItemsAsignados.DragDrop += new System.Windows.Forms.DragEventHandler(this.gcItemsAsignados_DragDrop);
            this.gcItemsAsignados.DragEnter += new System.Windows.Forms.DragEventHandler(this.gcItemsAsignados_DragEnter);
            // 
            // gvItemsAsignados
            // 
            this.gvItemsAsignados.GridControl = this.gcItemsAsignados;
            this.gvItemsAsignados.Name = "gvItemsAsignados";
            this.gvItemsAsignados.OptionsFind.AlwaysVisible = true;
            this.gvItemsAsignados.OptionsView.ShowGroupPanel = false;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel5.Controls.Add(this.btnAgregarItemAProtocolo, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.btnCancelar, 1, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 451);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(572, 43);
            this.tableLayoutPanel5.TabIndex = 66;
            // 
            // btnAgregarItemAProtocolo
            // 
            this.btnAgregarItemAProtocolo.BackColor = System.Drawing.Color.Transparent;
            this.btnAgregarItemAProtocolo.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnAgregarItemAProtocolo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnAgregarItemAProtocolo.BorderRadius = 4;
            this.btnAgregarItemAProtocolo.BorderSize = 3;
            this.btnAgregarItemAProtocolo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAgregarItemAProtocolo.FlatAppearance.BorderSize = 0;
            this.btnAgregarItemAProtocolo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarItemAProtocolo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarItemAProtocolo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnAgregarItemAProtocolo.Location = new System.Drawing.Point(3, 3);
            this.btnAgregarItemAProtocolo.Name = "btnAgregarItemAProtocolo";
            this.btnAgregarItemAProtocolo.Size = new System.Drawing.Size(280, 37);
            this.btnAgregarItemAProtocolo.TabIndex = 1;
            this.btnAgregarItemAProtocolo.Text = "Agregar";
            this.btnAgregarItemAProtocolo.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnAgregarItemAProtocolo.UseVisualStyleBackColor = false;
            this.btnAgregarItemAProtocolo.Click += new System.EventHandler(this.btnAgregarItemAProtocolo_Click);
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
            this.btnCancelar.Location = new System.Drawing.Point(289, 3);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(280, 37);
            this.btnCancelar.TabIndex = 0;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCerrarMin_Click);
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
            this.tlpNoti.Size = new System.Drawing.Size(572, 69);
            this.tlpNoti.TabIndex = 80;
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
            this.tlpCuerpo.Size = new System.Drawing.Size(568, 63);
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
            this.pnlCuerpo.Size = new System.Drawing.Size(519, 57);
            this.pnlCuerpo.TabIndex = 31;
            // 
            // lblMensaje
            // 
            this.lblMensaje.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMensaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lblMensaje.Location = new System.Drawing.Point(0, 22);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lblMensaje.Size = new System.Drawing.Size(519, 35);
            this.lblMensaje.TabIndex = 40;
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
            this.lblTitulo.Size = new System.Drawing.Size(519, 22);
            this.lblTitulo.TabIndex = 39;
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.panel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel11.Location = new System.Drawing.Point(3, 3);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(7, 488);
            this.panel11.TabIndex = 1;
            // 
            // formAsignarItemsAProtocolo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 519);
            this.Controls.Add(this.gcAgregar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formAsignarItemsAProtocolo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "formAsignarItemsAProtocolo";
            ((System.ComponentModel.ISupportInitialize)(this.gcAgregar)).EndInit();
            this.gcAgregar.ResumeLayout(false);
            this.tlpRealizados.ResumeLayout(false);
            this.pnlPendientes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl9)).EndInit();
            this.groupControl9.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcTodosItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTodosItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl7)).EndInit();
            this.groupControl7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcItemsAsignados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvItemsAsignados)).EndInit();
            this.tableLayoutPanel5.ResumeLayout(false);
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
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private AAFControles.AAFBoton btnAgregarItemAProtocolo;
        private AAFControles.AAFBoton btnCancelar;
        private System.Windows.Forms.TableLayoutPanel tlpNoti;
        private System.Windows.Forms.TableLayoutPanel tlpCuerpo;
        private FontAwesome.Sharp.IconButton iconoNotificacion;
        private System.Windows.Forms.Panel pnlCuerpo;
        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel panel11;
        private DevExpress.XtraEditors.GroupControl groupControl9;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl gcTodosItems;
        private DevExpress.XtraGrid.Views.Grid.GridView gvTodosItems;
        private DevExpress.XtraEditors.GroupControl groupControl7;
        private DevExpress.XtraGrid.GridControl gcItemsAsignados;
        private DevExpress.XtraGrid.Views.Grid.GridView gvItemsAsignados;
    }
}